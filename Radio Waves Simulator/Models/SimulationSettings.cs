using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Models {
    internal class SimulationSettings {

        public Size simulationRegion = new Size(500, 500);

        public float dt = 0.25f;

        public float dp = 0.05f; // the lower this value is the smaller the wire is elements are sliced into

        public int pixelSize = 5;

        public float C = 50;

        /// <summary>
        /// How many frames to simulate
        /// </summary>
        public int simulationFrames = 10;

        /// <summary>
        /// Multiplies contribution of each wire element by this value
        /// </summary>
        public float fieldMultiplier = 100;
    }
}
