using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Utils {
    internal class PointFUtils {
        /// <summary>
        /// Calculate distance from point1 to point2
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static float Distance(PointF point1, PointF point2) {
            return MathF.Sqrt(
                MathF.Pow(point2.X - point1.X, 2) +
                MathF.Pow(point2.Y - point1.Y, 2)
            );
        }

        public static float Magnitude(PointF point) {
            return MathF.Sqrt( MathF.Pow(point.X, 2) + MathF.Pow(point.Y, 2) );
        }
    }
}
