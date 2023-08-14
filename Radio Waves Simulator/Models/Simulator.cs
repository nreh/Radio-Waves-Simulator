﻿using Expressive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Models {
    /// <summary>
    /// Class that actually calculates the radio wave propagation
    /// </summary>
    internal class Simulator {
        SimulationSettings simulationSettings;

        public Simulator(SimulationSettings simulationSettings) {
            this.simulationSettings = simulationSettings;
        }

        public Frame calculateNextFrame(float dx) {
            throw new NotImplementedException();
        }
    }
}