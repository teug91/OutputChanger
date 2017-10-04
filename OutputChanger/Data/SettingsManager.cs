using System;
using System.Diagnostics;
using System.Security.Permissions;
using OutputChanger.Properties;
using OutputChanger.Input;

namespace OutputChanger
{
    /// <summary>
    /// Manages settings.
    /// </summary>
    internal static class SettingsManager
    {
        /// <summary>
        /// Get hotkeys from settings.
        /// </summary>
        /// <returns>Both hotkeys.</returns>
        internal static KeyCombo[] GetHotKeys()
        {
             return new KeyCombo[] { new KeyCombo(Keys.GetKeyModifier(Settings.Default.DisplayModKey), Keys.GetFunctionKey(Settings.Default.DisplayFunctionKey)),
                                    new KeyCombo(Keys.GetKeyModifier(Settings.Default.AudioModKey), Keys.GetFunctionKey(Settings.Default.AudioFunctionKey)) };
        }

        /// <summary>
        /// Gets autostart setting.
        /// </summary>
        /// <returns>True if activated, null if no access to registry.</returns>
        internal static bool? GetAutoStart()
        {
            try
            {
                RegistryPermission perm1 = new RegistryPermission(RegistryPermissionAccess.Write, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                perm1.Demand();
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (key.GetValue(Process.GetCurrentProcess().ProcessName) != null)
                {
                    if ((string)key.GetValue(Process.GetCurrentProcess().ProcessName) != Process.GetCurrentProcess().MainModule.FileName)
                        SetAutoStart(true);
                    return true;
                }
                else
                    return false;
            }

            // No registry access.
            catch (System.Security.SecurityException)
            {
                return null;
            }
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="keyCombos">Both hotkeys.</param>
        /// <param name="autoStart">Autostart setting.</param>
        internal static void SaveSettings(KeyCombo[] keyCombos, bool? autoStart)
        {
            if (Keys.GetKeyModifier(Settings.Default.DisplayModKey) != keyCombos[0].mod)
                Settings.Default.DisplayModKey = Keys.GetKeyModifierIndex(keyCombos[0].mod);

            if (Keys.GetFunctionKey(Settings.Default.DisplayFunctionKey) != keyCombos[0].key)
                Settings.Default.DisplayFunctionKey = Keys.GetFunctionKeyIndex(keyCombos[0].key);

            if (Keys.GetKeyModifier(Settings.Default.AudioModKey) != keyCombos[1].mod)
                Settings.Default.AudioModKey = Keys.GetKeyModifierIndex(keyCombos[1].mod);

            if (Keys.GetFunctionKey(Settings.Default.AudioFunctionKey) != keyCombos[1].key)
                Settings.Default.AudioFunctionKey = Keys.GetFunctionKeyIndex(keyCombos[1].key);


            if (autoStart != null)
            {
                SetAutoStart(autoStart);
            }

            Settings.Default.Save();
        }

        /// <summary>
        /// Sets autostart setting.
        /// </summary>
        /// <param name="autoStart">Activate or deactivate.</param>
        private static void SetAutoStart(bool? autoStart)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (autoStart == true)
                    key.SetValue(Process.GetCurrentProcess().ProcessName, Process.GetCurrentProcess().MainModule.FileName);
                else
                    key.DeleteValue(Process.GetCurrentProcess().ProcessName, false);
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
