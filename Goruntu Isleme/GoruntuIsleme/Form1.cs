using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;


namespace GoruntuIsleme
{
    public partial class Form1 : Form
    {
    	
    	private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
       
        public static int[] HistogramMatrisiRed = new int[256];
        public static int[] HistogramMatrisiGreen = new int[256];
        public static int[] HistogramMatrisiBlue = new int[256];

        
    	
        public Form1()
        {
            InitializeComponent();
              
        }




        private void button1_Click(object sender, EventArgs e)
        {
        	if(pictureBox1.Image != null)
        	{
        		
        		
        	
            if (comboBox1.SelectedItem.ToString() == "Gri Tonlama")
            {
               pictureBox2.Image= GriTonYap((Bitmap)pictureBox1.Image);

            }

            if (comboBox1.SelectedItem.ToString() == "Parlaklık Değiştir")
            {

                pictureBox2.Image = ParlaklikDegistir((Bitmap)pictureBox1.Image, Convert.ToInt32(numericUpDown1.Text));

            }

            if (comboBox1.SelectedItem.ToString() == "Görüntünün Histogramı")
            {


                Histogram((Bitmap)pictureBox1.Image);

                Form2 f2 = new Form2();
                f2.Show();

            }


            if (comboBox1.SelectedItem.ToString() == "Eşikleme")
            {
            	EsikDegeri =Convert.ToInt32((numericUpDown1.Text));
                pictureBox2.Image = Esikleme((Bitmap)pictureBox1.Image);

            }

            
             if(comboBox1.SelectedItem.ToString() == "Negatif Görüntüleme")
             	pictureBox2.Image= NegatifGoruntuleme((Bitmap)pictureBox1.Image);
             
             
             
             
             if(comboBox1.SelectedItem.ToString() == "Kontrast(Karşıtlık)")
             	FiltreyiUygula(true);
        	
        	 
             
             
             
             if(comboBox1.SelectedItem.ToString() == "Kontrastı Germe")
             {
             	
               pictureBox2.Image= kontrastGer((Bitmap)pictureBox1.Image);
             	
             	
             	Histogram((Bitmap)pictureBox1.Image);

                Form2 f2 = new Form2();
                f2.Text = "Orjinal resmin histogramı";
                f2.Show();

                
                Histogram((Bitmap)pictureBox2.Image);

                Form2 f3 = new Form2();
                f3.Text = "Yeni resmin histogramı";
                f3.Show();
                
             }
        	
        	 if(comboBox1.SelectedItem.ToString() == "Histogram Eşitleme(Dengeleme)")
            	
        	 {
        	 	

        	 	Histogram((Bitmap)pictureBox1.Image);

                Form2 f2 = new Form2();
                f2.Text = "Orjinal resmin histogramı";
                f2.Show();
                
                	
                pictureBox2.Image= histogramEsitleme((Bitmap)pictureBox1.Image);

                
                Histogram((Bitmap)pictureBox2.Image);

                Form2 f3 = new Form2();
                f3.Text = "Yeni resmin histogramı";
                f3.Show();
        	 	
        	 }
             
        	 
        	 
        	         	
        	 if(comboBox1.SelectedItem.ToString() == "Filtreleme(Yüksek)" &&comboBox2.SelectedItem.ToString() == "Gradyent" )
            { 
               
                 ApplyFilterGradyent(true);
                 
            if(pictureBox2.Image != null)
        	{
        	pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        	}

            }
        	 
        	 
        	 
        	 ComboBox2SelectedIndexChanged(sender,e);
        	
        	 
        	 
        	if (comboBox1.SelectedItem.ToString() == "Şekil Bulma")            
            {
                pictureBox2.Image = ShapeChecker.ProcessImage((Bitmap)pictureBox1.Image);
            }
         


        	if (comboBox1.SelectedItem.ToString() == "Hareket(Motion)")
            {
               MotionForm motionForm = new MotionForm();
               motionForm.Show();
            }
          
        

        	if (comboBox1.SelectedItem.ToString() == "Zincir Kod")
            {
            //burada form4 matrisine resmin datası gönderilecek.
            var form4 = new Form4();
            form4.Show();
            }
        	 
        	 
             
        	}
        		
        	
        }

        
        
        
           void Button2Click(object sender, EventArgs e)
        {
           	OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Bir Resim Dosyası Seçin.";
            ofd.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();

                previewBitmap = originalBitmap.KareKanvasaKopyala(pictureBox1.Width);
                pictureBox1.Image = previewBitmap;

                if((comboBox1.SelectedItem.ToString() != "Kontrast(Karşıtlık)") || comboBox1.SelectedItem.ToString() ==null)
                {
                	FiltreyiUygula(false);
                	pictureBox2.Image = null;
                }
                
                else
                {
                	FiltreyiUygula(true);
                	
                }
                
                textBox2.Text = ofd.FileName;
            }

           
        }
        
        
      
        
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        	if (comboBox1.SelectedItem.ToString() == "Parlaklık Değiştir" )
            {
               numericUpDown1.Visible = true;
               label4.Text= "Parlaklık(rakam)";
                label4.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString() == "Eşikleme")
            {
               numericUpDown1.Visible = true;
               label4.Text = "Eşik Değeri(rakam)";
                label4.Visible = true;
            }
            else
            {
                numericUpDown1.Visible=false;
                label4.Visible=false;
            }
            
            
            

