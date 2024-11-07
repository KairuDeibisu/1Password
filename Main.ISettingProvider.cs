// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ManagedCommon;
using Microsoft.PowerToys.Settings.UI.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin._1Password;

public partial class Main : ISettingProvider
{

    public IEnumerable<PluginAdditionalOption> AdditionalOptions => _settings.Options;

    public void UpdateSettings(PowerLauncherPluginSettings settings)
    {
        Logger.LogDebug("Settings updated...");

        _lastSettings = new PluginSettings(_rm);

        _lastSettings.WindowsEnableRoaming = _settings.WindowsEnableRoaming;
        _lastSettings.WindowsEnableHistory = _settings.WindowsEnableHistory;
        _lastSettings.OnePasswordExcludeVault = _settings.OnePasswordExcludeVault;
        _lastSettings.OnePasswordEmail = _settings.OnePasswordEmail;
        _lastSettings.OnePasswordInitVault = _settings.OnePasswordInitVault;
        _lastSettings.OnePasswordInstallPath = _settings.OnePasswordInstallPath;
        _lastSettings.OnePasswordPreloadFavorite = _settings.OnePasswordPreloadFavorite;

        _settings.UpdateSettings(settings);
        _disabled = false;
    }

    public Control CreateSettingPanel()
    {
        throw new NotImplementedException();
    }

}
