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
    /// A frame contains the field value at each point in the render region and also provides functions for generating a bitmap for rendering the frame.
    /// </summary>
    internal class Frame {
        /// <summary>
        /// 2D matrix containing the field strength
        /// </summary>
        public PointF[,] field;

        public SimulationSettings simulationSettings;

        private DirectBitmap? bitmap;

        /// <summary>
        /// Bitmap representation of field with brighter pixels representing higher field strength
        /// </summary>
        public DirectBitmap? Bitmap {
            get {
                return bitmap;
            }
            private set { }
        }

        public enum Mode {
            SCALAR,
            VECTOR_FIELD
        }
        private Mode renderMode;
        /// <summary>
        /// How the field will be represented, either by representing its strength at every point or a vector field.
        /// </summary>
        public Mode RenderMode {
            get { return renderMode; }
            set {
                renderMode = value;
                generateBitmap();
            }
        }

        private int vectorLengthModifier = 10;
        public int VectorLengthModifier {
            get { return vectorLengthModifier; }
            set {
                vectorLengthModifier = value;
                generateBitmap();
            }
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

        public Frame(int width, int height, SimulationSettings simulationSettings) {
            field = new PointF[width, height];
            this.width = width;
            this.height = height;
            this.simulationSettings = simulationSettings;
        }

        /// <summary>
        /// Generate and cache bitmap for this frame so that it can be rendered by FrameRenderer
        /// </summary>
        public void generateBitmap() {
            // dipose old bitmap if it already exists
            if (bitmap != null) {
                bitmap.Dispose();
                bitmap = null;
            }

            if (field == null) {
                throw new Exception("Field is null");
            }

            if (renderMode == Mode.SCALAR) {
                drawScalarBitmap(out bitmap, simulationSettings);
            } else if (renderMode == Mode.VECTOR_FIELD) {
                drawVectorfieldBitmap(out bitmap, simulationSettings);
            }
        }

        private void drawScalarBitmap(out DirectBitmap bitmap, SimulationSettings simulationSettings) {
            bitmap = new DirectBitmap(Width / simulationSettings.pixelSize, height / simulationSettings.pixelSize);

            for (int y = 0; y < bitmap.Height; y++) {
                for (int x = 0; x < bitmap.Width; x++) {
                    float mag = PointFUtils.Magnitude(field[y, x]);
                    int b = (int)((MathUtils.ClampMax(MathUtils.Normalize(mag, 20000000), 1) * 255));
                    Color pixelColor = Color.FromArgb(b, b, b);
                    bitmap.SetPixel(x, y, pixelColor);
                }
            }
        }

        private void drawVectorfieldBitmap(out DirectBitmap bitmap, SimulationSettings simulationSettings) {
            bitmap = new DirectBitmap(Width, height);

            var g = Graphics.FromImage(bitmap.Bitmap);
            var pen = new Pen(Color.White);
            var brush = new SolidBrush(Color.White);

            float offset = simulationSettings.pixelSize / 2.0f;

            for (int y=0; y<Height; y++) {
                for (int x=0; x<Width; x++) {
                    float xpos = offset + (x * simulationSettings.pixelSize);
                    float ypos = offset + (y * simulationSettings.pixelSize);

                    PointF pos1 = new PointF(xpos, ypos);
                    PointF pos2 = new PointF(xpos, ypos);

                    float magnitude = PointFUtils.Magnitude(field[x, y]);
                    float vectorLength = 0.75f * simulationSettings.pixelSize * MathUtils.SmoothClamp(magnitude, simulationSettings.fieldMultiplier);
                    float k = vectorLength / magnitude;

                    pos2.X += field[x, y].X * k;
                    pos2.Y += field[x, y].Y * k;

                    g.DrawLine(pen, pos1, pos2);
                    g.FillEllipse(brush, pos1.X - 2, pos1.Y - 2, 4, 4);
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
