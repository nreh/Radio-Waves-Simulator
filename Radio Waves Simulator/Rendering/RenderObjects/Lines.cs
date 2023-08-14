using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering.RenderObjects {
    internal class Lines : RenderObject, Parametric {

        List<PointF> points = new List<PointF>();

        public Lines(List<PointF> points) {
            this.points = points;

            // calculate length of all lines
            length = 0;
            cumulativeLengths = new float[points.Count - 1];
            directionalVectors = new PointF[points.Count - 1];

            for(int x=1; x<points.Count; x++) {
                float l = MathF.Sqrt(MathF.Pow(points[x].X - points[x - 1].X, 2) + MathF.Pow(points[x].Y - points[x - 1].Y, 2));

                cumulativeLengths[x - 1] = l;
                if (x > 1) {
                    cumulativeLengths[x - 1] += cumulativeLengths[x - 2];
                }

                directionalVectors[x - 1] = new PointF((points[x-1].X - points[x].X) / l, (points[x - 1].Y - points[x].Y) / l);
            }

            length = cumulativeLengths.Last();
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

        /// <summary>
        /// Sum of all line lengths
        /// </summary>
        private float length;

        /// <summary>
        /// Unit vectors pointing from one point to the next
        /// </summary>
        private PointF[] directionalVectors;

        /// <summary>
        /// The cummulative line length between each point.
        /// So if there are 4 points A,B,C,D
        /// 
        /// cumulativeLengths[0] would be the line length from AB
        /// cumulativeLengths[1] would be the line length from ABC
        /// cumulativeLengths[2] would be the line length from ABCD or just `length`
        /// </summary>
        private float[] cumulativeLengths;

        public PointF Position(float p) {
            // first we find which line segment the point p(t) will lie on
            float l = p * length;

            for (int x = 0; x < cumulativeLengths.Length; x++) {
                if (l <= cumulativeLengths[x]) {
                    // p(t) lies on line segment points[x-1],points[x]
                    float remainingLength = l;
                    if (x > 0) {
                        remainingLength -= cumulativeLengths[x-1];
                    }

                    return new PointF(directionalVectors[x].X * remainingLength, directionalVectors[x].Y * remainingLength);
                }
            }

            throw new Exception("p(t) lies outside of lines");
        }
    }
}
