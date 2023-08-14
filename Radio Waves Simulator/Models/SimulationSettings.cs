using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Models {
    internal class SimulationSettings {

        public Size simulationRegion = new Size(500, 500);

        public float dt = 0.2f;

        public float dp = 0.1f; // the lower this value is the smaller the wire is elements are sliced into

        public int pixelSize = 5;

        public float C = 20;
    }
}
