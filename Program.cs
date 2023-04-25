using System;
using SkriptFlow.Render;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SkriptFlow.FlowEngine;

namespace SkriptFlow
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static async Task Main(string[] args)
        {
            Logger.Log(LogLevel.INFO, $"Console enabled. You can now see all alerts from the plugins or by the Skriptflow itself.");
            ShowWindow(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle, 5); // 5 - Show, 0 - Hide : Useful for developers who make plugins.
            using var overlay = new FlowOverlay();
            await overlay.Run();
        }
    }
}
