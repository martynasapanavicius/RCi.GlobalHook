using System;
using RCi.GlobalHook.Events;

namespace RCi.GlobalHook
{
    public static class GlobalKeyboardHook
    {
        private static KeyboardHook _Instance;
        private static KeyboardHook Instance => _Instance ??= new KeyboardHook();

        public static event EventHandler<IKeyboardKeyEventArgs> KeyDown
        {
            add => Instance.KeyDown += value;
            remove => Instance.KeyDown -= value;
        }
        public static event EventHandler<IKeyboardKeyEventArgs> KeyUp
        {
            add => Instance.KeyUp += value;
            remove => Instance.KeyUp -= value;
        }
    }
}
