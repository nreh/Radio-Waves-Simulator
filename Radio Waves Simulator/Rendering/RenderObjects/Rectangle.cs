using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering.RenderObjects {
    internal class Rectangle : RenderObject {

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

        public override void Draw(RenderEngineState renderState, Graphics g) {
            PointF pos = realPosition(renderState);

            g.DrawRectangle(
                this.stroke,
                pos.X, pos.Y,
                this.width, this.height
            );
        }
    }
}
