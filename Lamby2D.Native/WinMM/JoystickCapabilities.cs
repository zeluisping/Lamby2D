using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.WinMM
{
    /// <summary>
    /// Joystick driver capabilities.
    /// </summary>
    public enum JoystickCapabilities : uint
    {
        HasZ = 0x1,
        HasR = 0x2,
        HasU = 0x4,
        HasV = 0x8,
        HasPOV = 0x10,
        POV4Dir = 0x20,
        POVCTS = 0x40,
    }
}
