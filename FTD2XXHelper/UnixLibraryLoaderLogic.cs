using System;
using System.Runtime.InteropServices;

namespace FTD2XXHelper
{
    internal class UnixLibraryLoaderLogic : ILibraryLoaderLogic
    {
        public IntPtr LoadLibrary(string fileName)
        {
            var libraryHandle = IntPtr.Zero;

            try
            {
                libraryHandle = UnixLoadLibrary(fileName, RTLD_NOW);
                if (libraryHandle == IntPtr.Zero)
                    Console.WriteLine("LoadLibrary ERR \"{0}\"", fileName);     
            }
            catch (Exception e)
            {
                var lastError = UnixGetLastError();
                Console.WriteLine("LoadLibrary exception: handle {0}.\r\nLast Error:{1}\r\nMsg: {2}", libraryHandle, lastError, e.ToString());
            }

            return libraryHandle;
        }

        public bool FreeLibrary(IntPtr libraryHandle)
        {
            return UnixFreeLibrary(libraryHandle) != 0;
        }

        public IntPtr GetProcAddress(IntPtr libraryHandle, string functionName)
        {
            UnixGetLastError(); // Clearing previous errors
            var functionHandle = UnixGetProcAddress(libraryHandle, functionName);
            var errorPointer = UnixGetLastError();
            if (errorPointer != IntPtr.Zero)
            {
                Console.WriteLine("dlsym: " + Marshal.PtrToStringAnsi(errorPointer));
                functionHandle = IntPtr.Zero;
            }
            if (functionHandle == IntPtr.Zero)
                Console.WriteLine("GetProcAddress ERR \"{0}\"", functionName);
            return functionHandle;
        }

        public string FixUpLibraryName(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                if (!fileName.EndsWith(".so", StringComparison.OrdinalIgnoreCase))
                    fileName += ".so";
                if (!fileName.StartsWith("lib", StringComparison.OrdinalIgnoreCase))
                    fileName = "lib" + fileName;
            }
            return fileName;
        }

        const int RTLD_NOW = 2;

        [DllImport("libdl.so", EntryPoint = "dlopen")]
        private static extern IntPtr UnixLoadLibrary(String fileName, int flags);

        [DllImport("libdl.so", EntryPoint = "dlclose", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int UnixFreeLibrary(IntPtr handle);

        [DllImport("libdl.so", EntryPoint = "dlsym", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr UnixGetProcAddress(IntPtr handle, String symbol);

        [DllImport("libdl.so", EntryPoint = "dlerror", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr UnixGetLastError();
    }
}
