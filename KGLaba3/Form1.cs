using System.Drawing;

namespace KGLaba3
{
    public partial class Form1 : Form
    {
        Bitmap bitmap1;
        Graphics graphics1;

        Bitmap bitmap2;
        Graphics graphics2;

        List<Pixel> pixelOutLineA = new List<Pixel>();
        List<Pixel> pixelOutLineA2 = new List<Pixel>();
        List<Pixel> pixelOutLineA3 = new List<Pixel>();
        List<Pixel> pixelOutLineB = new List<Pixel>();
        List<Pixel> pixelOutLineReference = new List<Pixel>();
        private Color boundaryColor = Color.Red, fillColor = Color.Red;
        int scale = 3;

        public Form1()
        {
            InitializeComponent();
            bitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics1 = Graphics.FromImage(bitmap1);
            pictureBox1.Image = bitmap1;

            this.PaintLineByEquation(3, 3, 100, 100, Color.Red, pixelOutLineA);
            this.PaintLineByEquation(3, 3, 100, 50, Color.Red, pixelOutLineA2);
            this.PaintLineByEquation(100, 50, 100, 100, Color.Red, pixelOutLineA3);
            this.PaintLineCDA(3, 3, 100, 100, Color.Red);
            this.PaintLineBrezenthema(3, 3, 100, 100, Color.Red);
            this.DrawLinesOnce();
            this.Fill(70, 50);
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //for (int i = 0; i < pixelOutLineA.Count(); i++)
            //{
            //    bitmap1.SetPixel(pixelOutLineA[i].x, pixelOutLineA[i].y, pixelOutLineA[i].color);
            //}
            //for (int i = 0; i < pixelOutLineA2.Count(); i++)
            //{
            //    bitmap1.SetPixel(pixelOutLineA2[i].x, pixelOutLineA2[i].y, pixelOutLineA2[i].color);
            //}
            //for (int i = 0; i < pixelOutLineA3.Count(); i++)
            //{
            //    bitmap1.SetPixel(pixelOutLineA3[i].x, pixelOutLineA3[i].y, pixelOutLineA3[i].color);
            //}
            Console.WriteLine("Okey");
        }

        private void DrawLinesOnce()
        {
            bitmap1.SetPixel(1, 1, fillColor);
            for (int i = 0; i < pixelOutLineA.Count(); i++)
            {
                bitmap1.SetPixel(pixelOutLineA[i].x, pixelOutLineA[i].y, pixelOutLineA[i].color);
            }
            for (int i = 0; i < pixelOutLineA2.Count(); i++)
            {
                bitmap1.SetPixel(pixelOutLineA2[i].x, pixelOutLineA2[i].y, pixelOutLineA2[i].color);
            }
            for (int i = 0; i < pixelOutLineA3.Count(); i++)
            {
                bitmap1.SetPixel(pixelOutLineA3[i].x, pixelOutLineA3[i].y, pixelOutLineA3[i].color);
            }

            pictureBox1.Image = bitmap1;
        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int i = 0; i < pixelOutLineB.Count(); i++)
            {
                graphics.FillRectangle(new SolidBrush(pixelOutLineB[i].color), pixelOutLineB[i].x, pixelOutLineB[i].y, 1, 1);
            }
        }


        void PaintLineMain(int x1, int y1, int x2, int y2, Color color, List<Pixel> pixelOutLine)
        {
            float dy = Math.Abs((y2 - y1) / (x2 - x1));
            int x = x1;
            float y = y1;
            while (x <= x2)
            {
                pixelOutLine.Add(new Pixel(x, (int)Math.Round(y, 0), color));
                x++;
                y += dy;
            }
        }
        void PaintLineByEquation(int x1, int y1, int x2, int y2, Color color, List<Pixel> pixelOutLine)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;

            // Определяем абсолютные значения приращений
            int absDx = Math.Abs(dx);
            int absDy = Math.Abs(dy);

            // Определяем направление движения (по знакам dx и dy)
            int signX = dx > 0 ? 1 : (dx < 0 ? -1 : 0);
            int signY = dy > 0 ? 1 : (dy < 0 ? -1 : 0);

