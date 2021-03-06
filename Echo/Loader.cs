﻿using System;
using System.IO;

namespace Echo
{
    public static class Loader
    {
        public static string ProjectDir { get; private set; }
        public static string EngineDir { get; private set; }

        private static string CurrentDir;
        public static string Asset { get; private set; }
        public static string Lib { get; private set; }

        /// <summary>
        /// set directories, default loading path is engine path
        /// </summary>
        static Loader()
        {
            ProjectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            EngineDir = ProjectDir + @"\..\Echo";
            CurrentDir = EngineDir;

            Asset = CurrentDir + @"\Asset";
            Lib = CurrentDir + @"\Lib";
        }

        /// <summary>
        /// change all loading path to engine path
        /// </summary>
        public static void UseEnginePath()
        {
            CurrentDir = EngineDir;

            Asset = CurrentDir + @"\Asset";
            Lib = CurrentDir + @"\Lib";
        }

        /// <summary>
        /// change all loading path to project path
        /// </summary>
        public static void UseProjectPath()
        {
            CurrentDir = ProjectDir;

            Asset = CurrentDir + @"\Asset";
            Lib = CurrentDir + @"\Lib";
        }
    }
}