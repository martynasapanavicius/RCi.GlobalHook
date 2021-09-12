using System;
using System.Runtime.InteropServices;
using RCi.GlobalHook.Data;
using RCi.GlobalHook.Events;

namespace RCi.GlobalHook
{
    internal class MouseHook :
        InputHook
    {
        public event EventHandler<IMouseEventArgs> MouseMove;
        public event EventHandler<IMouseButtonEventArgs> MouseDown;
        public event EventHandler<IMouseButtonEventArgs> MouseUp;
        public event EventHandler<IMouseWheelEventArgs> MouseWheel;

        public MouseHook() :
            base(HookType.WH_MOUSE_LL)
        {
        }

        protected override IntPtr HookProcCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                Process((MouseMessage)wParam, lParam);
            }
            return Hook.CallNextHookEx(Hook.HookHandle, nCode, wParam, lParam);
        }

        private void Process(MouseMessage message, IntPtr lParam)
        {
            var mouseInput = Marshal.PtrToStructure<MouseInput>(lParam);

            switch (message)
            {
                case MouseMessage.WM_LBUTTONDOWN:
                    MouseDown?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.Left));
                    break;

                case MouseMessage.WM_LBUTTONUP:
                    MouseUp?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.Left));
                    break;

                case MouseMessage.WM_MOUSEMOVE:
                    MouseMove?.Invoke(this, new MouseEventArgs(mouseInput.time, mouseInput.GetPosition()));
                    break;

                case MouseMessage.WM_MOUSEWHEEL:
                    MouseWheel?.Invoke(this, new MouseWheelEventArgs(mouseInput.time, mouseInput.GetPosition(), (short)mouseInput.mouseData.HIWORD()));
                    break;

                case MouseMessage.WM_RBUTTONDOWN:
                    MouseDown?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.Right));
                    break;

                case MouseMessage.WM_RBUTTONUP:
                    MouseUp?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.Right));
                    break;

                case MouseMessage.WM_MBUTTONDOWN:
                    MouseDown?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.Middle));
                    break;

                case MouseMessage.WM_MBUTTONUP:
                    MouseUp?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.Middle));
                    break;

                case MouseMessage.WM_XBUTTONDOWN:
                    switch (mouseInput.mouseData.HIWORD())
                    {
                        case 1:
                            MouseDown?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.XButton1));
                            break;
                        case 2:
                            MouseDown?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.XButton2));
                            break;
                    }
                    break;

                case MouseMessage.WM_XBUTTONUP:
                    switch (mouseInput.mouseData.HIWORD())
                    {
                        case 1:
                            MouseUp?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.XButton1));
                            break;
                        case 2:
                            MouseUp?.Invoke(this, new MouseButtonEventArgs(mouseInput.time, mouseInput.GetPosition(), MouseButton.XButton2));
                            break;
                    }
                    break;
            }
        }
    }
}
