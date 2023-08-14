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
        }

        private void AntennaShapesDropdown_SelectedIndexChanged(object sender, EventArgs e) {
            simulatorModel.SelectedAntenna = (string)AntennaShapesDropdown.SelectedItem;
        }
    }
}