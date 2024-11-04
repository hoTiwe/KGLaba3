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
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
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
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1304, 474);
            label6.Name = "label6";
            label6.Size = new Size(14, 15);
            label6.TabIndex = 21;
            label6.Text = "X";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1344, 475);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 22;
            label7.Text = "Y";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1380, 475);
            label8.Name = "label8";
            label8.Size = new Size(16, 15);
            label8.TabIndex = 23;
            label8.Text = "H";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1304, 492);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(29, 23);
            textBox5.TabIndex = 24;
            textBox5.Text = "20";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(1338, 492);
            textBox6.Margin = new Padding(3, 2, 3, 2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(29, 23);
            textBox6.TabIndex = 25;
            textBox6.Text = "20";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(1372, 492);
            textBox7.Margin = new Padding(3, 2, 3, 2);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(29, 23);
            textBox7.TabIndex = 26;
            textBox7.Text = "20";
            // 
            // button5
            // 
            button5.Location = new Point(1335, 553);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(32, 28);
            button5.TabIndex = 27;
            button5.Text = "B";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button3_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1335, 585);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(32, 31);
            button6.TabIndex = 28;
            button6.Text = "R";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button5_Click;
            // 
            // button7
            // 
            button7.Location = new Point(1335, 523);
            button7.Margin = new Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new Size(32, 26);
            button7.TabIndex = 29;
            button7.Text = "D";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button2_Click;
            // 
            // button8
            // 
            button8.Location = new Point(1335, 620);
            button8.Margin = new Padding(3, 2, 3, 2);
            button8.Name = "button8";
            button8.Size = new Size(32, 24);
            button8.TabIndex = 30;
            button8.Text = "J";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button6_Click;
            // 
            // scrollPanelA
            // 
            scrollPanelA.AutoScroll = true;
            scrollPanelA.Controls.Add(displayTextBoxA);
            scrollPanelA.Location = new Point(12, 425);
            scrollPanelA.Name = "scrollPanelA";
            scrollPanelA.Size = new Size(400, 300);
            scrollPanelA.TabIndex = 21;
            // 
            // displayTextBoxA
            // 
            displayTextBoxA.Location = new Point(0, 0);
            displayTextBoxA.Margin = new Padding(3, 2, 3, 2);
            displayTextBoxA.Multiline = true;
            displayTextBoxA.Name = "displayTextBoxA";
            displayTextBoxA.ScrollBars = ScrollBars.Vertical;
            displayTextBoxA.Size = new Size(389, 488);
            displayTextBoxA.TabIndex = 0;
            // 
            // scrollPanelB
            // 
            scrollPanelB.AutoScroll = true;
            scrollPanelB.Controls.Add(displayTextBoxB);
            scrollPanelB.Location = new Point(446, 425);
            scrollPanelB.Name = "scrollPanelB";
            scrollPanelB.Size = new Size(400, 300);
            scrollPanelB.TabIndex = 21;
            // 
            // displayTextBoxB
            // 
            displayTextBoxB.Location = new Point(0, 0);
            displayTextBoxB.Margin = new Padding(3, 2, 3, 2);
            displayTextBoxB.Multiline = true;
            displayTextBoxB.Name = "displayTextBoxB";
            displayTextBoxB.ScrollBars = ScrollBars.Vertical;
            displayTextBoxB.Size = new Size(394, 488);
            displayTextBoxB.TabIndex = 0;
            // 
            // scrollPanelC
            // 
            scrollPanelC.AutoScroll = true;
            scrollPanelC.Controls.Add(displayTextBoxC);
            scrollPanelC.Location = new Point(884, 425);
            scrollPanelC.Name = "scrollPanelC";
            scrollPanelC.Size = new Size(400, 300);
            scrollPanelC.TabIndex = 21;
            // 
            // displayTextBoxC
            // 
            displayTextBoxC.Location = new Point(0, 0);
            displayTextBoxC.Margin = new Padding(3, 2, 3, 2);
            displayTextBoxC.Multiline = true;
            displayTextBoxC.Name = "displayTextBoxC";
            displayTextBoxC.ScrollBars = ScrollBars.Vertical;
            displayTextBoxC.Size = new Size(394, 488);
            displayTextBoxC.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1435, 791);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
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
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}
