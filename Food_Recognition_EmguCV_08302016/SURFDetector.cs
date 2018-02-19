using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.Util.TypeEnum;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.XFeatures2D;
using Emgu.CV.OCR;
using Emgu.CV.ML;
using Emgu.CV.Features2D;

namespace Food_Recognition_EmguCV_08302016
{
    class SURFDetector
    {
        public void SURFDraw(Mat image, Mat testImage)
        {
            
            VectorOfKeyPoint keyPoint = new VectorOfKeyPoint();
            SURF surfCPU = new SURF(500, 4, 2, true, false);

            surfCPU.DetectRaw(image, keyPoint);
            Features2DToolbox.DrawKeypoints(image, keyPoint, testImage, new Bgr(Color.Red), Features2DToolbox.KeypointDrawType.Default);

           
        }
    }
}
