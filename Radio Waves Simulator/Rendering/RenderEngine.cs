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
        public RenderObjectList renderObjects = new RenderObjectList();

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

        #region Picturebox event handlers

        /// <summary>
        /// Picturebox that this renderer will work on
        /// </summary>
        private PictureBox? picturebox;

        /// <summary>
        /// Attach drag and zoom listeners to a picturebox as well as update renderState.BoundsSize
        /// </summary>
        /// <param name="pictureBox"></param>
        public void attachListeners(PictureBox pictureBox) {
            picturebox = pictureBox;

            pictureBox.MouseDown += OnDragStart;
            pictureBox.MouseMove += OnDrag;
            pictureBox.MouseUp += OnDragEnd;
            pictureBox.Resize += onResize;
            picturebox.Paint += onPaint;

            renderState.BoundsSize = pictureBox.Size;
        }

        private void onPaint(object? sender, PaintEventArgs e) {
            Draw(e.Graphics);
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

#pragma warning disable CS8602 // Dereference of a possibly null reference since we know that picturebox will not be null.
                picturebox.Refresh();
#pragma warning restore CS8602
            }
        }

        private void OnDragEnd(object? sender, MouseEventArgs e) {
            isDragging = false;
        }

        private void onResize(object? sender, EventArgs e) {
            // update render state with new size information

#pragma warning disable CS8602 // Dereference of a possibly null reference since we know that picturebox will not be null.
            renderState.BoundsSize = picturebox.Size;
#pragma warning restore CS8602

            picturebox.Refresh();
        }

        #endregion
    }
}
