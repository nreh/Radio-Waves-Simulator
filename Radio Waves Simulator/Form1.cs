namespace Radio_Waves_Simulator {
    public partial class Form1 : Form {

        Rendering.RenderEngine renderEngine;

        public Form1() {
            InitializeComponent();

            renderEngine = new Rendering.RenderEngine(new Rendering.RenderSettings());

            Pen dashedLinePattern = new Pen(Color.White);
            dashedLinePattern.DashPattern = new float[] { 1, 3 };

            renderEngine.AddObject(
                (new Rendering.RenderObjects.Rectangle(0, 0, 500, 500)).setStroke(dashedLinePattern)
            );

            renderEngine.AddObject(
                (new Rendering.RenderObjects.Lines((new PointF[] { new Point(0, -50), new Point(0, 50) }).ToList<PointF>())).setStroke(new Pen(Color.Yellow, 2))
            );

            renderEngine.renderState.centerCamera(pictureBox1.Width, pictureBox1.Height);

            renderEngine.attachListeners(pictureBox1);

            pictureBox1.Refresh();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            renderEngine.Draw(e.Graphics);
        }
    }
}