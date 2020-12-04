using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraph1
{
    public partial class Form1 : Form
    {
        public const double k1 = 0.1;
        public const double k2 = 0.2;
        public const double k3 = 0.3;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Aquamarine;
            pictureBox1.Paint += PictureBox1_Paint;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen newpen = new Pen(Color.DarkGreen, 1);
            Random rnd = new Random();
            int x1 = rnd.Next(-10, 10);
            int y1 = Convert.ToInt32(k1 * x1);
            Graph(new Point(x1,y1), new Point(pictureBox1.ClientSize.Width/2,0) );
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {

            int w = pictureBox1.ClientSize.Width / 2;
            int h = pictureBox1.ClientSize.Height / 2;
            //Смещение начала координат в центр PictureBox
            e.Graphics.TranslateTransform(w, h);
            DrawXAxis(new Point(-w, 0), new Point(w, 0), e.Graphics);
            DrawYAxis(new Point(0, h), new Point(0, -h), e.Graphics);
            //Центр координат
            e.Graphics.FillEllipse(Brushes.Red, -2, -2, 4, 4);
        }
        //Рисование оси X
        private void DrawXAxis(Point start, Point end, Graphics g)
        {
            g.DrawLine(Pens.Red, start, end);

        }
        // Y
        private void DrawYAxis(Point start, Point end, Graphics g)
        {
            g.DrawLine(Pens.Red, start, end);
        }
        private void Graph(Point start, Point end, Graphics g)
        {
            Pen newpen = new Pen(Color.DarkGreen, 1);

            g.DrawLine(newpen, start, end);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
