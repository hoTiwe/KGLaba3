using System.Drawing;

namespace KGLaba3
{
    public partial class Form1 : Form
    {
        List<Pixel> pixelOutLineA = new List<Pixel>();
        List<Pixel> pixelOutLineB = new List<Pixel>();
        List<Pixel> pixelOutLineReference = new List<Pixel>();

        public Form1()
        {
            InitializeComponent();
            this.PaintLineMain(3, 3, 100, 100, Color.Red);
            this.PaintLineCDA(3, 3, 100, 100, Color.Red);
            this.PaintLineBrezenthema(3, 3, 100, 100, Color.Red);

        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for(int i = 0; i < pixelOutLineA.Count(); i++){ 
                graphics.FillRectangle(new SolidBrush(pixelOutLineA[i].color), pixelOutLineA[i].x, pixelOutLineA[i].y, 1, 1);
            }
        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int i = 0; i < pixelOutLineB.Count(); i++)
            {
                graphics.FillRectangle(new SolidBrush(pixelOutLineB[i].color), pixelOutLineB[i].x, pixelOutLineB[i].y, 1, 1);
            }
        }


        void PaintLineMain(int x1, int y1, int x2, int y2, Color color)
        {
            float dy = Math.Abs((y2 - y1) / (x2 - x1));
            int x = x1;
            float y = y1;
            while (x <= x2)
            {
                pixelOutLineA.Add(new Pixel(x, (int)Math.Round(y, 0), color));
                x++;
                y += dy;
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
