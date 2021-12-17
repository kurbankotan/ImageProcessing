namespace GoruntuIsleme
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        	this.comboBox1 = new System.Windows.Forms.ComboBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.pictureBox2 = new System.Windows.Forms.PictureBox();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.button2 = new System.Windows.Forms.Button();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.trackBar1 = new System.Windows.Forms.TrackBar();
        	this.label5 = new System.Windows.Forms.Label();
        	this.label6 = new System.Windows.Forms.Label();
        	this.button3 = new System.Windows.Forms.Button();
        	this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        	this.comboBox2 = new System.Windows.Forms.ComboBox();
        	this.label7 = new System.Windows.Forms.Label();
        	this.pictureBox3 = new System.Windows.Forms.PictureBox();
        	this.label11 = new System.Windows.Forms.Label();
        	this.trackBar5 = new System.Windows.Forms.TrackBar();
        	this.label10 = new System.Windows.Forms.Label();
        	this.trackBar4 = new System.Windows.Forms.TrackBar();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.label9 = new System.Windows.Forms.Label();
        	this.trackBar3 = new System.Windows.Forms.TrackBar();
        	this.label8 = new System.Windows.Forms.Label();
        	this.trackBar2 = new System.Windows.Forms.TrackBar();
        	this.radioButton1 = new System.Windows.Forms.RadioButton();
        	this.comboBox3 = new System.Windows.Forms.ComboBox();
        	this.radioButton2 = new System.Windows.Forms.RadioButton();
        	this.trackBar6 = new System.Windows.Forms.TrackBar();
        	this.trackBar7 = new System.Windows.Forms.TrackBar();
        	this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
        	this.checkBox1 = new System.Windows.Forms.CheckBox();
        	this.label12 = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// comboBox1
        	// 
        	this.comboBox1.FormattingEnabled = true;
        	this.comboBox1.Items.AddRange(new object[] {
        	        	        	"Gri Tonlama",
        	        	        	"Parlaklık Değiştir",
        	        	        	"Görüntünün Histogramı",
        	        	        	"Eşikleme",
        	        	        	"Negatif Görüntüleme",
        	        	        	"Kontrast(Karşıtlık)",
        	        	        	"Kontrastı Germe",
        	        	        	"Histogram Eşitleme(Dengeleme)",
        	        	        	"Filtreleme(Alçak)",
        	        	        	"Filtreleme(Yüksek)",
        	        	        	"Geometrik İşlemler",
        	        	        	"Morfoloji",
        	        	        	"Zincir Kod",
        	        	        	"Hareket(Motion)",
        	        	        	"Şekil Bulma"});
        	this.comboBox1.Location = new System.Drawing.Point(319, 25);
        	this.comboBox1.Name = "comboBox1";
        	this.comboBox1.Size = new System.Drawing.Size(126, 21);
        	this.comboBox1.TabIndex = 2;
        	this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(316, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(42, 13);
        	this.label1.TabIndex = 3;
        	this.label1.Text = "İşlemler";
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(319, 54);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(121, 23);
        	this.button1.TabIndex = 4;
        	this.button1.Text = "Uygula";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 229);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(55, 13);
        	this.label2.TabIndex = 5;
        	this.label2.Text = "Asıl Resim";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(425, 229);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(76, 13);
        	this.label3.TabIndex = 6;
        	this.label3.Text = "İşlenmiş Resim";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(451, 6);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(85, 13);
        	this.label4.TabIndex = 8;
        	this.label4.Text = "Parlaklık (rakam)";
        	this.label4.Visible = false;
        	// 
        	// pictureBox2
        	// 
        	this.pictureBox2.BackColor = System.Drawing.Color.Silver;
        	this.pictureBox2.Location = new System.Drawing.Point(425, 245);
        	this.pictureBox2.Name = "pictureBox2";
        	this.pictureBox2.Size = new System.Drawing.Size(359, 269);
        	this.pictureBox2.TabIndex = 1;
        	this.pictureBox2.TabStop = false;
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.BackColor = System.Drawing.Color.Silver;
        	this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
        	this.pictureBox1.Location = new System.Drawing.Point(12, 245);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(359, 269);
        	this.pictureBox1.TabIndex = 0;
        	this.pictureBox1.TabStop = false;
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(12, 12);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(75, 23);
        	this.button2.TabIndex = 9;
        	this.button2.Text = "Resim Seç";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.Button2Click);
        	// 
        	// textBox2
        	// 
        	this.textBox2.Location = new System.Drawing.Point(12, 54);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(296, 20);
        	this.textBox2.TabIndex = 10;
        	// 
        	// trackBar1
        	// 
        	this.trackBar1.Location = new System.Drawing.Point(446, 67);
        	this.trackBar1.Maximum = 100;
        	this.trackBar1.Minimum = -100;
        	this.trackBar1.Name = "trackBar1";
        	this.trackBar1.Size = new System.Drawing.Size(284, 45);
        	this.trackBar1.TabIndex = 11;
        	this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
        	// 
        	// label5
        	// 
        	this.label5.Location = new System.Drawing.Point(567, 50);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(46, 15);
        	this.label5.TabIndex = 12;
        	this.label5.Text = "Kontrast";
        	// 
        	// label6
        	// 
        	this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        	this.label6.Location = new System.Drawing.Point(575, 98);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(56, 23);
        	this.label6.TabIndex = 13;
        	this.label6.Text = "0";
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(319, 83);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(121, 23);
        	this.button3.TabIndex = 14;
        	this.button3.Text = "Resmi Kaydet";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.Button3Click);
        	// 
        	// numericUpDown1
        	// 
        	this.numericUpDown1.Location = new System.Drawing.Point(451, 26);
        	this.numericUpDown1.Maximum = new decimal(new int[] {
        	        	        	1000,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.numericUpDown1.Minimum = new decimal(new int[] {
        	        	        	1000,
        	        	        	0,
        	        	        	0,
        	        	        	-2147483648});
        	this.numericUpDown1.Name = "numericUpDown1";
        	this.numericUpDown1.Size = new System.Drawing.Size(103, 20);
        	this.numericUpDown1.TabIndex = 15;
        	this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1ValueChanged);
        	// 
        	// comboBox2
        	// 
        	this.comboBox2.FormattingEnabled = true;
        	this.comboBox2.Location = new System.Drawing.Point(451, 26);
        	this.comboBox2.Name = "comboBox2";
        	this.comboBox2.Size = new System.Drawing.Size(130, 21);
        	this.comboBox2.TabIndex = 16;
        	this.comboBox2.Visible = false;
        	this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2SelectedIndexChanged);
        	// 
        	// label7
        	// 
        	this.label7.AutoSize = true;
        	this.label7.Location = new System.Drawing.Point(820, 229);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(81, 13);
        	this.label7.TabIndex = 18;
        	this.label7.Text = "Eklenmiş Resim";
        	this.label7.Visible = false;
        	// 
        	// pictureBox3
        	// 
        	this.pictureBox3.BackColor = System.Drawing.Color.Silver;
        	this.pictureBox3.Location = new System.Drawing.Point(820, 245);
        	this.pictureBox3.Name = "pictureBox3";
        	this.pictureBox3.Size = new System.Drawing.Size(359, 269);
        	this.pictureBox3.TabIndex = 17;
        	this.pictureBox3.TabStop = false;
        	this.pictureBox3.Visible = false;
        	// 
        	// label11
        	// 
        	this.label11.Location = new System.Drawing.Point(143, 163);
        	this.label11.Name = "label11";
        	this.label11.Size = new System.Drawing.Size(62, 15);
        	this.label11.TabIndex = 28;
        	this.label11.Text = "Mavi    ";
        	// 
        	// trackBar5
        	// 
        	this.trackBar5.Location = new System.Drawing.Point(235, 155);
        	this.trackBar5.Maximum = 300;
        	this.trackBar5.Name = "trackBar5";
        	this.trackBar5.Size = new System.Drawing.Size(148, 45);
        	this.trackBar5.TabIndex = 27;
        	this.trackBar5.Value = 150;
        	this.trackBar5.Scroll += new System.EventHandler(this.TrackBar5Scroll);
        	// 
        	// label10
        	// 
        	this.label10.Location = new System.Drawing.Point(143, 113);
        	this.label10.Name = "label10";
        	this.label10.Size = new System.Drawing.Size(62, 15);
        	this.label10.TabIndex = 26;
        	this.label10.Text = "Yeşil   ";
        	// 
        	// trackBar4
        	// 
        	this.trackBar4.Location = new System.Drawing.Point(235, 104);
        	this.trackBar4.Maximum = 300;
        	this.trackBar4.Name = "trackBar4";
        	this.trackBar4.Size = new System.Drawing.Size(148, 45);
        	this.trackBar4.TabIndex = 25;
        	this.trackBar4.Value = 150;
        	this.trackBar4.Scroll += new System.EventHandler(this.TrackBar4Scroll);
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.label11);
        	this.groupBox1.Controls.Add(this.trackBar5);
        	this.groupBox1.Controls.Add(this.label10);
        	this.groupBox1.Controls.Add(this.trackBar4);
        	this.groupBox1.Controls.Add(this.label9);
        	this.groupBox1.Controls.Add(this.trackBar3);
        	this.groupBox1.Controls.Add(this.label8);
        	this.groupBox1.Controls.Add(this.trackBar2);
        	this.groupBox1.Controls.Add(this.radioButton1);
        	this.groupBox1.Controls.Add(this.comboBox3);
        	this.groupBox1.Controls.Add(this.radioButton2);
        	this.groupBox1.Location = new System.Drawing.Point(809, 12);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(394, 207);
        	this.groupBox1.TabIndex = 21;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Gradyent";
        	this.groupBox1.Visible = false;
        	// 
        	// label9
        	// 
        	this.label9.Location = new System.Drawing.Point(143, 72);
        	this.label9.Name = "label9";
        	this.label9.Size = new System.Drawing.Size(62, 15);
        	this.label9.TabIndex = 24;
        	this.label9.Text = "Kırmızı ";
        	// 
        	// trackBar3
        	// 
        	this.trackBar3.Location = new System.Drawing.Point(235, 67);
        	this.trackBar3.Maximum = 300;
        	this.trackBar3.Name = "trackBar3";
        	this.trackBar3.Size = new System.Drawing.Size(148, 45);
        	this.trackBar3.TabIndex = 23;
        	this.trackBar3.Value = 150;
        	this.trackBar3.Scroll += new System.EventHandler(this.TrackBar3Scroll);
        	// 
        	// label8
        	// 
        	this.label8.Location = new System.Drawing.Point(143, 24);
        	this.label8.Name = "label8";
        	this.label8.Size = new System.Drawing.Size(62, 15);
        	this.label8.TabIndex = 22;
        	this.label8.Text = "Eşik    ";
        	// 
        	// trackBar2
        	// 
        	this.trackBar2.Location = new System.Drawing.Point(235, 16);
        	this.trackBar2.Maximum = 200;
        	this.trackBar2.Name = "trackBar2";
        	this.trackBar2.Size = new System.Drawing.Size(148, 45);
        	this.trackBar2.TabIndex = 21;
        	this.trackBar2.Value = 100;
        	this.trackBar2.Scroll += new System.EventHandler(this.TrackBar2Scroll);
        	// 
        	// radioButton1
        	// 
        	this.radioButton1.Checked = true;
        	this.radioButton1.Location = new System.Drawing.Point(16, 88);
        	this.radioButton1.Name = "radioButton1";
        	this.radioButton1.Size = new System.Drawing.Size(104, 24);
        	this.radioButton1.TabIndex = 0;
        	this.radioButton1.TabStop = true;
        	this.radioButton1.Text = "Birinci Türevi";
        	this.radioButton1.UseVisualStyleBackColor = true;
        	this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
        	// 
        	// comboBox3
        	// 
        	this.comboBox3.FormattingEnabled = true;
        	this.comboBox3.Location = new System.Drawing.Point(6, 28);
        	this.comboBox3.Name = "comboBox3";
        	this.comboBox3.Size = new System.Drawing.Size(114, 21);
        	this.comboBox3.TabIndex = 20;
        	this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.ComboBox3SelectedIndexChanged);
        	// 
        	// radioButton2
        	// 
        	this.radioButton2.Location = new System.Drawing.Point(16, 111);
        	this.radioButton2.Name = "radioButton2";
        	this.radioButton2.Size = new System.Drawing.Size(104, 21);
        	this.radioButton2.TabIndex = 1;
        	this.radioButton2.Text = "İkinci Türevi";
        	this.radioButton2.UseVisualStyleBackColor = true;
        	this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2CheckedChanged);
        	// 
        	// trackBar6
        	// 
        	this.trackBar6.Location = new System.Drawing.Point(403, 179);
        	this.trackBar6.Maximum = 200;
        	this.trackBar6.Name = "trackBar6";
        	this.trackBar6.Size = new System.Drawing.Size(371, 45);
        	this.trackBar6.TabIndex = 22;
        	this.trackBar6.Visible = false;
        	this.trackBar6.Scroll += new System.EventHandler(this.TrackBar6Scroll);
        	// 
        	// trackBar7
        	// 
        	this.trackBar7.Location = new System.Drawing.Point(374, 245);
        	this.trackBar7.Maximum = 200;
        	this.trackBar7.Name = "trackBar7";
        	this.trackBar7.Orientation = System.Windows.Forms.Orientation.Vertical;
        	this.trackBar7.Size = new System.Drawing.Size(45, 269);
        	this.trackBar7.TabIndex = 23;
        	this.trackBar7.Visible = false;
        	this.trackBar7.Scroll += new System.EventHandler(this.TrackBar7Scroll);
        	// 
        	// numericUpDown2
        	// 
        	this.numericUpDown2.Location = new System.Drawing.Point(587, 27);
        	this.numericUpDown2.Maximum = new decimal(new int[] {
        	        	        	360,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.numericUpDown2.Minimum = new decimal(new int[] {
        	        	        	1,
        	        	        	0,
        	        	        	0,
        	        	        	-2147483648});
        	this.numericUpDown2.Name = "numericUpDown2";
        	this.numericUpDown2.Size = new System.Drawing.Size(98, 20);
        	this.numericUpDown2.TabIndex = 24;
        	this.numericUpDown2.Visible = false;
        	this.numericUpDown2.ValueChanged += new System.EventHandler(this.NumericUpDown2ValueChanged);
        	// 
        	// checkBox1
        	// 
        	this.checkBox1.Location = new System.Drawing.Point(692, 27);
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.Size = new System.Drawing.Size(104, 24);
        	this.checkBox1.TabIndex = 25;
        	this.checkBox1.Text = "Resmi Sığdır";
        	this.checkBox1.UseVisualStyleBackColor = true;
        	this.checkBox1.Visible = false;
        	this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
        	// 
        	// label12
        	// 
        	this.label12.Location = new System.Drawing.Point(587, 4);
        	this.label12.Name = "label12";
        	this.label12.Size = new System.Drawing.Size(98, 18);
        	this.label12.TabIndex = 26;
        	this.label12.Text = "Açı";
        	this.label12.Visible = false;
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(1226, 533);
        	this.Controls.Add(this.label12);
        	this.Controls.Add(this.checkBox1);
        	this.Controls.Add(this.numericUpDown2);
        	this.Controls.Add(this.trackBar7);
        	this.Controls.Add(this.trackBar6);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.label7);
        	this.Controls.Add(this.pictureBox3);
        	this.Controls.Add(this.comboBox2);
        	this.Controls.Add(this.numericUpDown1);
        	this.Controls.Add(this.button3);
        	this.Controls.Add(this.label6);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.trackBar1);
        	this.Controls.Add(this.textBox2);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.comboBox1);
        	this.Controls.Add(this.pictureBox2);
        	this.Controls.Add(this.pictureBox1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Name = "Form1";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Sayisal Görüntü İşleme";
        	this.Load += new System.EventHandler(this.Form1Load);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

