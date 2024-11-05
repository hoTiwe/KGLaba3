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
            scrollPanelA = new Panel();
            displayTextBoxA = new TextBox();
            scrollPanelB = new Panel();
            displayTextBoxB = new TextBox();
            scrollPanelC = new Panel();
            displayTextBoxC = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            scrollPanelA.SuspendLayout();
            scrollPanelB.SuspendLayout();
            scrollPanelC.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.HighlightText;
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox1.Location = new Point(14, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(457, 533);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.HighlightText;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox2.Location = new Point(510, 16);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(457, 533);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.HighlightText;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox3.Location = new Point(1010, 16);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(457, 533);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F);
            label1.Location = new Point(14, 573);
            label1.Name = "label1";
            label1.Size = new Size(0, 19);
            label1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F);
            label2.Location = new Point(510, 573);
            label2.Name = "label2";
            label2.Size = new Size(0, 19);
            label2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(1010, 573);
            label3.Name = "label3";
            label3.Size = new Size(0, 19);
            label3.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(1514, 567);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
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
            button2.Location = new Point(1487, 115);
            button2.Name = "button2";
            button2.Size = new Size(141, 29);
            button2.TabIndex = 9;
            button2.Text = "Меняем масштаб";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonSetScale_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1487, 27);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(136, 24);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Оси и границы";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox_CheckedOsi;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(1487, 73);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(69, 24);
            checkBox2.TabIndex = 11;
            checkBox2.Text = "Сетка";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBoxNetX_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1487, 163);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 12;
            textBox1.Text = "7";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1487, 295);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 13;
            textBox2.Text = "20";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1487, 360);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 14;
            textBox3.Text = "10";
            // 
            // button3
            // 
            button3.Location = new Point(1494, 212);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 15;
            button3.Text = "Двигаем";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonSetOffset_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1487, 272);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 16;
            label4.Text = "Сдвиг по Х";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1487, 337);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 17;
            label5.Text = "Сдвиг по Y";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1486, 419);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 18;
            textBox4.Text = "20";
            // 
            // Задержка
            // 
            Задержка.AutoSize = true;
            Задержка.Location = new Point(1487, 396);
            Задержка.Name = "Задержка";
            Задержка.Size = new Size(76, 20);
            Задержка.TabIndex = 19;
            Задержка.Text = "Задержка";
            // 
            // button4
            // 
            button4.Location = new Point(1506, 455);
            button4.Name = "button4";
            button4.Size = new Size(94, 57);
            button4.TabIndex = 20;
            button4.Text = "Изменить скорость";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // scrollPanelA
            // 
            scrollPanelA.AutoScroll = true;
            scrollPanelA.Controls.Add(displayTextBoxA);
            scrollPanelA.Location = new Point(14, 567);
            scrollPanelA.Margin = new Padding(3, 4, 3, 4);
            scrollPanelA.Name = "scrollPanelA";
            scrollPanelA.Size = new Size(457, 400);
            scrollPanelA.TabIndex = 21;
            // 
            // displayTextBoxA
            // 
            displayTextBoxA.Location = new Point(0, 0);
            displayTextBoxA.Multiline = true;
            displayTextBoxA.Name = "displayTextBoxA";
            displayTextBoxA.ScrollBars = ScrollBars.Vertical;
            displayTextBoxA.Size = new Size(444, 650);
            displayTextBoxA.TabIndex = 0;
            // 
            // scrollPanelB
            // 
            scrollPanelB.AutoScroll = true;
            scrollPanelB.Controls.Add(displayTextBoxB);
            scrollPanelB.Location = new Point(510, 567);
            scrollPanelB.Margin = new Padding(3, 4, 3, 4);
            scrollPanelB.Name = "scrollPanelB";
            scrollPanelB.Size = new Size(457, 400);
            scrollPanelB.TabIndex = 21;
            // 
            // displayTextBoxB
            // 
            displayTextBoxB.Location = new Point(0, 0);
            displayTextBoxB.Multiline = true;
            displayTextBoxB.Name = "displayTextBoxB";
            displayTextBoxB.ScrollBars = ScrollBars.Vertical;
            displayTextBoxB.Size = new Size(450, 650);
            displayTextBoxB.TabIndex = 0;
            // 
            // scrollPanelC
            // 
            scrollPanelC.AutoScroll = true;
            scrollPanelC.Controls.Add(displayTextBoxC);
            scrollPanelC.Location = new Point(1010, 567);
            scrollPanelC.Margin = new Padding(3, 4, 3, 4);
            scrollPanelC.Name = "scrollPanelC";
            scrollPanelC.Size = new Size(457, 400);
            scrollPanelC.TabIndex = 21;
            // 
            // displayTextBoxC
            // 
            displayTextBoxC.Location = new Point(0, 0);
            displayTextBoxC.Multiline = true;
            displayTextBoxC.Name = "displayTextBoxC";
            displayTextBoxC.ScrollBars = ScrollBars.Vertical;
            displayTextBoxC.Size = new Size(450, 650);
            displayTextBoxC.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1640, 1055);
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
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(scrollPanelA);
            Controls.Add(scrollPanelB);
            Controls.Add(scrollPanelC);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            scrollPanelA.ResumeLayout(false);
            scrollPanelA.PerformLayout();
            scrollPanelB.ResumeLayout(false);
            scrollPanelB.PerformLayout();
            scrollPanelC.ResumeLayout(false);
            scrollPanelC.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel scrollPanelA;
        private Panel scrollPanelB;
        private Panel scrollPanelC;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
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
        private TextBox displayTextBoxA;
        private TextBox displayTextBoxB;
        private TextBox displayTextBoxC;
        private Label Задержка;
        private Button button4;
    }
}
