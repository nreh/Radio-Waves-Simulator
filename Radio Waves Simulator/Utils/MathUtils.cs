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
    }
}
