// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace FoodTrackerApp
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
{
    private static ISettings AppSettings
    {
        get
        {
            return CrossSettings.Current;
        }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private static readonly string SettingsDefault = string.Empty;

    #endregion


    public static string AccessToken
    {
        get
        {
            return AppSettings.GetValueOrDefault("accessToken", SettingsDefault);
        }
        set
        {
            AppSettings.AddOrUpdateValue("accessToken", value);
        }
    }

        public static string LogId
        {
            get
            {
                return AppSettings.GetValueOrDefault("logId", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("logId", value);
            }
        }

        public static string LogDate
        {
            get
            {
                return AppSettings.GetValueOrDefault("logDate", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("logDate", value);
            }
        }

    }
}

