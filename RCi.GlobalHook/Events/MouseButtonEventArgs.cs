namespace RCi.GlobalHook.Events
{
    public class MouseButtonEventArgs :
        MouseEventArgs,
        IMouseButtonEventArgs
    {
        public MouseButton Button { get; }

        public MouseButtonEventArgs(uint time, System.Drawing.Point position, MouseButton button) :
            base(time, position)
        {
            Button = button;
        }
    }
}
