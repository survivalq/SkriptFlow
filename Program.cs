using System;
using SkriptFlow.Render;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SkriptFlow.FlowEngine;
using Pastel;
using System.Drawing;

namespace SkriptFlow
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static async Task Main(string[] args)
        {
            Console.WriteLine($"{Logger.Log("default")} {$"Console enabled.".Pastel(Color.Lime)} {$"You can now see all alerts from the plugins or by the Skriptflow itself.".Pastel(Color.White)}");
            ShowWindow(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle, 0); // 5 - Show, 0 - Hide : Useful for developers who make plugins.
            using var overlay = new FlowOverlay();
            await overlay.Run();
        }
    }
}
