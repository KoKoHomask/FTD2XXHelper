using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FTD2XXHelper
{
    internal class WindowsLibraryLoaderLogic : ILibraryLoaderLogic
    {
        public IntPtr LoadLibrary(string fileName)
        {
            var libraryHandle = IntPtr.Zero;

            try
            {
                libraryHandle = WindowsLoadLibrary(fileName);

                if (libraryHandle == IntPtr.Zero)
                    Console.WriteLine("LoadLibrary ERR \"{0}\"", fileName);
            }
            catch (Exception e)
            {
                var lastError = WindowsGetLastError();
                Console.WriteLine("LoadLibrary exception: handle {0}.\r\nLast Error:{1}\r\nMsg: {2}", libraryHandle, lastError, e.ToString());
            }

            return libraryHandle;
        }

        public bool FreeLibrary(IntPtr libraryHandle)
        {
            try
            {
                var isSuccess = WindowsFreeLibrary(libraryHandle);
                if (!isSuccess)
                    Console.WriteLine("Failed FreeLibrary:{0}", libraryHandle);
                return isSuccess;
            }
            catch (Exception e)
            {
                var lastError = WindowsGetLastError();
                Console.WriteLine("FreeLibrary exception: handle {0}.\r\nLast Error:{1}\r\nMsg: {2}", libraryHandle, lastError, e.ToString());
                return false;
            }
        }

        public IntPtr GetProcAddress(IntPtr libraryHandle, string functionName)
        {
            try
            {
                var functionHandle = WindowsGetProcAddress(libraryHandle, functionName);
                if (functionHandle == IntPtr.Zero)
                    Console.WriteLine("GetProcAddress ERR \"{0}\"", functionName);
                return functionHandle;
            }
            catch (Exception e)
            {
                var lastError = WindowsGetLastError();
                Console.WriteLine("GetProcAddress exception: handle {0}.\r\nLast Error:{1}\r\nMsg: {2}", libraryHandle, lastError, e.ToString());
                return IntPtr.Zero;
            }
        }

        public string FixUpLibraryName(string fileName)
        {
            if (!String.IsNullOrEmpty(fileName) && !fileName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                return fileName + ".dll";
            return fileName;
        }

        [DllImport("kernel32", EntryPoint = "LoadLibrary", CallingConvention = CallingConvention.Winapi,
            SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern IntPtr WindowsLoadLibrary(string dllPath);

        [DllImport("kernel32", EntryPoint = "FreeLibrary", CallingConvention = CallingConvention.Winapi,
            SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern bool WindowsFreeLibrary(IntPtr handle);

        [DllImport("kernel32", EntryPoint = "GetProcAddress", CallingConvention = CallingConvention.Winapi,
            SetLastError = true)]
        private static extern IntPtr WindowsGetProcAddress(IntPtr handle, string procedureName);

        private static int WindowsGetLastError()
        {
            return Marshal.GetLastWin32Error();
        }
    }
}
