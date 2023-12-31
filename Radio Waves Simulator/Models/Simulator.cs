﻿using Expressive;
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
    internal class Simulator : IDisposable {
        SimulationSettings simulationSettings;
        Lines wire;
        CurrentFunction currentFunction;

        /// <summary>
        /// If true, simulateFrames will cancel current work
        /// </summary>
        public bool cancelFlag = false;

        private bool isSimulating = false;
        public bool IsSimulating {
            get {
                return isSimulating;
            }
            private set { }
        }

        /// <summary>
        /// Current time
        /// </summary>
        float t = 0;

        public List<Frame> allFrames = new List<Frame>();
        private bool disposedValue;

        public Simulator(SimulationSettings simulationSettings, Lines wire, CurrentFunction currentFunction) {
            this.simulationSettings = simulationSettings;
            this.wire = wire;
            this.currentFunction = currentFunction;
        }

        /// <summary>
        /// Simulate a number of frames
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="onFrame">Invoked when a frame is calculated and rendered</param>
        public void simulateFrames(int frames, EventHandler? onFrame = null) {
            // reset flags
            cancelFlag = false;
            isSimulating = true;

            for(int x=0; x<frames; x++) {
                if (cancelFlag) break;

                allFrames.Add(calculateFrame(t));
                Debug.WriteLine("Calculated frame " + (x + 1).ToString() + "/" + frames.ToString());

                allFrames.Last().generateBitmap();
                Debug.WriteLine("Generated bitmap for frame " + (x + 1).ToString() + "/" + frames.ToString());

                onFrame?.Invoke(this, new onFrameEventArgs());

                t += simulationSettings.dt;
            }

            isSimulating = false;
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

        // This dispose structure was created by Visual Studio auto complete so I'm not going to touch it too much

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                foreach (Frame f in allFrames) {
                    f.Bitmap.Dispose();
                }

                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~Simulator() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public class onFrameEventArgs : EventArgs {
        public onFrameEventArgs() {
            
        }
    }
}
