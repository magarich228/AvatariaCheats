using System.Runtime.InteropServices;

namespace AvatariaCheats.CLI;

public class KeyInvoker
{
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    private const int KeyEventfKeyup = 0x0002;
    
    public void Invoke(Keys key)
    {
        keybd_event((byte)key, 0, 0, UIntPtr.Zero);
        keybd_event((byte)key, 0, KeyEventfKeyup, UIntPtr.Zero);
    }
}

public enum Keys : byte
{
    W = 0x57,
    S = 0x53,
    A = 0x41,
    D = 0x44
}