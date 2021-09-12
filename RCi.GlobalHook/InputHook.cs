using System;
using RCi.GlobalHook.Data;

namespace RCi.GlobalHook
{
    internal abstract class InputHook :
        IDisposable
    {
        protected Hook Hook { get; private set; }

        protected InputHook(HookType hookType)
        {
            Hook = new Hook(hookType, HookProcCallback);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~InputHook() => Dispose(false);

        protected virtual void Dispose(bool disposing)
        {
            Hook.Dispose();
            Hook = default;
        }

        protected virtual IntPtr HookProcCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return Hook.CallNextHookEx(Hook.HookHandle, nCode, wParam, lParam);
        }
    }
}
