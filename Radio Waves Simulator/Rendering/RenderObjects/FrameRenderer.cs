using Radio_Waves_Simulator.Models;
using Radio_Waves_Simulator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering.RenderObjects {
    /// <summary>
    /// Renders Frame objects
    /// </summary>
    internal class FrameRenderer : RenderObject {
        private float width;
        public float Width {
            get {
                return width;
            }
            set {
                width = value;
            }
        }

        private float height;
        public float Height {
            get {
                return height;
            }
            set {
                height = value;
            }
        }

        private Frame frame;

        public FrameRenderer(float width, float height, Frame frame) {
            this.width = width;
            this.height = height;
            this.frame = frame;
        }

        public override void Draw(RenderEngineState renderState, Graphics g) {
            PointF position = realPosition(renderState);

            float x = position.X - (width / 2);
            float y = position.Y - (height / 2);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(frame.Bitmap.Bitmap, new RectangleF(x, y, width, height));
        }
    }
}
