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

namespace Radio_Waves_Simulator.Simulator {
    /// <summary>
    /// Handles simulation state and settings
    /// </summary>
    internal class SimulatorModel {

        public SimulationSettings simulationSettings = new SimulationSettings();

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

        private Dictionary<string, Expression> currentFunctions;
        public Dictionary<string, Expression> CurrentFunctions {
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

            currentFunctions = new Dictionary<string, Expression>();

            foreach (var file in files) {
                try {

                    currentFunctions.Add(
                        Path.GetFileNameWithoutExtension(file),
                        new Expression(File.ReadAllText(file))
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
        private void createDefaultObjects() {

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
    }
}
