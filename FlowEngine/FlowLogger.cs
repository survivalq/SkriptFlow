using System;
using System.Drawing;
using System.Text;
using Pastel;

// Latest logger class, feel free to integrate it in your plugin project.
// Make sure that Pastel nuget package is installed before using it.

namespace SkriptFlow.FlowEngine
{
    public enum LogLevel
    {
        INFO,
        WARN,
        ERROR,
        DEBUG,
        FATAL
    }

    public static class Logger
    {
        public static void Log(LogLevel level, string message)
        {
            var sb = new StringBuilder();

            sb.Append($"{$"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}".Pastel(Color.LightGray)} {"|".Pastel(Color.LightGray)} ");

            switch (level)
            {
                case LogLevel.INFO:
                    sb.Append($"{"INFO".PadRight(4).Pastel(Color.Cyan)} {"|".Pastel(Color.LightGray)} {"+".Pastel(Color.Green)} ] {message.Pastel(Color.LightBlue)}");
                    break;

                case LogLevel.WARN:
                    sb.Append($"{"WARN".PadRight(4).Pastel(Color.Yellow)} {"|".Pastel(Color.LightGray)} {"!".Pastel(Color.Yellow)} ] {message.Pastel(Color.LightGoldenrodYellow)}");
                    break;

                case LogLevel.ERROR:
                    sb.Append($"{"ERROR".PadRight(4).Pastel(Color.Red)} {"|".Pastel(Color.LightGray)} {"-".Pastel(Color.DarkRed)} ] {message.Pastel(Color.OrangeRed)}");
                    break;

                case LogLevel.DEBUG:
                    sb.Append($"{"DEBUG".PadRight(4).Pastel(Color.Violet)} {"|".Pastel(Color.LightGray)} {"*".Pastel(Color.Magenta)} ] {message.Pastel(Color.LightGray)}");
                    break;

                case LogLevel.FATAL:
                    sb.Append($"{"FATAL".PadRight(4).Pastel(Color.Crimson)} {"|".Pastel(Color.LightGray)} {"X".Pastel(Color.Crimson)} ] {message.PastelBg(Color.DarkRed).Pastel(Color.White)}");
                    break;

                default:
                    sb.Append($"{"DEBUG".PadRight(4).Pastel(Color.Violet)} {"|".Pastel(Color.LightGray)} {"*".Pastel(Color.Magenta)} ] {message.Pastel(Color.LightGray)}");
                    break;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
