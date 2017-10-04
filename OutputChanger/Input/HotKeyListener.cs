using OutputChanger.Changers;
using OutputChanger.Properties;
using System.ComponentModel;

namespace OutputChanger.Input
{
    /// <summary>
    /// Doing stuff with hotkeys.
    /// </summary>
    internal class HotKeyListener
    {
        private KeyCombo[] keyCombos;
        private HotKey displayHotKey;
        private HotKey soundHotKey;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HotKeyListener" /> class.
        /// </summary>
        public HotKeyListener()
        {
            keyCombos = SettingsManager.GetHotKeys();

            displayHotKey = new HotKey(keyCombos[0].key, keyCombos[0].mod, OnDisplayHotKeyHandler);
            soundHotKey = new HotKey(keyCombos[1].key, keyCombos[1].mod, OnSoundHotKeyHandler);

            Settings.Default.SettingsSaving += SettingSaving;
        }

        /// <summary>
        /// Register new hotkeys and removes old.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingSaving(object sender, CancelEventArgs e)
        {
            KeyCombo[] newHotKeys = SettingsManager.GetHotKeys();

            if (newHotKeys[0].mod != keyCombos[0].mod || newHotKeys[0].key != keyCombos[0].key)
            {
                displayHotKey.Unregister();
                displayHotKey = new HotKey(newHotKeys[0].key, newHotKeys[0].mod, OnDisplayHotKeyHandler);
            }

            if (newHotKeys[1].mod != keyCombos[1].mod || newHotKeys[1].key != keyCombos[1].key)
            {
                soundHotKey.Unregister();
                soundHotKey = new HotKey(newHotKeys[1].key, newHotKeys[1].mod, OnDisplayHotKeyHandler);
            }

            keyCombos = newHotKeys;
        }

        /// <summary>
        /// Changing primary display.
        /// </summary>
        /// <param name="hotKey"></param>
        private static void OnDisplayHotKeyHandler(HotKey hotKey)
        {
            DisplayChanger.ChangeDisplay();
        }

        /// <summary>
        /// Changing sound device.
        /// </summary>
        /// <param name="hotKey"></param>
        private static void OnSoundHotKeyHandler(HotKey hotKey)
        {
            AudioChanger.ChangeAudioDevice();
        }
    }
}
