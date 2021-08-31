using System;
using System.Collections.Generic;
using System.Text;

namespace FTD2XXHelper
{
    interface ILibraryLoaderLogic
    {
        IntPtr LoadLibrary(string fileName);
        bool FreeLibrary(IntPtr libraryHandle);
        IntPtr GetProcAddress(IntPtr libraryHandle, string functionName);
        string FixUpLibraryName(string fileName);
    }
}
