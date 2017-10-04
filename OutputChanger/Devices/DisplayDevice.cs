using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputChanger.Devices
{
    /// <summary>
    /// Display object.
    /// </summary>
    class DisplayDevice
    {
        public uint id;
        public bool isSelected;
        public bool isDesktop;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DisplayDevice" /> class.
        /// </summary>
        /// <param name="i">ID.</param>
        /// <param name="s">Is primary.</param>
        /// <param name="d">Is part of desktop.</param>
        public DisplayDevice(uint i, bool s, bool d)
        {
            id = i;
            isSelected = s;
            isDesktop = d;
        }
    }
}
