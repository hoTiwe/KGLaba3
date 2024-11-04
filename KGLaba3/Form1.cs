using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace KGLaba3
{
    public partial class Form1 : Form
    {
        List<Pixel> pixelsA = new List<Pixel>();
        List<Pixel> pixelsB = new List<Pixel>();
        List<Pixel> pixelsC = new List<Pixel>();

        int scale = 7;
        int offsetX = 20, offsetY = -10;
        int coeffNet = 0;

        double totalTimeA = 0;
        double totalTimeB = 0;
        double totalTimeC = 0;

        Graphics graphicsA;
        Bitmap bitmapA;
        Graphics graphicsB;
        Bitmap bitmapB;
        Graphics graphicsC;
        Bitmap bitmapC;

        int paintedA = 0;
        int paintedB = 0;
        int paintedC = 0;
        bool needInit = true;

        public Form1()
        {
            InitializeComponent();
            getPixelsB();
            getPixelsC();
            timer1.Start();
        }

        void paintPixel(Graphics grap, Pixel pixel)
        {
            SolidBrush color = new SolidBrush(pixel.color);
            grap.FillRectangle(color, (pixel.x + offsetX) * scale, 400 - (pixel.y - offsetY) * scale, 1 * scale - coeffNet, 1 * scale - coeffNet);
        }

        void clearPictureBox(Graphics grap, PictureBox p)
        {
            grap.FillRectangle(new SolidBrush(Color.White), 0, 0, p.Width, p.Height);
        }

        void paintX(Graphics graphics)
        {
            int y = pictureBox1.Height + (offsetY + 1) * scale - 1;
            graphics.FillRectangle(new SolidBrush(Color.Black), 0, y, pictureBox1.Width, 2);
        }

        void paintY(Graphics graphics)
        {
            int x = (offsetX + 1) * scale - 1;
            graphics.FillRectangle(new SolidBrush(Color.Black), x, 0, 2, pictureBox1.Height);
        }

        private void buttonSetScale_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int newScale))
            {
                Console.WriteLine(newScale);

                scale = newScale;
                clearPictureBox(graphicsA, pictureBox1);
                paintedA = 0;
                clearPictureBox(graphicsB, pictureBox2);
                paintedB = 0;
                clearPictureBox(graphicsC, pictureBox3);
                paintedC = 0;
            }
            else
            {
                MessageBox.Show("Please enter a valid integer for scale.");
            }
        }
        private void buttonSetOffset_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox2.Text, out int newOffsetX) &&
                int.TryParse(textBox3.Text, out int newOffsetY))
            {
                offsetX = newOffsetX;
                offsetY = -newOffsetY;

                clearPictureBox(graphicsA, pictureBox1);
                paintedA = 0;
                clearPictureBox(graphicsB, pictureBox2);
                paintedB = 0;
                clearPictureBox(graphicsC, pictureBox3);
                paintedC = 0;
            }
            else
            {
                MessageBox.Show("Please enter valid integers for offsets.");
            }
        }

        private void checkBox_CheckedOsi(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                paintX(graphicsA);
                paintY(graphicsA);
                paintX(graphicsB);
                paintY(graphicsB);
                paintX(graphicsC);
                paintY(graphicsC);
            }
            else
            {
                clearPictureBox(graphicsA, pictureBox1);
                paintedA = 0;
                clearPictureBox(graphicsB, pictureBox2);
                paintedB = 0;
                clearPictureBox(graphicsC, pictureBox3);
                paintedC = 0;
            }
        }

        private void checkBoxNetX_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                coeffNet = 1;
                Console.WriteLine("Ñåòêà âêëþ÷åíà");
                clearPictureBox(graphicsA, pictureBox1);
                paintedA = 0;
                clearPictureBox(graphicsB, pictureBox2);
                paintedB = 0;
                clearPictureBox(graphicsC, pictureBox3);
                paintedC = 0;
            }
            else
            {
                coeffNet = 0;
                Console.WriteLine("Ñåòêà off");
                clearPictureBox(graphicsA, pictureBox1);
                paintedA = 0;
                clearPictureBox(graphicsB, pictureBox2);
                paintedB = 0;
                clearPictureBox(graphicsC, pictureBox3);
                paintedC = 0;
            }
        }

        int CalculateDiff(Bitmap b1, Bitmap b2, bool needChange = false)
        {
            int k = 0;
            for (int i = 0; i < pictureBox1.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Width; j++)
                {
                    Color c1 = b1.GetPixel(i, j);
                    Color c2 = b2.GetPixel(i, j);
                    if (c1 != c2)
                    {
                        if (needChange)
                        {
                            c1 = Color.FromArgb(255, 255 - c1.R, 255 - c1.G, 255 - c1.B);
                            c2 = (c2.A == 0) ? Color.Black : Color.FromArgb(255, 255 - c2.R, 255 - c2.G, 255 - c2.B);
                            graphicsA.FillRectangle(new SolidBrush(c1), i, j, 1, 1);
                            graphicsB.FillRectangle(new SolidBrush(c2), i, j, 1, 1);
                        }
                        k++;
                    }
                }
            }
            return k;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (needInit)
            {
                bitmapA = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                graphicsA = Graphics.FromImage(bitmapA);

                bitmapB = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                graphicsB = Graphics.FromImage(bitmapB);

                bitmapC = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                graphicsC = Graphics.FromImage(bitmapC);
                needInit = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (paintedA < pixelsA.Count) paintPixel(graphicsA, pixelsA[paintedA++]);
            if (paintedB < pixelsB.Count) paintPixel(graphicsB, pixelsB[paintedB++]);
            if (paintedC < pixelsC.Count) paintPixel(graphicsC, pixelsC[paintedC++]);

            pictureBox1.Image = bitmapA;
            pictureBox2.Image = bitmapB;
            pictureBox3.Image = bitmapC;
        }

        List<Pixel> PaintLineMain(int x1, int y1, int x2, int y2, Color color)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            HashSet<Pixel> pixels = new HashSet<Pixel>();
            double r2 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            double p = Math.Atan2(y2 - y1, x2 - x1);

            for (int i = 0; i <= 100; i++)
            {
                double r = r2 * i / 100;

                double x = Math.Round(x1 + r * Math.Cos(p), 0);
                double y = Math.Round(y1 + r * Math.Sin(p), 0);

                pixels.Add(new Pixel((int)x, (int)y, color));
            }
            double[] polar = ToPolar(x1, y1);

            stopwatch.Stop();
            label1.Text += $"Прямая ({Math.Round(polar[0], 2)}; {Math.Round(polar[1], 2)}) - ({Math.Round(r2, 2)}; {Math.Round(p, 2)})  ({x1}; {y1}) - ({x2}; {y2}): {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeA += stopwatch.Elapsed.TotalMilliseconds;

            return pixels.ToList();
        }


        List<Pixel> PaintLineCDA(int x1, int y1, int x2, int y2, Color color)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Pixel> pixels = new List<Pixel>();

            int length = Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            double dx = (double)(x2 - x1) / length;
            double dy = (double)(y2 - y1) / length;
            double x = x1;
            double y = y1;

            int i = 1;
            while (i <= length)
            {
                pixels.Add(new Pixel((int)Math.Round(x, 0), (int)Math.Round(y, 0), color));
                x += dx;
                y += dy;
                i++;
            }

            stopwatch.Stop();
            label2.Text += $"Прямая с координатами ({x1}; {y1}) - ({x2}; {y2}): {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            double res = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            label2.Text += $"Расстояние = {res}\n";
            totalTimeB += stopwatch.Elapsed.TotalMilliseconds;

            return pixels;
        }

        List<Pixel> PaintLineBrezenthema(int x1, int y1, int x2, int y2, Color color)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Pixel> pixels = new List<Pixel>();
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int x = x1, y = y1;
            int err = dx - dy;

            while (true)
            {
                pixels.Add(new Pixel(x, y, color));

                if (x == x2 && y == y2) break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
                }
            }
            stopwatch.Stop();
            label3.Text += $"Прямая с координатами ({x1}; {y1}) - ({x2}; {y2}): {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeC += stopwatch.Elapsed.TotalMilliseconds;

            return pixels;
        }

        public List<Pixel> FillA(HashSet<Pixel> conture, Pixel seedPixel)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Stack<Pixel> stack = new Stack<Pixel>();
            stack.Push(seedPixel);

            List<Pixel> insidePixels = new List<Pixel>();
            Color color = seedPixel.color;

            while (stack.Count > 0)
            {
                Pixel pixel = stack.Pop();
                int x = pixel.x;
                int y = pixel.y;

                // Пропуск пикселя, если он уже закрашен или является частью контура
                if (conture.Contains(pixel) || insidePixels.Contains(pixel))
                    continue;

                // Ищем левую границу интервала
                int left = x;
                while (!conture.Contains(new Pixel(left, y, color)) && !insidePixels.Contains(new Pixel(left, y, color)))
                {
                    left--;
                }
                left++;

                // Ищем правую границу интервала
                int right = x;
                while (!conture.Contains(new Pixel(right, y, color)) && !insidePixels.Contains(new Pixel(right, y, color)))
                {
                    right++;
                }
                right--;

                // Добавляем пиксели интервала в список закрашиваемых
                for (int i = left; i <= right; i++)
                {
                    Pixel nPixel = new Pixel(i, y, color);
                    insidePixels.Add(nPixel);
                }

                // Проверяем верхний и нижний ряды для интервалов
                for (int i = left; i <= right; i++)
                {
                    // Верхний ряд
                    if (!conture.Contains(new Pixel(i, y - 1, color)) && !insidePixels.Contains(new Pixel(i, y - 1, color)))
                    {
                        stack.Push(new Pixel(i, y - 1, color));
                    }

                    // Нижний ряд
                    if (!conture.Contains(new Pixel(i, y + 1, color)) && !insidePixels.Contains(new Pixel(i, y + 1, color)))
                    {
                        stack.Push(new Pixel(i, y + 1, color));
                    }
                }
            }
            stopwatch.Stop();
            label1.Text += $"Закраска области: {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeA += stopwatch.Elapsed.TotalMilliseconds;

            return insidePixels; // Возвращаем множество точек, которые необходимо закрасить
        }

        public List<Pixel> FillB(HashSet<Pixel> conture, Pixel seedPixel)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var stack = new Stack<Pixel>();
            var filledPixels = new List<Pixel>();
            var targetColor = seedPixel.color;
            var directions = new List<(int, int)> { (1, 0), (0, 1), (-1, 0), (0, -1) };

            stack.Push(seedPixel);

            while (stack.Count > 0)
            {
                var currentPixel = stack.Pop();

                if (filledPixels.Contains(currentPixel)) continue;
                filledPixels.Add(currentPixel);

                foreach (var (dx, dy) in directions)
                {
                    int newX = currentPixel.x + dx;
                    int newY = currentPixel.y + dy;
                    Pixel pixel = new Pixel(newX, newY, targetColor);

                    if (!conture.Contains(pixel) && !filledPixels.Contains(pixel))
                    {
                        stack.Push(pixel);
                    }
                }
            }

            stopwatch.Stop();
            label2.Text += $"Закраска области: {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeB += stopwatch.Elapsed.TotalMilliseconds;

            return filledPixels;
        }

        public List<Pixel> FillC(HashSet<Pixel> contour, Pixel seedPixel)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var stack = new Stack<Pixel>();
            var filledPixels = new HashSet<Pixel>();

            // Затравочный пиксель
            stack.Push(seedPixel);

            // Восьмисвязные направления
            var directions = new List<(int dx, int dy)>
            {
                (1, 0), (0, 1), (-1, 0), (0, -1),   // основные направления
            };

            while (stack.Count > 0)
            {
                var currentPixel = stack.Pop();

                // Пропускаем, если пиксель уже закрашен или является частью контура
                if (filledPixels.Contains(currentPixel) || contour.Contains(currentPixel))
                    continue;

                // Добавляем пиксель в список закрашенных
                filledPixels.Add(currentPixel);

                // Добавляем соседние пиксели по всем 8 направлениям
                foreach (var (dx, dy) in directions)
                {
                    int newX = currentPixel.x + dx;
                    int newY = currentPixel.y + dy;
                    var adjacentPixel = new Pixel(newX, newY, currentPixel.color);

                    if (!filledPixels.Contains(adjacentPixel) && !contour.Contains(adjacentPixel))
                    {
                        stack.Push(adjacentPixel);
                    }
                }

                Pixel pixel1 = new Pixel(currentPixel.x + 1, currentPixel.y, currentPixel.color);
                Pixel pixel2 = new Pixel(currentPixel.x, currentPixel.y + 1, currentPixel.color);
                if (!filledPixels.Contains(pixel1) && !contour.Contains(pixel1) && !filledPixels.Contains(pixel2) && !contour.Contains(pixel2))
                {
                    stack.Push(new Pixel(currentPixel.x + 1, currentPixel.y + 1, currentPixel.color));
                }

                pixel1 = new Pixel(currentPixel.x + 1, currentPixel.y, currentPixel.color);
                pixel2 = new Pixel(currentPixel.x, currentPixel.y - 1, currentPixel.color);
                if (!filledPixels.Contains(pixel1) && !contour.Contains(pixel1) && !filledPixels.Contains(pixel2) && !contour.Contains(pixel2))
                {
                    stack.Push(new Pixel(currentPixel.x + 1, currentPixel.y - 1, currentPixel.color));
                }

                pixel1 = new Pixel(currentPixel.x - 1, currentPixel.y, currentPixel.color);
                pixel2 = new Pixel(currentPixel.x, currentPixel.y + 1, currentPixel.color);
                if (!filledPixels.Contains(pixel1) && !contour.Contains(pixel1) && !filledPixels.Contains(pixel2) && !contour.Contains(pixel2))
                {
                    stack.Push(new Pixel(currentPixel.x - 1, currentPixel.y + 1, currentPixel.color));
                }

                pixel1 = new Pixel(currentPixel.x - 1, currentPixel.y, currentPixel.color);
                pixel2 = new Pixel(currentPixel.x, currentPixel.y - 1, currentPixel.color);
                if (!filledPixels.Contains(pixel1) && !contour.Contains(pixel1) && !filledPixels.Contains(pixel2) && !contour.Contains(pixel2))
                {
                    stack.Push(new Pixel(currentPixel.x - 1, currentPixel.y - 1, currentPixel.color));
                }
            }

            stopwatch.Stop();
            label3.Text += $"Закраска области: {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeC += stopwatch.Elapsed.TotalMilliseconds;

            return new List<Pixel>(filledPixels);
        }
        public List<Pixel> GetPixelsFigureA(List<Pixel> vertices, Pixel seedPixel)
        {
            var contourPixels = new HashSet<Pixel>();
            for (int i = 0; i < vertices.Count; i++)
            {
                var start = vertices[i];
                var end = vertices[(i + 1) % vertices.Count];
                contourPixels.UnionWith(PaintLineMain(start.x, start.y, end.x, end.y, seedPixel.color));
            }

            List<Pixel> filledPixels = FillA(contourPixels, seedPixel);

            var allPixels = contourPixels.ToList();
            allPixels.AddRange(filledPixels);

            return allPixels;
        }

        public List<Pixel> GetPixelsFigureB(List<Pixel> vertices, Pixel seedPixel, String figure)
        {
            label2.Text += $"Фигура  {figure}: ";
            var contourPixels = new HashSet<Pixel>();

            for (int i = 0; i < vertices.Count; i++)
            {
                var start = vertices[i];
                var end = vertices[(i + 1) % vertices.Count];
                contourPixels.UnionWith(PaintLineCDA(start.x, start.y, end.x, end.y, start.color));
            }

            List<Pixel> filledPixels = FillB(contourPixels, seedPixel);

            var allPixels = contourPixels.ToList();
            allPixels.AddRange(filledPixels);

            return allPixels;
        }

        public List<Pixel> GetPixelsFigureC(List<Pixel> vertices, Pixel seedPixel)
        {
            var contourPixels = new HashSet<Pixel>();
            for (int i = 0; i < vertices.Count; i++)
            {
                var start = vertices[i];
                var end = vertices[(i + 1) % vertices.Count];
                contourPixels.UnionWith(PaintLineBrezenthema(start.x, start.y, end.x, end.y, start.color));
            }

            List<Pixel> filledPixels = FillC(contourPixels, seedPixel);

            var allPixels = contourPixels.ToList();
            allPixels.AddRange(filledPixels);

            return allPixels;
        }

        public static List<Pixel> DrawPartCircle(int centerX, int centerY, int radius, bool paintRight = true, bool paintBottom = false)
        {
            List<Pixel> pixels = new List<Pixel>();

            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;

            // ������ ������
            while (x <= y)
            {
                if (paintRight || paintBottom) pixels.Add(new Pixel(centerX + x, centerY - y, Color.Black));
                if (paintRight || paintBottom) pixels.Add(new Pixel(centerX + y, centerY - x, Color.Black));
                if (paintRight) pixels.Add(new Pixel(centerX + x, centerY + y, Color.Black));
                if (paintRight) pixels.Add(new Pixel(centerX + y, centerY + x, Color.Black));

                if (paintBottom) pixels.Add(new Pixel(centerX - x, centerY - y, Color.Black));
                if (paintBottom) pixels.Add(new Pixel(centerX - y, centerY - x, Color.Black));
                if (d < 0)
                    d += 4 * x + 6;
                else
                {
                    d += 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
            return pixels;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int diff1 = CalculateDiff(bitmapA, bitmapC);
            label1.Text += $"I = {diff1}\nm = {(double)diff1 / (pictureBox2.Width / scale * pictureBox2.Height / scale)}\n";

            int diff2 = CalculateDiff(bitmapB, bitmapC);

            label2.Text += $"I = {diff2}\nm = {(double)diff2 / (pictureBox2.Width / scale * pictureBox2.Height / scale)}\n";

            CalculateDiff(bitmapA, bitmapB, true);
        }

        private void getPixelsA()
        {
            pixelsA.AddRange(GetPixelsFigureA(
               new List<Pixel> {
                    new Pixel(-16, 4, Color.Green),
                    new Pixel(-8, 4, Color.Green),
                    new Pixel(-12, 24, Color.Green),
               },
                new Pixel(-3 * 4, 2 * 4, Color.Green)));

            pixelsA.AddRange(GetPixelsFigureA(
                new List<Pixel> {
                    new Pixel(-10, 0, Color.Orange),
                    new Pixel(-10, 6, Color.Orange),
                    new Pixel(2, 6, Color.Orange),
                    new Pixel(2, 0, Color.Orange),
                },
                new Pixel(-4, 4, Color.Orange)));


            pixelsA.AddRange(GetPixelsFigureA(
                new List<Pixel> {
                new Pixel(0, 10, Color.LightGoldenrodYellow),
                new Pixel(-2, 12, Color.LightGoldenrodYellow),
                new Pixel(-4, 12, Color.LightGoldenrodYellow),
                new Pixel(-6, 10, Color.LightGoldenrodYellow),
                new Pixel(-6, 8, Color.LightGoldenrodYellow),
                new Pixel(-4, 6, Color.LightGoldenrodYellow),
                new Pixel(-2, 6, Color.LightGoldenrodYellow),
                },
                new Pixel(-4, 8, Color.LightGoldenrodYellow)));

            pixelsA.AddRange(GetPixelsFigureA(
                new List<Pixel> {
                new Pixel(-10, 6, Color.Red),
                new Pixel(-4, 10, Color.Red),
                new Pixel(2, 6, Color.Red),
                },
                new Pixel(-4, 8, Color.Red)));

            pixelsA.AddRange(GetPixelsFigureA(
                new List<Pixel> {
                new Pixel(-6, 2, Color.Yellow),
                new Pixel(-6, 4, Color.Yellow),
                new Pixel(-4, 4, Color.Yellow),
                new Pixel(-4, 2, Color.Yellow),
                },
                new Pixel(-5, 3, Color.Yellow)));

            pixelsA.AddRange(GetPixelsFigureA(
                new List<Pixel> {
                new Pixel(-2, 0, Color.SaddleBrown),
                new Pixel(-2, 4, Color.SaddleBrown),
                new Pixel(0, 4, Color.SaddleBrown),
                new Pixel(0, 0, Color.SaddleBrown),
                },
                new Pixel(-1, 2, Color.SaddleBrown)));

            pixelsA.AddRange(PaintLineMain(-12, 0, -12, 16, Color.Black));

            pixelsA.AddRange(PaintLineMain(-12, 6, -10, 8, Color.Black));
            pixelsA.AddRange(PaintLineMain(-12, 6, -14, 8, Color.Black));

            pixelsA.AddRange(PaintLineMain(-12, 8, -10, 10, Color.Black));
            pixelsA.AddRange(PaintLineMain(-12, 8, -14, 10, Color.Black));

            label1.Text += $"Всего веремени: {totalTimeA} ms.\n";
        }

        private void getPixelsB()
        {
            pixelsB.AddRange(GetPixelsFigureB(
                new List<Pixel> {
                    new Pixel(-16, 4, Color.Green),
                    new Pixel(-8, 4, Color.Green),
                    new Pixel(-12, 24, Color.Green),
                },
                 new Pixel(-3 * 4, 2 * 4, Color.Green), "Треугольник"));
            Console.WriteLine("Pixele green B " + pixelsB.Count);

            pixelsB.AddRange(GetPixelsFigureB(
                new List<Pixel> {
                    new Pixel(-10, 0, Color.Orange),
                    new Pixel(-10, 6, Color.Orange),
                    new Pixel(2, 6, Color.Orange),
                    new Pixel(2, 0, Color.Orange),
                },
                new Pixel(-4, 4, Color.Orange), "Прямоугольник"));

            pixelsB.AddRange(GetPixelsFigureB(
                new List<Pixel> {
                new Pixel(0, 10, Color.LightGoldenrodYellow),
                new Pixel(-2, 12, Color.LightGoldenrodYellow),
                new Pixel(-4, 12, Color.LightGoldenrodYellow),
                new Pixel(-6, 10, Color.LightGoldenrodYellow),
                new Pixel(-6, 8, Color.LightGoldenrodYellow),
                new Pixel(-4, 6, Color.LightGoldenrodYellow),
                new Pixel(-2, 6, Color.LightGoldenrodYellow),
                },
                new Pixel(-4, 8, Color.LightGoldenrodYellow), "Семиугольник"));

            pixelsB.AddRange(GetPixelsFigureB(
                new List<Pixel> {
                new Pixel(-10, 6, Color.Red),
                new Pixel(-4, 10, Color.Red),
                new Pixel(2, 6, Color.Red),
                },
                new Pixel(-4, 8, Color.Red), "Треугольник"));

            pixelsB.AddRange(GetPixelsFigureB(
                new List<Pixel> {
                new Pixel(-6, 2, Color.Yellow),
                new Pixel(-6, 4, Color.Yellow),
                new Pixel(-4, 4, Color.Yellow),
                new Pixel(-4, 2, Color.Yellow),
                },
                new Pixel(-5, 3, Color.Yellow), "Прямоугольник"));

            pixelsB.AddRange(GetPixelsFigureB(
                new List<Pixel> {
                new Pixel(-2, 0, Color.SaddleBrown),
                new Pixel(-2, 4, Color.SaddleBrown),
                new Pixel(0, 4, Color.SaddleBrown),
                new Pixel(0, 0, Color.SaddleBrown),
                },
                new Pixel(-1, 2, Color.SaddleBrown), "Прямоугольник"));

            pixelsB.AddRange(PaintLineCDA(-12, 0, -12, 16, Color.Black));

            pixelsB.AddRange(PaintLineCDA(-12, 6, -10, 8, Color.Black));
            pixelsB.AddRange(PaintLineCDA(-12, 6, -14, 8, Color.Black));

            pixelsB.AddRange(PaintLineCDA(-12, 8, -10, 10, Color.Black));
            pixelsB.AddRange(PaintLineCDA(-12, 8, -14, 10, Color.Black));

            label2.Text += $"Всего веремени: {totalTimeB} ms.\n";
        }

        private void getPixelsC()
        {
            pixelsC.AddRange(GetPixelsFigureC(
                new List<Pixel> {
                    new Pixel(-16, 4, Color.Green),
                    new Pixel(-8, 4, Color.Green),
                    new Pixel(-12, 24, Color.Green),
                },
                 new Pixel(-3 * 4, 2 * 4, Color.Green)));
            Console.WriteLine("Pixele green C " + pixelsC.Count);

            pixelsC.AddRange(GetPixelsFigureC(
                new List<Pixel> {
                    new Pixel(-10, 0, Color.Orange),
                    new Pixel(-10, 6, Color.Orange),
                    new Pixel(2, 6, Color.Orange),
                    new Pixel(2, 0, Color.Orange),
                },
                new Pixel(-4, 4, Color.Orange)));

            pixelsC.AddRange(GetPixelsFigureC(
                new List<Pixel> {
                new Pixel(0, 10, Color.LightGoldenrodYellow),
                new Pixel(-2, 12, Color.LightGoldenrodYellow),
                new Pixel(-4, 12, Color.LightGoldenrodYellow),
                new Pixel(-6, 10, Color.LightGoldenrodYellow),
                new Pixel(-6, 8, Color.LightGoldenrodYellow),
                new Pixel(-4, 6, Color.LightGoldenrodYellow),
                new Pixel(-2, 6, Color.LightGoldenrodYellow),
                },
                new Pixel(-4, 8, Color.LightGoldenrodYellow)));

            pixelsC.AddRange(GetPixelsFigureC(
                new List<Pixel> {
                new Pixel(-10, 6, Color.Red),
                new Pixel(-4, 10, Color.Red),
                new Pixel(2, 6, Color.Red),
                },
                new Pixel(-4, 8, Color.Red)));

            pixelsC.AddRange(GetPixelsFigureC(
                new List<Pixel> {
                new Pixel(-6, 2, Color.Yellow),
                new Pixel(-6, 4, Color.Yellow),
                new Pixel(-4, 4, Color.Yellow),
                new Pixel(-4, 2, Color.Yellow),
                },
                new Pixel(-5, 3, Color.Yellow)));

            pixelsC.AddRange(GetPixelsFigureC(
                new List<Pixel> {
                new Pixel(-2, 0, Color.SaddleBrown),
                new Pixel(-2, 4, Color.SaddleBrown),
                new Pixel(0, 4, Color.SaddleBrown),
                new Pixel(0, 0, Color.SaddleBrown),
                },
                new Pixel(-1, 2, Color.SaddleBrown)));

            pixelsC.AddRange(PaintLineBrezenthema(-12, 0, -12, 16, Color.Black));

            pixelsC.AddRange(PaintLineBrezenthema(-12, 6, -10, 8, Color.Black));
            pixelsC.AddRange(PaintLineBrezenthema(-12, 6, -14, 8, Color.Black));

            pixelsC.AddRange(PaintLineBrezenthema(-12, 8, -10, 10, Color.Black));
            pixelsC.AddRange(PaintLineBrezenthema(-12, 8, -14, 10, Color.Black));

            label3.Text += $"Всего веремени: {totalTimeC} ms.\n";
        }

        public static double[] ToPolar(double x, double y)
        {
            if (x == 0 && y == 0)
                return [0, 0];

            double r = Math.Sqrt(x * x + y * y);
            double theta;

            if (x > 0 && y >= 0)
                theta = Math.Atan(y / x);
            else if (x < 0 && y >= 0)
                theta = Math.PI - Math.Atan(Math.Abs(y / x));
            else if (x < 0 && y < 0)
                theta = Math.PI + Math.Atan(Math.Abs(y / x));
            else
                theta = 2 * Math.PI - Math.Atan(Math.Abs(y / x));

            theta = theta % (2 * Math.PI);

            return [r, theta];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int speed))
            {
                timer1.Interval = speed;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        { // D
            int x = Int32.Parse(textBox5.Text);
            int y = Int32.Parse(textBox6.Text);
            int H = Int32.Parse(textBox7.Text);
            pixelsA.Clear();
            paintedA = 0;
            pixelsA = PaintLineBrezenthema(x - H / 4, y - H / 2, x - H / 4, y + H / 2, Color.Black);
            pixelsA.AddRange(DrawPartCircle(x - H / 4, y, H / 2));
        }

        private void button3_Click(object sender, EventArgs e)
        { // B
            int x = Int32.Parse(textBox5.Text);
            int y = Int32.Parse(textBox6.Text);
            int H = Int32.Parse(textBox7.Text);
            pixelsA.Clear();
            paintedA = 0;
            pixelsA = PaintLineBrezenthema(x - H / 8, y + H / 2, x - H / 8, y - H / 2, Color.Black);
            pixelsA.AddRange(DrawPartCircle(x - H / 8, y + H / 4, H / 4));
            pixelsA.AddRange(DrawPartCircle(x - H / 8, y - H / 4, H / 4 + H % 2));
        }

        private void button5_Click(object sender, EventArgs e)
        { // R
            int x = Int32.Parse(textBox5.Text);
            int y = Int32.Parse(textBox6.Text);
            int H = Int32.Parse(textBox7.Text);
            pixelsA.Clear();
            paintedA = 0;
            pixelsA = PaintLineBrezenthema(x - H / 8, y + H / 2, x - H / 8, y - H / 2, Color.Black);
            pixelsA.AddRange(DrawPartCircle(x - H / 8, y + H / 4, H / 4 + H % 2));
            pixelsA.AddRange(PaintLineBrezenthema(x - H / 8, y, x + H / 8 +  H % 2, y - H / 2, Color.Black));
        }

        private void button6_Click(object sender, EventArgs e)
        { // J
            int x = Int32.Parse(textBox5.Text);
            int y = Int32.Parse(textBox6.Text);
            int H = Int32.Parse(textBox7.Text);
            pixelsA.Clear();
            paintedA = 0;
            pixelsA = PaintLineBrezenthema(x + H / 4, y + H / 2,  x + H / 4, y - H / 4, Color.Black);
            pixelsA.AddRange(DrawPartCircle(x, y - H / 4, H / 4, false, true));
        }

    }


    public class Pixel
        {
        public int x, y;
        public Color color;

        public Pixel(int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public Pixel(Pixel p)
        {
            this.x = p.x;
            this.y = p.y;
            this.color = p.color;
        }

        public override bool Equals(object obj)
        {
            if (obj is Pixel pixel)
            {
                return x == pixel.x && y == pixel.y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

    }
}
