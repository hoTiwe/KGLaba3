using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace KGLaba3
{
    public partial class Form1 : Form
    {
        List<Pixel> pixelOutLineA = new List<Pixel>();
        List<Pixel> pixelOutLineB = new List<Pixel>();
        List<Pixel> pixelOutLineReference = new List<Pixel>();

        double timeA = 0;
        double timeB = 0;
        double timeMain = 0;
        int countDiffA = 0;
        int countDiffB = 0;
        int scaleA = 10, scaleB = 10, scaleReference = 10;
        double m1 = 0;
        double m2 = 0;

        int offsetXA = 20, offsetYA = 10, offsetXB = 20, offsetYB = 15;
        public Form1()
        {
            InitializeComponent();

        }

        void paintPixels(Graphics graphics, List<Pixel> pixels, int offsetX, int offsetY, int scale)
        {
            for (int i = 0; i < pixels.Count(); i++)
            {
                graphics.FillRectangle(new SolidBrush(pixels[i].color), (pixels[i].x + offsetX) * scale, 400 - (pixels[i].y + offsetY) * scale, 1 * scale, 1 * scale);
            }
        }

        List<Pixel> CalculateDiff(List<Pixel> outlineT, List<Pixel> onsideT, List<Pixel> outlineM, List<Pixel> onsideM)
        {
            List<Pixel> mergedList1 = outlineT.Concat(onsideT).ToList();
            List<Pixel> mergedList2 = outlineM.Concat(onsideM).ToList();

            List<Pixel> ans = new List<Pixel>();
            for (int i = 0; i < mergedList1.Count(); i++)
            {
                int index = mergedList2.FindIndex(0, mergedList2.Count(), (item) => item == mergedList1[i]);
                if (index == -1)
                {
                    ans.Add(mergedList1[i]);
                }
            }

            for (int i = 0; i < mergedList2.Count(); i++)
            {
                int index = mergedList1.FindIndex(0, mergedList1.Count(), (item) => item == mergedList2[i]);
                if (index == -1)
                {
                    ans.Add(mergedList2[i]);
                }
            }
            return ans;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var figure1 = GetPixelsA(new List<Pixel> {
                new Pixel(-16, 4, Color.Green),
                new Pixel(-8, 4, Color.Green),
                new Pixel(-12, 24, Color.Green),
                },
                new Pixel(-3 * 4, 2 * 4, Color.Green));
            paintPixels(graphics, figure1, offsetXA, offsetYA, scaleA);

            var figure2 = GetPixelsA(new List<Pixel> {
                new Pixel(-10, 0, Color.Orange),
                new Pixel(-10, 6, Color.Orange),
                new Pixel(2, 6, Color.Orange),
                new Pixel(2, 0, Color.Orange),
                },
                new Pixel(-4, 4, Color.Orange));
            paintPixels(graphics, figure2, offsetXA, offsetYA, scaleA);

            var figure3 = GetPixelsA(new List<Pixel> {
                new Pixel(0, 10, Color.LightGoldenrodYellow),
                new Pixel(-2, 12, Color.LightGoldenrodYellow),
                new Pixel(-4, 12, Color.LightGoldenrodYellow),
                new Pixel(-6, 10, Color.LightGoldenrodYellow),
                new Pixel(-6, 8, Color.LightGoldenrodYellow),
                new Pixel(-4, 6, Color.LightGoldenrodYellow),
                new Pixel(-2, 6, Color.LightGoldenrodYellow),
                },
                new Pixel(-4, 8, Color.LightGoldenrodYellow));
            paintPixels(graphics, figure3, offsetXA, offsetYA, scaleA);

            var figure4 = GetPixelsA(new List<Pixel> {
                new Pixel(-10, 6, Color.Red),
                new Pixel(-4, 10, Color.Red),
                new Pixel(2, 6, Color.Red),
                },
                new Pixel(-4, 8, Color.Red));
            paintPixels(graphics, figure4, offsetXA, offsetYA, scaleA);

            var figure5 = GetPixelsA(new List<Pixel> {
                new Pixel(-6, 2, Color.Yellow),
                new Pixel(-6, 4, Color.Yellow),
                new Pixel(-4, 4, Color.Yellow),
                new Pixel(-4, 2, Color.Yellow),
                },
                new Pixel(-5, 3, Color.Yellow));
            paintPixels(graphics, figure5, offsetXA, offsetYA, scaleA);

            var figure6 = GetPixelsA(new List<Pixel> {
                new Pixel(-2, 0, Color.SaddleBrown),
                new Pixel(-2, 4, Color.SaddleBrown),
                new Pixel(0, 4, Color.SaddleBrown),
                new Pixel(0, 0, Color.SaddleBrown),
                },
                new Pixel(-1, 2, Color.SaddleBrown));
            paintPixels(graphics, figure6, offsetXA, offsetYA, scaleA);

            var line1 = PaintLineMain(-12, 0, -12, 16, Color.Black);
            paintPixels(graphics, line1, offsetXA, offsetYA, scaleA);

            var line2 = PaintLineMain(-12, 6, -10, 8, Color.Black);
            line2.AddRange(
                PaintLineMain(-12, 6, -14, 8, Color.Black)
            );
            paintPixels(graphics, line2, offsetXA, offsetYA, scaleA);

            var line3 = PaintLineMain(-12, 8, -10, 10, Color.Black);
            line3.AddRange(
                PaintLineMain(-12, 8, -14, 10, Color.Black)
            );
            paintPixels(graphics, line3, offsetXA, offsetYA, scaleA);

        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var figure1 = GetPixelsB(new List<Pixel> {
                new Pixel(-16, 4, Color.Green),
                new Pixel(-8, 4, Color.Green),
                new Pixel(-12, 24, Color.Green),
                },
                new Pixel(-3 * 4, 2 * 4, Color.Green));
            paintPixels(graphics, figure1, offsetXA, offsetYA, scaleA);

            var figure2 = GetPixelsB(new List<Pixel> {
                new Pixel(-10, 0, Color.Orange),
                new Pixel(-10, 6, Color.Orange),
                new Pixel(2, 6, Color.Orange),
                new Pixel(2, 0, Color.Orange),
                },
                new Pixel(-4, 4, Color.Orange));
            paintPixels(graphics, figure2, offsetXA, offsetYA, scaleA);

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
            paintPixels(graphics, figure3, offsetXA, offsetYA, scaleA);

            var figure4 = GetPixelsB(new List<Pixel> {
                new Pixel(-10, 6, Color.Red),
                new Pixel(-4, 10, Color.Red),
                new Pixel(2, 6, Color.Red),
                },
                new Pixel(-4, 8, Color.Red));
            paintPixels(graphics, figure4, offsetXA, offsetYA, scaleA);

            var figure5 = GetPixelsB(new List<Pixel> {
                new Pixel(-6, 2, Color.Yellow),
                new Pixel(-6, 4, Color.Yellow),
                new Pixel(-4, 4, Color.Yellow),
                new Pixel(-4, 2, Color.Yellow),
                },
                new Pixel(-5, 3, Color.Yellow));
            paintPixels(graphics, figure5, offsetXA, offsetYA, scaleA);

            var figure6 = GetPixelsB(new List<Pixel> {
                new Pixel(-2, 0, Color.SaddleBrown),
                new Pixel(-2, 4, Color.SaddleBrown),
                new Pixel(0, 4, Color.SaddleBrown),
                new Pixel(0, 0, Color.SaddleBrown),
                },
                new Pixel(-1, 2, Color.SaddleBrown));
            paintPixels(graphics, figure6, offsetXA, offsetYA, scaleA);

            var line1 = PaintLineCDA(-12, 0, -12, 16, Color.Black);
            paintPixels(graphics, line1, offsetXA, offsetYA, scaleA);

            var line2 = PaintLineCDA(-12, 6, -10, 8, Color.Black);
            line2.AddRange(
                PaintLineCDA(-12, 6, -14, 8, Color.Black)
            );
            paintPixels(graphics, line2, offsetXA, offsetYA, scaleA);

            var line3 = PaintLineCDA(-12, 8, -10, 10, Color.Black);
            line3.AddRange(
                PaintLineCDA(-12, 8, -14, 10, Color.Black)
            );
            paintPixels(graphics, line3, offsetXA, offsetYA, scaleA);
        }

        private void PictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var figure1 = GetPixelsC(new List<Pixel> {
                new Pixel(-16, 4, Color.Green),
                new Pixel(-8, 4, Color.Green),
                new Pixel(-12, 24, Color.Green),
                },
                new Pixel(-3 * 4, 2 * 4, Color.Green));
            paintPixels(graphics, figure1, offsetXA, offsetYA, scaleA);
            
            var figure2 = GetPixelsC(new List<Pixel> {
                new Pixel(-10, 0, Color.Orange),
                new Pixel(-10, 6, Color.Orange),
                new Pixel(2, 6, Color.Orange),
                new Pixel(2, 0, Color.Orange),
                },
                new Pixel(-4, 4, Color.Orange));
            paintPixels(graphics, figure2, offsetXA, offsetYA, scaleA);

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
            paintPixels(graphics, figure3, offsetXA, offsetYA, scaleA);

            var figure4 = GetPixelsC(new List<Pixel> {
                new Pixel(-10, 6, Color.Red),
                new Pixel(-4, 10, Color.Red),
                new Pixel(2, 6, Color.Red),
                },
                new Pixel(-4, 8, Color.Red));
            paintPixels(graphics, figure4, offsetXA, offsetYA, scaleA);

            var figure5 = GetPixelsC(new List<Pixel> {
                new Pixel(-6, 2, Color.Yellow),
                new Pixel(-6, 4, Color.Yellow),
                new Pixel(-4, 4, Color.Yellow),
                new Pixel(-4, 2, Color.Yellow),
                },
                new Pixel(-5, 3, Color.Yellow));
            paintPixels(graphics, figure5, offsetXA, offsetYA, scaleA);

            var figure6 = GetPixelsC(new List<Pixel> {
                new Pixel(-2, 0, Color.SaddleBrown),
                new Pixel(-2, 4, Color.SaddleBrown),
                new Pixel(0, 4, Color.SaddleBrown),
                new Pixel(0, 0, Color.SaddleBrown),
                },
                new Pixel(-1, 2, Color.SaddleBrown));
            paintPixels(graphics, figure6, offsetXA, offsetYA, scaleA);

            var line1 = PaintLineBrezenthema(-12, 0, -12, 16, Color.Black);
            paintPixels(graphics, line1, offsetXA, offsetYA, scaleA);

            var line2 = PaintLineBrezenthema(-12, 6, -10, 8, Color.Black);
            line2.AddRange(
                PaintLineBrezenthema(-12, 6, -14, 8, Color.Black)
            );
            paintPixels(graphics, line2, offsetXA, offsetYA, scaleA);

            var line3 = PaintLineBrezenthema(-12, 8, -10, 10, Color.Black);
            line3.AddRange(
                PaintLineBrezenthema(-12, 8, -14, 10, Color.Black)
            );
            paintPixels(graphics, line3, offsetXA, offsetYA, scaleA);
           // stopwatch.Stop();
            //TimeSpan elapsedTime = stopwatch.Elapsed;

           // timeMain = elapsedTime.TotalMilliseconds;
            //Console.WriteLine(" Time Reference: " + timeMain + " Count total: " + pixelOutLineReference.Count());
        }


        List<Pixel> PaintLineMain(int x1, int y1, int x2, int y2, Color color)
        {
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
            return pixels;
        }

        List<Pixel> PaintLineCDA(int x1, int y1, int x2, int y2, Color color)
        {
            List<Pixel> pixels = new List<Pixel>();

            int length = Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            double dx = (double) (x2 - x1) / length;
            double dy = (double) (y2 - y1) / length;
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
            return pixels;
        }

        List<Pixel> PaintLineBrezenthema(int x1, int y1, int x2, int y2, Color color)
        {
            List<Pixel> pixels = new List<Pixel>();
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;

            int err = dx - dy;

            while (true)
            {
                pixels.Add(new Pixel(x1, y1, color));

                if (x1 == x2 && y1 == y2) break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }
            return pixels;
        }


        public List<Pixel> FillA(HashSet<Pixel> conture, Pixel seedPixel)
        {

            Stack<Pixel> stack = new Stack<Pixel>();
            stack.Push(seedPixel);

            List<Pixel> insidePixels = new List<Pixel>();
            Color color = seedPixel.color;

            while (stack.Count > 0)
            {
                Pixel pixel = stack.Pop();
                int x = pixel.x;
                int y = pixel.y;

                // ѕропуск пиксел€, если он уже закрашен или €вл€етс€ частью контура
                if (conture.Contains(pixel) || insidePixels.Contains(pixel))
                    continue;

                // »щем левую границу интервала
                int left = x;
                while (!conture.Contains(new Pixel(left, y, color)) && !insidePixels.Contains(new Pixel(left, y, color)))
                {
                    left--;
                }
                left++;

                // »щем правую границу интервала
                int right = x;
                while (!conture.Contains(new Pixel(right, y, color)) && !insidePixels.Contains(new Pixel(right, y, color)))
                {
                    right++;
                }
                right--;

                // ƒобавл€ем пиксели интервала в список закрашиваемых
                for (int i = left; i <= right; i++)
                {
                    Pixel nPixel = new Pixel(i, y, color);
                    insidePixels.Add(nPixel);
                }

                // ѕровер€ем верхний и нижний р€ды дл€ интервалов
                for (int i = left; i <= right; i++)
                {
                    // ¬ерхний р€д
                    if (!conture.Contains(new Pixel(i, y - 1, color)) && !insidePixels.Contains(new Pixel(i, y - 1, color)))
                    {
                        stack.Push(new Pixel(i, y - 1, color));
                    }

                    // Ќижний р€д
                    if (!conture.Contains(new Pixel(i, y + 1, color)) && !insidePixels.Contains(new Pixel(i, y + 1, color)))
                    {
                        stack.Push(new Pixel(i, y + 1, color));
                    }
                }
            }

            return insidePixels; // ¬озвращаем множество точек, которые необходимо закрасить
        }


        public List<Pixel> FillB(HashSet<Pixel> conture, Pixel seedPixel)
        {
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

            return filledPixels;
        }

        public List<Pixel> FillC(HashSet<Pixel> contour, Pixel seedPixel)
        {
            var stack = new Stack<Pixel>();
            var filledPixels = new HashSet<Pixel>();

            // «атравочный пиксель
            stack.Push(seedPixel);

            // ¬осьмисв€зные направлени€
            var directions = new List<(int dx, int dy)>
        {
            (1, 0), (0, 1), (-1, 0), (0, -1),   // основные направлени€
            //(1, 1), (-1, 1), (-1, -1), (1, -1)  // диагональные направлени€
        };

            while (stack.Count > 0)
            {
                var currentPixel = stack.Pop();

                // ѕропускаем, если пиксель уже закрашен или €вл€етс€ частью контура
                if (filledPixels.Contains(currentPixel) || contour.Contains(currentPixel))
                    continue;

                // ƒобавл€ем пиксель в список закрашенных
                filledPixels.Add(currentPixel);

                // ƒобавл€ем соседние пиксели по всем 8 направлени€м
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

            return new List<Pixel>(filledPixels);
        }

        public List<Pixel> GetPixelsA(List<Pixel> vertices, Pixel seedPixel)
        {
            var contourPixels = new HashSet<Pixel>();
            for (int i = 0; i < vertices.Count; i++)
            {
                var start = vertices[i];
                var end = vertices[(i + 1) % vertices.Count];
                contourPixels.UnionWith(PaintLineMain(start.x, start.y, end.x, end.y, start.color));
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
