using System;
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

            this.PaintLineMain(-4, 1, -2, 1, Color.Green);
            this.PaintLineMain(-2, 1, -3, 6, Color.Green);
            this.PaintLineMain(-4, 1, -3, 6, Color.Green);
            paintPixels(graphics, pixelOutLineA, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillA(pixelOutLineA, new Pixel(-3 * 4, 2 * 4, Color.Green)), offsetXA, offsetYA, scaleA);
            pixelOutLineA.Clear();

            
            this.PaintLineMain(-2.5, 0, -2.5, 1.5, Color.Orange);
            this.PaintLineMain(-2.5, 1.5, 0.5, 1.5, Color.Orange);
            this.PaintLineMain(0.5, 1.5, 0.5, 0, Color.Orange);
            this.PaintLineMain(0.5, 0, -2.5, 0, Color.Orange);
            paintPixels(graphics, pixelOutLineA, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillA(pixelOutLineA, new Pixel(-1 * 4, 1 * 4, Color.Orange)), offsetXA, offsetYA, scaleA);
            pixelOutLineA.Clear();
            

            this.PaintLineMain(0, 2.5, -0.5, 3, Color.LightGoldenrodYellow);
            this.PaintLineMain(-0.5, 3, -1, 3, Color.LightGoldenrodYellow);
            this.PaintLineMain(-1, 3, -1.5, 2.5, Color.LightGoldenrodYellow);
            this.PaintLineMain(-1.5, 2.5, -1.5, 2, Color.LightGoldenrodYellow);
            this.PaintLineMain(-1.5, 2, -1, 1.5, Color.LightGoldenrodYellow);
            this.PaintLineMain(-1, 1.5, -0.5, 1.5, Color.LightGoldenrodYellow);
            this.PaintLineMain(-0.5, 1.5, 0, 2.5, Color.LightGoldenrodYellow);
            paintPixels(graphics, pixelOutLineA, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillA(pixelOutLineA, new Pixel(-1 * 4, 2 * 4, Color.LightGoldenrodYellow)), offsetXA, offsetYA, scaleA);
            pixelOutLineA.Clear();
            
            this.PaintLineMain(-2.5, 1.5, -1, 2.5, Color.Red);
            this.PaintLineMain(-1, 2.5, 0.5, 1.5, Color.Red);
            this.PaintLineMain(0.5, 1.5, -2.5, 1.5, Color.Red);
            paintPixels(graphics, pixelOutLineA, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillA(pixelOutLineA, new Pixel(-1 * 4, 2 * 4, Color.Red)), offsetXA, offsetYA, scaleA);
            pixelOutLineA.Clear();
            
            this.PaintLineMain(-1.5, 0.5, -1.5, 1, Color.Yellow);
            this.PaintLineMain(-1.5, 1, -1, 1, Color.Yellow);
            this.PaintLineMain(-1, 1, -1, 0.5, Color.Yellow);
            this.PaintLineMain(-1, 0.5, -1.5, 0.5, Color.Yellow);
            paintPixels(graphics, pixelOutLineA, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillA(pixelOutLineA, new Pixel(-5, 3, Color.Yellow)), offsetXA, offsetYA, scaleA);
            pixelOutLineA.Clear();
            
            this.PaintLineMain(-0.5, 0, -0.5, 1, Color.SaddleBrown);
            this.PaintLineMain(-0.5, 1, 0, 1, Color.SaddleBrown);
            this.PaintLineMain(0, 1, 0, 0, Color.SaddleBrown);
            this.PaintLineMain(0, 0, -0.5, 0, Color.SaddleBrown);
            paintPixels(graphics, pixelOutLineA, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillA(pixelOutLineA, new Pixel(-1, 2, Color.SaddleBrown)), offsetXA, offsetYA, scaleA);
            pixelOutLineA.Clear();
            
            this.PaintLineMain(-3, 0, -3, 4, Color.Black);
            paintPixels(graphics, pixelOutLineA, offsetXA, offsetYA, scaleA);
            pixelOutLineA.Clear();

            this.PaintLineMain(-3, 1.5, -2.5, 2, Color.Black);
            this.PaintLineMain(-3, 1.5, -3.5, 2, Color.Black);
            paintPixels(graphics, pixelOutLineA, offsetXA, offsetYA, scaleA);
            pixelOutLineA.Clear();

            this.PaintLineMain(-3, 2, -2.5, 2.5, Color.Black);
            this.PaintLineMain(-3, 2, -3.5, 2.5, Color.Black);
            pixelOutLineA.Clear();

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            timeA = elapsedTime.TotalMilliseconds;

            List<Pixel> diff = CalculateDiff(pixelOutLineA, new List<Pixel>(), pixelOutLineReference, new List<Pixel>());
            countDiffA = diff.Count();
                       
        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            this.PaintLineCDA(-4, 1, -2, 1, Color.Green);
            this.PaintLineCDA(-2, 1, -3, 6, Color.Green);
            this.PaintLineCDA(-4, 1, -3, 6, Color.Green);
            paintPixels(graphics, pixelOutLineB, offsetXA, offsetYA, scaleA);
            paintPixels(graphics,
                 FillB(pixelOutLineB, new Pixel(-3 * 4, 2 * 4, Color.Green))
                , offsetXA, offsetYA, scaleA);
            pixelOutLineB.Clear();

            this.PaintLineCDA(-2.5, 0, -2.5, 1.5, Color.Orange);
            this.PaintLineCDA(-2.5, 1.5, 0.5, 1.5, Color.Orange);
            this.PaintLineCDA(0.5, 1.5, 0.5, 0, Color.Orange);
            this.PaintLineCDA(0.5, 0, -2.5, 0, Color.Orange);
            paintPixels(graphics, pixelOutLineB, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillB(pixelOutLineB, new Pixel(-1 * 4, 1 * 4, Color.Orange)), offsetXA, offsetYA, scaleA);
            pixelOutLineB.Clear();


            this.PaintLineCDA(0, 2.5, -0.5, 3, Color.LightGoldenrodYellow);
            this.PaintLineCDA(-0.5, 3, -1, 3, Color.LightGoldenrodYellow);
            this.PaintLineCDA(-1, 3, -1.5, 2.5, Color.LightGoldenrodYellow);
            this.PaintLineCDA(-1.5, 2.5, -1.5, 2, Color.LightGoldenrodYellow);
            this.PaintLineCDA(-1.5, 2, -1, 1.5, Color.LightGoldenrodYellow);
            this.PaintLineCDA(-1, 1.5, -0.5, 1.5, Color.LightGoldenrodYellow);
            this.PaintLineCDA(-0.5, 1.5, 0, 2.5, Color.LightGoldenrodYellow);
            paintPixels(graphics, pixelOutLineB, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillB(pixelOutLineB, new Pixel(-1 * 4, 2 * 4, Color.LightGoldenrodYellow)), offsetXA, offsetYA, scaleA);
            pixelOutLineB.Clear();

            this.PaintLineCDA(-2.5, 1.5, -1, 2.5, Color.Red);
            this.PaintLineCDA(-1, 2.5, 0.5, 1.5, Color.Red);
            this.PaintLineCDA(0.5, 1.5, -2.5, 1.5, Color.Red);
            paintPixels(graphics, pixelOutLineB, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillB(pixelOutLineB, new Pixel(-1 * 4, 2 * 4, Color.Red)), offsetXA, offsetYA, scaleA);
            pixelOutLineB.Clear();

            this.PaintLineCDA(-1.5, 0.5, -1.5, 1, Color.Yellow);
            this.PaintLineCDA(-1.5, 1, -1, 1, Color.Yellow);
            this.PaintLineCDA(-1, 1, -1, 0.5, Color.Yellow);
            this.PaintLineCDA(-1, 0.5, -1.5, 0.5, Color.Yellow);
            paintPixels(graphics, pixelOutLineB, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillB(pixelOutLineB, new Pixel(-5, 3, Color.Yellow)), offsetXA, offsetYA, scaleA);
            pixelOutLineB.Clear();

            this.PaintLineCDA(-0.5, 0, -0.5, 1, Color.SaddleBrown);
            this.PaintLineCDA(-0.5, 1, 0, 1, Color.SaddleBrown);
            this.PaintLineCDA(0, 1, 0, 0, Color.SaddleBrown);
            this.PaintLineCDA(0, 0, -0.5, 0, Color.SaddleBrown);
            paintPixels(graphics, pixelOutLineB, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillB(pixelOutLineB, new Pixel(-1, 2, Color.SaddleBrown)), offsetXA, offsetYA, scaleA);
            pixelOutLineB.Clear();

            this.PaintLineCDA(-3, 0, -3, 4, Color.Black);
            paintPixels(graphics, pixelOutLineB, offsetXA, offsetYA, scaleA);
            pixelOutLineB.Clear();

            this.PaintLineCDA(-3, 1.5, -2.5, 2, Color.Black);
            this.PaintLineCDA(-3, 1.5, -3.5, 2, Color.Black);
            paintPixels(graphics, pixelOutLineB, offsetXA, offsetYA, scaleA);
            pixelOutLineB.Clear();

            this.PaintLineCDA(-3, 2, -2.5, 2.5, Color.Black);
            this.PaintLineCDA(-3, 2, -3.5, 2.5, Color.Black);
            pixelOutLineB.Clear();
            
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            //List<Pixel> diff = CalculateDiff(pixelOutLineA, new List<Pixel>(), pixelOutLineReference, new List<Pixel>());
            //countDiffA = diff.Count();
            timeB = elapsedTime.TotalMilliseconds;
            List<Pixel> diff = CalculateDiff(pixelOutLineB, new List<Pixel>(), pixelOutLineReference, new List<Pixel>());
            Console.WriteLine("Diff B: " + diff.Count() + " Time B: " + timeB + "Count total: " + pixelOutLineB.Count());
        }

        private void PictureBox3_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics graphics = e.Graphics;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            

            this.PaintLineBrezenthema(-4, 1, -2, 1, Color.Green);
            this.PaintLineBrezenthema(-2, 1, -3, 6, Color.Green);
            this.PaintLineBrezenthema(-4, 1, -3, 6, Color.Green);

            paintPixels(graphics, pixelOutLineReference, offsetXA, offsetYA, scaleA);
            
            paintPixels(graphics, FillArea(pixelOutLineReference, new Pixel(-3 * 4, 2 * 4, Color.Green)), offsetXA, offsetYA, scaleA);
            /*
            pixelOutLineReference.Clear();
            
            this.PaintLineBrezenthema(-2.5, 0, -2.5, 1.5, Color.Orange);
            this.PaintLineBrezenthema(-2.5, 1.5, 0.5, 1.5, Color.Orange);
            this.PaintLineBrezenthema(0.5, 1.5, 0.5, 0, Color.Orange);
            this.PaintLineBrezenthema(0.5, 0, -2.5, 0, Color.Orange);
            paintPixels(graphics, pixelOutLineReference, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillC(pixelOutLineReference, new Pixel(-1 * 4, 1 * 4, Color.Orange)), offsetXA, offsetYA, scaleA);
            pixelOutLineReference.Clear();

            this.PaintLineBrezenthema(0, 2.5, -0.5, 3, Color.LightGoldenrodYellow);
            this.PaintLineBrezenthema(-0.5, 3, -1, 3, Color.LightGoldenrodYellow);
            this.PaintLineBrezenthema(-1, 3, -1.5, 2.5, Color.LightGoldenrodYellow);
            this.PaintLineBrezenthema(-1.5, 2.5, -1.5, 2, Color.LightGoldenrodYellow);
            this.PaintLineBrezenthema(-1.5, 2, -1, 1.5, Color.LightGoldenrodYellow);
            this.PaintLineBrezenthema(-1, 1.5, -0.5, 1.5, Color.LightGoldenrodYellow);
            this.PaintLineBrezenthema(-0.5, 1.5, 0, 2.5, Color.LightGoldenrodYellow);
            paintPixels(graphics, pixelOutLineReference, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillC(pixelOutLineReference, new Pixel(-1 * 4, 2 * 4, Color.LightGoldenrodYellow)), offsetXA, offsetYA, scaleA);
            pixelOutLineReference.Clear();

            this.PaintLineBrezenthema(-2.5, 1.5, -1, 2.5, Color.Red);
            this.PaintLineBrezenthema(-1, 2.5, 0.5, 1.5, Color.Red);
            this.PaintLineBrezenthema(0.5, 1.5, -2.5, 1.5, Color.Red);
            paintPixels(graphics, pixelOutLineReference, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillC(pixelOutLineReference, new Pixel(-1 * 4, 9, Color.Red)), offsetXA, offsetYA, scaleA);
            pixelOutLineReference.Clear();
            

            this.PaintLineBrezenthema(-1.5, 0.5, -1.5, 1, Color.Yellow);
            this.PaintLineBrezenthema(-1.5, 1, -1, 1, Color.Yellow);
            this.PaintLineBrezenthema(-1, 1, -1, 0.5, Color.Yellow);
            this.PaintLineBrezenthema(-1, 0.5, -1.5, 0.5, Color.Yellow);
            paintPixels(graphics, pixelOutLineReference, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillC(pixelOutLineReference, new Pixel(-5, 3, Color.Yellow)), offsetXA, offsetYA, scaleA);
            pixelOutLineReference.Clear();

            this.PaintLineBrezenthema(-0.5, 0, -0.5, 1, Color.SaddleBrown);
            this.PaintLineBrezenthema(-0.5, 1, 0, 1, Color.SaddleBrown);
            this.PaintLineBrezenthema(0, 1, 0, 0, Color.SaddleBrown);
            this.PaintLineBrezenthema(0, 0, -0.5, 0, Color.SaddleBrown);
            paintPixels(graphics, pixelOutLineReference, offsetXA, offsetYA, scaleA);
            paintPixels(graphics, FillC(pixelOutLineReference, new Pixel(-1, 2, Color.SaddleBrown)), offsetXA, offsetYA, scaleA);
            pixelOutLineReference.Clear();

            this.PaintLineBrezenthema(-3, 0, -3, 4, Color.Black);
            paintPixels(graphics, pixelOutLineReference, offsetXA, offsetYA, scaleA);
            pixelOutLineReference.Clear();

            this.PaintLineBrezenthema(-3, 1.5, -2.5, 2, Color.Black);
            this.PaintLineBrezenthema(-3, 1.5, -3.5, 2, Color.Black);
            paintPixels(graphics, pixelOutLineReference, offsetXA, offsetYA, scaleA);
            pixelOutLineReference.Clear();

            this.PaintLineBrezenthema(-3, 2, -2.5, 2.5, Color.Black);
            this.PaintLineBrezenthema(-3, 2, -3.5, 2.5, Color.Black);
            pixelOutLineReference.Clear();
            */
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            timeMain = elapsedTime.TotalMilliseconds;
            Console.WriteLine(" Time Reference: " + timeMain + " Count total: " + pixelOutLineReference.Count());
        }


        void PaintLineMain(double x1, double y1, double x2, double y2, Color color)
        {
            x1 *= 4;
            x2 *= 4;
            y1 *= 4;
            y2 *= 4;
            double dx = x2 - x1;
            double dy = y2 - y1;

            int absDx = (int)Math.Abs(dx);
            int absDy = (int)Math.Abs(dy);

            int signX = dx > 0 ? 1 : (dx < 0 ? -1 : 0);
            int signY = dy > 0 ? 1 : (dy < 0 ? -1 : 0);

            if (absDx > absDy)
            {
                double y = y1;
                double k = (double)dy / dx;

                for (double x = x1; x != x2 + signX; x += signX)
                {
                    pixelOutLineA.Add(new Pixel((int)x, (int)Math.Round(y), color));
                    y += k * signX;
                }
            }
            else
            {
                double x = x1;
                double k = (double)dx / dy;

                for (double y = y1; y != y2 + signY; y += signY)
                {
                    pixelOutLineA.Add(new Pixel((int)Math.Round(x), (int)y, color));
                    x += k * signY;
                }
            }
        }

        void PaintLineCDA(double x1, double y1, double x2, double y2, Color color)
        {
            x1 *= 4;
            x2 *= 4;
            y1 *= 4;
            y2 *= 4;
            double length = Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            double dx = (x2 - x1) / length;
            double dy = (y2 - y1) / length;
            double x = x1;
            double y = y1;

            int i = 1;
            while (i <= length)
            {
                pixelOutLineB.Add(new Pixel((int)Math.Round(x, 0), (int)Math.Round(y, 0), color));
                x += dx;
                y += dy;
                i++;
            }
        }

        void PaintLineBrezenthema(double x1, double y1, double x2, double y2, Color color)
        {
            // Приведение координат к целым после умножения на 2
            int xStart = (int)(x1 * 4);
            int yStart = (int)(y1 * 4);
            int xEnd = (int)(x2 * 4);
            int yEnd = (int)(y2 * 4);

            int dx = Math.Abs(xEnd - xStart);
            int dy = Math.Abs(yEnd - yStart);

            int sx = xStart < xEnd ? 1 : -1;
            int sy = yStart < yEnd ? 1 : -1;

            int err = dx - dy;

            while (true)
            {
                pixelOutLineReference.Add(new Pixel(xStart, yStart, color));

                if (xStart == xEnd && yStart == yEnd) break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    xStart += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    yStart += sy;
                }
            }
            
        }



        public List<Pixel> FillA(List<Pixel> conture, Pixel seedPixel)
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
                    if (!conture.Contains(new Pixel(i, y - 1, color))  && !insidePixels.Contains(new Pixel(i, y - 1, color)))
                    {
                        stack.Push(new Pixel(i, y - 1, color));
                    }

                    // Нижний ряд
                    if (!conture.Contains(new Pixel(i, y + 1, color))  && !insidePixels.Contains(new Pixel(i, y + 1, color)))
                    {
                        stack.Push(new Pixel(i, y + 1, color));
                    }
                }
            }

            return insidePixels; // Возвращаем множество точек, которые необходимо закрасить
        }


        public List<Pixel> FillB(List<Pixel> conture, Pixel seedPixel)
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

        public static List<Pixel> FillArea(List<Pixel> pixels, Pixel seedPixel)
        {
            var stack = new Stack<Pixel>();
            var filledPixels = new HashSet<Pixel>();
            var targetColor = seedPixel.color;

            // Восьмисвязные направления
            var directions = new List<(int, int)>
        {
            (1, 0), (0, 1), (-1, 0), (0, -1),
            (1, 1), (-1, 1), (-1, -1), (1, -1)
        };

            stack.Push(seedPixel);

            while (stack.Count > 0)
            {
                var currentPixel = stack.Pop();

                if (filledPixels.Contains(currentPixel)) continue;

                filledPixels.Add(currentPixel);
                currentPixel.color = targetColor;

                foreach (var (dx, dy) in directions)
                {
                    int newX = currentPixel.x + dx;
                    int newY = currentPixel.y + dy;

                    var adjacentPixel = pixels.FirstOrDefault(p => p.x == newX && p.y == newY);

                    if (adjacentPixel != null &&
                        adjacentPixel.color != targetColor &&
                        !filledPixels.Contains(adjacentPixel))
                    {
                        stack.Push(adjacentPixel);
                    }
                }
            }

            return filledPixels.ToList();
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
                return x == pixel.x && y == pixel.y && color == pixel.color;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

    }
}
