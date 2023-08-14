using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Models {

    /// <summary>
    /// The simulator calculates the field frame by frame, where each frame is separated by some seconds dx
    /// 
    /// A frame contains the field value at each point in the render region
    /// </summary>
    internal class Frame {
        /// <summary>
        /// 2D matrix containing the field strength
        /// </summary>
        public PointF[,] field;

        public Frame(int width, int height) {
            field = new PointF[width, height];
        }
    }

    /// <summary>
    /// To improve rendering performance, rather than rendering frames, this class could be used to renderthe change in the field strengths instead.
    /// This would it so that if only part of the render region is changing, the entire region doesn't need to be updated.
    /// 
    /// TODO: IMPLEMENT THIS
    /// </summary>
    internal class DeltaFrame {
        /// <summary>
        /// 2D matrix containing the change of field values between previous frame and this one
        /// </summary>
        public PointF[,] deltas;

        public DeltaFrame(int width, int height) {
            deltas = new PointF[width, height];
        }
    }
}
