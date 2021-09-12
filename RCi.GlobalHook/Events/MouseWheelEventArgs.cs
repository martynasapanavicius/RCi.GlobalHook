namespace RCi.GlobalHook.Events
{
    public class MouseWheelEventArgs :
        MouseEventArgs,
        IMouseWheelEventArgs
    {
        public int Delta { get; }

        public MouseWheelEventArgs(uint time, System.Drawing.Point position, int delta) :
            base(time, position)
        {
            Delta = delta;
        }
    }
}
