using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering {
    /// <summary>
    /// Used for rendering simulation
    /// </summary>
    internal class RenderEngine {

        private RenderEngineState renderState = new RenderEngineState();
        private RenderSettings renderSettings;
        private Graphics graphics;

        /// <summary>
        /// List of objects to render
        /// </summary>
        private List<RenderObject> renderObjects = new List<RenderObject>();

        public RenderEngine(RenderSettings _renderSettings, Graphics _graphics) {
            renderSettings = _renderSettings;
            graphics = _graphics;
        }

        public void Draw() {
            foreach (RenderObject obj in renderObjects) {
                obj.Draw(renderState, graphics);
            }
        }
    }
}
