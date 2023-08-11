using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering {
    /// <summary>
    /// Used for storing state such as camera position or zoom
    /// </summary>
    internal class RenderEngineState {

        // Camera state

        public PointF cameraPosition = new PointF(0,0);

        // Helper functions

        public void centerCamera(float displayWidth, float displayHeight) {
            cameraPosition = new PointF(-displayWidth / 2, -displayHeight / 2);
        }

    }
}
