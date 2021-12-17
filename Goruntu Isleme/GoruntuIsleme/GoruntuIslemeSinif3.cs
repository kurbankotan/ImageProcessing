using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace GoruntuIsleme
{
    public static class ResimIsleme3
    {



    	        public static Bitmap GradyentFiltreleme(
                                this Bitmap sourceBitmap,
                                EdgeFilterType filterType,
                                DerivativeLevel derivativeLevel,
                                float redFactor = 1.0f,
                                float greenFactor = 1.0f,
                                float blueFactor = 1.0f,
                                byte threshold = 0)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];


            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);


            int derivative = (int)derivativeLevel;
            int byteOffset = 0;
            int blueGradient, greenGradient, redGradient = 0;
            double blue = 0, green = 0, red = 0;


            bool exceedsThreshold = false;


            for (int offsetY = 1; offsetY < sourceBitmap.Height - 1; offsetY++)
            {
                for (int offsetX = 1; offsetX <
                    sourceBitmap.Width - 1; offsetX++)
                {
                    byteOffset = offsetY * sourceData.Stride +
                                 offsetX * 4;


                    blueGradient =
                    Math.Abs(pixelBuffer[byteOffset - 4] -
                    pixelBuffer[byteOffset + 4]) / derivative;


                    blueGradient +=
                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                    pixelBuffer[byteOffset + sourceData.Stride]) / derivative;


                    byteOffset++;


                    greenGradient =
                    Math.Abs(pixelBuffer[byteOffset - 4] -
                    pixelBuffer[byteOffset + 4]) / derivative;


                    greenGradient +=
                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                    pixelBuffer[byteOffset + sourceData.Stride]) / derivative;


                    byteOffset++;


                    redGradient =
                    Math.Abs(pixelBuffer[byteOffset - 4] -
                    pixelBuffer[byteOffset + 4]) / derivative;


                    redGradient +=
                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                    pixelBuffer[byteOffset + sourceData.Stride]) / derivative;


                    if (blueGradient + greenGradient + redGradient > threshold)
                    { exceedsThreshold = true; }
                    else
                    {
                        byteOffset -= 2;


                        blueGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                                pixelBuffer[byteOffset + 4]);
                        byteOffset++;


                        greenGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                                 pixelBuffer[byteOffset + 4]);
                        byteOffset++;


                        redGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                               pixelBuffer[byteOffset + 4]);


                        if (blueGradient + greenGradient + redGradient > threshold)
                        { exceedsThreshold = true; }
                        else
                        {
                            byteOffset -= 2;


                            blueGradient =
                            Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                            pixelBuffer[byteOffset + sourceData.Stride]);


                            byteOffset++;


                            greenGradient =
                            Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                            pixelBuffer[byteOffset + sourceData.Stride]);


                            byteOffset++;


                            redGradient =
                            Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                            pixelBuffer[byteOffset + sourceData.Stride]);


                            if (blueGradient + greenGradient +
                                      redGradient > threshold)
                            { exceedsThreshold = true; }
                            else
                            {
                                byteOffset -= 2;


                                blueGradient =
                                Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] -
                                pixelBuffer[byteOffset + 4 + sourceData.Stride]) / derivative;


                                blueGradient +=
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] -
                                pixelBuffer[byteOffset + sourceData.Stride - 4]) / derivative;


                                byteOffset++;


                                greenGradient =
                                Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] -
                                pixelBuffer[byteOffset + 4 + sourceData.Stride]) / derivative;


                                greenGradient +=
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] -
                                pixelBuffer[byteOffset + sourceData.Stride - 4]) / derivative;


                                byteOffset++;


                                redGradient =
                                Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] -
                                pixelBuffer[byteOffset + 4 + sourceData.Stride]) / derivative;


                                redGradient +=
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] -
                                pixelBuffer[byteOffset + sourceData.Stride - 4]) / derivative;


                                if (blueGradient + greenGradient + redGradient > threshold)
                                { exceedsThreshold = true; }
                                else
                                { exceedsThreshold = false; }
                            }
                        }
                    }


                    byteOffset -= 2;


                    if (exceedsThreshold)
                    {
                        if (filterType == EdgeFilterType.EdgeDetectMono)
                        {
                            blue = green = red = 255;
                        }
                        else if (filterType == EdgeFilterType.EdgeDetectGradient)
                        {
                            blue = blueGradient * blueFactor;
                            green = greenGradient * greenFactor;
                            red = redGradient * redFactor;
                        }
                        else if (filterType == EdgeFilterType.Sharpen)
                        {
                            blue = pixelBuffer[byteOffset] * blueFactor;
                            green = pixelBuffer[byteOffset + 1] * greenFactor;
                            red = pixelBuffer[byteOffset + 2] * redFactor;
                        }
                        else if (filterType == EdgeFilterType.SharpenGradient)
                        {
                            blue = pixelBuffer[byteOffset] + blueGradient * blueFactor;
                            green = pixelBuffer[byteOffset + 1] + greenGradient * greenFactor;
                            red = pixelBuffer[byteOffset + 2] + redGradient * redFactor;
                        }
                    }
                    else
                    {
                        if (filterType == EdgeFilterType.EdgeDetectMono ||
                            filterType == EdgeFilterType.EdgeDetectGradient)
                        {
                            blue = green = red = 0;
                        }
                        else if (filterType == EdgeFilterType.Sharpen ||
                                 filterType == EdgeFilterType.SharpenGradient)
                        {
                            blue = pixelBuffer[byteOffset];
                            green = pixelBuffer[byteOffset + 1];
                            red = pixelBuffer[byteOffset + 2];
                        }
                    }


                    blue = (blue > 255 ? 255 :
                           (blue < 0 ? 0 :
                            blue));


                    green = (green > 255 ? 255 :
                            (green < 0 ? 0 :
                             green));


                    red = (red > 255 ? 255 :
                          (red < 0 ? 0 :
                           red));


                    resultBuffer[byteOffset] = (byte)blue;
                    resultBuffer[byteOffset + 1] = (byte)green;
                    resultBuffer[byteOffset + 2] = (byte)red;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);


            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);


            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);


            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        } 
    	
    	
       public enum EdgeFilterType
        {
            None,
            EdgeDetectMono,
            EdgeDetectGradient,
            Sharpen,
            SharpenGradient
        }

        public enum DerivativeLevel
        {
            First = 1,
            Second = 2
        }
        
    	
  
        
        
                public static Bitmap AcikMorfolojiFiltresi(Bitmap kaynakBitmap,
                                                  int matrixSize,
                                                  bool applyBlue = true,
                                                  bool applyGreen = true,
                                                  bool applyRed = true)
        {
            Bitmap resultBitmap = DilateAndErodeFilter(kaynakBitmap, matrixSize,
                                                        MorphologyType.Erosion,
                                               applyBlue, applyGreen, applyRed);

            resultBitmap = DilateAndErodeFilter(resultBitmap, matrixSize,
                                                MorphologyType.Dilation,
                                               applyBlue, applyGreen, applyRed);

            return resultBitmap;
        }

        public static Bitmap KapaliMorfolojiFiltresi(Bitmap kaynakBitmap,
                                                   int matrixSize,
                                                   bool applyBlue = true,
                                                   bool applyGreen = true,
                                                   bool applyRed = true)
        {
            Bitmap resultBitmap = DilateAndErodeFilter(kaynakBitmap, matrixSize,
                                                        MorphologyType.Dilation,
                                                applyBlue, applyGreen, applyRed);

            resultBitmap = DilateAndErodeFilter(resultBitmap, matrixSize,
                                                 MorphologyType.Erosion, 
                                                applyBlue, applyGreen, applyRed);

            return resultBitmap;
        }

        public static Bitmap DilateAndErodeFilter(Bitmap sourceBitmap,
                                                int matrixSize,
                                                MorphologyType morphType,
                                                bool applyBlue = true,
                                                bool applyGreen = true,
                                                bool applyRed = true)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            int filterOffset = (matrixSize - 1) / 2;

            byte morphResetValue = 0;

            if (morphType == MorphologyType.Erosion)
            {
                morphResetValue = 255;
            }

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    int byteOffset = offsetY *
                                     sourceData.Stride +
                                     offsetX * 4;

                    byte blue = morphResetValue;
                    byte green = morphResetValue;
                    byte red = morphResetValue;

                    int calcOffset;
                    if (morphType == MorphologyType.Dilation)
                    {
                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {
                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                (filterY * sourceData.Stride);

                                if (pixelBuffer[calcOffset] > blue)
                                {
                                    blue = pixelBuffer[calcOffset];
                                }

                                if (pixelBuffer[calcOffset + 1] > green)
                                {
                                    green = pixelBuffer[calcOffset + 1];
                                }

                                if (pixelBuffer[calcOffset + 2] > red)
                                {
                                    red = pixelBuffer[calcOffset + 2];
                                }
                            }
                        }
                    }
                    else if (morphType == MorphologyType.Erosion)
                    {
                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {

                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                (filterY * sourceData.Stride);

                                if (pixelBuffer[calcOffset] < blue)
                                {
                                    blue = pixelBuffer[calcOffset];
                                }

                                if (pixelBuffer[calcOffset + 1] < green)
                                {
                                    green = pixelBuffer[calcOffset + 1];
                                }

                                if (pixelBuffer[calcOffset + 2] < red)
                                {
                                    red = pixelBuffer[calcOffset + 2];
                                }
                            }
                        }
                    }

                    if (applyBlue == false)
                    {
                        blue = pixelBuffer[byteOffset];
                    }

                    if (applyGreen == false)
                    {
                        green = pixelBuffer[byteOffset + 1];
                    }

                    if (applyRed == false)
                    {
                        red = pixelBuffer[byteOffset + 2];
                    }

                    resultBuffer[byteOffset] = blue;
                    resultBuffer[byteOffset + 1] = green;
                    resultBuffer[byteOffset + 2] = red;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public enum MorphologyType
        {
            Dilation,
            Erosion
        }
        
        
        
        
        
        
        
        
    	
    }
}
