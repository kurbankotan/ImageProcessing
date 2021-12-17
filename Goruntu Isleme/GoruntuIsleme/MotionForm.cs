
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;

namespace GoruntuIsleme
{
    public partial class MotionForm : Form
    {
        private IVideoSource _videoSource = null;
        readonly MotionDetector detector = new MotionDetector(
            new TwoFramesDifferenceDetector( ),
            new MotionAreaHighlighting( ) );

        //private int motionDetectionType = 1;
        //private int motionProcessingType = 1;
        private const int StatLength = 15;

        private int _statIndex;

        private int _statReady;
 
        private readonly int[] _statCount = new int[StatLength];

        private int _flash;
        private const float MotionAlarmLevel = 0.015f;

        private readonly List<float> _motionHistory = new List<float>( );
        private int _detectedObjectsCount = -1;

        public MotionForm( )
        {
            InitializeComponent( );
            Application.Idle += Application_Idle;
        }

        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            CloseVideoSource( );
        }

        private void localVideoCaptureDeviceToolStripMenuItem_Click( object sender, EventArgs e )
        {
            VideoCaptureDeviceForm form = new VideoCaptureDeviceForm( );

            if ( form.ShowDialog( this ) == DialogResult.OK )
            {
                VideoCaptureDevice videoSource = new VideoCaptureDevice( form.VideoDevice );
                OpenVideoSource( videoSource );
            }
        }
        private void OpenVideoSource( IVideoSource source )
        {

            Cursor = Cursors.WaitCursor;

            CloseVideoSource( );

            videoSourcePlayer.VideoSource = new AsyncVideoSource( source );
            videoSourcePlayer.Start( );

            _statIndex = _statReady = 0;

            timer.Start( );
            alarmTimer.Start( );

            _videoSource = source;

            Cursor = Cursors.Default;
        }

        private void CloseVideoSource( )
        {

            Cursor = Cursors.WaitCursor;

            videoSourcePlayer.SignalToStop( );

            for ( int i = 0; ( i < 50 ) && ( videoSourcePlayer.IsRunning ); i++ )
            {
                Thread.Sleep( 100 );
            }
            if ( videoSourcePlayer.IsRunning )
                videoSourcePlayer.Stop( );

            timer.Stop( );
            alarmTimer.Stop( );

            _motionHistory.Clear( );

            if ( detector != null )
                detector.Reset( );

            videoSourcePlayer.BorderColor = Color.Black;
            Cursor = Cursors.Default;
        }

        private void videoSourcePlayer_NewFrame( object sender, ref Bitmap image )
        {
            lock ( this )
            {
                if ( detector != null )
                {
                    float motionLevel = detector.ProcessFrame( image );

                    if ( motionLevel > MotionAlarmLevel )
                    {

                        _flash = 2 * ( 1000 / alarmTimer.Interval );
                    }

                    var algorithm = detector.MotionProcessingAlgorithm as BlobCountingObjectsProcessing;
                    if ( algorithm != null )
                    {
                        BlobCountingObjectsProcessing countingDetector = algorithm;
                        _detectedObjectsCount = countingDetector.ObjectsCount;
                    }
                    else
                    {
                        _detectedObjectsCount = -1;
                    }

                    _motionHistory.Add( motionLevel );
                    if ( _motionHistory.Count > 300 )
                    {
                        _motionHistory.RemoveAt( 0 );
                    }
                }
            }
        }

        private void Application_Idle( object sender, EventArgs e )
        {
            objectsCountLabel.Text = ( _detectedObjectsCount < 0 ) ? string.Empty : "Objects: " + _detectedObjectsCount;
        }

        private void timer_Tick( object sender, EventArgs e )
        {
            IVideoSource videoSource = videoSourcePlayer.VideoSource;

            if ( videoSource != null )
            {

                _statCount[_statIndex] = videoSource.FramesReceived;

                if ( ++_statIndex >= StatLength )
                    _statIndex = 0;
                if ( _statReady < StatLength )
                    _statReady++;

                float fps = 0;

                for ( int i = 0; i < _statReady; i++ )
                {
                    fps += _statCount[i];
                }
                fps /= _statReady;

                _statCount[_statIndex] = 0;

                fpsLabel.Text = fps.ToString( "F2" ) + @" fps";
            }
        }

        private void alarmTimer_Tick( object sender, EventArgs e )
        {
            if ( _flash != 0 )
            {
                videoSourcePlayer.BorderColor = ( _flash % 2 == 1 ) ? Color.Black : Color.Red;
                _flash--;
            }
        }
    }
}