using Radio_Waves_Simulator.Utils;
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

        private DirectBitmap? bitmap;

        /// <summary>
        /// Bitmap representation of field with brighter pixels representing higher field strength
        /// </summary>
        public DirectBitmap Bitmap {
            get {
                if (bitmap == null) {
                    generateBitmap();
                }

#pragma warning disable CS8603 // Possible null reference return.
                return bitmap;
#pragma warning restore CS8603 // Possible null reference return.
            }
            private set { }
        }

        private int width;
        public int Width {
            get { return width; }
            private set { }
        }

        private int height;
        public int Height {
            get { return height; }
            private set { }
        }

        public Frame(int width, int height) {
            field = new PointF[width, height];
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Generate and cache bitmap for this frame so that it can be rendered by FrameRenderer
        /// </summary>
        public void generateBitmap() {
            if (field == null) {
                throw new Exception("Field is null");
            }


            bitmap = new DirectBitmap(Width, height);

            for (int y = 0; y < Height; y++) {
                for (int x=0; x<Width; x++) {
                    float mag = PointFUtils.Magnitude(field[y, x]);
                    int b = (int)((MathUtils.ClampMax(MathUtils.Normalize(mag, 20000000), 1) * 255));
                    Color pixelColor = Color.FromArgb(b, b, b);
                    bitmap.SetPixel(x, y, pixelColor);
                }
            }
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
