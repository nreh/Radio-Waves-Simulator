using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering {
    /// <summary>
    /// Used for rendering simulation
    /// </summary>
    internal class RenderEngine {

        public RenderEngineState renderState = new RenderEngineState();
        private RenderSettings renderSettings;

        /// <summary>
        /// List of objects to render
        /// </summary>
        private List<RenderObject> renderObjects = new List<RenderObject>();

        public RenderEngine(RenderSettings _renderSettings) {
            renderSettings = _renderSettings;
        }

        public void Draw(Graphics g) {
            foreach (RenderObject obj in renderObjects) {
                obj.Draw(renderState, g);
            }
        }

        public void AddObject(RenderObject obj) {
            renderObjects.Add(obj);
        }

        private PictureBox picturebox;

        /// <summary>
        /// Attach drag and zoom listeners to a picturebox
        /// </summary>
        /// <param name="pictureBox"></param>
        public void attachListeners(PictureBox pictureBox) {
            picturebox = pictureBox;

            pictureBox.MouseDown += OnDragStart;
            pictureBox.MouseMove += OnDrag;
            pictureBox.MouseUp += OnDragEnd;
        }

        private PointF dragStart = new PointF(0,0);
        private PointF originalCameraPosition = new PointF(0, 0);
        private bool isDragging = false;

        private void OnDragStart(object? sender, MouseEventArgs e) {
            dragStart = new PointF(e.X, e.Y);
            originalCameraPosition = renderState.cameraPosition;
            isDragging = true;
        }

        private void OnDrag(object? sender, MouseEventArgs e) {
            if (isDragging) {
                renderState.cameraPosition.X = originalCameraPosition.X - (e.X - dragStart.X);
                renderState.cameraPosition.Y = originalCameraPosition.Y -  (e.Y - dragStart.Y);

                picturebox.Refresh();
            }
        }

        private void OnDragEnd(object? sender, MouseEventArgs e) {
            isDragging = false;
        }
    }
}
