namespace KGLaba3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button3 = new Button();
            label4 = new Label();
            label5 = new Label();
            textBox4 = new TextBox();
            Задержка = new Label();
            button4 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            button2 = new Button();
            label5 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.HighlightText;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.HighlightText;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(446, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(400, 400);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.HighlightText;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(884, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(400, 400);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F);
            label1.Location = new Point(12, 430);
            label1.Name = "label1";
            label1.Size = new Size(0, 13);
            label1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F);
            label2.Location = new Point(446, 430);
            label2.Name = "label2";
            label2.Size = new Size(0, 13);
            label2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(884, 430);
            label3.Name = "label3";
            label3.Size = new Size(0, 13);
            label3.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(1325, 425);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Сравнить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer1
            //
            timer1.Enabled = true;
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            //
            // button2
            //
            button2.Location = new Point(1301, 86);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(123, 22);
            button2.TabIndex = 9;
            button2.Text = "Меняем масштаб";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonSetScale_Click;
            //
            // checkBox1
            //
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1301, 20);
            checkBox1.Margin = new Padding(3, 2, 3, 2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(109, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Оси и границы";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox_CheckedOsi;
            //
            // checkBox2
            //
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(1301, 55);
            checkBox2.Margin = new Padding(3, 2, 3, 2);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(57, 19);
            checkBox2.TabIndex = 11;
            checkBox2.Text = "Сетка";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBoxNetX_CheckedChanged;
            //
            // textBox1
            //
            textBox1.Location = new Point(1301, 122);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(110, 23);
            textBox1.TabIndex = 12;
            textBox1.Text = "7";
            //
            // textBox2
            //
            textBox2.Location = new Point(1301, 221);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(110, 23);
            textBox2.TabIndex = 13;
            textBox2.Text = "20";
            //
            // textBox3
            //
            textBox3.Location = new Point(1301, 270);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(110, 23);
            textBox3.TabIndex = 14;
            textBox3.Text = "10";
            //
            // button3
            //
            button3.Location = new Point(1307, 159);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(82, 22);
            button3.TabIndex = 15;
            button3.Text = "Двигаем";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonSetOffset_Click;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(1301, 204);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 16;
            label4.Text = "Сдвиг по Х";
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(1301, 253);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 17;
            label5.Text = "Сдвиг по Y";
            //
            // textBox4
            //
            textBox4.Location = new Point(1300, 314);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(110, 23);
            textBox4.TabIndex = 18;
            textBox4.Text = "20";
            //
            // Задержка
            //
            Задержка.AutoSize = true;
            Задержка.Location = new Point(1301, 297);
            Задержка.Name = "Задержка";
            Задержка.Size = new Size(60, 15);
            Задержка.TabIndex = 19;
            Задержка.Text = "Задержка";
            //
            // button4
            //
            button4.Location = new Point(1318, 341);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(82, 43);
            button4.TabIndex = 20;
            button4.Text = "Изменить скорость";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            //
            // textBox1
            //
            textBox1.Location = new Point(1297, 442);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(38, 23);
            textBox1.TabIndex = 9;
            //
            // textBox2
            //
            textBox2.Location = new Point(1345, 442);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(38, 23);
            textBox2.TabIndex = 10;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(1308, 424);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 11;
            label4.Text = "X";
            //
            // button2
            //
            button2.Location = new Point(1308, 483);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 12;
            button2.Text = "D";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(1358, 424);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 13;
            label5.Text = "Y";
            //
            // textBox3
            //
            textBox3.Location = new Point(1389, 442);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(38, 23);
            textBox3.TabIndex = 14;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Location = new Point(1400, 424);
            label6.Name = "label6";
            label6.Size = new Size(16, 15);
            label6.TabIndex = 15;
            label6.Text = "H";
            //
            // button3
            //
            button3.Location = new Point(1308, 521);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 16;
            button3.Text = "B";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            //
            // button4
            //
            button4.Location = new Point(1308, 562);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 17;
            button4.Text = "R";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            //
            // button5
            //
            button5.Location = new Point(1308, 600);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 18;
            button5.Text = "J";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            //
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1435, 816);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            ClientSize = new Size(1435, 791);
            Controls.Add(button4);
            Controls.Add(Задержка);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private Button button2;
        private Label label5;
        private TextBox textBox3;
        private Label label6;
        private Button button3;
        private Button button4;
        private Button button5;
        private System.Windows.Forms.Timer timer1;
        private Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button3;
        private Label label4;
        private Label label5;
        private TextBox textBox4;
        private Label Задержка;
        private Button button4;
    }
}