            // Выбор основной оси для шага
            if (absDx > absDy)
            {
                // Если dx > dy, двигаемся вдоль оси X
                float y = y1;
                float k = (float)dy / dx;  // Коэффициент наклона

                for (int x = x1; x != x2 + signX; x += signX)
                {
                    pixelOutLine.Add(new Pixel(x, (int)Math.Round(y), color));
                    y += k * signX;  // Обновляем y с учетом наклона
                }
            }
            else
            {
                // Если dy >= dx, двигаемся вдоль оси Y
                float x = x1;
                float k = (float)dx / dy;  // Коэффициент наклона, обратный в этом случае

                for (int y = y1; y != y2 + signY; y += signY)
                {
                    pixelOutLine.Add(new Pixel((int)Math.Round(x), y, color));
                    x += k * signY;  // Обновляем x с учетом наклона
                }
            }
        }
        void PaintLineCDA(int x1, int y1, int x2, int y2, Color color)
        {
            int length = Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            float dx = (x2 - x1) / length;
            float dy = (y2 - y1) / length;
            float x = x1;
            float y = y1;

            int i = 1;
            while (i <= length)
            {
                pixelOutLineB.Add(new Pixel((int)Math.Round(x, 0), (int)Math.Round(y, 0), color));
                x += dx;
                y += dy;
                i++;
            }
        }

        void PaintLineBrezenthema(int x1, int y1, int x2, int y2, Color color)
        {
            int x = x1;
            int y = y1;

            int dx = x2 - x1;
            int dy = y2 - y1;
            int D = -dx;

            int DX = dx << 1;
            int DY = dy << 1;
            while (x <= x2)
            {
                pixelOutLineReference.Add(new Pixel(x, y, color));

                x++;
                D += DY;
                if (D >= 0)
                {
                    y++;
                    D -= DX;
                }
            }
        }

        int Sign(float value)
        {
            return value > 0 ? 1 : (value < 0 ? -1 : 0);
        }

        public void Fill(int x, int y)
        {
            Console.WriteLine($"{bitmap1.GetPixel(3, 3)}");
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));

            while (stack.Count > 0)
            {
                Point seed = stack.Pop();
                int xLeft = seed.X;
                int xRight = seed.X+1;
                int yCurrent = seed.Y;

                // Находим крайний левый предел интервала
                while (xLeft >= 0 && GetPixelColor(xLeft, yCurrent) != GetPixelColor(3,3) && GetPixelColor(xLeft, yCurrent) != GetPixelColor(1, 1))
                {
                    Console.WriteLine($"{GetPixelColor(xLeft, yCurrent)} and {boundaryColor}");
                    SetPixelColor(xLeft, yCurrent, fillColor);
                    xLeft--;
                }
                xLeft++;

                // Находим крайний правый предел интервала
                while (xRight < bitmap1.Width && GetPixelColor(xRight, yCurrent) != GetPixelColor(3, 3) && GetPixelColor(xRight, yCurrent) != GetPixelColor(1, 1))
                {
                    SetPixelColor(xRight, yCurrent, fillColor);
                    xRight++;
                }
                xRight--;

                // Проверка строки сверху (yCurrent - 1)
                if (yCurrent > 0)
                {
                    CheckAndPushNewSeeds(stack, xLeft, xRight, yCurrent - 1);
                }

                // Проверка строки снизу (yCurrent + 1)
                if (yCurrent < bitmap1.Height - 1)
                {
                    CheckAndPushNewSeeds(stack, xLeft, xRight, yCurrent + 1);
                }
            }
        }

        private void CheckAndPushNewSeeds(Stack<Point> stack, int xLeft, int xRight, int y)
        {
            bool inInterval = false;

            for (int x = xLeft; x <= xRight; x++)
            {
                if (GetPixelColor(x, y) != GetPixelColor(3, 3) && GetPixelColor(x, y) != GetPixelColor(3, 3))
                {
                    if (!inInterval)
                    {
                        inInterval = true;
                        stack.Push(new Point(x, y));
                    }
                }
                else
                {
                    inInterval = false;
                }
            }
        }

        private Color GetPixelColor(int x, int y)
        {
            return bitmap1.GetPixel(x, y);
        }

        private void SetPixelColor(int x, int y, Color color)
        {
            bitmap1.SetPixel(x, y, color);
            Console.WriteLine($"{bitmap1.GetPixel(x, y)} for x = {x} and y = {y}");
            pictureBox1.Image = bitmap1;
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
    }
}
