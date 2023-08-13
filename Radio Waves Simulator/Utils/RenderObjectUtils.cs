using Radio_Waves_Simulator.Rendering;
using Radio_Waves_Simulator.Rendering.RenderObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Utils {
    /// <summary>
    /// Utility functions related to RenderObjects
    /// </summary>
    internal class RenderObjectUtils {

        /// <summary>
        /// Load Lines RenderObject from file
        /// </summary>
        /// <param name="datafile">File that contains list of points in the Line object</param>
        /// <returns></returns>
        public static Lines loadLinesFromFile(string datafile) {
            List<PointF> points = new List<PointF>();

            string[] lines = File.ReadAllLines(datafile);
            foreach (string line in lines) {
                string[] s = line.Split(",");
                float x = float.Parse(s[0].Trim());
                float y = float.Parse(s[1].Trim());

                points.Add(new PointF(x, y));
            }

            return new Lines(points);
        }

    }
}
