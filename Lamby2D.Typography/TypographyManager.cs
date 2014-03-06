using Lamby2D.Native.FreeType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Typography
{
    static class TypographyManager
    {
        // Static variables
        static IntPtr _libraryhandle;
        static bool _triedload;

        // Static properties
        public static IntPtr LibraryHandle
        {
            get
            {
                if (_triedload == false) {
                    _triedload = true;
                    int error = FreeType.FT_Init_FreeType(out _libraryhandle);
                    if (error != 0) {
                        _libraryhandle = IntPtr.Zero;
                    }
                }
                return _libraryhandle;
            }
        }
    }
}
