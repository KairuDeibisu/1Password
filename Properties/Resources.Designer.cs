﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Community.PowerToys.Run.Plugin._1Password.Properties
{
    using System;


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources()
        {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Community.PowerToys.Run.Plugin._1Password.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to No matching account for the provided email. Please verify the email address..
        /// </summary>
        internal static string error_email_found_no_match
        {
            get
            {
                return ResourceManager.GetString("error_email_found_no_match", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Multiple accounts detected. Please specify an email address to select the correct account..
        /// </summary>
        internal static string error_email_not_specified
        {
            get
            {
                return ResourceManager.GetString("error_email_not_specified", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Internal Error: Initialization failed: Items or Vaults are not set up correctly..
        /// </summary>
        internal static string error_internal_error_vaults_not_initialized
        {
            get
            {
                return ResourceManager.GetString("error_internal_error_vaults_not_initialized", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Failed to initialize the 1Password manager. Ensure 1Password is running and your credentials are correct..
        /// </summary>
        internal static string error_internal_init_passsword_manager
        {
            get
            {
                return ResourceManager.GetString("error_internal_init_passsword_manager", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Configuration error: Path to the 1Password CLI is required but not set..
        /// </summary>
        internal static string error_missing_required_one_password_cli_path
        {
            get
            {
                return ResourceManager.GetString("error_missing_required_one_password_cli_path", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to No 1Password accounts found. Please ensure you&apos;re signed in..
        /// </summary>
        internal static string error_one_password_no_accounts_found
        {
            get
            {
                return ResourceManager.GetString("error_one_password_no_accounts_found", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to 1Password Plugin Disabled.
        /// </summary>
        internal static string msg_box_title_one_password_disabled
        {
            get
            {
                return ResourceManager.GetString("msg_box_title_one_password_disabled", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Domain.
        /// </summary>
        internal static string one_password_domain
        {
            get
            {
                return ResourceManager.GetString("one_password_domain", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Account Email.
        /// </summary>
        internal static string one_password_email
        {
            get
            {
                return ResourceManager.GetString("one_password_email", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Specify the account email if you have multiple 1Password accounts..
        /// </summary>
        internal static string one_password_email_desc
        {
            get
            {
                return ResourceManager.GetString("one_password_email_desc", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Name of the vault to exclude from searches. Excluded vaults are ignored, even if they contain favorites..
        /// </summary>
        internal static string one_password_exclude_vault_desc
        {
            get
            {
                return ResourceManager.GetString("one_password_exclude_vault_desc", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Exclude Vault.
        /// </summary>
        internal static string one_password_exlude_vault
        {
            get
            {
                return ResourceManager.GetString("one_password_exlude_vault", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Preload Vault.
        /// </summary>
        internal static string one_password_init_vault
        {
            get
            {
                return ResourceManager.GetString("one_password_init_vault", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Name of the vault to preload for quick searches. Only the vault&apos;s ID and name are preloaded..
        /// </summary>
        internal static string one_password_init_vault_desc
        {
            get
            {
                return ResourceManager.GetString("one_password_init_vault_desc", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Install Path.
        /// </summary>
        internal static string one_password_install_path
        {
            get
            {
                return ResourceManager.GetString("one_password_install_path", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Path to the 1Password CLI executable (op.exe)..
        /// </summary>
        internal static string one_password_install_path_desc
        {
            get
            {
                return ResourceManager.GetString("one_password_install_path_desc", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Preload Favorites.
        /// </summary>
        internal static string one_password_preload_favorite
        {
            get
            {
                return ResourceManager.GetString("one_password_preload_favorite", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to KairuDeibisu.
        /// </summary>
        internal static string plugin_author
        {
            get
            {
                return ResourceManager.GetString("plugin_author", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Search 1Password for usernames and passwords.
        /// </summary>
        internal static string plugin_description
        {
            get
            {
                return ResourceManager.GetString("plugin_description", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to 1Password (Unofficial Plugin).
        /// </summary>
        internal static string plugin_name
        {
            get
            {
                return ResourceManager.GetString("plugin_name", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to 1Password Settings.
        /// </summary>
        internal static string plugin_setting
        {
            get
            {
                return ResourceManager.GetString("plugin_setting", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Windows History.
        /// </summary>
        internal static string windows_enable_history
        {
            get
            {
                return ResourceManager.GetString("windows_enable_history", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Allows items copied from 1Password to appear in Windows clipboard history..
        /// </summary>
        internal static string windows_enable_history_desc
        {
            get
            {
                return ResourceManager.GetString("windows_enable_history_desc", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Allow Roaming.
        /// </summary>
        internal static string windows_enable_roaming
        {
            get
            {
                return ResourceManager.GetString("windows_enable_roaming", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Enables copied items to sync across devices via Windows clipboard..
        /// </summary>
        internal static string windows_enable_roaming_desc
        {
            get
            {
                return ResourceManager.GetString("windows_enable_roaming_desc", resourceCulture);
            }
        }
    }
}
