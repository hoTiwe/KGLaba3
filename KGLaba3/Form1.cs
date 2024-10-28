using System;
using System.Diagnostics;
using System.Drawing;

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
        int scaleA = 20, scaleB = 20, scaleReference = 20;
        double m1 = 0;
        double m2 = 0;

        int offsetXA = 5, offsetYA = 5, offsetXB = 5, offsetYB = 5;
        public Form1()
        {
            InitializeComponent();
            getPixelsReference();
            getPixelsA();
            getPixelsB();
        }

        void getPixelsA()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            this.PaintLineMain(-4, 1, -2, 1, Color.Green);
            this.PaintLineMain(-2, 1, -3, 6, Color.Green);
            this.PaintLineMain(-4, 1, -3, 6, Color.Green);


            this.PaintLineMain(-2.5, 0, -2.5, 1.5, Color.Orange);
            this.PaintLineMain(-2.5, 1.5, 0.5, 1.5, Color.Orange);
            this.PaintLineMain(0.5, 1.5, 0.5, 0, Color.Orange);
            this.PaintLineMain(0.5, 0, -2.5, 0, Color.Orange);

            this.PaintLineMain(0, 2.5, -0.5, 3, Color.LightYellow);
            this.PaintLineMain(-0.5, 3, -1, 3, Color.LightYellow);
            this.PaintLineMain(-1, 3, -1.5, 2.5, Color.LightYellow);
            this.PaintLineMain(-1.5, 2.5, -1.5, 2, Color.LightYellow);
            this.PaintLineMain(-1.5, 2, -1, 1.5, Color.LightYellow);
            this.PaintLineMain(-1, 1.5, -0.5, 1.5, Color.LightYellow);
            this.PaintLineMain(-0.5, 1.5, -4, 1, Color.LightYellow);

            this.PaintLineMain(-2.5, 1.5, -1, 2.5, Color.Red);
            this.PaintLineMain(-1, 2.5, 0.5, 1.5, Color.Red);
            this.PaintLineMain(0.5, 1.5, -2.5, 1.5, Color.Red);

            this.PaintLineMain(-1.5, 0.5, -1.5, 1, Color.Yellow);
            this.PaintLineMain(-1.5, 1, -1, 1, Color.Yellow);
            this.PaintLineMain(-1, 1, -1, 0.5, Color.Yellow);
            this.PaintLineMain(-1, 0.5, -1.5, 0.5, Color.Yellow);

            this.PaintLineMain(-0.5, 0, -0.5, 1, Color.SaddleBrown);
            this.PaintLineMain(-0.5, 1, 0, 1, Color.SaddleBrown);
            this.PaintLineMain(0, 1, 0, 0, Color.SaddleBrown);
            this.PaintLineMain(0, 0, -0.5, 0, Color.SaddleBrown);

            this.PaintLineMain(-3, 0, -3, 4, Color.Black);

            this.PaintLineMain(-3, -1.5, -2.5, -2, Color.Black);
            this.PaintLineMain(-3, -1.5, -3.5, -2, Color.Black);

            this.PaintLineMain(-3, -2, -2.5, 2.5, Color.Black);
            this.PaintLineMain(-3, -2, -3.5, 2.5, Color.Black);

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            timeA = elapsedTime.TotalMilliseconds;

            List<Pixel> diff = CalculateDiff(pixelOutLineA, new List<Pixel>(), pixelOutLineReference, new List<Pixel>());
            countDiffA = diff.Count();
            Console.WriteLine("Diff A: " + diff.Count() + " Time A: " + timeA + "Count total: " + pixelOutLineA.Count());

        }

        void getPixelsB()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            this.PaintLineCDA(-4, 1, -2, 1, Color.Green);
            this.PaintLineCDA(-2, 1, -3, 6, Color.Green);
            this.PaintLineCDA(-4, 1, -3, 6, Color.Green);

            this.PaintLineCDA(-2.5, 0, -2.5, 1.5, Color.Orange);
            this.PaintLineCDA(-2.5, 1.5, 0.5, 1.5, Color.Orange);
            this.PaintLineCDA(0.5, 1.5, 0.5, 0, Color.Orange);
            this.PaintLineCDA(0.5, 0, -2.5, 0, Color.Orange);

            this.PaintLineCDA(0, 2.5, -0.5, 3, Color.LightYellow);
            this.PaintLineCDA(-0.5, 3, -1, 3, Color.LightYellow);
            this.PaintLineCDA(-1, 3, -1.5, 2.5, Color.LightYellow);
            this.PaintLineCDA(-1.5, 2.5, -1.5, 2, Color.LightYellow);
            this.PaintLineCDA(-1.5, 2, -1, 1.5, Color.LightYellow);
            this.PaintLineCDA(-1, 1.5, -0.5, 1.5, Color.LightYellow);
            this.PaintLineCDA(-0.5, 1.5, -4, 1, Color.LightYellow);

            this.PaintLineCDA(-2.5, 1.5, -1, 2.5, Color.Red);
            this.PaintLineCDA(-1, 2.5, 0.5, 1.5, Color.Red);
            this.PaintLineCDA(0.5, 1.5, -2.5, 1.5, Color.Red);

            this.PaintLineCDA(-1.5, 0.5, -1.5, 1, Color.Yellow);
            this.PaintLineCDA(-1.5, 1, -1, 1, Color.Yellow);
            this.PaintLineCDA(-1, 1, -1, 0.5, Color.Yellow);
            this.PaintLineCDA(-1, 0.5, -1.5, 0.5, Color.Yellow);

            this.PaintLineCDA(-0.5, 0, -0.5, 1, Color.SaddleBrown);
            this.PaintLineCDA(-0.5, 1, 0, 1, Color.SaddleBrown);
            this.PaintLineCDA(0, 1, 0, 0, Color.SaddleBrown);
            this.PaintLineCDA(0, 0, -0.5, 0, Color.SaddleBrown);

            this.PaintLineCDA(-3, 0, -3, 4, Color.Black);

            this.PaintLineCDA(-3, -1.5, -2.5, -2, Color.Black);
            this.PaintLineCDA(-3, -1.5, -3.5, -2, Color.Black);

            this.PaintLineCDA(-3, -2, -2.5, 2.5, Color.Black);
            this.PaintLineCDA(-3, -2, -3.5, 2.5, Color.Black);

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            timeB = elapsedTime.TotalMilliseconds;
            List<Pixel> diff = CalculateDiff(pixelOutLineB, new List<Pixel>(), pixelOutLineReference, new List<Pixel>());
            Console.WriteLine("Diff B: " + diff.Count() + " Time B: " + timeB + "Count total: " + pixelOutLineB.Count());
        }

        void getPixelsReference()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            this.PaintLineBrezenthema(-4, 1, -2, 1, Color.Green);
            this.PaintLineBrezenthema(-2, 1, -3, 6, Color.Green);
            this.PaintLineBrezenthema(-4, 1, -3, 6, Color.Green);
            /*
            this.PaintLineBrezenthema(-2.5, 0, -2.5, 1.5, Color.Orange);
            this.PaintLineBrezenthema(-2.5, 1.5, 0.5, 1.5, Color.Orange);
            this.PaintLineBrezenthema(0.5, 1.5, 0.5, 0, Color.Orange);
            this.PaintLineBrezenthema(0.5, 0, -2.5, 0, Color.Orange);

            this.PaintLineBrezenthema(0, 2.5, -0.5, 3, Color.LightYellow);
            this.PaintLineBrezenthema(-0.5, 3, -1, 3, Color.LightYellow);
            this.PaintLineBrezenthema(-1, 3, -1.5, 2.5, Color.LightYellow);
            this.PaintLineBrezenthema(-1.5, 2.5, -1.5, 2, Color.LightYellow);
            this.PaintLineBrezenthema(-1.5, 2, -1, 1.5, Color.LightYellow);
            this.PaintLineBrezenthema(-1, 1.5, -0.5, 1.5, Color.LightYellow);
            this.PaintLineBrezenthema(-0.5, 1.5, -4, 1, Color.LightYellow);

            this.PaintLineBrezenthema(-2.5, 1.5, -1, 2.5, Color.Red);
            this.PaintLineBrezenthema(-1, 2.5, 0.5, 1.5, Color.Red);
            this.PaintLineBrezenthema(0.5, 1.5, -2.5, 1.5, Color.Red);
            this.PaintLineBrezenthema(-1.5, 0.5, -1.5, 1, Color.Yellow);
            this.PaintLineBrezenthema(-1.5, 1, -1, 1, Color.Yellow);
            this.PaintLineBrezenthema(-1, 1, -1, 0.5, Color.Yellow);
            this.PaintLineBrezenthema(-1, 0.5, -1.5, 0.5, Color.Yellow);

            this.PaintLineBrezenthema(-0.5, 0, -0.5, 1, Color.SaddleBrown);
            this.PaintLineBrezenthema(-0.5, 1, 0, 1, Color.SaddleBrown);
            this.PaintLineBrezenthema(0, 1, 0, 0, Color.SaddleBrown);
            this.PaintLineBrezenthema(0, 0, -0.5, 0, Color.SaddleBrown);

            this.PaintLineBrezenthema(-3, 0, -3, 4, Color.Black);

            this.PaintLineBrezenthema(-3, -1.5, -2.5, -2, Color.Black);
            this.PaintLineBrezenthema(-3, -1.5, -3.5, -2, Color.Black);

            this.PaintLineBrezenthema(-3, -2, -2.5, 2.5, Color.Black);
            this.PaintLineBrezenthema(-3, -2, -3.5, 2.5, Color.Black);*/

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            timeMain = elapsedTime.TotalMilliseconds;
            Console.WriteLine(" Time Reference: " + timeMain + " Count total: " + pixelOutLineReference.Count());

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
            for (int i = 0; i < pixelOutLineA.Count(); i++)
            {
                graphics.FillRectangle(new SolidBrush(pixelOutLineA[i].color), (pixelOutLineA[i].x + offsetXA * scaleA), (pixelOutLineA[i].y + offsetYA * scaleA), 1 * scaleA, 1 * scaleA);
            }
        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int i = 0; i < pixelOutLineB.Count(); i++)
            {
                graphics.FillRectangle(new SolidBrush(pixelOutLineB[i].color), (pixelOutLineB[i].x + offsetXB * scaleB), (pixelOutLineB[i].y + offsetYB * scaleB), 1 * scaleB, 1 * scaleB);
            }
        }

        private void PictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int i = 0; i < pixelOutLineReference.Count(); i++)
            {
                graphics.FillRectangle(new SolidBrush(pixelOutLineReference[i].color), (pixelOutLineReference[i].x + offsetXB * scaleB), (pixelOutLineReference[i].y + offsetYB * scaleB), 1, 1);
            }
        }


        void PaintLineMain(double x1, double y1, double x2, double y2, Color color)
        {
            x1 *= scaleA;
            x2 *= scaleA;
            y1 *= scaleA;
            y2 *= scaleA;
            double dx = x2 - x1;
            double dy = y2 - y1;

            double absDx = Math.Abs(dx);
            double absDy = Math.Abs(dy);

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
            x1 *= scaleB;
            x2 *= scaleB;
            y1 *= scaleB;
            y2 *= scaleB;
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
            x1 *= scaleReference;
            x2 *= scaleReference;
            y1 *= scaleReference;
            y2 *= scaleReference;
            if (x1 > x2)
            {
                double temp = x1;
                x1 = x2;
                x2 = temp;

                temp = y1;
                y1 = y2;
                y2 = temp;
            }


            double dx, dy, p, x, y;
            dx = x2 - x1;
            dy = y2 - y1;
            x = x1;
            y = y1;
            p = 2 * dy - dx;
            while (x < x2)
            {
                if (p >= 0)
                {
                    pixelOutLineReference.Add(new Pixel((int)x, (int)y, color));
                    y = y - 1;
                    p = p + 2 * dy - 2 * dx;
                }
                else
                {
                    pixelOutLineReference.Add(new Pixel((int)x, (int)y, color));
                    p = p + 2 * dy;
                }
                x = x + 1;
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

        public static bool operator ==(Pixel left, Pixel right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Pixel left, Pixel right)
        {
            return left.x != right.x || left.y != right.y;
        }
    }
}
