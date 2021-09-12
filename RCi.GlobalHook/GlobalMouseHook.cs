using System;
using RCi.GlobalHook.Events;

namespace RCi.GlobalHook
{
    public static class GlobalMouseHook
    {
        private static MouseHook _Instance;
        private static MouseHook Instance => _Instance ??= new MouseHook();

        public static event EventHandler<IMouseEventArgs> MouseMove
        {
            add => Instance.MouseMove += value;
            remove => Instance.MouseMove -= value;
        }
        public static event EventHandler<IMouseButtonEventArgs> MouseDown
        {
            add => Instance.MouseDown += value;
            remove => Instance.MouseDown -= value;
        }
        public static event EventHandler<IMouseButtonEventArgs> MouseUp
        {
            add => Instance.MouseUp += value;
            remove => Instance.MouseUp -= value;
        }
        public static event EventHandler<IMouseWheelEventArgs> MouseWheel
        {
            add => Instance.MouseWheel += value;
            remove => Instance.MouseWheel -= value;
        }
    }
}