            if (comboBox1.SelectedItem.ToString() == "Görüntünün Histogramı")
                button1.Text = "Histogramı Göster";

            else
                button1.Text = "Uygula";
            
            if (comboBox1.SelectedItem.ToString() == "Kontrast(Karşıtlık)")
            {
            	trackBar1.Minimum = -100;
            	trackBar1.Maximum = 100;
            	label5.Text = "Kontrast";
            	trackBar1.Visible =true;
            	label6.Visible = true;
            	label5.Visible =true;
            	
            }

            else
                {
            	
            	trackBar1.Visible =false;
            	label6.Visible =false;
            	label5.Visible =false;
               }
            
            if(comboBox1.SelectedItem.ToString()=="Filtreleme(Alçak)")
            {
            	comboBox2.Items.Clear();
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.GaussFiltreleme3x3);
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.GaussFiltreleme5x5);

            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.Ortalama3x3);
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.Ortalama5x5);
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.Ortalama7x7);
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.Ortalama9x9);
            
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.Medyan3x3);
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.Medyan5x5);
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.Medyan7x7);
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.Medyan9x9);
            comboBox2.Items.Add(ResimIsleme.FiltrelemeTipleri.Medyan11x11);

            comboBox2.SelectedIndex = 0;
            	comboBox2.Visible =true;
            	comboBox2.SelectedIndex = 0;
            	ComboBox2SelectedIndexChanged(sender,e);
            }
            else if(comboBox1.SelectedItem.ToString() == "Filtreleme(Yüksek)")
            {
            	comboBox2.Items.Clear();
            	comboBox2.Items.Add("Laplacian 3x3");
            	comboBox2.Items.Add("Laplacian 3x3 Grayscale");
            	comboBox2.Items.Add("Laplacian 5x5");
            	comboBox2.Items.Add("Laplacian 5x5 Grayscale");
            	comboBox2.Items.Add("Sobel 3x3");
            	comboBox2.Items.Add("Sobel 3x3 Grayscale");
            	comboBox2.Items.Add("Prewitt");
            	comboBox2.Items.Add("Prewitt Grayscale");
            	comboBox2.Items.Add("Gradyent");
            	
            	comboBox2.Visible =true;
            	comboBox2.SelectedIndex = 0;
            	ComboBox2SelectedIndexChanged(sender,e);
            	
            }
            else
            	if(comboBox1.SelectedItem.ToString() == "Geometrik İşlemler")
            {
            	comboBox2.Items.Clear();
            	comboBox2.Items.Add("Açılı Döndürme");
            	comboBox2.Items.Add("Ters Çevirme");
            	comboBox2.Items.Add("Aynalama");
            	comboBox2.Items.Add("Öteleme");
            	comboBox2.Items.Add("Zoom");
            	
            	comboBox2.Visible =true;
            	comboBox2.SelectedIndex = 0;
            	ComboBox2SelectedIndexChanged(sender,e);
            	
            }
            
            else
            	if(comboBox1.SelectedItem.ToString() == "Morfoloji")
            {
            	comboBox2.Items.Clear();
            	comboBox2.Items.Add("Dilate");
            	comboBox2.Items.Add("Erode");
            	comboBox2.Items.Add("Open");
            	comboBox2.Items.Add("Closed");
            	
            	comboBox2.Visible =true;
            	comboBox2.SelectedIndex = 0;
            	ComboBox2SelectedIndexChanged(sender,e);
            	            	
            }
            else
              comboBox2.Visible = false;
                    	
            
            
            
            if (comboBox1.SelectedItem.ToString() == "Şekil Bulma")
            {
                pictureBox2.Image = ShapeChecker.ProcessImage((Bitmap)pictureBox1.Image);
            }

            
            
          if (comboBox1.SelectedItem.ToString() == "Hareket(Motion)")
            {
               MotionForm motionForm = new MotionForm();
               motionForm.Show();
            }
          
           if (comboBox1.SelectedItem.ToString() == "Zincir Kod")
            {
            //burada form4 matrisine resmin datası gönderilecek.
            var form4 = new Form4();
            form4.Show();
            }
          
         }


       

        public static Bitmap GriTonYap(Bitmap original)
        {
            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //original resimden pikseli al
                    Color originalColor = original.GetPixel(i, j);

                    //pikselin gri tonlamasını yap
                    int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59)
                        + (originalColor.B * .11)) ;

                    //color nesenesini oluştur
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);

                    //yeni resmin pikselini gri tonlu versiyonuna ata
                    newBitmap.SetPixel(i, j, newColor);
                }
            }

            return newBitmap;
        }




        public static Bitmap ParlaklikDegistir(Bitmap original, int parlaklik)
        {

            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //original resimden pikseli al
                    Color originalColor = original.GetPixel(i, j);

                    //color nesenesini oluştur
                    Color newColor = Color.FromArgb(Math.Abs(((int)originalColor.R + parlaklik))%256, Math.Abs(((int)originalColor.G + parlaklik))%256, Math.Abs(((int)originalColor.B + parlaklik))%256);

                    //yeni resmin pikselini gri tonlu versiyonuna ata
                    newBitmap.SetPixel(i, j, newColor);
                }
            }

            return newBitmap;
        }
  
        
  
        public void Histogram(Bitmap original)
        {
            
               for(int n=0;n<256;n++)
             	{
            		HistogramMatrisiRed[n] = 0;
             		HistogramMatrisiGreen[n] = 0;
             		HistogramMatrisiBlue[n] = 0;
             	}
            
            
            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
             

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                 
                    Color originalColor = original.GetPixel(i, j);

                    HistogramMatrisiRed[(int)originalColor.R]++;
                    HistogramMatrisiGreen[(int)originalColor.G]++;
                    HistogramMatrisiBlue[(int)originalColor.B]++;

                            
                    

                }
            }


        }
        
        
        
        

