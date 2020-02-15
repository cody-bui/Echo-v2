using System;

namespace EchoCore
{
    public static class Log
    {
        private static void ConsoleLog(in string type, params object[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine($"[{type}]: {data[i]}");
            }
            Console.ResetColor();
        }

        public static void Init(params object[] data)
        {
            Console.ForegroundColor = System.ConsoleColor.Cyan;
            ConsoleLog("init", data);
        }

        public static void Var(params object[] data)
        {
            Console.ForegroundColor = System.ConsoleColor.Green;
            ConsoleLog("var", data);
        }

        public static void Info(params object[] data)
        {
            Console.ForegroundColor = System.ConsoleColor.Gray;
            ConsoleLog("info", data);
        }

        public static void Warning(params object[] data)
        {
            Console.ForegroundColor = System.ConsoleColor.Yellow;
            ConsoleLog("warning", data);
        }

        public static void Error(params object[] data)
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
            ConsoleLog("error", data);
        }

        public static void Delete(params object[] data)
        {
            Console.ForegroundColor = System.ConsoleColor.Magenta;
            ConsoleLog("delete", data);
        }
    }
}