using System;
using System.Runtime.InteropServices;
using RCi.GlobalHook.Data;
using RCi.GlobalHook.Events;

namespace RCi.GlobalHook
{
    internal class KeyboardHook :
        InputHook
    {
        public event EventHandler<IKeyboardKeyEventArgs> KeyDown;
        public event EventHandler<IKeyboardKeyEventArgs> KeyUp;

        public KeyboardHook() :
            base(HookType.WH_KEYBOARD_LL)
        {
        }

        protected override IntPtr HookProcCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                Process((KeyboardMessage)wParam, lParam);
            }
            return Hook.CallNextHookEx(Hook.HookHandle, nCode, wParam, lParam);
        }

        private void Process(KeyboardMessage message, IntPtr lParam)
        {
            switch (message)
            {
                case KeyboardMessage.WM_KEYDOWN:
                    KeyDown?.Invoke(this, new KeyboardKeyEventArgs((Keys)Marshal.ReadInt32(lParam)));
                    break;

                case KeyboardMessage.WM_KEYUP:
                    KeyUp?.Invoke(this, new KeyboardKeyEventArgs((Keys)Marshal.ReadInt32(lParam)));
                    break;

                case KeyboardMessage.WM_SYSKEYDOWN:
                    KeyDown?.Invoke(this, new KeyboardKeyEventArgs((Keys)Marshal.ReadInt32(lParam)));
                    break;

                case KeyboardMessage.WM_SYSKEYUP:
                    KeyUp?.Invoke(this, new KeyboardKeyEventArgs((Keys)Marshal.ReadInt32(lParam)));
                    break;
            }
        }
    }
}
