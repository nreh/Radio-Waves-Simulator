using Radio_Waves_Simulator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering.RenderObjects {
    /// <summary>
    /// Represent RenderObject as a parametric function
    /// </summary>
    internal interface Parametric {
        /// <summary>
        /// </summary>
        /// <param name="p">Value ranging from 0.0 to 1.0</param>
        /// <returns>
        /// FieldVector with position on curve from start to end where start is when p=0 and end is when p=1.
        /// The FieldVector points tangent to the curve at that point.
        /// </returns>
        public FieldVector Position(float p);
    }
}
