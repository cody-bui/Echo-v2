using System;
using System.Diagnostics;

namespace EchoCore
{
    public static class Timestep
    {
        private static Stopwatch stpw;
        private static uint previousLap = 0;
        private static uint currentLap = 0;

        static Timestep()
        {
            stpw = new Stopwatch();
            stpw.Start();
        }

        public static uint Lap
        {
            get => (uint)stpw.Elapsed.TotalMilliseconds;
        }

        public static uint Delta
        {
            get
            {
                previousLap = currentLap;
                currentLap = (uint)stpw.Elapsed.TotalMilliseconds;
                return currentLap - previousLap;
            }
        }
    }
}
