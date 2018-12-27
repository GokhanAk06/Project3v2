namespace Project3v2
{
    partial class Project3v2
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
            if(disposing && (components != null))
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
            this.chooseFormat = new System.Windows.Forms.ComboBox();
            this.weightText = new System.Windows.Forms.TextBox();
            this.heightText = new System.Windows.Forms.TextBox();
            this.chooseBttn = new System.Windows.Forms.Button();
            this.startBttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseFormat
            // 
            this.chooseFormat.FormattingEnabled = true;
            this.chooseFormat.Items.AddRange(new object[] {
            "4:2:0",
            "4:2:2",
            "4:4:4"});
            this.chooseFormat.Location = new System.Drawing.Point(843, 69);
            this.chooseFormat.Name = "chooseFormat";
            this.chooseFormat.Size = new System.Drawing.Size(121, 21);
            this.chooseFormat.TabIndex = 0;
            // 
            // weightText
            // 
            this.weightText.Location = new System.Drawing.Point(843, 97);
            this.weightText.Name = "weightText";
            this.weightText.Size = new System.Drawing.Size(121, 20);
            this.weightText.TabIndex = 1;
            this.weightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.weightText_KeyPress);
            // 
            // heightText
            // 
            this.heightText.Location = new System.Drawing.Point(843, 124);
            this.heightText.Name = "heightText";
            this.heightText.Size = new System.Drawing.Size(121, 20);
            this.heightText.TabIndex = 2;
            this.heightText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.heightText_KeyPress);
            // 
            // chooseBttn
            // 
            this.chooseBttn.Location = new System.Drawing.Point(843, 208);
            this.chooseBttn.Name = "chooseBttn";
            this.chooseBttn.Size = new System.Drawing.Size(121, 23);
            this.chooseBttn.TabIndex = 3;
            this.chooseBttn.Text = "Choose YUV";
            this.chooseBttn.UseVisualStyleBackColor = true;
            this.chooseBttn.Click += new System.EventHandler(this.chooseBttn_Click);
            // 
            // startBttn
            // 
            this.startBttn.Location = new System.Drawing.Point(843, 238);
            this.startBttn.Name = "startBttn";
            this.startBttn.Size = new System.Drawing.Size(121, 23);
            this.startBttn.TabIndex = 4;
            this.startBttn.Text = "Start";
            this.startBttn.UseVisualStyleBackColor = true;
            this.startBttn.Click += new System.EventHandler(this.startBttn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(769, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "orjinal weight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(771, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "orjinal height";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(738, 680);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(762, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Standardization";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(837, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 34);
            this.label4.TabIndex = 9;
            this.label4.Text = "Options";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(843, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(843, 177);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 11;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(762, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "showing height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(762, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "showing weight";
            // 
            // Project3v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 705);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startBttn);
            this.Controls.Add(this.chooseBttn);
            this.Controls.Add(this.heightText);
            this.Controls.Add(this.weightText);
            this.Controls.Add(this.chooseFormat);
            this.Name = "Project3v2";
            this.Text = "Project3v2";
            this.Load += new System.EventHandler(this.Project3v2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chooseFormat;
        private System.Windows.Forms.TextBox weightText;
        private System.Windows.Forms.TextBox heightText;
        private System.Windows.Forms.Button chooseBttn;
        private System.Windows.Forms.Button startBttn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

