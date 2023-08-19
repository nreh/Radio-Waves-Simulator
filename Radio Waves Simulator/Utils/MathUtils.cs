using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Utils {
    internal class MathUtils {

        /// <summary>
        /// Normalize value so that when value is max, 1 is return and when it is 0, 0 is returned
        /// 
        /// If invalid value is supplied, 0 is returned instead
        /// </summary>
        /// <param name="value"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Normalize(float value, float max) {
            if (float.IsNaN(value)) {
                return 0;
            }

            return value / max;
        }


        public static float ClampMax(float value, float max) {
            if (value > max) {
                return max;
            }

            return value;
        }

        /// <summary>
        /// Scales a value so that it aproaches 1 when higher. In a sense, it's roughly similar to ClampMax but as
        /// the value aproaches its max, it smooths out rather than sharply stopping at a max value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="max">Around the maximum value this function should expect as input</param>
        /// <returns></returns>
        public static float SmoothClamp(float value, float max) {
            float k = value * max;
            return k / (MathF.Pow(value, 1.7f) + k);
        }
    }
}
