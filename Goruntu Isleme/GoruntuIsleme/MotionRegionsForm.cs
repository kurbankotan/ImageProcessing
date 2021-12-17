using System;
using System.Drawing;
using System.Windows.Forms;
using MotionDetectorSample;

namespace GoruntuIsleme
{
    public partial class MotionRegionsForm : Form
    {
        public Bitmap VideoFrame
        {
            set { defineRegionsControl.BackgroundImage = value; }
        }

        public Rectangle[] MotionRectangles
        {
            get { return defineRegionsControl.Rectangles; }
            set { defineRegionsControl.Rectangles = value; }
        }

        public MotionRegionsForm( )
        {
            InitializeComponent( );

            defineRegionsControl.OnNewRectangle += defineRegionsControl_NewRectangleHandler;
        }

        protected override void OnLoad( EventArgs e )
        {
            if ( defineRegionsControl.BackgroundImage != null )
            {
                int imageWidth  = defineRegionsControl.BackgroundImage.Width;
                int imageHeight = defineRegionsControl.BackgroundImage.Height;

                defineRegionsControl.Size = new Size( imageWidth + 2, imageHeight + 2 );

                Size = new Size( imageWidth + 2 + 26, imageHeight + 2 + 118 );
            }

            base.OnLoad( e );
        }

        private void rectangleButton_Click( object sender, EventArgs e )
        {
            DrawingMode currentMode = defineRegionsControl.DrawingMode;

            currentMode = ( currentMode == DrawingMode.Rectangular ) ? DrawingMode.None : DrawingMode.Rectangular;

            defineRegionsControl.DrawingMode = currentMode;

            rectangleButton.Checked = ( currentMode == DrawingMode.Rectangular );
        }

        private void defineRegionsControl_NewRectangleHandler( object sender, Rectangle rect )
        {
            rectangleButton.Checked = false;
        }

        private void clearButton_Click( object sender, EventArgs e )
        {
            defineRegionsControl.RemoveAllRegions( );
        }
    }
}