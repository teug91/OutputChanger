using System.Collections.Generic;
using System.Windows.Input;

namespace OutputChanger.Input
{
    /// <summary>
    /// Helper for keys and key modifiers.
    /// </summary>
    public static class Keys
    {
        /// <summary>
        /// Gets index of key modifier.
        /// </summary>
        /// <param name="keyModifier">Key modifier.</param>
        /// <returns>Index.</returns>
        public static int GetKeyModifierIndex(KeyModifier keyModifier)
        {
            return GetKeyModifiers().IndexOf(keyModifier);
        }

        /// <summary>
        /// Gets index of function key.
        /// </summary>
        /// <param name="keyModifier">Function key.</param>
        /// <returns>Index.</returns>
        public static int GetFunctionKeyIndex(Key key)
        {
            return GetFunctionKeys().IndexOf(key);
        }

        /// <summary>
        /// Gets key modifier from index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns>Key modifier.</returns>
        public static KeyModifier GetKeyModifier(int index)
        {
            return GetKeyModifiers()[index];
        }

        /// <summary>
        /// Gets function key from index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns>Function key.</returns>
        public static Key GetFunctionKey(int index)
        {
            return GetFunctionKeys()[index];
        }

        /// <summary>
        /// Gets the key modifier.
        /// </summary>
        /// <returns>List of key modifiers.</returns>
        public static List<KeyModifier> GetKeyModifiers()
        {
            var keyModifiers = new List<KeyModifier>();
            keyModifiers.Add(KeyModifier.Alt);
            keyModifiers.Add(KeyModifier.Ctrl);
            keyModifiers.Add(KeyModifier.Shift);
            keyModifiers.Add(KeyModifier.Win);

            return keyModifiers;
        }

        /// <summary>
        /// Gets the function keys.
        /// </summary>
        /// <returns>List of function keys.</returns>
        public static List<Key> GetFunctionKeys()
        {
            var functionKeys = new List<Key>();
            functionKeys.Add(Key.F1);
            functionKeys.Add(Key.F2);
            functionKeys.Add(Key.F3);
            functionKeys.Add(Key.F4);
            functionKeys.Add(Key.F5);
            functionKeys.Add(Key.F6);
            functionKeys.Add(Key.F7);
            functionKeys.Add(Key.F8);
            functionKeys.Add(Key.F9);
            functionKeys.Add(Key.F10);
            functionKeys.Add(Key.F11);
            functionKeys.Add(Key.F12);

            return functionKeys;
        }
    }
}
