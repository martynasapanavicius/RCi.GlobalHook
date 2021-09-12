namespace RCi.GlobalHook.Data
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/inputdev/keyboard-input-notifications
    /// </summary>
    internal enum KeyboardMessage
    {
        WM_ACTIVATE = 0x0006,
        WM_APPCOMMAND = 0x0319,
        WM_CHAR = 0x0102,
        WM_DEADCHAR = 0x0103,
        WM_HOTKEY = 0x0312,
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_KILLFOCUS = 0x0008,
        WM_SETFOCUS = 0x0007,
        WM_SYSDEADCHAR = 0x0107,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_UNICHAR = 0x0109,
    }
}
