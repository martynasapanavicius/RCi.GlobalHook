using System;
using System.Runtime.InteropServices;

namespace RCi.GlobalHook.Sys
{
    internal static class Kernel32
    {
        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
