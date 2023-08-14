using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Utils {
    /// <summary>
    /// Stores position and direction information
    /// </summary>
    internal class FieldVector {

        public PointF position, direction;
        public FieldVector() { }

        public FieldVector(PointF position, PointF direction) {
            this.position = position;
            this.direction = direction;
        }
    }
}
