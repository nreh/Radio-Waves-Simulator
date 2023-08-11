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

        public Rectangle(float x, float y, float width, float height) {
            this.position = new PointF(x - width / 2, y - height / 2);

            this.width = width;
            this.height = height;
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
