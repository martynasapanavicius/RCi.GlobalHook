using System;

namespace RCi.GlobalHook.Events
{
    public class KeyboardKeyEventArgs :
        EventArgs,
        IKeyboardKeyEventArgs
    {
        public Keys Keys { get; }

        public KeyboardKeyEventArgs(Keys keys)
        {
            Keys = keys;
        }
    }
}
