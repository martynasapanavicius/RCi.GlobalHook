namespace RCi.GlobalHook.Events
{
    public interface IMouseEventArgs
    {
        public uint Time { get; }
        public System.Drawing.Point Position { get; }
    }
}
