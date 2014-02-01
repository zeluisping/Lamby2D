using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.WinMM
{
    /// <summary>
    /// Joystick information data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickInfoEx
    {
        /// <summary>
        /// The size of the structure.
        /// </summary>
        uint Size;
        /// <summary>
        /// Flags to indicate what to return.
        /// </summary>
        uint Flags;
        /// <summary>
        /// The X position.
        /// </summary>
        uint XPos;
        /// <summary>
        /// The Y position.
        /// </summary>
        uint YPos;
        /// <summary>
        /// The Z position.
        /// </summary>
        uint ZPos;
        /// <summary>
        /// The rudder/4th axis position.
        /// </summary>
        uint RPos;
        /// <summary>
        /// The 5th axis position.
        /// </summary>
        uint UPos;
        /// <summary>
        /// The 6th axis position.
        /// </summary>
        uint VPos;
        /// <summary>
        /// The button states.
        /// </summary>
        uint Buttons;
        /// <summary>
        /// The current button number pressed.
        /// </summary>
        uint ButtonNumber;
        /// <summary>
        /// The point of view state.
        /// </summary>
        uint POV;
        /// <summary>
        /// Reserved for communication between winmm & driver.
        /// </summary>
        [Obsolete("Reserved for communication between winmm & driver.", true)]
        uint dwReserved1;
        /// <summary>
        /// Reserved for future expansion.
        /// </summary>
        [Obsolete("Reserved for future expansion.", true)]
        uint dwReserved2;
    }
}
