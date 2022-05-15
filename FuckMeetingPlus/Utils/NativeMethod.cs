using WindowsInput;

namespace FuckMeetingPlus.Utils;

public class NativeMethod
{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern bool SetCursorPos(int x, int y);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;

    internal static void LeftMouseClick(int Xposition, int Yposition)
    {
        SetCursorPos(Xposition, Yposition);
        mouse_event(MOUSEEVENTF_LEFTDOWN, Xposition, Yposition, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, Xposition, Yposition, 0, 0);
    }

    internal static void KeyInput(string str)
    {
        new InputSimulator().Keyboard.TextEntry(str);
    }
}