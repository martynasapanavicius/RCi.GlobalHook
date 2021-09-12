using System;
using System.Diagnostics;
using System.Threading;
using RCi.GlobalHook.Data;
using RCi.GlobalHook.Sys;

namespace RCi.GlobalHook
{
    public class Hook :
        IDisposable
    {
        #region // storage

        public HookType HookType { get; }

        private HookProc HookProc { get; set; }

        public IntPtr HookHandle { get; private set; }

        #endregion

        #region // ctor

        public Hook(HookType hookType, HookProc hookProc)
        {
            if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
            {
                throw new HookException($"thread apartment state is  not {ApartmentState.STA}");
            }

            HookType = hookType;
            HookProc = hookProc;
            HookHandle = SetWindowsHook(HookType, HookProc);
        }

        #endregion

        #region // dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Hook() => Dispose(false);

        protected virtual void Dispose(bool disposing)
        {
            // unhook and reset handle
            UnhookWindowsHook(HookHandle);
            HookHandle = default;

            // release callback reference, will let GC to collect it
            HookProc = default;
        }

        #endregion

        #region // routines

        private static IntPtr SetWindowsHook(HookType hookType, HookProc hookProc)
        {
            using var currentProcess = Process.GetCurrentProcess();
            using var mainModule = currentProcess.MainModule;
            if (mainModule is null)
            {
                throw new HookException($"{nameof(mainModule)} is null");
            }
            return SetWindowsHook(hookType, hookProc, mainModule);
        }

        private static IntPtr SetWindowsHook(HookType hookType, HookProc hookProc, ProcessModule processModule)
        {
            var hHook = User32.SetWindowsHookEx((int)hookType, hookProc, Kernel32.GetModuleHandle(processModule.ModuleName), 0);
            if (hHook == IntPtr.Zero)
            {
                throw new HookException($"{nameof(User32.SetWindowsHookEx)} failed");
            }
            return hHook;
        }

        private static void UnhookWindowsHook(IntPtr hHook)
        {
            if (!User32.UnhookWindowsHookEx(hHook))
            {
                throw new HookException($"{nameof(User32.UnhookWindowsHookEx)} failed");
            }
        }

        public static IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam)
        {
            return User32.CallNextHookEx(idHook, nCode, wParam, lParam);
        }

        #endregion
    }
}
