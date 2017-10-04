using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputChanger.Devices
{
    /// <summary>
    /// Audio device object.
    /// </summary>
    class AudioDevice
    {
        public int id;
        public string name;
        public bool isSelected;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioDevice" /> class.
        /// </summary>
        /// <param name="i">ID.</param>
        /// <param name="n">Name.</param>
        /// <param name="iS">Is default.</param>
        public AudioDevice(int i, string n, bool iS)
        {
            id = i;
            name = n;
            isSelected = iS;
        }
    }
}
