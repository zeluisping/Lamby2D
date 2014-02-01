using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.WinMM
{
    public enum JoystickError : uint
    {
        /// <summary>
        /// No error.
        /// </summary>
        None = 0,

        /// <summary>
        /// Unspecified error.
        /// </summary>
        Unspecified = 1,
        /// <summary>
        /// Device ID out of range.
        /// </summary>
        BadDeviceID = 2,
        /// <summary>
        /// Driver failed enable.
        /// </summary>
        NotEnabled = 3,
        /// <summary>
        /// Device already allocated.
        /// </summary>
        Allocated = 4,
        /// <summary>
        /// Device handle is invalid.
        /// </summary>
        InvalidHandle = 5,
        /// <summary>
        /// No device driver present.
        /// </summary>
        NoDriver = 6,
        /// <summary>
        /// Memory allocation error.
        /// </summary>
        NoMemory = 7,
        /// <summary>
        /// Function isn't supported.
        /// </summary>
        NotSupported = 8,
        /// <summary>
        /// Error value out of range.
        /// </summary>
        BadErrorNumber = 9,
        /// <summary>
        /// Invalid flag passed.
        /// </summary>
        InvalidFlag = 10,
        /// <summary>
        /// Invalid parameter passed.
        /// </summary>
        InvalidParameter = 11,
        /// <summary>
        /// Handle being used simultaneously on another thread (eg callback).
        /// </summary>
        HandleBusy = 12,
        /// <summary>
        /// Specified alias not found.
        /// </summary>
        InvalidAlias = 13,
        /// <summary>
        /// Bad registry database.
        /// </summary>
        BadRegistryDatabase = 14,
        /// <summary>
        /// Registry key not found.
        /// </summary>
        KeyNotFound = 15,
        /// <summary>
        /// Registry read error.
        /// </summary>
        ReadError = 16,
        /// <summary>
        /// Registry write error.
        /// </summary>
        WriteError = 17,
        /// <summary>
        /// Registry delete error.
        /// </summary>
        DeleteError = 18,
        /// <summary>
        /// Registry value not found.
        /// </summary>
        ValueNotFound = 19,
        /// <summary>
        /// Driver does not call DriverCallback.
        /// </summary>
        NoDriverCallback = 20,
        /// <summary>
        /// More data to be returned.
        /// </summary>
        MoreData = 21,
        /// <summary>
        /// Last error in range.
        /// </summary>
        LastError = 21,

        /// <summary>
        /// Bad parameters.
        /// </summary>
        Parameters = 160 + 5,
        /// <summary>
        /// Request not completed.
        /// </summary>
        NotCompleted = 160 + 6,
        /// <summary>
        /// Joystick is unplugged.
        /// </summary>
        Unplugged = 160 + 7,
    }
}
