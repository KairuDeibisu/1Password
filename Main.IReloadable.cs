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
using System.Diagnostics;

namespace Community.PowerToys.Run.Plugin._1Password;

public partial class Main : IReloadable
{

    public void ReloadData()
    {
        Logger.LogDebug("Reloading 1Password plugin data");

        if (_context is not null)
        {
            UpdateIconPath(_context.API.GetCurrentTheme());
        }


        if (!_disabled)
        {
            HandleUpdate();
        }

        
        Debug.WriteLine(PluginSettings.OnePasswordVaultsToLoad);


    }

    private void HandleUpdate()
    {

        if (PluginSettings.UpdateFlags.VaultsToLoadUpdated) {
            UpdateVaultsToLoad();
            InitializeItems();
        }


        if (PluginSettings.UpdateFlags.OnePasswordExcludeVaultUpdated)
        {
            UpdateInitialVault();
            UpdateFavoriteItems();
        }

        if (PluginSettings.UpdateFlags.OnePasswordInitVaultUpdated)
        {
            UpdateInitialVault();
        }

        if (PluginSettings.UpdateFlags.OnePasswordPreloadFavoriteUpdated)
        {
            UpdateFavoriteItems();
        }

        PluginSettings.UpdateFlags.ClearFlags();
    }

    private void UpdateVaultsToLoad()
    {
        var vaultNames = PluginSettings.GetPreviousValue<List<string>>(nameof(PluginSettings.OnePasswordVaultsToLoad));


        // Remove each vault from _vaults if it's not in the list of vaults to load and is not the initial vault.
        _vaults.RemoveAll(vault =>
        {
            var shouldKeep = PluginSettings.OnePasswordVaultsToLoad?.Contains(vault.Name) ?? false;
            var isInitVault = vault.Name == PluginSettings.OnePasswordInitVault;

            return !shouldKeep && !isInitVault;
        });
        
        InitializeVaults();
    }

    private void UpdateFavoriteItems()
    {
        // Check if the password manager is null. If it is, exit the method early.
        if (_passwordManager is null)
        {
            return;
        }

        // Retrieve a list of items currently marked as favorites from the password manager.
        var favorites = _passwordManager.SearchForItems(favorite: true).ToList();

        // Identify items in _favoriteItems that are no longer in the updated list of favorites.
        var outdatedFavorites = _favoriteItems
            .Where(favorite =>
                favorites.Any(favItem => favItem.Id != favorite.Id)) // Item is not in the updated favorites list
            .ToList();

        // Remove these outdated items from _favoriteItems.
        _favoriteItems.RemoveAll(favorite => outdatedFavorites.Contains(favorite));

        // Further filter the outdated favorites to find those not associated with any vault in _vaults.
        var outdatedFavoritesNotAssociatedWithAnyVault = outdatedFavorites
            .Where(favorite =>
                !_vaults.Any(vault => favorite?.Vault?.Id == vault.Id)) // Item's vault is not present in the current vaults
            .ToList();

        // Remove these filtered outdated items from _items as well.
        foreach (var item in outdatedFavoritesNotAssociatedWithAnyVault)
        {
            _items.Remove(item);
        }

        // Identify new favorite items that are not already present in _favoriteItems and add them.
        var newFavorites = favorites.Where(item =>
            _favoriteItems.All(favItem => favItem.Id != item.Id)); // Check if the item is not already in _favoriteItems
        _favoriteItems.AddRange(newFavorites);

        // Refresh the items collection
        InitializeFavoriteItems();
    }

    private void UpdateInitialVault()
    {
        var previousVaultName = PluginSettings.GetPreviousValue<string>(nameof(PluginSettings.OnePasswordInitVault));
        var allVaults = _passwordManager?.GetVaults();
        var previousVault = allVaults?.FirstOrDefault(v => v.Name == previousVaultName);

        if (previousVault == null)
        {
            Logger.LogWarning("Previous vault is null skiping part of the update step for the init vault");
        }
        else
        {
            _vaults.Remove(previousVault);
            _items.RemoveAll(item => item?.Vault?.Id == previousVault.Id);
        }

        InitializeVaults();
        InitializeItems();
    }

    public void LoadVault(Vault vault)
    {
        if (_passwordManager is null || _vaults is null || _vaults.Contains(vault))
        {
            return;
        }

        AddItemsFromVault(_passwordManager.GetItems(vault));

        if (!_vaults.Contains(vault)) { 
            _vaults.Add(vault);
        }
    }




}
