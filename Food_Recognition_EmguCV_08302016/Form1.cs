﻿using System;
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
    public partial class Form1 : Form
    {
        SURFDetector SURFDetect = new SURFDetector();
        SIFTDetector SIFTDetect = new SIFTDetector();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // CvInvoke.CalcHist();
        }
        public void mainFunction(Mat image)
        {
            Mat testImage = new Mat();
            ContourImage(image, testImage);
           // SURFDetect.SURFDraw(image, testImage);
            SIFTDetect.SIFTDraw(image, testImage);
            //differenceImage(image,testImage);
            
            TestImage.Image = testImage.Bitmap;
        }
        public void applyHistogram(Mat image)
        {
            Mat hist = new Mat();
            int hbins = 10, sbins = 12;
            int[] histSize = { hbins, sbins };
            float[] hrange = { 0, 180 };
            float[] srange = { 0, 256 };
            float[] range = { 1, 255 };
            int[] channel = { 0, 1 };

            CvInvoke.CalcHist(image, channel, new Mat(), hist, histSize, range, true);
            subtractImage.Image = hist.Bitmap;

        }
        // get the contours of image and draw all possible contour
        void ContourImage(Mat image, Mat testImage)
        {
            Mat thresholdImage = new Mat();

            Mat structuringElement = new Mat();
            // convert original image into grayscale
            CvInvoke.CvtColor(image, thresholdImage, ColorConversion.Bgr2Gray);
            // threshold the image
            // CvInvoke.Threshold(thresholdImage, thresholdImage, 100, 200, ThresholdType.BinaryInv);

            // detect edges in image using canny
            CvInvoke.Canny(thresholdImage, thresholdImage, 100, 200, 7, false);
            /*
           structuringElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle,new Size(3,3) ,new Point(-1, -1));
           CvInvoke.InRange(image, new ScalarArray(new MCvScalar(0, 0,0)), new ScalarArray(new MCvScalar(170, 170, 170)), thresholdImage);
           CvInvoke.Erode(thresholdImage, thresholdImage, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
           */
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                // find contour in image from threshold image
                CvInvoke.FindContours(thresholdImage, contours, null, RetrType.External, ChainApproxMethod.ChainApproxNone);
                //mask
                Mat mask = new Mat(thresholdImage.Rows, thresholdImage.Cols, DepthType.Cv8U, 1);

                double maxArea = new double();
                int largestContourIndex = new int();
                largestContourIndex = 0;
                maxArea = 0;
                // find largest contour in image
                for (int i = 0; i < contours.Size; i++)
                {
                    double area = CvInvoke.ContourArea(contours[i]);
                    if (area > maxArea)
                    {
                        maxArea = area;
                        largestContourIndex = i;
                    }
                }
                // draw contour on image
                CvInvoke.DrawContours(mask, contours, /*largestContourIndex*/-1, new MCvScalar(255, 145, 36), 2, LineType.EightConnected, null);
                // create new image row and cols
                Mat crop = new Mat(image.Rows, image.Cols, DepthType.Cv8U, 1);
                // set backgroud of image to BGR value
                crop.SetTo(new ScalarArray(new MCvScalar(20, 20, 20)),null);
                // copy the image
                image.CopyTo(crop, mask);
                // normalize the image
                CvInvoke.Normalize(mask.Clone(), mask, 0, 255, NormType.MinMax, DepthType.Cv8U);

                //TestImage.Image = crop.Bitmap;
                //subtractImage.Image = mask.Bitmap;
                subtractImage.Image = crop.Bitmap;

            }
        }

        public void differenceImage(Mat image, Mat testImage)
        {
            Mat imageGray = new Mat();
            Mat threshImageInv = new Mat();
            Mat threshImage = new Mat();
            CvInvoke.CvtColor(image, imageGray, ColorConversion.Bgr2Gray);
            CvInvoke.Threshold(imageGray, threshImage, 150, 200, ThresholdType.Binary); // it is good
            CvInvoke.Threshold(imageGray, threshImageInv, 150, 255, ThresholdType.BinaryInv); // it is good

            //CvInvoke.AbsDiff(threshImage, threshImageInv, testImage);
            //CvInvoke.Subtract(threshImageInv, threshImage, testImage);

            subtractImage.Image = threshImageInv.Bitmap;
            TestImage.Image = threshImage.Bitmap;

            testImage = threshImage;

        }

        private void OpenImageByClickingButton_Click(object sender, EventArgs e)
        {
            Mat imageOriginal = new Mat();
            string fileName;
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "JPEG|*.jpg"; // list of format to save image
            openImage.DefaultExt = @"C:\Users\Anish\OneDrive - Texas Southern University\Texas Southern University\Summer 2016\Sample Scranton";
            if (openImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openImage.FileName;
                imageOriginal = CvInvoke.Imread(fileName, LoadImageType.Unchanged);
                CvInvoke.Resize(imageOriginal, imageOriginal, new Size(500, 500), 0, 0);
                mainFunction(imageOriginal);
                RealImage.Image = imageOriginal.Bitmap;
            }
        }
    }
}
