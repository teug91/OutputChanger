using System.Windows;

using OutputChanger.Input;
using System.Windows.Input;

namespace OutputChanger.GUI
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : ToolWindow
    {
        internal KeyCombo[] keyCombos;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SettingsWindow" /> class.
        /// </summary>
        internal SettingsWindow()
        {
            InitializeComponent();

            InitializeAutoStartCheckbox();
            InitializeComboBoxes();
        }

        /// <summary>
        /// Sets up all comboboxes.
        /// </summary>
        private void InitializeComboBoxes()
        {
            foreach (var keyModifier in Keys.GetKeyModifiers())
            {
                DisplayModComboBox.Items.Add(keyModifier);
                AudioModComboBox.Items.Add(keyModifier);
            }

            foreach (var key in Keys.GetFunctionKeys())
            {
                DisplayKeyComboBox.Items.Add(key);
                AudioKeyComboBox.Items.Add(key);
            }

            keyCombos = SettingsManager.GetHotKeys();

            DisplayModComboBox.SelectedItem = keyCombos[0].mod;
            DisplayKeyComboBox.SelectedItem = keyCombos[0].key;
            
            AudioModComboBox.SelectedItem = keyCombos[1].mod;
            AudioKeyComboBox.SelectedItem = keyCombos[1].key;
        }

        /// <summary>
        /// Sets checkbox to value from settings.
        /// </summary>
        private void InitializeAutoStartCheckbox()
        {
            bool? autoStart = SettingsManager.GetAutoStart();

            if (autoStart == null)
                autostartCheckbox.Visibility = Visibility.Hidden;
            else
                autostartCheckbox.IsChecked = autoStart;
        }

        /// <summary>
        /// Occurs when 'Save' button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            keyCombos[0].mod = (KeyModifier) DisplayModComboBox.SelectedItem;
            keyCombos[0].key = (Key) DisplayKeyComboBox.SelectedValue;

            keyCombos[1].mod = (KeyModifier) AudioModComboBox.SelectedValue;
            keyCombos[1].key = (Key) AudioKeyComboBox.SelectedValue;

            bool? autoStart = null;

            if (autostartCheckbox.Visibility == Visibility.Visible)
                autoStart = autostartCheckbox.IsChecked;

            SettingsManager.SaveSettings(keyCombos, autoStart);
            Close();
        }

        /// <summary>
        /// Occurs when 'Cancel' button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
