using System.Runtime.InteropServices;

namespace RimworldRender
{
    public static class ConsoleUtil
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();
    }
}
