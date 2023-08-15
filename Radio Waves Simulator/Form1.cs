using Radio_Waves_Simulator.Simulator;

namespace Radio_Waves_Simulator {
    public partial class Form1 : Form {

        SimulatorModel simulatorModel;

        public Form1() {
            InitializeComponent();
            simulatorModel = new SimulatorModel(pictureBox1);

            // Update dropdown showing antenna shapes
            foreach (string shape in simulatorModel.AntennaShapes.Keys) {
                AntennaShapesDropdown.Items.Add(shape);
            }

            AntennaShapesDropdown.SelectedItem = simulatorModel.SelectedAntenna;

            // Update dropdown showing current vs. time functions
            foreach (string function in simulatorModel.CurrentFunctions.Keys) {
                CurrentFunctionsDropDown.Items.Add(function);
            }

            CurrentFunctionsDropDown.SelectedItem = simulatorModel.SelectedCurrentFunction;


            // Load simulation settings into UI
            simRegionWidth.Value = simulatorModel.simulationSettings.simulationRegion.Width;
            simRegionHeight.Value = simulatorModel.simulationSettings.simulationRegion.Height;
            timeStep.Value = Convert.ToDecimal(simulatorModel.simulationSettings.dt);
            wireElementSize.Value = Convert.ToDecimal(simulatorModel.simulationSettings.dp);
            pixelSize.Value = simulatorModel.simulationSettings.pixelSize;
            lightSpeed.Value = Convert.ToDecimal(simulatorModel.simulationSettings.C);
            simulationFrames.Value = simulatorModel.simulationSettings.simulationFrames;
            fieldMultiplier.Value = Convert.ToDecimal(simulatorModel.simulationSettings.fieldMultiplier);

            // Add event handlers
            simRegionWidth.ValueChanged += (s, e) => { 
                simulatorModel.simulationSettings.simulationRegion.Width = (int)simRegionWidth.Value;
                simulatorModel.createDefaultObjects();
                simulatorModel.redraw();
            };
            simRegionHeight.ValueChanged += (s, e) => { 
                simulatorModel.simulationSettings.simulationRegion.Height = (int)simRegionHeight.Value;
                simulatorModel.createDefaultObjects();
                simulatorModel.redraw();
            };
            timeStep.ValueChanged += (s, e) => { simulatorModel.simulationSettings.dt = (float)simRegionHeight.Value; };
            wireElementSize.ValueChanged += (s, e) => { simulatorModel.simulationSettings.dp = (float)wireElementSize.Value; };
            pixelSize.ValueChanged += (s, e) => { simulatorModel.simulationSettings.pixelSize = (int)pixelSize.Value; };
            lightSpeed.ValueChanged += (s, e) => { simulatorModel.simulationSettings.C = (float)lightSpeed.Value; };
            simulationFrames.ValueChanged += (s, e) => { simulatorModel.simulationSettings.simulationFrames = (int)simulationFrames.Value; };
            fieldMultiplier.ValueChanged += (s, e) => { simulatorModel.simulationSettings.fieldMultiplier = (int)fieldMultiplier.Value; };
        }



        private void AntennaShapesDropdown_SelectedIndexChanged(object sender, EventArgs e) {
            simulatorModel.SelectedAntenna = (string)AntennaShapesDropdown.SelectedItem;
        }

        private void CurrentFunctionsDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            simulatorModel.SelectedCurrentFunction = (string)CurrentFunctionsDropDown.SelectedItem;
        }

        private void SimulateButton_Click(object sender, EventArgs e) {
            // disable UI while things are loading
            tabControl1.Enabled = false;
            SimulateButton.Enabled = false;
            SimulateButton.Text = "Please wait...";

            // start backgroundworker
            backgroundWorker1.RunWorkerAsync();
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            simulatorModel.drawFrame(trackBar1.Value);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            simulatorModel.startSimulation((o, e) => {
                // every time new frame is created update UI
                int progress = (int)MathF.Ceiling(100 * simulatorModel.simulator.allFrames.Count / simulatorModel.simulationSettings.simulationFrames);
                backgroundWorker1.ReportProgress(progress);
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            // update window title
            this.Text = "Radio Wave Simulator - " + (e.ProgressPercentage) + "%";

            // show newest frame
            trackBar1.Maximum = simulatorModel.simulator.allFrames.Count-1;
            trackBar1.Value = trackBar1.Maximum;
            simulatorModel.drawFrame(trackBar1.Value);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            // update window title
            this.Text = "Radio Wave Simulator";

            trackBar1.Enabled = true;
            trackBar1.Maximum = simulatorModel.simulator.allFrames.Count - 1;
            trackBar1.Value = 0;

            simulatorModel.drawFrame(0);

            // re-enable UI
            tabControl1.Enabled = true;
            SimulateButton.Enabled = true;
            SimulateButton.Text = "Simulate";
        }
    }
}