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
    class SIFTDetector
    {
        public void SIFTDraw(Mat image,Mat testImage)
        {
            

            SIFT siftCPU = new SIFT();
            VectorOfKeyPoint keyPoint = new VectorOfKeyPoint();
            siftCPU.DetectRaw(image, keyPoint);
            
            Features2DToolbox.DrawKeypoints(image, keyPoint, testImage, new Bgr(Color.GreenYellow), Features2DToolbox.KeypointDrawType.NotDrawSinglePoints);
            
        }
    }
}
