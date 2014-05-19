// Helpers/Settings.cs
using Cirrious.CrossCore;
using Refractored.MvxPlugins.Settings;

namespace MDPi.Core.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Simply setup your settings once when it is initialized.
        /// </summary>
        private static ISettings m_Settings;
        private static ISettings AppSettings
        {
            get
            {
                return m_Settings ?? (m_Settings = Mvx.GetSingleton<ISettings>());
            }
        }

#region Setting Constants

        private const string ServerIPAddressKey = "server_ip_address_key";
        private static string ServerIPAddressDefault = string.Empty;

#endregion

    public static string ServerIPAddress
    {
        get
        {
            return AppSettings.GetValueOrDefault(ServerIPAddressKey, ServerIPAddressDefault);
        }
        set
        {
            //if value has changed then save it!
            if (AppSettings.AddOrUpdateValue(ServerIPAddressKey, value))
                AppSettings.Save();
        }
    }

    }
}