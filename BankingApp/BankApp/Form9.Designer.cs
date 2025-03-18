namespace BankApp
{
    partial class Form9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            this.comConturiExped = new System.Windows.Forms.ComboBox();
            this.cmbcontDest = new System.Windows.Forms.ComboBox();
            this.btnselcntexp = new System.Windows.Forms.Button();
            this.btnIncarca = new System.Windows.Forms.Button();
            this.btnselcntdes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextboxSuma = new System.Windows.Forms.TextBox();
            this.btnTrimite = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comConturiExped
            // 
            this.comConturiExped.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.comConturiExped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comConturiExped.ForeColor = System.Drawing.SystemColors.Info;
            this.comConturiExped.FormattingEnabled = true;
            this.comConturiExped.Location = new System.Drawing.Point(389, 15);
            this.comConturiExped.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comConturiExped.Name = "comConturiExped";
            this.comConturiExped.Size = new System.Drawing.Size(239, 33);
            this.comConturiExped.TabIndex = 0;
            this.comConturiExped.Text = "Conturi Expeditor";
            this.comConturiExped.SelectedIndexChanged += new System.EventHandler(this.comConturiExped_SelectedIndexChanged);
            // 
            // cmbcontDest
            // 
            this.cmbcontDest.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbcontDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcontDest.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbcontDest.FormattingEnabled = true;
            this.cmbcontDest.Location = new System.Drawing.Point(389, 297);
            this.cmbcontDest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbcontDest.Name = "cmbcontDest";
            this.cmbcontDest.Size = new System.Drawing.Size(239, 33);
            this.cmbcontDest.TabIndex = 1;
            this.cmbcontDest.Text = "Conturi Destinatar";
            this.cmbcontDest.SelectedIndexChanged += new System.EventHandler(this.cmbcontDest_SelectedIndexChanged);
            // 
            // btnselcntexp
            // 
            this.btnselcntexp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnselcntexp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselcntexp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnselcntexp.Location = new System.Drawing.Point(389, 75);
            this.btnselcntexp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnselcntexp.Name = "btnselcntexp";
            this.btnselcntexp.Size = new System.Drawing.Size(240, 65);
            this.btnselcntexp.TabIndex = 2;
            this.btnselcntexp.Text = "Selectează Cont Expeditor";
            this.btnselcntexp.UseVisualStyleBackColor = false;
            this.btnselcntexp.Click += new System.EventHandler(this.btnselcntexp_Click);
            // 
            // btnIncarca
            // 
            this.btnIncarca.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIncarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncarca.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnIncarca.Location = new System.Drawing.Point(389, 177);
            this.btnIncarca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIncarca.Name = "btnIncarca";
            this.btnIncarca.Size = new System.Drawing.Size(240, 75);
            this.btnIncarca.TabIndex = 3;
            this.btnIncarca.Text = "Încarcă Conturi Destinatar";
            this.btnIncarca.UseVisualStyleBackColor = false;
            this.btnIncarca.Click += new System.EventHandler(this.btnIncarca_Click);
            // 
            // btnselcntdes
            // 
            this.btnselcntdes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnselcntdes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselcntdes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnselcntdes.Location = new System.Drawing.Point(389, 368);
            this.btnselcntdes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnselcntdes.Name = "btnselcntdes";
            this.btnselcntdes.Size = new System.Drawing.Size(240, 75);
            this.btnselcntdes.TabIndex = 4;
            this.btnselcntdes.Text = "Selectează Cont Destinatar";
            this.btnselcntdes.UseVisualStyleBackColor = false;
            this.btnselcntdes.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label1.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(144, 476);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Introduceți Suma Dorită:";
            // 
            // TextboxSuma
            // 
            this.TextboxSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxSuma.Location = new System.Drawing.Point(496, 476);
            this.TextboxSuma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextboxSuma.Name = "TextboxSuma";
            this.TextboxSuma.Size = new System.Drawing.Size(132, 30);
            this.TextboxSuma.TabIndex = 6;
            // 
            // btnTrimite
            // 
            this.btnTrimite.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrimite.Location = new System.Drawing.Point(681, 476);
            this.btnTrimite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTrimite.Name = "btnTrimite";
            this.btnTrimite.Size = new System.Drawing.Size(212, 63);
            this.btnTrimite.TabIndex = 7;
            this.btnTrimite.Text = "Trimite Banii";
            this.btnTrimite.UseVisualStyleBackColor = true;
            this.btnTrimite.Click += new System.EventHandler(this.btnTrimite_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(16, -22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 228);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnTrimite);
            this.Controls.Add(this.TextboxSuma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnselcntdes);
            this.Controls.Add(this.btnIncarca);
            this.Controls.Add(this.btnselcntexp);
            this.Controls.Add(this.cmbcontDest);
            this.Controls.Add(this.comConturiExped);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form9";
            this.Text = "Transfer Bani";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comConturiExped;
        private System.Windows.Forms.ComboBox cmbcontDest;
        private System.Windows.Forms.Button btnselcntexp;
        private System.Windows.Forms.Button btnIncarca;
        private System.Windows.Forms.Button btnselcntdes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextboxSuma;
        private System.Windows.Forms.Button btnTrimite;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}