using System;
using System.Threading;
using RCi.GlobalHook.Events;

namespace RCi.GlobalHook.Sample
{
    internal static class Program
    {
        [STAThread]
        internal static void Main()
        {
            GlobalMouseHook.MouseMove += (_, args) => Console.WriteLine($"{args.Time} {args.Position} Move");
            GlobalMouseHook.MouseDown += (_, args) => Console.WriteLine($"{args.Time} {args.Position} {args.Button} Down");
            GlobalMouseHook.MouseUp += (_, args) => Console.WriteLine($"{args.Time} {args.Position} {args.Button} Up");
            GlobalMouseHook.MouseWheel += (_, args) => Console.WriteLine($"{args.Time} {args.Position} {args.Delta} Wheel");
            GlobalKeyboardHook.KeyDown += (_, args) => Console.WriteLine($"{args.Keys} Down");
            GlobalKeyboardHook.KeyUp += (_, args) => Console.WriteLine($"{args.Keys} Up");

            Console.CursorVisible = false;
            Console.WriteLine("[Press ESC to exit]");
            var signal = new AutoResetEvent(false);
            GlobalKeyboardHook.KeyDown += (_, args) =>
            {
                if (args.Keys == Keys.Escape)
                {
                    signal.Set(); // pulse signal
                }
            };
            signal.WaitOne(); // block thread and wait for signal
        }
    }
}
