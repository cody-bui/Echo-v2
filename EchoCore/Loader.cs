using System;
using System.Diagnostics.Tracing;
using System.IO;

namespace EchoCore
{
    public static class Loader
    {
        private static readonly string WorkingDir = Environment.CurrentDirectory;

        public static readonly string ProjectDir = Directory.GetParent(WorkingDir).Parent.FullName;
        public static readonly string EngineDir = ProjectDir + @"\..\EchoCore";

        public static readonly string ProjectAsset = ProjectDir + @"\asset";
        public static readonly string ProjectLib = ProjectDir + @"\lib";

        public static readonly string EngineAsset = EngineDir + @"\asset";
        public static readonly string EngineLib = EngineDir + @"\lib";
    }
}
