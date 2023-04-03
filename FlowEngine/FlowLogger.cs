using System;
using System.Drawing;
using Pastel;

namespace SkriptFlow.FlowEngine
{
    public class Logger
    {
        public static string Log(string type)
        {
            string logType = "default";
            switch (type)
            {
                case "info":
                    logType = $"{$"[{DateTime.Now.ToString("HH:mm:ss")}".Pastel(Color.LightGray)} {"|".Pastel(Color.LightGray)} {"INFO".Pastel(Color.Cyan)} {"|".Pastel(Color.LightGray)} {"+".Pastel(Color.Green)} {"]".Pastel(Color.LightGray)}";
                    break;

                case "error":
                    logType = $"{$"[{DateTime.Now.ToString("HH:mm:ss")}".Pastel(Color.LightGray)} {"|".Pastel(Color.LightGray)} {"ERROR".Pastel(Color.Red)} {"|".Pastel(Color.LightGray)} {"-".Pastel(Color.Red)} {"]".Pastel(Color.LightGray)}";
                    break;
                
                case "warn":
                    logType = $"{$"[{DateTime.Now.ToString("HH:mm:ss")}".Pastel(Color.LightGray)} {"|".Pastel(Color.LightGray)} {"WARN".Pastel(Color.Yellow)} {"|".Pastel(Color.LightGray)} {"!".Pastel(Color.Yellow)} {"]".Pastel(Color.LightGray)}";
                    break;

                default:
                    logType = $"{$"[{DateTime.Now.ToString("HH:mm:ss")}".Pastel(Color.LightGray)} {"|".Pastel(Color.LightGray)} {"INFO".Pastel(Color.Cyan)} {"|".Pastel(Color.LightGray)} {"*".Pastel(Color.Magenta)} {"]".Pastel(Color.LightGray)}";
                    break;
            }
            return logType;
        }
    }
}