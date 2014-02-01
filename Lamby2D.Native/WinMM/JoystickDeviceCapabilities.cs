using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.WinMM
{
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickDeviceCapabilities
    {
        /// <summary>
        /// The manufacturer ID.
        /// </summary>
        short ManufacturerID;
        /// <summary>
        /// The product ID.
        /// </summary>
        short ProductID;
        /// <summary>
        /// The product name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        string ProductName;
        /// <summary>
        /// The minimum X position value.
        /// </summary>
        uint XMin;
        /// <summary>
        /// The maximum X position value.
        /// </summary>
        uint XMax;
        /// <summary>
        /// The minimum Y position value.
        /// </summary>
        uint YMin;
        /// <summary>
        /// The maximum Y position value.
        /// </summary>
        uint YMax;
        /// <summary>
        /// The minimum Z position value.
        /// </summary>
        uint ZMin;
        /// <summary>
        /// The maximum Z position value.
        /// </summary>
        uint ZMax;
        /// <summary>
        /// The number of buttons.
        /// </summary>
        uint NumButtons;
        /// <summary>
        /// Minimum message period when captured.
        /// </summary>
        uint MinMessagePeriod;
        /// <summary>
        /// Maximum message period when captured.
        /// </summary>
        uint MaxMessagePeriod;

        /// <summary>
        /// The minimum R position value.
        /// </summary>
        uint RMin;
        /// <summary>
        /// The maximum R position value.
        /// </summary>
        uint RMax;
        /// <summary>
        /// The minimum U (5th axis) position value.
        /// </summary>
        uint UMin;
        /// <summary>
        /// The maximum U (5th axis) position value.
        /// </summary>
        uint UMax;
        /// <summary>
        /// The minimum V (6th axis) position value.
        /// </summary>
        uint VMin;
        /// <summary>
        /// The maximum V (6th axis) position value.
        /// </summary>
        uint VMax;
        /// <summary>
        /// The joystick capabilities.
        /// </summary>
        JoystickCapabilities Capabilities;
        /// <summary>
        /// The maximum number of axis supported.
        /// </summary>
        uint MaxAxis;
        /// <summary>
        /// The number of axes in use.
        /// </summary>
        uint NumAxes;
        /// <summary>
        /// The maximum number of buttons supported.
        /// </summary>
        uint MaxButtons;
        /// <summary>
        /// The registry key.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        string RegistryKey;
        /// <summary>
        /// The OEM VxD in use.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        string OEMVxD;
    }
}
