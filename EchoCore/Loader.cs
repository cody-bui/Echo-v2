using System;
using System.IO;

namespace EchoCore
{
    public static class Loader
    {
        public static string ProjectDir { get; private set; }
        public static string EngineDir { get; private set; }

        private static string CurrentDir = EngineDir;
        public static string Asset { get; private set; }
        public static string Lib { get; private set; }

        /// <summary>
        /// set directories, default loading path is engine path
        /// </summary>
        static Loader()
        {
            ProjectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            EngineDir = ProjectDir + @"\..\EchoCore";

            Asset = CurrentDir + @"\asset";
            Lib = CurrentDir + @"\lib";
        }

        /// <summary>
        /// change all loading path to engine path
        /// </summary>
        public static void UseEnginePath()
        {
            CurrentDir = EngineDir;
        }

        /// <summary>
        /// change all loading path to project path
        /// </summary>
        public static void UseProjectPath()
        {
            CurrentDir = ProjectDir;
        }
    }
}