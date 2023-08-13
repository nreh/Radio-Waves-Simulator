using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering {
    internal abstract class RenderObject {

        public PointF position = new PointF(0,0);

        public Pen stroke = new Pen(Color.White);

        public static PointF realPosition(RenderEngineState renderState, PointF position) {
            PointF centerOffset = renderState.getCenterOffset();
            return new PointF(position.X - renderState.cameraPosition.X + centerOffset.X, position.Y - renderState.cameraPosition.Y + centerOffset.Y);
        }

        public PointF realPosition(RenderEngineState renderState) {
            PointF centerOffset = renderState.getCenterOffset();
            return new PointF(position.X - renderState.cameraPosition.X + centerOffset.X, position.Y - renderState.cameraPosition.Y + centerOffset.Y);
        }

        /// <summary>
        /// Draw the object
        /// </summary>
        /// <param name="renderState"></param>
        /// <param name="g"></param>
        public abstract void Draw(RenderEngineState renderState, Graphics g);

        // factory functions

        public RenderObject setStroke(Pen pen) {
            stroke = pen;
            return this;
        }
    }
}
