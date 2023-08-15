using Expressive;
using Radio_Waves_Simulator.Rendering.RenderObjects;
using Radio_Waves_Simulator.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Models {
    /// <summary>
    /// Class that does the actual calculation of the radio wave propagation
    /// </summary>
    internal class Simulator {
        SimulationSettings simulationSettings;
        Lines wire;
        CurrentFunction currentFunction;

        /// <summary>
        /// Current time
        /// </summary>
        float t = 0;

        public List<Frame> allFrames = new List<Frame>();

        public Simulator(SimulationSettings simulationSettings, Lines wire, CurrentFunction currentFunction) {
            this.simulationSettings = simulationSettings;
            this.wire = wire;
            this.currentFunction = currentFunction;
        }

        /// <summary>
        /// Simulate a number of frames
        /// </summary>
        /// <param name="frames"></param>
        public void simulateFrames(int frames) {
            for(int x=0; x<frames; x++) {
                allFrames.Add(calculateFrame(t));                
                t += simulationSettings.dt;
                Debug.WriteLine("Calculated frame " + (x + 1).ToString() + "/" + frames.ToString());
            }
            for (int x = 0; x < frames; x++) {
                allFrames[x].generateBitmap();
                Debug.WriteLine("Generated bitmap for frame " + (x + 1).ToString() + "/" + frames.ToString());
            }
        }

        /// <summary>
        /// Calculate field at time t
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Frame calculateFrame(float t) {
            int regionWidth = simulationSettings.simulationRegion.Width;
            int regionHeight = simulationSettings.simulationRegion.Height;

            Frame f = new Frame(regionWidth / simulationSettings.pixelSize +1, regionHeight / simulationSettings.pixelSize +1);

            float rw2 = regionWidth / 2;
            float rh2 = regionHeight / 2;

            // populate matrix with field data

            float c = simulationSettings.C;

            int i = 0;
            int j = 0;
            for (float y = -rh2; y <= rh2; y += simulationSettings.pixelSize) {
                for (float x = -rw2; x <= rw2; x+= simulationSettings.pixelSize) {
                    f.field[i, j] = calculateFieldAt(new PointF(x, y), t, c);
                    j++;
                }
                j = 0;
                i++;
            }

            f.generateBitmap();

            return f;
        }

        PointF calculateFieldAt(PointF position, float t, float c) {
            PointF value = new PointF(0, 0);

            // Add up all wire contributions
            for(float p=0; p<=1 + 0.01f; p+=simulationSettings.dp) {
                PointF w = calculateContributionFromWireElement(position, p, t, c);
                value.X += w.X;
                value.Y += w.Y;
            }

            // increase contribution for cases where field isn't visible enough or is too visible
            value.X *= simulationSettings.fieldMultiplier;
            value.Y *= simulationSettings.fieldMultiplier;

            return value;
        }

        PointF calculateContributionFromWireElement(PointF position, float p, float t, float c) {

            // first get wire element position and tangent

            FieldVector wireElement = wire.Position(p);

            // then calculate the length of the wire element

            float wireElementLength = wire.Length / simulationSettings.dp;

            // we can now calculate dl, which is the vector representing the wire element's length and direction
            PointF dl = wireElement.direction;
            dl.X *= wireElementLength;
            dl.Y *= wireElementLength;

            // now calculate distance from wire element to point of interest

            float R = PointFUtils.Distance(position, wireElement.position);

            // retarded time

            float rTime = t - (R / c);

            // calculate dJ/dt at retarded time

            float dJ = currentFunction.derivativeAt(rTime);

            // multiply together and return

            return new PointF(dJ * (1/R) * dl.X, dJ * (1 / R) * dl.Y);

        }
    }
}
