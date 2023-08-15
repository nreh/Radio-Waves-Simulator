using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Radio_Waves_Simulator.Rendering.RenderObjects;
using Radio_Waves_Simulator.Rendering;
using Expressive;
using Radio_Waves_Simulator.Models;
using System.ComponentModel;

namespace Radio_Waves_Simulator.Simulator {
    /// <summary>
    /// Handles simulation state and settings
    /// </summary>
    internal class SimulatorModel {

        public SimulationSettings simulationSettings = new SimulationSettings();

        public Models.Simulator? simulator = null;

        private Dictionary<string, Lines> antennaShapes;
        /// <summary>
        /// Antenna shapes that can be selected
        /// </summary>
        public Dictionary<string, Lines> AntennaShapes {
            get {
                return antennaShapes;
            }
            private set { }
        }
        
        private string selectedAntenna = "";
        public string SelectedAntenna {
            get {
                return selectedAntenna;
            }
            set {
                selectedAntenna = value;

                RenderObject? antennaObj = renderEngine.renderObjects.getObjectByName("antenna");
                if (antennaObj != null) {
                    // remove existing antenna object
                    renderEngine.renderObjects.Remove(antennaObj);
                }

                // add new antenna object
                renderEngine.renderObjects.Add(AntennaShapes[value]);

                redraw();
            }
        }

        private Dictionary<string, CurrentFunction> currentFunctions;
        public Dictionary<string, CurrentFunction> CurrentFunctions {
            get {
                return currentFunctions;
            }
            private set { }
        }

        private string selectedCurrentFunction = "";
        public string SelectedCurrentFunction {
            get {
                return selectedCurrentFunction;
            }
            set {
                selectedCurrentFunction = value;
            }
        }

        RenderEngine renderEngine;
        RenderSettings renderSettings = new RenderSettings();

        public PictureBox pictureBox;

        /// <summary>
        /// Create and initialize Simulator
        /// </summary>
        /// <param name="pictureBox">Picturebox the will render everything</param>
        /// <exception cref="Exception">When no antenna's are loaded</exception>
        public SimulatorModel(PictureBox _pictureBox) {
            pictureBox = _pictureBox;

            // read antenna shapes in 'Antenna Shapes' directory
            var files = Directory.GetFiles("Antenna Shapes/");

            antennaShapes = new Dictionary<string, Lines>();

            foreach (var file in files) {
                try {

                    string shapeName = Path.GetFileNameWithoutExtension(file);
                    Lines newShape = Utils.RenderObjectUtils.loadLinesFromFile(file);

                    // make line yellow
                    newShape.stroke = new Pen(Color.Yellow);

                    newShape.name = "antenna";

                    antennaShapes.Add(shapeName, newShape);

                    Debug.WriteLine("Loaded antenna shape from " + file);
                } catch (Exception e) {
                    Debug.WriteLine("Failed to load antenna shape from " + file);
                    Debug.WriteLine(e.ToString());
                }
            }

            // read current functions in 'Current Functions' directory

            files = Directory.GetFiles("Current Functions/");

            currentFunctions = new Dictionary<string, CurrentFunction>();

            foreach (var file in files) {
                try {

                    currentFunctions.Add(
                        Path.GetFileNameWithoutExtension(file),
                        CurrentFunction.loadFromFile(file)
                    );

                    Debug.WriteLine("Loaded current function from " + file);
                } catch (Exception e) {
                    Debug.WriteLine("Failed to load current function from " + file);
                    Debug.WriteLine(e.ToString());
                }
            }

            // set default current vs. time function to 'Bell Curve'

            if (currentFunctions.Count > 0) {
                if (currentFunctions.Keys.Contains("Bell Curve")) {
                    selectedCurrentFunction = "Bell Curve";
                } else {
                    // if not, set to first loaded function
                    selectedCurrentFunction = currentFunctions.Keys.First();
                }
            } else {
                Debug.WriteLine("No current functions loaded!");
                throw new Exception("No current functions loaded!");
            }

            // set up renderEngine

            renderEngine = new RenderEngine(renderSettings);
            renderEngine.attachListeners(pictureBox);

            createDefaultObjects();

            // set default antenna to 'Straight Line'
            if (antennaShapes.Count > 0) {
                if (antennaShapes.Keys.Contains("Vertical Line")) {
                    SelectedAntenna = "Vertical Line";
                } else {
                    // if not, set to first loaded shape
                    SelectedAntenna = antennaShapes.Keys.First();
                }
            } else {
                Debug.WriteLine("No antenna shapes loaded!");
                throw new Exception("No antenna shapes were loaded!");
            }

            // initial paint
            redraw();
        }

        /// <summary>
        /// Create default objects such as simulation region
        /// </summary>
        public void createDefaultObjects() {

            // remove existing objects if necessary
            renderEngine.renderObjects.removeRenderObjectByName("simulation region", quiet: true);

            // Add a dashed box indicating simulation region

            Pen dashedLinePattern = new Pen(Color.White);
            dashedLinePattern.DashPattern = new float[] { 1, 3 };

            renderEngine.AddObject(
                (new Rendering.RenderObjects.Rectangle(0, 0, simulationSettings.simulationRegion.Width, simulationSettings.simulationRegion.Height))
                .setName("simulation region")
                .setStroke(dashedLinePattern)
            );

        }

        /// <summary>
        /// Refresh picturebox
        /// </summary>
        public void redraw() {
            pictureBox.Refresh();
        }

        public EventHandler? onSimulationComplete;

        /// <summary>
        /// Start calculating simulation frames
        /// </summary>
        /// <param name="onFrame">Invoked when a new frame is calculated</param>
        /// <exception cref="Exception"></exception>
        public void startSimulation(EventHandler? onFrame = null) {
            var w = renderEngine.renderObjects.getObjectByName("antenna");
            
            if (w == null) {
                throw new Exception("Antenna doesn't exist in render engine!");
            }

            if (simulator != null) {
                simulator.Dispose();
                simulator = null;
            }

            simulator = new Models.Simulator(simulationSettings, (Lines)w, CurrentFunctions[selectedCurrentFunction]);

            simulator.simulateFrames(simulationSettings.simulationFrames, onFrame);

            onSimulationComplete?.Invoke(this, new EventArgs());
        }

        public void drawFrame(int frameIndex) {
            if (simulator == null) {
                throw new Exception("No simulation calculated");
            }

            if (frameIndex >= simulator.allFrames.Count) {
                throw new Exception("Index out of bounds");
            }

            // remove last frame if already exists
            renderEngine.renderObjects.removeRenderObjectByName("frame", quiet: true);

            // add new frame object to renderEngine
            FrameRenderer fr = new FrameRenderer(simulationSettings.simulationRegion.Width, simulationSettings.simulationRegion.Height, simulator.allFrames[frameIndex]);
            fr.name = "frame";
            renderEngine.AddObject(fr, 0);
            redraw();

            Debug.WriteLine("Showing frame " + frameIndex.ToString());
        }

    }
}
