// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.PowerToys.Settings.UI.Library;
using OnePassword.Vaults;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin._1Password
{
    public class PluginSettings
    {

        public string? OnePasswordInstallPath { get; set; }
        public string? OnePasswordInitVault { get; set; }
        public string? OnePasswordExcludeVault { get; set; }
        public string? OnePasswordEmail { get; set; }
        public bool OnePasswordPreloadFavorite { get; set; }
        public bool WindowsEnableHistory { get; set; }
        public bool WindowsEnableRoaming { get; set; }


        private ResourceManager _rm;

        public PluginSettings(ResourceManager rm) {
            _rm = rm;
        }

        public IEnumerable<PluginAdditionalOption> Options => new List<PluginAdditionalOption>
        {
            CreateOption(nameof(OnePasswordInstallPath), _rm.GetString("one_password_install_path"), _rm.GetString("one_password_install_path_desc")),
            CreateOption(nameof(OnePasswordInitVault), _rm.GetString("one_password_init_vault"), _rm.GetString("one_password_init_vault_desc")),
            CreateOption(nameof(OnePasswordExcludeVault), _rm.GetString("one_password_exclude_vault"), _rm.GetString("one_password_exclude_vault_desc")),
            CreateOption(nameof(OnePasswordEmail), _rm.GetString("one_password_email"), _rm.GetString("one_password_email_desc")),
            CreateOption(nameof(OnePasswordPreloadFavorite), _rm.GetString("one_password_preload_favorite"), optionType: PluginAdditionalOption.AdditionalOptionType.Checkbox),
            CreateOption(nameof(WindowsEnableHistory), _rm.GetString("windows_enable_history"), _rm.GetString("windows_enable_history_desc"), PluginAdditionalOption.AdditionalOptionType.Checkbox),
            CreateOption(nameof(WindowsEnableRoaming), _rm.GetString("windows_enable_roaming"), _rm.GetString("windows_enable_roaming_desc"), PluginAdditionalOption.AdditionalOptionType.Checkbox)
        };

        public void UpdateSettings(PowerLauncherPluginSettings settings)
        {
            OnePasswordInstallPath = GetSettingOrDefault<string>(settings, nameof(OnePasswordInstallPath));
            OnePasswordEmail = GetSettingOrDefault<string>(settings, nameof(OnePasswordEmail));
            OnePasswordInitVault = GetSettingOrDefault<string>(settings, nameof(OnePasswordInitVault));
            OnePasswordExcludeVault = GetSettingOrDefault<string>(settings, nameof(OnePasswordExcludeVault));
            OnePasswordPreloadFavorite = GetSettingOrDefault<bool>(settings, nameof(OnePasswordPreloadFavorite));
            WindowsEnableHistory = GetSettingOrDefault<bool>(settings, nameof(WindowsEnableHistory));
            WindowsEnableRoaming = GetSettingOrDefault<bool>(settings, nameof(WindowsEnableRoaming));
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

        private T GetSettingOrDefault<T>(PowerLauncherPluginSettings settings, string key)
        {
            var defaultOption = Options.First(x => x.Key == key);
            var option = settings?.AdditionalOptions?.FirstOrDefault(x => x.Key == key);

            object value;

            switch (defaultOption.PluginOptionType)
            {
                case PluginAdditionalOption.AdditionalOptionType.Textbox:
                    value = option?.TextValue ?? defaultOption.TextValue;
                    break;
                case PluginAdditionalOption.AdditionalOptionType.Checkbox:
                    value = option?.Value ?? defaultOption.Value;
                    break;
                default:
                    throw new NotSupportedException();
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

    }
}
