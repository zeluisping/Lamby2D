using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.WinMM
{
    public static class WinMM
    {
        /// <summary>
        ///   Informs the joystick driver that the configuration has changed
        ///   and should be reloaded from the registry.
        /// </summary>
        /// <param name="dwFlags">
        ///   Reserved for future use. Must equal zero.
        /// </param>
        /// <returns>
        ///   <see cref="JoystickError.None"/> if successful or
        ///   <see cref="JoystickError.Parameters"/> if the parameter is
        ///   non-zero.
        /// </returns>
        [DllImport("winmm.dll")]
        public static extern JoystickError joyConfigChanged(uint dwFlags);
        /// <summary>
        ///   Queries a joystick to determine its capabilities.
        /// </summary>
        /// <param name="uJoyID">
        ///   Identifier of the joystick to be queried. Valid values range from
        ///   -1 to 15. A value of -1 enables retrieval of the szRegKey member
        ///   of the <see cref="JoystickDeviceCapabilities"/> structure whether
        ///   a device is present or not.
        /// </param>
        /// <param name="pjc">
        ///   Reference to a <see cref="JoystickDeviceCapabilities"/> structure
        ///   to contain the capabilities of the joystick.
        /// </param>
        /// <param name="cbjc">
        ///   Size, in bytes, of the <see cref="JoystickDeviceCapabilities"/>
        ///   structure.
        /// </param>
        /// <returns>
        ///   <para>
        ///     <see cref="JoystickError.None"/> if successful or one of
        ///     the following error values:
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.NoDriver"/>: The joystick driver is
        ///     not present, or the specified joystick identifier is invalid.
        ///     The specified joystick identifier is invalid.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.InvalidParameter"/>: An invalid
        ///     parameter was passed.
        ///   </para>
        /// </returns>
        [DllImport("winmm.dll", EntryPoint = "joyGetDevCapsW", CharSet = CharSet.Unicode)]
        public static extern JoystickError joyGetDevCaps(uint uJoyID, ref JoystickDeviceCapabilities pjc, uint cbjc);
        /// <summary>
        ///   Queries the joystick driver for the number of joysticks it
        ///   supports.
        /// </summary>
        /// <returns>
        ///   The number of joysticks supported by the current driver or zero
        ///   if no driver is installed.
        /// </returns>
        [DllImport("winmm.dll")]
        public static extern uint joyGetNumDevs();
        /// <summary>
        ///   Queries a joystick for its position and button status.
        /// </summary>
        /// <param name="uJoyID">
        ///   Identifier of the joystick to be queried. Valid values range from
        ///   zero to 15.
        /// </param>
        /// <param name="pji">
        ///   Structure that contains the extended position information and
        ///   button status of the joystick. You must set
        ///   <see cref="JoystickInfo.Size"/> and
        ///   <see cref="JoystickInfo.Flags"/> members or joyGetPosEx will
        ///   fail. The information returned from joyGetPosEx depends on the
        ///   flags you specify in <see cref="JoystickInfo.Flags"/>.
        /// </param>
        /// <returns>
        ///   <para>
        ///     <see cref="JoystickError.None"/> if successful or one
        ///     of the following errors:
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.NoDriver"/>: The joystick driver is
        ///     not present.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.InvalidParameter"/>: An invalid
        ///     parameter was passed.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.BadDeviceID"/>: The specified joystick
        ///     identifier is invalid.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.Unplugged"/>: The specified joystick
        ///     is not connected to the system.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.Parameters"/>: The specified joystick
        ///     identifier is invalid.
        ///   </para>
        /// </returns>
        [DllImport("winmm.dll")]
        public static extern JoystickError joyGetPosEx(uint uJoyID, ref JoystickInfoEx pji);
        /// <summary>
        ///   Queries a joystick for its current movement threshold.
        /// </summary>
        /// <param name="uJoyID">
        ///   Identifier of the joystick. Valid values range from zero to 15.
        /// </param>
        /// <param name="puThreshold">
        ///   Variable that contains the movement threshold value.
        /// </param>
        /// <returns>
        ///   <para>
        ///     <see cref="JoystickError.None"/> if successful or one of
        ///     the following error values:
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.NoDriver"/>: The joystick driver is
        ///     not present.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.InvalidParameter"/>: An invalid
        ///     parameter was passed.
        ///   </para>
        /// </returns>
        [DllImport("winmm.dll")]
        public static extern JoystickError joyGetThreshold(uint uJoyID, ref uint puThreshold);
        /// <summary>
        /// Releases the specified captured joystick.
        /// </summary>
        /// <param name="uJoyID">
        ///   Identifier of the joystick to be released. Valid values range
        ///   from zero to 15.
        /// </param>
        /// <returns>
        ///   <para>
        ///     <see cref="JoystickError.None"/> if successful or one of
        ///     the following error values:
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.NoDriver"/>: The joystick driver is
        ///     not present.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.InvalidParameter"/>: The specified
        ///     joystick device identifier is invalid.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.Parameters"/>: The specified joystick
        ///     device identifier is invalid.
        ///   </para>
        /// </returns>
        [DllImport("winmm.dll")]
        public static extern JoystickError joyReleaseCapture(uint uJoyID);
        /// <summary>
        /// Captures a joystick by causing its messages to be sent to the specified window.
        /// </summary>
        /// <param name="hwnd">
        ///   Handle to the window to receive the joystick messages.
        /// </param>
        /// <param name="uJoyID">
        ///   Identifier of the joystick to be captured. Valid values range
        ///   from zero to 15.
        /// </param>
        /// <param name="uPeriod">
        ///   Polling frequency, in milliseconds.
        /// </param>
        /// <param name="fChanged">
        ///   Change position flag. Specify true for this parameter to send
        ///   messages only when the position changes by a value greater than
        ///   the joystick movement threshold. Otherwise, messages are sent at
        ///   the polling frequency specified.
        /// </param>
        /// <returns>
        ///   <para>
        ///     <see cref="JoystickError.None"/> if successful or one of
        ///     the following error values:
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.NoDriver"/>: The joystick driver is
        ///     not present.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.InvalidParameter"/>: Invalid joystick
        ///     Id or window handle is zero.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.NotCompleted"/>: Cannot capture
        ///     joystick input because a required service (such as a Windows
        ///     timer) is unavailable.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.Unplugged"/>: The specified joystick
        ///     is not connected to the system.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.Parameters"/>: Invalid joystick ID or
        ///     window handle is zero.
        ///   </para>
        /// </returns>
        [DllImport("winmm.dll")]
        public static extern JoystickError joySetCapture(IntPtr hwnd, uint uJoyID, uint uPeriod, [MarshalAs(UnmanagedType.Bool)] bool fChanged);
        /// <summary>
        ///   Sets the movement threshold of a joystick.
        /// </summary>
        /// <param name="uJoyID">
        ///   Identifier of the joystick. Valid values range from zero to 15.
        /// </param>
        /// <param name="uThreshold">
        ///   New movement threshold.
        /// </param>
        /// <returns>
        ///   <para>
        ///     <see cref="JoystickError.None"/> if successful or one
        ///     of the following errors:
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.NoDriver"/>: The joystick driver is
        ///     not present.
        ///   </para>
        ///   <para>
        ///     <see cref="JoystickError.Parameters"/>: The specified joystick
        ///     identifier is invalid.
        ///   </para>
        /// </returns>
        [DllImport("winmm.dll")]
        public static extern JoystickError joySetThreshold(uint uJoyID, uint uThreshold);
    }
}
