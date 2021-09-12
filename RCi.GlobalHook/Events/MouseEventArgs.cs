using System;

namespace RCi.GlobalHook.Events
{
    public class MouseEventArgs :
        EventArgs,
        IMouseEventArgs
    {
        public uint Time { get; }
        public System.Drawing.Point Position { get; }

        public MouseEventArgs(uint time, System.Drawing.Point position)
        {
            Time = time;
            Position = position;
        }
    }
}
