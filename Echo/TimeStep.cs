using System.Diagnostics;

namespace Echo
{
    public class Timestep
    {
        private Stopwatch stpw;
        private uint previousLap = 0;
        private uint currentLap = 0;

        public Timestep()
        {
            stpw = new Stopwatch();
            stpw.Start();
        }

        public uint Lap
        {
            get => (uint)stpw.Elapsed.TotalMilliseconds;
        }

        public uint Delta
        {
            get
            {
                previousLap = currentLap;
                currentLap = (uint)stpw.Elapsed.TotalMilliseconds;
                return currentLap - previousLap;
            }
        }

        public void Pause()
        {
            stpw.Stop();
        }

        public void Resume()
        {
            stpw.Start();
        }
    }
}