using Expressive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Models {
    internal class CurrentFunction {
        Expression function;
        Expression timeDerivative;

        public CurrentFunction(Expression function, Expression timeDerivative) {
            this.function = function;
            this.timeDerivative = timeDerivative;
        }

        public float valueAt(float t) {
            return (float)function.Evaluate(new Dictionary<string, object> {["t"] = t });
        }

        public float derivativeAt(float t) {
            return (float)timeDerivative.Evaluate(new Dictionary<string, object> { ["t"] = t });
        }

        /// <summary>
        /// Load currentFunction from file which contains both the current vs time function and its time-derivative in the next line.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <exception cref="Exception">File is in invalid format</exception>
        public static CurrentFunction loadFromFile(string filename) {

            string[] lines = File.ReadAllLines(filename);

            if (lines.Length < 2) {
                throw new Exception("Invalid file content, requires at least 2 lines");
            }

            // first read first line
            var f1 = new Expression(lines[0]);
            var f2 = new Expression(lines[1]);

            return new CurrentFunction(f1, f2);
        }
    }

    /// <summary>
    /// Stores approximated function
    /// 
    /// Unused as of now but I'm keeping it around if I implement GPU calculation.
    /// </summary>
    internal class AproximateFunction {

        float[] values;
        float dt;
        float maxT;

        public AproximateFunction(Expression expression, int resolution, float maxT) {
            dt = maxT / resolution;
            this.maxT = maxT;

            values = new float[(int)Math.Ceiling(maxT / dt)];
            for(int x=0; x<resolution; x++) {
                values[x] = (float)expression.Evaluate(new Dictionary<string, object> { ["t"] = x * dt });
            }
        }


    }

}
