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

            sb.Append($"{$"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}".Pastel(Color.LightGray)} ");
            sb.Append($"{"|".Pastel(Color.LightGray)} ");

            switch (level)
            {
                case LogLevel.INFO:
                    sb.Append($"{"INFO".PadRight(5).Pastel(Color.Cyan)} ");
                    sb.Append($"{"|".Pastel(Color.LightGray)} ");
                    sb.Append($"{"+".Pastel(Color.Green)} ");
                    sb.Append($"] {message.Pastel(Color.LightBlue)}");
                    break;

                case LogLevel.WARN:
                    sb.Append($"{"WARN".PadRight(5).Pastel(Color.Yellow)} ");
                    sb.Append($"{"|".Pastel(Color.LightGray)} ");
                    sb.Append($"{"!".Pastel(Color.Yellow)} ");
                    sb.Append($"] {message.Pastel(Color.LightGoldenrodYellow)}");
                    break;

                case LogLevel.ERROR:
                    sb.Append($"{"ERROR".PadRight(5).Pastel(Color.Red)} ");
                    sb.Append($"{"|".Pastel(Color.LightGray)} ");
                    sb.Append($"{"-".Pastel(Color.DarkRed)} ");
                    sb.Append($"] {message.Pastel(Color.OrangeRed)}");
                    break;

                case LogLevel.DEBUG:
                    sb.Append($"{"DEBUG".PadRight(5).Pastel(Color.Violet)} ");
                    sb.Append($"{"|".Pastel(Color.LightGray)} ");
                    sb.Append($"{"*".Pastel(Color.Magenta)} ");
                    sb.Append($"] {message.Pastel(Color.LightGray)}");
                    break;

                case LogLevel.FATAL:
                    sb.Append($"{"FATAL".PadRight(5).Pastel(Color.Crimson)} ");
                    sb.Append($"{"|".Pastel(Color.LightGray)} ");
                    sb.Append($"{"X".Pastel(Color.Crimson)} ");
                    sb.Append($"] {message.PastelBg(Color.DarkRed).Pastel(Color.White)}");
                    break;

                default:
                    sb.Append($"{message.Pastel(Color.Black)}");
                    break;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
