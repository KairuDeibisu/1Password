// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.PowerToys.Settings.UI.Library;
using OnePassword.Vaults;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin._1Password
{
    public static class PluginSettings
    {

        private static Dictionary<string, object?> _previousValues = new Dictionary<string, object?>();

        public static class UpdateFlags
        {
            internal static bool _onePasswordInstallPathUpdated;
            public static bool OnePasswordInstallPathUpdated
            {
                get => _onePasswordInstallPathUpdated;
                private set => _onePasswordInstallPathUpdated = value;
            }

            internal static bool _onePasswordInitVaultUpdated;
            public static bool OnePasswordInitVaultUpdated
            {
                get => _onePasswordInitVaultUpdated;
                private set => _onePasswordInitVaultUpdated = value;
            }

            internal static bool _onePasswordExcludeVaultUpdated;
            public static bool OnePasswordExcludeVaultUpdated
            {
                get => _onePasswordExcludeVaultUpdated;
                private set => _onePasswordExcludeVaultUpdated = value;
            }

            internal static bool _onePasswordEmailUpdated;
            public static bool OnePasswordEmailUpdated
            {
                get => _onePasswordEmailUpdated;
                private set => _onePasswordEmailUpdated = value;
            }

            internal static bool _onePasswordPreloadFavoriteUpdated;
            public static bool OnePasswordPreloadFavoriteUpdated
            {
                get => _onePasswordPreloadFavoriteUpdated;
                private set => _onePasswordPreloadFavoriteUpdated = value;
            }

            internal static bool _windowsEnableHistoryUpdated;
            public static bool WindowsEnableHistoryUpdated
            {
                get => _windowsEnableHistoryUpdated;
                private set => _windowsEnableHistoryUpdated = value;
            }

            internal static bool _windowsEnableRoamingUpdated;
            public static bool WindowsEnableRoamingUpdated
            {
                get => _windowsEnableRoamingUpdated;
                private set => _windowsEnableRoamingUpdated = value;
            }

            internal static bool _vaultsToLoadUpdated;

            public static bool VaultsToLoadUpdated
            {
                get => _vaultsToLoadUpdated;
                private set => _vaultsToLoadUpdated = value;
            }

            public static void ClearFlags()
            {
                _onePasswordInstallPathUpdated = false;
                _onePasswordInitVaultUpdated = false;
                _onePasswordExcludeVaultUpdated = false;
                _onePasswordEmailUpdated = false;
                _onePasswordPreloadFavoriteUpdated = false;
                _windowsEnableHistoryUpdated = false;
                _windowsEnableRoamingUpdated = false;
                _vaultsToLoadUpdated = false;
            }
        }

        private static string? _onePasswordInstallPath;
        public static string? OnePasswordInstallPath
        {
            get => _onePasswordInstallPath;
            set => SetProperty(ref _onePasswordInstallPath, value, nameof(OnePasswordInstallPath), ref UpdateFlags._onePasswordInstallPathUpdated);
        }

        private static string? _onePasswordInitVault;
        public static string? OnePasswordInitVault
        {
            get => _onePasswordInitVault;
            set => SetProperty(ref _onePasswordInitVault, value, nameof(OnePasswordInitVault), ref UpdateFlags._onePasswordInitVaultUpdated);
        }

        private static string? _onePasswordExcludeVault;
        public static string? OnePasswordExcludeVault
        {
            get => _onePasswordExcludeVault;
            set => SetProperty(ref _onePasswordExcludeVault, value, nameof(OnePasswordExcludeVault), ref UpdateFlags._onePasswordExcludeVaultUpdated);
        }

        private static string? _onePasswordEmail;
        public static string? OnePasswordEmail
        {
            get => _onePasswordEmail;
            set => SetProperty(ref _onePasswordEmail, value, nameof(OnePasswordEmail), ref UpdateFlags._onePasswordEmailUpdated);
        }

        private static bool _onePasswordPreloadFavorite;
        public static bool OnePasswordPreloadFavorite
        {
            get => _onePasswordPreloadFavorite;
            set => SetProperty(ref _onePasswordPreloadFavorite, value, nameof(OnePasswordPreloadFavorite), ref UpdateFlags._onePasswordPreloadFavoriteUpdated);
        }

        private static bool _windowsEnableHistory;
        public static bool WindowsEnableHistory
        {
            get => _windowsEnableHistory;
            set => SetProperty(ref _windowsEnableHistory, value, nameof(WindowsEnableHistory), ref UpdateFlags._windowsEnableHistoryUpdated);
        }

        private static bool _windowsEnableRoaming;
        public static bool WindowsEnableRoaming
        {
            get => _windowsEnableRoaming;
            set => SetProperty(ref _windowsEnableRoaming, value, nameof(WindowsEnableRoaming), ref UpdateFlags._windowsEnableRoamingUpdated);
        }

        public static List<string>? _vaultsToLoad;
        public static List<string>? OnePasswordVaultsToLoad {
            get => _vaultsToLoad;
            set => SetProperty(ref _vaultsToLoad, value, nameof(OnePasswordVaultsToLoad), ref UpdateFlags._vaultsToLoadUpdated);
        }

        private static void SetProperty<T>(ref T field, T value, string propertyName, ref bool updateFlag)
        {
            // If the field is being set for the first time (it's default value)
            if (EqualityComparer<T>.Default.Equals(field, default))
            {
                // Just set the value without updating the flag
                field = value;
            }
            else if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                // Otherwise, update the value and set the flag
                _previousValues[propertyName] = field;
                field = value;
                updateFlag = true;
            }
        }




        public static IEnumerable<PluginAdditionalOption> Options => new List<PluginAdditionalOption>
        {
            CreateOption(nameof(OnePasswordInstallPath), Properties.Resources.one_password_install_path, Properties.Resources.one_password_install_path_desc),
            CreateOption(nameof(OnePasswordInitVault), Properties.Resources.one_password_init_vault, Properties.Resources.one_password_init_vault_desc),
            CreateOption(nameof(OnePasswordExcludeVault), Properties.Resources.one_password_exlude_vault, Properties.Resources.one_password_exclude_vault_desc),
            CreateOption(nameof(OnePasswordEmail), Properties.Resources.one_password_email, Properties.Resources.one_password_email_desc),
            CreateOption(nameof(OnePasswordPreloadFavorite), Properties.Resources.one_password_preload_favorite, optionType: PluginAdditionalOption.AdditionalOptionType.Checkbox),
            CreateOption(nameof(WindowsEnableHistory), Properties.Resources.windows_enable_history,
                Properties.Resources.windows_enable_history_desc, PluginAdditionalOption.AdditionalOptionType.Checkbox),
            CreateOption(nameof(WindowsEnableRoaming), Properties.Resources.windows_enable_roaming,
                Properties.Resources.windows_enable_roaming_desc, PluginAdditionalOption.AdditionalOptionType.Checkbox),
            CreateOption(nameof(OnePasswordVaultsToLoad), Properties.Resources.one_password_list_of_vaults,
                Properties.Resources.one_password_list_of_vaults_desc, PluginAdditionalOption.AdditionalOptionType.CheckboxAndMultilineTextbox),
        };

        public static void UpdateSettings(PowerLauncherPluginSettings settings)
        {
            OnePasswordInstallPath = GetSettingOrDefault<string>(settings, nameof(OnePasswordInstallPath));
            OnePasswordEmail = GetSettingOrDefault<string>(settings, nameof(OnePasswordEmail));
            OnePasswordInitVault = GetSettingOrDefault<string>(settings, nameof(OnePasswordInitVault));
            OnePasswordExcludeVault = GetSettingOrDefault<string>(settings, nameof(OnePasswordExcludeVault));
            OnePasswordPreloadFavorite = GetSettingOrDefault<bool>(settings, nameof(OnePasswordPreloadFavorite));
            WindowsEnableHistory = GetSettingOrDefault<bool>(settings, nameof(WindowsEnableHistory));
            WindowsEnableRoaming = GetSettingOrDefault<bool>(settings, nameof(WindowsEnableRoaming));
            OnePasswordVaultsToLoad = GetSettingOrDefault<List<string>>(settings, nameof(OnePasswordVaultsToLoad));
        }


        private static PluginAdditionalOption CreateOption(string key, string displayLabel, string displayDescription = "", PluginAdditionalOption.AdditionalOptionType optionType = PluginAdditionalOption.AdditionalOptionType.Textbox)
        {
            return new PluginAdditionalOption
            {
                Key = key,
                DisplayLabel = displayLabel,
                DisplayDescription = displayDescription,
                PluginOptionType = optionType
            };
        }

        private static T GetSettingOrDefault<T>(PowerLauncherPluginSettings settings, string key)
        {
            var defaultOption = Options.First(x => x.Key == key);
            var option = settings?.AdditionalOptions?.FirstOrDefault(x => x.Key == key);

            object value = defaultOption.PluginOptionType switch
            {
                PluginAdditionalOption.AdditionalOptionType.Textbox => option?.TextValue ?? defaultOption.TextValue,
                PluginAdditionalOption.AdditionalOptionType.Checkbox => option?.Value ?? defaultOption.Value,
                PluginAdditionalOption.AdditionalOptionType.CheckboxAndMultilineTextbox => option?.Value== true
                    ? option?.TextValueAsMultilineList ?? defaultOption.TextValueAsMultilineList
                    : new List<string>(),
                _ => throw new NotSupportedException()
            };


            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T GetPreviousValue<T>(string key)
        {
            if (_previousValues.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            throw new KeyNotFoundException($"The key '{key}' was not found in the previous values.");
        }
    }
}
