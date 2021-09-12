using System;
using RCi.GlobalHook.Data;

namespace RCi.GlobalHook
{
    internal static class Extensions
    {
        public static System.Drawing.Point GetPosition(this MouseInput mouseInput)
        {
            return new System.Drawing.Point(mouseInput.dx, mouseInput.dy);
        }

        public static int HIWORD(this int n)
        {
            return (n >> 16) & 0xffff;
        }

        public static int HIWORD(this IntPtr n)
        {
            return HIWORD(unchecked((int)(long)n));
        }

        public static int LOWORD(this int n)
        {
            return n & 0xffff;
        }

        public static int LOWORD(this IntPtr n)
        {
            return LOWORD(unchecked((int)(long)n));
        }
    }
}
