using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering.RenderObjects {
    internal class Lines : RenderObject {

        List<PointF> points = new List<PointF>();

        public Lines(List<PointF> points) {
            this.points = points;
        }

        public override void Draw(RenderEngineState renderState, Graphics g) {
            for(int x=1; x<points.Count; x++) {
                g.DrawLine(
                    this.stroke, 
                    realPosition(renderState, points[x - 1]),
                    realPosition(renderState, points[x])
                );
            }
        }
    }
}
