using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace KGLaba3
{
    public partial class Form1 : Form
    {
        List<Pixel> pixelsA = new List<Pixel>();
        List<Pixel> pixelsB = new List<Pixel>();
        List<Pixel> pixelsC = new List<Pixel>();

        int scale = 10;
        int offsetX = 20, offsetY = 10;

        double totalTimeA = 0;
        double totalTimeB = 0;
        double totalTimeC = 0;
        string statsA = "";
        string statsB = "";
        string statsC = "";

        Graphics graphicsA = null;
        Graphics graphicsB = null;
        public Form1()
        {
            InitializeComponent();
        }

        void paintPixels(Graphics graphics, List<Pixel> pixels)
        {
            for (int i = 0; i < pixels.Count(); i++)
            {
                SolidBrush color = new SolidBrush(pixels[i].color);
                graphics.FillRectangle(color, (pixels[i].x + offsetX) * scale, 400 - (pixels[i].y + offsetY) * scale, 1 * scale, 1 * scale);
            }
        }

        List<Pixel> CalculateDiff(List<Pixel> image1, List<Pixel> image2)
        {
            HashSet<Pixel> img1 = new HashSet<Pixel>();
            HashSet<Pixel> img2 = new HashSet<Pixel>();

            for (int i = 0; i < image1.Count; i++)
            {
                img1.Add(image1[image1.Count - i - 1]);
            }
            for (int i = 0; i < image2.Count; i++)
            {
                img2.Add(image2[image2.Count - i - 1]);
            }

            HashSet<Pixel> result = new HashSet<Pixel>();
            foreach (Pixel pixel1 in img1)
            {
                bool success = false;
                foreach (Pixel pixel2 in img2)
                {
                    if (pixel1.x == pixel2.x && pixel1.y == pixel2.y && pixel1.color == pixel2.color)
                    {
                        success = true;
                        break;
                    }
                }
                if (!success)
                {
                    result.Add(pixel1);
                }
            }

            foreach (Pixel pixel2 in img1)
            {
                bool success = false;
                foreach (Pixel pixel1 in img2)
                {
                    if (pixel1.x == pixel2.x && pixel1.y == pixel2.y && pixel1.color == pixel2.color)
                    {
                        success = true;
                        break;
                    }
                }
                if (!success)
                {
                    result.Add(pixel2);
                }
            }
            return result.ToList();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            graphicsA = e.Graphics;

            var figure1 = GetPixelsA(new List<List<double>> {
                    new List<double> { 16.49, 165.96 },
                    new List<double> { 8.94, 153.43, },
                    new List<double> { 26.83, 116.57, },
                },
                new Pixel(-3 * 4, 2 * 4, Color.Green));
            paintPixels(graphicsA, figure1);
            
            var figure2 = GetPixelsA(new List<List<double>> {
                    new List<double> { 10, 180 },
                    new List<double> { 11.66, 149.04 },
                    new List<double> { 6.32, 71.57 },
                    new List<double> { 2, 0 },
                },
                new Pixel(-4, 4, Color.Orange));
            paintPixels(graphicsA, figure2);

            var figure3 = GetPixelsA(new List<List<double>> {
                new List<double> { 10, 90 },
                new List<double> { 12.17, 99.46 },
                new List<double> { 12.65, 108.43 },
                new List<double> { 11.66, 120.96 },
                new List<double> { 10, 126.87 },
                new List<double> { 7.21, 123.69 },
                new List<double> { 6.32, 108.43 },
                },
                new Pixel(-4, 8, Color.LightGoldenrodYellow));
            paintPixels(graphicsA, figure3);

            var figure4 = GetPixelsA(new List<List<double>> {
                new List<double> { 11.66, 149.04 },
                new List<double> { 10.77, 111.80 },
                new List<double> { 6.32, 71.57 },
                },
                new Pixel(-4, 8, Color.Red));
            paintPixels(graphicsA, figure4);

            var figure5 = GetPixelsA(new List<List<double>> {
                new List<double> { 6.32, 161.57 },
                new List<double> { 7.21, 146.31 },
                new List<double> { 5.66, 135 },
                new List<double> { 4.47, 153.43 },
                },
                new Pixel(-5, 3, Color.Yellow));
            paintPixels(graphicsA, figure5);

            var figure6 = GetPixelsA(new List<List<double>> {
                new List<double> { 2, 180 },
                new List<double> { 4.47, 116.57 },
                new List<double> { 4, 90 },
                new List<double> { 0, 0 },
                },
                new Pixel(-1, 2, Color.SaddleBrown));
            paintPixels(graphicsA, figure6);

            var line1 = PaintLineMain( 12, 180, 20, 126.87, Color.Black);
            paintPixels(graphicsA, line1);

            var line2 = PaintLineMain(13.42, 153.43, 12.81, 141.34, Color.Black);
            line2.AddRange(
                PaintLineMain(13.42, 153.43, 16.12, 150.26, Color.Black)
            );
            paintPixels(graphicsA, line2);

            var line3 = PaintLineMain(14.42, 146.31, 14.14, 135, Color.Black);
            line3.AddRange(
                PaintLineMain(14.42, 146.31, 17.20, 144.46, Color.Black)
            );
            paintPixels(graphicsA, line3);

            label1.Text = statsA + $"Всего веремени: {totalTimeA} ms.\n";
        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            graphicsB = e.Graphics;

            var figure1 = GetPixelsB(new List<Pixel> {
                new Pixel(-16, 4, Color.Green),
                new Pixel(-8, 4, Color.Green),
                new Pixel(-12, 24, Color.Green),
                },
                new Pixel(-3 * 4, 2 * 4, Color.Green));
            paintPixels(graphicsB, figure1);

            var figure2 = GetPixelsB(new List<Pixel> {
                new Pixel(-10, 0, Color.Orange),
                new Pixel(-10, 6, Color.Orange),
                new Pixel(2, 6, Color.Orange),
                new Pixel(2, 0, Color.Orange),
                },
                new Pixel(-4, 4, Color.Orange));
            paintPixels(graphicsB, figure2);

            var figure3 = GetPixelsB(new List<Pixel> {
                new Pixel(0, 10, Color.LightGoldenrodYellow),
                new Pixel(-2, 12, Color.LightGoldenrodYellow),
                new Pixel(-4, 12, Color.LightGoldenrodYellow),
                new Pixel(-6, 10, Color.LightGoldenrodYellow),
                new Pixel(-6, 8, Color.LightGoldenrodYellow),
                new Pixel(-4, 6, Color.LightGoldenrodYellow),
                new Pixel(-2, 6, Color.LightGoldenrodYellow),
                },
                new Pixel(-4, 8, Color.LightGoldenrodYellow));
            paintPixels(graphicsB, figure3);

            var figure4 = GetPixelsB(new List<Pixel> {
                new Pixel(-10, 6, Color.Red),
                new Pixel(-4, 10, Color.Red),
                new Pixel(2, 6, Color.Red),
                },
                new Pixel(-4, 8, Color.Red));
            paintPixels(graphicsB, figure4);

            var figure5 = GetPixelsB(new List<Pixel> {
                new Pixel(-6, 2, Color.Yellow),
                new Pixel(-6, 4, Color.Yellow),
                new Pixel(-4, 4, Color.Yellow),
                new Pixel(-4, 2, Color.Yellow),
                },
                new Pixel(-5, 3, Color.Yellow));
            paintPixels(graphicsB, figure5);

            var figure6 = GetPixelsB(new List<Pixel> {
                new Pixel(-2, 0, Color.SaddleBrown),
                new Pixel(-2, 4, Color.SaddleBrown),
                new Pixel(0, 4, Color.SaddleBrown),
                new Pixel(0, 0, Color.SaddleBrown),
                },
                new Pixel(-1, 2, Color.SaddleBrown));
            paintPixels(graphicsB, figure6);

            var line1 = PaintLineCDA(-12, 0, -12, 16, Color.Black);
            paintPixels(graphicsB, line1);

            var line2 = PaintLineCDA(-12, 6, -10, 8, Color.Black);
            line2.AddRange(
                PaintLineCDA(-12, 6, -14, 8, Color.Black)
            );
            paintPixels(graphicsB, line2);

            var line3 = PaintLineCDA(-12, 8, -10, 10, Color.Black);
            line3.AddRange(
                PaintLineCDA(-12, 8, -14, 10, Color.Black)
            );
            paintPixels(graphicsB, line3);

            label2.Text = statsB + $"Всего веремени: {totalTimeB} ms.\n";
        }

        private void PictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            var figure1 = GetPixelsC(new List<Pixel> {
                new Pixel(-16, 4, Color.Green),
                new Pixel(-8, 4, Color.Green),
                new Pixel(-12, 24, Color.Green),
                },
                new Pixel(-3 * 4, 2 * 4, Color.Green));
            paintPixels(graphics, figure1);

            var figure2 = GetPixelsC(new List<Pixel> {
                new Pixel(-10, 0, Color.Orange),
                new Pixel(-10, 6, Color.Orange),
                new Pixel(2, 6, Color.Orange),
                new Pixel(2, 0, Color.Orange),
                },
                new Pixel(-4, 4, Color.Orange));
            paintPixels(graphics, figure2);

            var figure3 = GetPixelsC(new List<Pixel> {
                new Pixel(0, 10, Color.LightGoldenrodYellow),
                new Pixel(-2, 12, Color.LightGoldenrodYellow),
                new Pixel(-4, 12, Color.LightGoldenrodYellow),
                new Pixel(-6, 10, Color.LightGoldenrodYellow),
                new Pixel(-6, 8, Color.LightGoldenrodYellow),
                new Pixel(-4, 6, Color.LightGoldenrodYellow),
                new Pixel(-2, 6, Color.LightGoldenrodYellow),
                },
                new Pixel(-4, 8, Color.LightGoldenrodYellow));
            paintPixels(graphics, figure3);

            var figure4 = GetPixelsC(new List<Pixel> {
                new Pixel(-10, 6, Color.Red),
                new Pixel(-4, 10, Color.Red),
                new Pixel(2, 6, Color.Red),
                },
                new Pixel(-4, 8, Color.Red));
            paintPixels(graphics, figure4);

            var figure5 = GetPixelsC(new List<Pixel> {
                new Pixel(-6, 2, Color.Yellow),
                new Pixel(-6, 4, Color.Yellow),
                new Pixel(-4, 4, Color.Yellow),
                new Pixel(-4, 2, Color.Yellow),
                },
                new Pixel(-5, 3, Color.Yellow));
            paintPixels(graphics, figure5);

            var figure6 = GetPixelsC(new List<Pixel> {
                new Pixel(-2, 0, Color.SaddleBrown),
                new Pixel(-2, 4, Color.SaddleBrown),
                new Pixel(0, 4, Color.SaddleBrown),
                new Pixel(0, 0, Color.SaddleBrown),
                },
                new Pixel(-1, 2, Color.SaddleBrown));
            paintPixels(graphics, figure6);

            var line1 = PaintLineBrezenthema(-12, 0, -12, 16, Color.Black);
            paintPixels(graphics, line1);

            var line2 = PaintLineBrezenthema(-12, 6, -10, 8, Color.Black);
            line2.AddRange(
                PaintLineBrezenthema(-12, 6, -14, 8, Color.Black)
            );
            paintPixels(graphics, line2);

            var line3 = PaintLineBrezenthema(-12, 8, -10, 10, Color.Black);
            line3.AddRange(
                PaintLineBrezenthema(-12, 8, -14, 10, Color.Black)
            );
            paintPixels(graphics, line3);

            label3.Text = statsC + $"Всего веремени: {totalTimeC} ms.\n";
        }


        List<Pixel> PaintLineMain(double r1, double p1, double r2, double p2, Color color)
        {
            int x1 = (int)Math.Round(r1 * Math.Cos(p1 * Math.PI / 180), 0);
            int y1 = (int)Math.Round(r1 * Math.Sin(p1 * Math.PI / 180), 0);

            int x2 = (int)Math.Round(r2 * Math.Cos(p2 * Math.PI / 180), 0);
            int y2 = (int) Math.Round(r2 * Math.Sin(p2 * Math.PI / 180), 0);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Pixel> pixels = new List<Pixel>();

            int dx = x2 - x1;
            int dy = y2 - y1;

            int absDx = Math.Abs(dx);
            int absDy = Math.Abs(dy);

            int signX = dx > 0 ? 1 : (dx < 0 ? -1 : 0);
            int signY = dy > 0 ? 1 : (dy < 0 ? -1 : 0);

            if (absDx > absDy)
            {
                double y = y1;
                double k = (double)dy / dx;

                for (double x = x1; x != x2 + signX; x += signX)
                {
                    pixels.Add(new Pixel((int)x, (int)Math.Round(y), color));
                    y += k * signX;
                }
            }
            else
            {
                double x = x1;
                double k = (double)dx / dy;

                for (double y = y1; y != y2 + signY; y += signY)
                {
                    pixels.Add(new Pixel((int)Math.Round(x), (int)y, color));
                    x += k * signY;
                }
            }

            stopwatch.Stop();
            statsA += $"Прямая ({r1}; {p1}) ({r2}; {p2}) или ({x1}; {y1}) - ({x2}; {y2}): {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeA += stopwatch.Elapsed.TotalMilliseconds;
            pixelsA.AddRange(pixels);

            return pixels;
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
            statsB += $"Прямая с координатами ({x1}; {y1}) - ({x2}; {y2}): {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeB += stopwatch.Elapsed.TotalMilliseconds;
            pixelsB.AddRange(pixels);

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
            statsC += $"Прямая с координатами ({x1}; {y1}) - ({x2}; {y2}): {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeC += stopwatch.Elapsed.TotalMilliseconds;
            pixelsC.AddRange(pixels);

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
            statsA += $"Закраска области: {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeA += stopwatch.Elapsed.TotalMilliseconds;
            pixelsA.AddRange(insidePixels);

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
            statsB += $"Закраска области: {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeB += stopwatch.Elapsed.TotalMilliseconds;
            pixelsB.AddRange(filledPixels);

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
            statsC += $"Закраска области: {stopwatch.Elapsed.TotalMilliseconds} ms.\n";
            totalTimeC += stopwatch.Elapsed.TotalMilliseconds;
            pixelsC.AddRange(filledPixels);

            return new List<Pixel>(filledPixels);
        }
        public List<Pixel> GetPixelsA(List<List<double>> vertices, Pixel seedPixel)
        {
            var contourPixels = new HashSet<Pixel>();
            for (int i = 0; i < vertices.Count; i++)
            {
                var start = vertices[i];
                var end = vertices[(i + 1) % vertices.Count];
                contourPixels.UnionWith(PaintLineMain(start[0], start[1], end[0], end[1], seedPixel.color));
            }

            List<Pixel> filledPixels = FillA(contourPixels, seedPixel);

            var allPixels = contourPixels.ToList();
            allPixels.AddRange(filledPixels);

            return allPixels;
        }

        public List<Pixel> GetPixelsB(List<Pixel> vertices, Pixel seedPixel)
        {
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

        public List<Pixel> GetPixelsC(List<Pixel> vertices, Pixel seedPixel)
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

        private void button1_Click(object sender, EventArgs e)
        {
            List<Pixel> diff1 = CalculateDiff(pixelsA, pixelsC);
            label1.Text += $"I = {diff1.Count}\nm = {(double)diff1.Count / (pictureBox2.Width / scale * pictureBox2.Height / scale)}\n";

            List<Pixel> diff2 = CalculateDiff(pixelsB, pixelsC);

            label2.Text += $"I = {diff2.Count}\nm = {(double)diff2.Count / (pictureBox2.Width / scale * pictureBox2.Height / scale)}\n";

            List<Pixel> diff3 = CalculateDiff(pixelsA, pixelsB);
            for (int i = 0; i < diff3.Count; i++)
            {
                diff3[i].color = Color.FromArgb(255 - diff3[i].color.R, 255 - diff3[i].color.G, 255 - diff3[i].color.B);
                paintPixels(pictureBox1.CreateGraphics(), new List<Pixel> { diff3[i] });
            }

            List<Pixel> diff4 = CalculateDiff(pixelsB, pixelsA);
            for (int i = 0; i < diff3.Count; i++)
            {
                diff4[i].color = Color.FromArgb( 255 - diff4[i].color.R, 255 - diff4[i].color.G, 255 - diff4[i].color.B);
                paintPixels(pictureBox2.CreateGraphics(), [diff4[i]]);
            }
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
