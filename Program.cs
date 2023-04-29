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
            Logger.Log(LogLevel.INFO, $"Console enabled. Everything that happens will be logged here.");
            ShowWindow(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle, 0); // 5 - Show, 0 - Hide : Useful for developers who make plugins.
            using var overlay = new FlowOverlay();
            await overlay.Run();
        }
    }
}
