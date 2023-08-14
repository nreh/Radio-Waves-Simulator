﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Models {
    internal class SimulationSettings {

        public SizeF simulationRegion = new SizeF(500, 500);

        public float dt = 0.2f;

        public float dp = 0.1f;

    }
}
