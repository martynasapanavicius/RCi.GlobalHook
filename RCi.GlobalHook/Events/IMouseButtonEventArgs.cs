namespace RCi.GlobalHook.Events
{
    public interface IMouseButtonEventArgs :
        IMouseEventArgs
    {
        MouseButton Button { get; }
    }
}
