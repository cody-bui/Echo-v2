using System;

namespace EchoCore
{
    public static class Log
    {
        /// <summary>
        /// one of the log types
        /// </summary>
        public enum LogType
        {
            Init = 0,
            Var,
            Message,
            Warning,
            Error,
            Delete
        }

        /// <summary>
        /// change console color based on log type
        /// </summary>
        /// <param name="lt">type of log</param>
        private static void ConsoleColor(LogType lt)
        {
            switch (lt)
            {
                case LogType.Init:
                    Console.ForegroundColor = System.ConsoleColor.Cyan;
                    break;

                case LogType.Var:
                    Console.ForegroundColor = System.ConsoleColor.Green;
                    break;

                case LogType.Message:
                    Console.ForegroundColor = System.ConsoleColor.Gray;
                    break;

                case LogType.Warning:
                    Console.ForegroundColor = System.ConsoleColor.Yellow;
                    break;

                case LogType.Error:
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    break;

                case LogType.Delete:
                    Console.ForegroundColor = System.ConsoleColor.Magenta;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// logging function
        /// </summary>
        /// <param name="lt">one of the 6 types of log</param>
        /// <param name="data">all the data to output to console</param>
        public static void ConsoleLog(LogType lt, params object[] data)
        {
            string type = lt.ToString();

            ConsoleColor(lt);           // change console color
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine($"[{type}]: {data[i]}");
            }
            Console.ResetColor();       // reset color
        }
    }
}