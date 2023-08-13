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

        // Render bounds information

        private PointF centerOffset = new PointF(0,0);

        /// <summary>
        /// Returns center offset which is just the height and width of the container divided by 2
        /// 
        /// Cached so that it doesn't have to be recalculated for each renderObject
        /// </summary>
        /// <returns></returns>
        public PointF getCenterOffset() {
            return centerOffset;
        }


        private SizeF boundsSize = new SizeF(0,0);


        /// <summary>
        /// Size of whatever is being rendered in. For example if Picturebox this would be the height and width of the picturebox
        /// </summary>
        public SizeF BoundsSize {
            get {
                return boundsSize;
            }
            set { 
                boundsSize = value;
                centerOffset = new PointF(value.Width / 2, value.Height / 2);
            }
        }

        // Camera state

        public PointF cameraPosition = new PointF(0,0);

        // Helper functions

        public void centerCamera(float displayWidth, float displayHeight) {
            cameraPosition = new PointF(0, 0);
        }

    }
}
