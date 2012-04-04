using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Html_Demo
{
    [DefaultEvent("ColorSelected")]
    public partial class ColorPicker : UserControl
    {
        private Image Image;
        private Color _selectedColor;

        public event EventHandler ColorSelected;

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string strDriver, string strDevice, string strOutput, IntPtr pData);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        public static extern int GetPixel(IntPtr hdc, int x, int y);

        public ColorPicker()
        {
            Image = Properties.Resources.web_pallete;
            InitializeComponent();
            Size = Image.Size;
        }


        /// <summary>
        /// Gets or sets the selected color of the palette
        /// </summary>
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set { _selectedColor = value; }
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Size = Image.Size;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawImage(Image, ClientRectangle);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Point p = PointToScreen(new Point(e.X, e.Y));
            IntPtr hdc = CreateDC("Display", null, null, IntPtr.Zero);
            int selColor = GetPixel(hdc, p.X, p.Y);
            DeleteDC(hdc);

            SelectedColor = Color.FromArgb((selColor & 0x000000FF), (selColor & 0x0000FF00) >> 8,(selColor & 0x00FF0000) >> 16);

            if (ColorSelected != null)
            {
                ColorSelected(this, EventArgs.Empty);
            }
        }

        private void ColorPicker_Load(object sender, EventArgs e)
        {

        }
    }
}
