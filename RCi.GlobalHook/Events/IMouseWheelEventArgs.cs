namespace RCi.GlobalHook.Events
{
    public interface IMouseWheelEventArgs :
        IMouseEventArgs
    {
        int Delta { get; }
    }
}