public static int EsikDegeri;    
    
public static Bitmap Esikleme(Bitmap original)
        {
            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //original resimden pikseli al
                    Color originalColor = original.GetPixel(i, j);

                    //pikselin gri tonlamasını yap
                    int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59)
                        + (originalColor.B * .11)) ;

                    if(grayScale<EsikDegeri)
                    	grayScale=0;
                    else
                    	grayScale=255;
                   
                    //color nesenesini oluştur
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);

                    //yeni resmin pikselini gri tonlu versiyonuna ata
                    newBitmap.SetPixel(i, j, newColor);
                }
            }

            return newBitmap;
        }
        

        
     
     
     public static Bitmap NegatifGoruntuleme(Bitmap original)
        {

            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //original resimden pikseli al
                    Color originalColor = original.GetPixel(i, j);

                    //color nesenesini oluştur
                    Color newColor = Color.FromArgb(Math.Abs((256-(int)originalColor.R))%256, Math.Abs((256-(int)originalColor.G ))%256, Math.Abs((256-(int)originalColor.B ))%256);

                    //yeni resmin pikselini gri tonlu versiyonuna ata
                    newBitmap.SetPixel(i, j, newColor);
                }
            }

            return newBitmap;
        }

     
     
     

     private void FiltreyiUygula(bool preview)
        {
            if (previewBitmap == null)
            {
                return;
            }

            if (preview == true)
            {
                pictureBox2.Image = previewBitmap.Kontrast(trackBar1.Value);
            }
            else
            {
                resultBitmap = originalBitmap.Kontrast(trackBar1.Value);
            }
        }
     
             
     
     
     
     
     private void FiltreyiUygula1(bool preview)
        {
            if (previewBitmap == null || comboBox2.SelectedIndex == -1)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
                selectedSource = previewBitmap;
                
            }
            else
            {
                selectedSource = originalBitmap;
            }

            if (selectedSource != null)
            {
                ResimIsleme.FiltrelemeTipleri filtrelemeTipleri =
                    ((ResimIsleme.FiltrelemeTipleri)comboBox2.SelectedItem);

                bitmapResult = selectedSource.ResimBulanikFiltresi(filtrelemeTipleri);
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    pictureBox2.Image = bitmapResult;
                }
                else
                {
                    resultBitmap = bitmapResult;
                }
            }
        }

     
     
     private void FiltreyiUygula2(bool preview)
        {
            if (previewBitmap == null || comboBox2.SelectedIndex == -1)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
                selectedSource = previewBitmap;
            }
            else
            {
                selectedSource = originalBitmap;
            }

            if (selectedSource != null)
            {
                if (comboBox2.SelectedItem.ToString() == "None")
                {
                    bitmapResult = selectedSource;
                }
                else if (comboBox2.SelectedItem.ToString() == "Laplacian 3x3")
                {
                    bitmapResult = selectedSource.Laplacian3x3Filter(false);
                }
                else if (comboBox2.SelectedItem.ToString() == "Laplacian 3x3 Grayscale")
                {
                    bitmapResult = selectedSource.Laplacian3x3Filter(true);
                }
                else if (comboBox2.SelectedItem.ToString() == "Laplacian 5x5")
                {
                    bitmapResult = selectedSource.Laplacian5x5Filter(false);
                }
                else if (comboBox2.SelectedItem.ToString() == "Laplacian 5x5 Grayscale")
                {
                    bitmapResult = selectedSource.Laplacian5x5Filter(true);
                }

                else if (comboBox2.SelectedItem.ToString() == "Sobel 3x3")
                {
                    bitmapResult = selectedSource.Sobel3x3Filter(false);
                }
                else if (comboBox2.SelectedItem.ToString() == "Sobel 3x3 Grayscale")
                {
                    bitmapResult = selectedSource.Sobel3x3Filter();
                }
                else if (comboBox2.SelectedItem.ToString() == "Prewitt")
                {
                    bitmapResult = selectedSource.PrewittFilter(false);
                }
                else if (comboBox2.SelectedItem.ToString() == "Prewitt Grayscale")
                {
                    bitmapResult = selectedSource.PrewittFilter();
                }

            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    pictureBox2.Image = bitmapResult;
                }
                else
                {
                    resultBitmap = bitmapResult;
                }
            }
        }
 
        
        
        
        
        
        
        void TrackBar1Scroll(object sender, EventArgs e)
        {
        	if(comboBox1.SelectedItem.ToString() == "Kontrast(Karşıtlık)")
        	{
        	   label6.Text = trackBar1.Value.ToString();
               FiltreyiUygula(true);
        	}
        	
        	
        	if((comboBox1.SelectedItem.ToString() == "Geometrik İşlemler") && (comboBox2.SelectedItem.ToString() == "Zoom"))
        	{
        		label6.Text =trackBar1.Value.ToString() + "X";
        		if(pictureBox1.Image != null && trackBar1.Value>0)
        		   pictureBox2.Image = Yakinlastirma((Bitmap)pictureBox1.Image,trackBar1.Value);
        		
        		if(pictureBox1.Image != null && trackBar1.Value<0)
        		{
        			pictureBox2.Image = Uzaklastirma((Bitmap)pictureBox1.Image,Math.Abs(trackBar1.Value));
        			//pictureBox2.Image = new Bitmap(Uzaklastirma((Bitmap)pictureBox1.Image,Math.Abs(trackBar1.Value)), new Size((int)pictureBox1.Size.Width/Math.Abs(trackBar1.Value),(int) pictureBox1.Size.Height/Math.Abs(trackBar1.Value)));
        			//pictureBox2.Size = new Size(pictureBox2.Size.Width/Math.Abs(trackBar1.Value), pictureBox2.Size.Height/Math.Abs(trackBar1.Value));
        		}
        		    
        	}
        	
        }
        
        
        
        
        
        
        void Form1Load(object sender, EventArgs e)
        {
        	comboBox1.SelectedIndex = 0;

        	
        	
        	
        	          comboBox3.Items.Clear();
                      comboBox3.Items.Add(ResimIsleme3.EdgeFilterType.None);              // Muhakkak EdgefilterType tipinde eklenmeli yoksa tür dönüşümnde hata çıkarır
                      comboBox3.Items.Add(ResimIsleme3.EdgeFilterType.EdgeDetectMono);

                      comboBox3.Items.Add(ResimIsleme3.EdgeFilterType.EdgeDetectGradient);
                      comboBox3.Items.Add(ResimIsleme3.EdgeFilterType.Sharpen);
                      comboBox3.Items.Add(ResimIsleme3.EdgeFilterType.SharpenGradient);
        			  comboBox3.SelectedIndex = 0;
        	
        }
        
        
        
        
        void Button3Click(object sender, EventArgs e)
        {
           

            if (pictureBox2.Image != null)
            {
                	SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Resim Dosyasını Kaydedin.";
            sfd.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png";
            sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    pictureBox2.Image.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();

                    resultBitmap = null;
                }
            }        	
        }
        
        
        
        
 
       
        
        
         public static Bitmap kontrastGer(Bitmap original)
        {

           Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            byte min=255, max=0;
            
            for(int i = 0; i < original.Height; i++)
                {
                    for(int j = 0; j < original.Width; j++)
                            {
                               Color originalColor = original.GetPixel(j, i);

                               if (min > originalColor.R) min = originalColor.R;
                               if (min > originalColor.G) min = originalColor.R;
                               if (min > originalColor.B) min = originalColor.B;
                               if (max < originalColor.R) max = originalColor.R;
                               if (max < originalColor.G) max = originalColor.G;
                               if (max < originalColor.B) max = originalColor.B;
    
                            }
                   }
            
            
             for(int i = 0; i < original.Height; i++)
                   {
                        for(int j = 0; j < original.Width; j++)
                             {
                        	    Color originalColor = original.GetPixel(j, i);
                        	    byte r = (byte)((originalColor.R - min) * 255 / (max - min));
                        	    byte g = (byte)((originalColor.G - min) * 255 / (max - min));
                        	    byte b = (byte)((originalColor.B - min) * 255 / (max - min));
 
                                newBitmap.SetPixel(j, i, Color.FromArgb(r,g,b));
                              }
                   }
          
          
          

            return newBitmap;
        }





         public Bitmap histogramEsitleme(Bitmap original)
        {
            Bitmap renderedImage = new Bitmap(original.Width, original.Height);

            uint pixels = (uint)original.Height * (uint)original.Width;
            decimal Const = 255 /(decimal)pixels;

            int x, y, R, G, B;
           
            Histogram(original);

           
            for (int r = 1; r < 256; r++)
            {
                HistogramMatrisiRed[r] = HistogramMatrisiRed[r] + HistogramMatrisiRed[r - 1];
                HistogramMatrisiGreen[r] = HistogramMatrisiGreen[r] + HistogramMatrisiGreen[r - 1];
                HistogramMatrisiBlue[r] = HistogramMatrisiBlue[r] + HistogramMatrisiBlue[r - 1];
            }

            for (y = 0; y < original.Height; y++)
            {
                for (x = 0; x < original.Width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);

                    R = (int)((decimal)HistogramMatrisiRed[pixelColor.R] * Const);
                    G = (int)((decimal)HistogramMatrisiGreen[pixelColor.G] * Const);
                    B = (int)((decimal)HistogramMatrisiBlue[pixelColor.B] * Const);
                   
                    Color newColor = Color.FromArgb(R, G, B);
                    renderedImage.SetPixel(x, y, newColor);
                }
            }


            
            
            return renderedImage;
        }
        
        
        
        
        
        void NumericUpDown1ValueChanged(object sender, EventArgs e)
        {
        	button1_Click(sender,e);
        }
        
    
    
        
        void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
        {
        	if(comboBox1.SelectedItem.ToString()== "Filtreleme(Alçak)" && pictureBox1.Image != null)
        	{
        		
        			FiltreyiUygula1(true);
        			
        		
        	}
        	if(comboBox1.SelectedItem.ToString()== "Filtreleme(Yüksek)")
        	{
        		pictureBox3.Visible = true;
        		label7.Visible = true;
        		
        		if(comboBox2.SelectedItem.ToString() == "Gradyent" && pictureBox1.Image != null)
        		{

                      groupBox1.Visible = true;


            	      ComboBox3SelectedIndexChanged(sender,e);
        			
        			   ApplyFilterGradyent(true);
        	          if(pictureBox2.Image != null)
        	              {
        	                  pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        	              }
        		}
        		else if(comboBox2.SelectedItem.ToString() != "Gradyent")
        		
        		{
        			     groupBox1.Visible = false;
        		         FiltreyiUygula2(true);
        		        if(pictureBox1.Image != null)
        		           {
        			           pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        			            groupBox1.Visible = false;
        		           }
        		
        		}
        		
        	}
        	else
        	{
        		pictureBox3.Visible =false;
        		label7.Visible = false;
        	}
        	
        	
        	if((comboBox1.SelectedItem.ToString() == "Geometrik İşlemler") && (comboBox2.SelectedItem.ToString() == "Ters Çevirme") && pictureBox1.Image != null)
        	   {
        	   	pictureBox2.Image = TersCevirme((Bitmap)pictureBox1.Image);
        	   }
        	
        	 if ((comboBox1.SelectedItem.ToString() == "Geometrik İşlemler") && (comboBox2.SelectedItem.ToString() == "Aynalama") && pictureBox1.Image != null)
            {
               pictureBox2.Image= Aynalama((Bitmap)pictureBox1.Image);

            }
        	
        	 
        	 
        	 
        	 if ((comboBox2.SelectedItem != null) && comboBox2.SelectedItem.ToString() == "Zoom" && pictureBox1.Image != null)
            {
        	  	trackBar1.Maximum = 10;
        	  	trackBar1.Minimum = -10;
            	trackBar1.Visible =true;
            	
            	label5.Text = "Zoom";
            	label6.Text = trackBar1.Value.ToString();
            	label6.Visible = true;
            	label5.Visible =true;
            	
            	
            }

            else
                {
            	
            	trackBar1.Visible =false;
            	label6.Visible =false;
            	label5.Visible =false;
               }
            
            
            
            
            if(comboBox1.SelectedItem.ToString() == "Geometrik İşlemler" && comboBox2.SelectedItem.ToString() == "Zoom" && pictureBox1.Image != null)
            {
            	if(trackBar1.Value != 0)
            	pictureBox2.Image= Yakinlastirma((Bitmap)pictureBox1.Image,trackBar1.Value);
            	
            	
            }
        	
            
             if(comboBox1.SelectedItem.ToString() == "Geometrik İşlemler" && comboBox2.SelectedItem.ToString() == "Öteleme" && pictureBox1.Image != null)
            {
            	trackBar6.Maximum=pictureBox1.Width;
            	trackBar7.Minimum=-(int)pictureBox1.Height;
            	trackBar7.Maximum = 0;
            	
            	trackBar6.Visible = true;
            	trackBar7.Visible = true;
            	TrackBar6Scroll(sender, e);
            	
            }
             else
             {
             	trackBar6.Visible = false;
            	trackBar7.Visible = false;
             }
             
             
             
             
          if(comboBox1.SelectedItem.ToString() == "Geometrik İşlemler" && comboBox2.SelectedItem.ToString() == "Açılı Döndürme" && pictureBox1.Image != null)
            {
            	numericUpDown2.Visible = true;
            	checkBox1.Visible = true;
            	label12.Visible = true;
            	pictureBox2.Image= ResimCevir((Bitmap)pictureBox1.Image,(float)numericUpDown2.Value,checkBox1.Checked?true:false);
            	
            }
          else
          {
          	numericUpDown2.Visible =false;
          	checkBox1.Visible = false;
          	label12.Visible = false;
          }
        	
        	
          if(comboBox1.SelectedItem.ToString() == "Morfoloji" && comboBox2.SelectedItem.ToString() == "Dilate" && pictureBox1.Image != null)
          {
          	pictureBox2.Image = ResimIsleme3.DilateAndErodeFilter((Bitmap)pictureBox1.Image, 3,ResimIsleme3.MorphologyType.Dilation);
          }
          
          
          
          if(comboBox1.SelectedItem.ToString() == "Morfoloji" && comboBox2.SelectedItem.ToString() == "Erode" && pictureBox1.Image != null)
          {
          	pictureBox2.Image = ResimIsleme3.DilateAndErodeFilter((Bitmap)pictureBox1.Image, 3,ResimIsleme3.MorphologyType.Erosion);
          }
          
         
          
          if(comboBox1.SelectedItem.ToString() == "Morfoloji" && comboBox2.SelectedItem.ToString() == "Open" && pictureBox1.Image != null)
          {
          	pictureBox2.Image = ResimIsleme3.AcikMorfolojiFiltresi((Bitmap)pictureBox1.Image, 3);
          }
          
         if(comboBox1.SelectedItem.ToString() == "Morfoloji" && comboBox2.SelectedItem.ToString() == "Closed" && pictureBox1.Image != null)
          {
          	pictureBox2.Image = ResimIsleme3.KapaliMorfolojiFiltresi((Bitmap)pictureBox1.Image, 3);
          }
          
        }
        
        
        
        
        
        
        
        
        
        
        public static Bitmap ResimEkle(Bitmap original1, Bitmap original2)
        {
            
            Bitmap newBitmap = new Bitmap(original1.Width, original1.Height);
            

            for (int i = 0; i < original1.Width; i++)
            {
                for (int j = 0; j < original1.Height; j++)
                {
                    //original resimden pikseli al
                    Color original1Color = original1.GetPixel(i, j);
                    Color original2Color = original2.GetPixel(i, j);
 
                   
                    //color nesenesini oluştur
                    Color newColor = Color.FromArgb((original1Color.R + original2Color.R)%256, (original1Color.G + original2Color.G)%256, (original1Color.B + original2Color.B)%256);

                    //yeni resmi ata
                    newBitmap.SetPixel(i, j, newColor);
                }
            }

            return newBitmap;
        }
        
        
        
        
       private void ApplyFilterGradyent(bool preview)
        {
            if (previewBitmap == null || comboBox3.SelectedIndex == -1)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
            	selectedSource = (Bitmap)pictureBox1.Image;
               
            }
            else
            {
                selectedSource = originalBitmap;
                
            }

            if (selectedSource != null)
            {
                
            	ResimIsleme3.EdgeFilterType filterType =  ((ResimIsleme3.EdgeFilterType)comboBox3.SelectedItem);
                ResimIsleme3.DerivativeLevel derivitaveLevel = (radioButton1.Checked ?  ResimIsleme3.DerivativeLevel.First : ResimIsleme3.DerivativeLevel.Second);

                if (filterType == ResimIsleme3.EdgeFilterType.None)
                {
                    bitmapResult = selectedSource;
                }
                else
                {
                    bitmapResult = selectedSource.GradyentFiltreleme(
                                   filterType, derivitaveLevel,
                                   trackBar3.Value / 100.0f,
                                   trackBar4.Value / 100.0f,
                                   trackBar5.Value / 100.0f,
                                   (byte)trackBar2.Value);
                }
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                   pictureBox2.Image = bitmapResult;
                }
                else
                {
                    resultBitmap = bitmapResult;
                    
                }
            }
            
                
         }

            
       
       
       
          
   
        
        void ComboBox3SelectedIndexChanged(object sender, EventArgs e)
        {
        	
        	label8.Text = "Eşik " + trackBar2.Value.ToString();
        	label9.Text = "Kırmızı " + trackBar3.Value.ToString();
        	label10.Text = "Yeşi " + trackBar4.Value.ToString() ;
            label11.Text = "Mavi " + trackBar5.Value.ToString() ;

            
        	ApplyFilterGradyent(true);
        	if(pictureBox2.Image != null)
        	{
        	pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        	}
        }
        
    
        
        
         public static Bitmap TersCevirme(Bitmap original)
        {
            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j =0; j< original.Height ; j++)
                {
                    //original resimden pikseli al
                    Color originalColor = original.GetPixel(i, j);

                    //color nesenesini oluştur
                    Color newColor = Color.FromArgb(originalColor.R, originalColor.G,originalColor.B);

                    //yeni resmin pikselini gri tonlu versiyonuna ata
                    newBitmap.SetPixel(i, original.Height-1-j, newColor);
                }
            }

            return newBitmap;
        }
        
         
         
         
         
         
           public static Bitmap Aynalama(Bitmap original)
        {
            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //original resimden pikseli al
                    Color originalColor = original.GetPixel(i, j);

                    //color nesenesini oluştur
                    Color newColor = Color.FromArgb(originalColor.R, originalColor.G,originalColor.B);

                    //yeni resmin pikselini gri tonlu versiyonuna ata
                    newBitmap.SetPixel(original.Width-1-i,j, newColor);
                }
            }

            return newBitmap;
        }
        
           
           
           
           
            public static Bitmap Yakinlastirma(Bitmap original, int fark)
        {
            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width/fark; i++)
            {
                for (int j = 0; j < original.Height/fark; j++)
                {
                    //original resimden pikseli al
                    Color originalColor = original.GetPixel(i, j);

                    //color nesenesini oluştur
                    Color newColor = Color.FromArgb(originalColor.R, originalColor.G,originalColor.B);

                    //yeni resmin pikselini gri tonlu versiyonuna ata
                    for(int m = 0 ;m<fark;m++)
                    	for(int n=0; n<fark; n++)
                          newBitmap.SetPixel(i*fark+m,j*fark+n, newColor);
                }
            }
            

            return newBitmap;
        }
        
           
       
       public static Bitmap Uzaklastirma(Bitmap original, int fark)
        {
            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width/fark, original.Height/fark);
           

            for (int i = 0; i < original.Width; i += fark)
            {
                for (int j = 0; j <original.Height; j += fark)
                {
                    int Rdegeri = 0, Gdegeri=0, Bdegeri=0;
                	 
                	for(int m = 0 ;m<fark;m++)
                	{
                		for(int n=0; n<fark; n++)
                        {
                    	Color originalColor = original.GetPixel(i+m,j+n);
                    	Rdegeri+=originalColor.R;
                    	Gdegeri+=originalColor.G;
                    	Bdegeri+=originalColor.B;
                        }
                	}
                		
                	Color newColor = Color.FromArgb(Rdegeri/(fark*fark), Gdegeri/(fark*fark),Bdegeri/(fark*fark));
                	newBitmap.SetPixel(i/fark,j/fark, newColor);

                }
            }
            
         return newBitmap;
         
            //return Bitmap Resim = new Bitmap(newBitmap, new Size((int)original.Width/fark, (int)original.Height/fark));
           
        }
        
        
        
        
        public static Bitmap Oteleme(Bitmap original,int otelemex, int otelemey)
        {
            //origimal resmi ile aynı ölçüde boş bir bitmap yap
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width-otelemex; i++)
            {
                for (int j = 0; j < original.Height-otelemey; j++)
                {
                    //original resimden pikseli al
                    Color originalColor = original.GetPixel(i, j);

                    //yeni resmin pikselini gri tonlu versiyonuna ata
                    newBitmap.SetPixel(i+otelemex, j+otelemey, originalColor);
                }
            }

            return newBitmap;
        }

        
        
        
        
        
        
        void TrackBar6Scroll(object sender, EventArgs e)
        {
        	pictureBox2.Image = Oteleme((Bitmap)pictureBox1.Image,trackBar6.Value,Math.Abs(trackBar7.Value));
        }
        
        void TrackBar7Scroll(object sender, EventArgs e)
        {
        	pictureBox2.Image = Oteleme((Bitmap)pictureBox1.Image,trackBar6.Value,Math.Abs(trackBar7.Value));
        }
        
        
        
        
        
      public static Bitmap ResimCevir(Image image, float angle, bool sigdir)
		{
      	    
			if(image == null)
				throw new ArgumentNullException("image");

			const double pi2 = Math.PI / 2.0;

			double oldWidth = (double) image.Width;
			double oldHeight = (double) image.Height;

			double theta = ((double) angle) * Math.PI / 180.0;
			double locked_theta = theta;


			while( locked_theta < 0.0 )
				locked_theta += 2 * Math.PI;

			double newWidth, newHeight; 
			int nWidth, nHeight;


			double adjacentTop, oppositeTop;
			double adjacentBottom, oppositeBottom;


			if( (locked_theta >= 0.0 && locked_theta < pi2) ||
				(locked_theta >= Math.PI && locked_theta < (Math.PI + pi2) ) )
			{
				adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
				oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth;

				adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
				oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
			}
			else
			{
				adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
				oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight;

				adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
				oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
			}
			
			newWidth = adjacentTop + oppositeBottom;
			newHeight = adjacentBottom + oppositeTop;

			nWidth = (int) Math.Ceiling(newWidth);
			nHeight = (int) Math.Ceiling(newHeight);

			Bitmap rotatedBmp = new Bitmap(nWidth, nHeight);

			using(Graphics g = Graphics.FromImage(rotatedBmp))
			{

				Point [] points;

				if( locked_theta >= 0.0 && locked_theta < pi2 )
				{
					points = new Point[] { 
											 new Point( (int) oppositeBottom, 0 ), 
											 new Point( nWidth, (int) oppositeTop ),
											 new Point( 0, (int) adjacentBottom )
										 };

				}
				else if( locked_theta >= pi2 && locked_theta < Math.PI )
				{
					points = new Point[] { 
											 new Point( nWidth, (int) oppositeTop ),
											 new Point( (int) adjacentTop, nHeight ),
											 new Point( (int) oppositeBottom, 0 )						 
										 };
				}
				else if( locked_theta >= Math.PI && locked_theta < (Math.PI + pi2) )
				{
					points = new Point[] { 
											 new Point( (int) adjacentTop, nHeight ), 
											 new Point( 0, (int) adjacentBottom ),
											 new Point( nWidth, (int) oppositeTop )
										 };
				}
				else
				{
					points = new Point[] { 
											 new Point( 0, (int) adjacentBottom ), 
											 new Point( (int) oppositeBottom, 0 ),
											 new Point( (int) adjacentTop, nHeight )		
										 };
				}

				g.DrawImage(image, points);
			}

			
			float genislik,yukseklik;
			if(sigdir)
			{
				float kat = (float)(oldWidth/newWidth)<(float)(oldHeight/newHeight)? (float)(oldWidth/newWidth) : (float)(oldHeight/newHeight);
				genislik= (kat*(float)newWidth);
				yukseklik = (kat*(float)newHeight);
			}
			else
			{
				 genislik= (float)nWidth;
				 yukseklik = (float)nHeight;
			}
			Bitmap donmusResim = new Bitmap(rotatedBmp, new Size((int)genislik, (int)yukseklik));
			//return objBitmap;
			
			return donmusResim;
		}
        
       
         
        
        void NumericUpDown2ValueChanged(object sender, EventArgs e)
        {
          if( numericUpDown2.Value > 359.9m )
			{
				numericUpDown2.Value = 0;
				return ;
			}

			if( numericUpDown2.Value < 0.0m )
			{
				numericUpDown2.Value = 359;
				return ;
			}
			
			
			ComboBox2SelectedIndexChanged(sender,e);
			
			
			
        }
        
        void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
               ComboBox2SelectedIndexChanged(sender,e);      	
        }
        
        
 
        
        void TrackBar2Scroll(object sender, EventArgs e)
        {
        	label8.Text = "Eşik " + trackBar2.Value.ToString();
        	        	ApplyFilterGradyent(true);
        	if(pictureBox2.Image != null)
        	{
        	pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        	}
        }
        
        void TrackBar3Scroll(object sender, EventArgs e)
        {
        	label9.Text = "Kırmızı " + trackBar3.Value.ToString();

        	ApplyFilterGradyent(true);
        	if(pictureBox2.Image != null)
        	{
        	pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        	}
        }
        
        void TrackBar4Scroll(object sender, EventArgs e)
        {
        	label10.Text = "Yeşi " + trackBar4.Value.ToString() ;

        	ApplyFilterGradyent(true);
        	if(pictureBox2.Image != null)
        	{
        	pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        	}
        }
        
        void TrackBar5Scroll(object sender, EventArgs e)
        {
            label11.Text = "Mavi " + trackBar5.Value.ToString() ;

        	ApplyFilterGradyent(true);
        	if(pictureBox2.Image != null)
        	{
        	pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        	}
        	
        }
        
        void RadioButton1CheckedChanged(object sender, EventArgs e)
        {
        	ApplyFilterGradyent(true);
        	if(pictureBox2.Image != null)
        	{
        	pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        	}       	
        }
        
        void RadioButton2CheckedChanged(object sender, EventArgs e)
        {
        	ApplyFilterGradyent(true);
        	if(pictureBox2.Image != null)
        	{
        	pictureBox3.Image = ResimEkle((Bitmap)pictureBox1.Image, (Bitmap)pictureBox2.Image);
        	}        	
        }
    }
}
   

