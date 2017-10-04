using System.Windows.Input;
using System.Configuration;

/// <summary>
/// Duo of key modifier and key.
/// </summary>
namespace OutputChanger.Input
{
    internal class KeyCombo
    {
        internal KeyModifier mod;
        internal Key key;

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyCombo" /> class.
        /// </summary>
        /// <param name="m">Key modifier.</param>
        /// <param name="k">Key.</param>
        internal KeyCombo(KeyModifier m, Key k)
        {
            mod = m;
            key = k;
        }
    }
}
