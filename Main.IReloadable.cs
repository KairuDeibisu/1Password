// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using OnePassword.Vaults;
using OnePassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wox.Plugin;
using OnePassword.Accounts;
using OnePassword.Items;
using ManagedCommon;
using System.Resources;

namespace Community.PowerToys.Run.Plugin._1Password;

public partial class Main : IReloadable
{

    private int _reloadCount = 0;
    private readonly int _maxReload = 15;
    private DateTime _lastReloadTime = DateTime.MinValue;
    private readonly TimeSpan _reloadCooldown = TimeSpan.FromHours(1);
    private TimeSpan _debounceThreshold = TimeSpan.FromSeconds(1);



    /// <summary>
    /// Reloads the plugin data when settings have changed. This method handles multiple reload requests
    /// and prevents redundant reloads through a debounce and rate limit mechanism:
    /// 
    /// - **Debounce**: If a reload is attempted within the current debounce threshold of the last reload, it is ignored, and
    ///   the threshold is doubled to increase the delay between subsequent attempts. This threshold resets to its initial value
    ///   after the cooldown period has passed.
    /// - **Rate Limit**: If reload attempts exceed the maximum allowed (`_maxReload`) within the cooldown period (e.g., 1 hour),
    ///   the reload is aborted to avoid excessive reloading.
    /// 
    /// The method performs the following steps:
    /// 1. Checks if settings have changed. If not, the reload is aborted.
    /// 2. Checks the debounce threshold. If the reload is triggered too soon after the last reload, it is ignored, and the
    ///    debounce threshold is doubled.
    /// 3. Resets the reload count and debounce threshold if the cooldown period has passed since the last reload attempt.
    /// 4. Checks if the reload count has reached the maximum allowed within the cooldown period, and if so, aborts the reload.
    /// 
    /// During reloading, the plugin clears its current items and reinitializes them based on the updated settings.
    /// The `_reloadCount`, `_lastReloadTime`, and `_debounceThreshold` are updated on successful reloads.
    /// </summary>
    public void ReloadData()
    {

        if (_context is not null)
        {
            UpdateIconPath(_context.API.GetCurrentTheme());
        }

        var currentTime = DateTime.Now;

        // Check if settings have changed, and reload if true, bypassing debounce and reload limits
        if (HaveSettingsChanged(_lastSettings, _settings))
        {
            Logger.LogDebug("Settings have changed, trying to reload");
            // Debounce: Ignore reloads attempted within debounce threshold
            if ((currentTime - _lastReloadTime) < _debounceThreshold)
            {
                Logger.LogDebug("Reload attempt ignored due to debounce threshold.");

                // Double the debounce threshold each time it's hit
                _debounceThreshold = TimeSpan.FromSeconds(_debounceThreshold.TotalSeconds * 2);
                Logger.LogDebug($"Debounce threshold doubled to {_debounceThreshold.TotalSeconds} seconds.");


                return;
            }

            // Reset the reload count if the cooldown period has passed
            if (currentTime - _lastReloadTime >= _reloadCooldown)
            {
                _reloadCount = 0;
                _lastReloadTime = currentTime;
            }

            // Check if reload limit has been reached
            if (_reloadCount >= _maxReload)
            {
                Logger.LogDebug("Max reload depth reached. Possible bug in program. Stopping to prevent rate limit.");
                return;
            }
        }
        else {
            Logger.LogDebug("Aborting reload: Settings have not changed.");
            return;
        }

        Logger.LogDebug("Attempting to reload 1Password plugin data");



        _items.Clear();

        if (!_disabled)
        {
            InitializeItems();
            _reloadCount++;
            _lastReloadTime = currentTime; // Update the last reload time after a successful reload
            Logger.LogDebug($"Reload count incremented to {_reloadCount} at {currentTime}.");
        }
    }

    private bool HaveSettingsChanged(PluginSettings oldSettings, PluginSettings newSettings)
    {
        bool settingsChanged = false;

        if (oldSettings.OnePasswordInstallPath != newSettings.OnePasswordInstallPath)
        {
            Logger.LogDebug($"Setting changed: OnePasswordInstallPath from '{oldSettings.OnePasswordInstallPath}' to '{newSettings.OnePasswordInstallPath}'");
            settingsChanged = true;
        }

        if (oldSettings.OnePasswordInitVault != newSettings.OnePasswordInitVault)
        {
            Logger.LogDebug($"Setting changed: OnePasswordInitVault from '{oldSettings.OnePasswordInitVault}' to '{newSettings.OnePasswordInitVault}'");
            settingsChanged = true;
        }

        if (oldSettings.OnePasswordExcludeVault != newSettings.OnePasswordExcludeVault)
        {
            Logger.LogDebug($"Setting changed: OnePasswordExcludeVault from '{oldSettings.OnePasswordExcludeVault}' to '{newSettings.OnePasswordExcludeVault}'");
            settingsChanged = true;
        }

        if (oldSettings.OnePasswordEmail != newSettings.OnePasswordEmail)
        {
            Logger.LogDebug($"Setting changed: OnePasswordEmail from '{oldSettings.OnePasswordEmail}' to '{newSettings.OnePasswordEmail}'");
            settingsChanged = true;
        }

        if (oldSettings.OnePasswordPreloadFavorite != newSettings.OnePasswordPreloadFavorite)
        {
            Logger.LogDebug($"Setting changed: OnePasswordPreloadFavorite from '{oldSettings.OnePasswordPreloadFavorite}' to '{newSettings.OnePasswordPreloadFavorite}'");
            settingsChanged = true;
        }

        if (oldSettings.WindowsEnableHistory != newSettings.WindowsEnableHistory)
        {
            Logger.LogDebug($"Setting changed: WindowsEnableHistory from '{oldSettings.WindowsEnableHistory}' to '{newSettings.WindowsEnableHistory}'");
            settingsChanged = true;
        }

        if (oldSettings.WindowsEnableRoaming != newSettings.WindowsEnableRoaming)
        {
            Logger.LogDebug($"Setting changed: WindowsEnableRoaming from '{oldSettings.WindowsEnableRoaming}' to '{newSettings.WindowsEnableRoaming}'");
            settingsChanged = true;
        }

        return settingsChanged;
    }

    public void LoadVault(Vault vault)
    {
        if (_passwordManager is null || _vaults is null || _vaults.ContainsKey(vault.Id))
        {
            return;
        }

        AddItemsFromVault(_passwordManager.GetItems(vault));
        _vaults.TryAdd(vault.Id, vault);
    }




}
