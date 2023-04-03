using System;
using SkriptFlow.Render;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SkriptFlow
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static async Task Main(string[] args)
        {
            ShowWindow(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle, 0); // 5 - Show, 0 - Hide
            using var overlay = new FlowOverlay();
            await overlay.Run();
        }
    }
}
