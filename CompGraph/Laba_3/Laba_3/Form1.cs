﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
namespace Laba_3
{
    public partial class Form1 : Form
    {
        // Объявляем объект "g" класса Graphics
        Graphics g;
        string filename = @"Strings.txt";
        string[] sm = {

"First line", "Second line", "Third line",
"Fourth line", "Fifth line", "Sixth line",
"Seventh line", "Eighth line", "Ninth line",
"Tenth line", "Eleven line", "Twelve line",
"Thirteenth line", "Fourteenth line",
"Fifteenth line"};

        public Form1()
        {
            InitializeComponent();
            // Предоставляем объекту "g" класса Graphics возможность
            // рисования на pictureBox1:
            g = pictureBox1.CreateGraphics();
        }
        // **************** Запись в файл ********************
        private void InFile_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter(new FileStream(filename,
            FileMode.Create, FileAccess.Write));

            foreach (string s in sm) { f.WriteLine(s); }
            f.Close();
            MessageBox.Show("15 строк записано в файл !");
        }
        // *************** Очистка файла и PictureBox **********
        private void ClearFile_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 255));
            File.Delete(filename);
            MessageBox.Show("Файл Strings.txt удалён !");
        }

        // *************** Отображение строк текста *************
        private void ShowText_Click(object sender, EventArgs e)
        {
            int k = 0;
            // Чтение строк из файла
            try
            {
                StreamReader f = new StreamReader(new FileStream(filename,
                FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 15; i++) { sm[i] = f.ReadLine(); }
                f.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            // **** Отображение строк разными шрифтами и выравниванием **
            pictureBox1.BackColor = Color.FromName("Azure");
            pictureBox1.Refresh();
            for (int i = 0; i < 15; i++)
            {
                // Отображение первой группы строк
                if ((i >= 0) && (i < 9))
                {
                    Font fn = new Font("Times New Roman", 24, FontStyle.Underline);
                    StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Blue,new RectangleF(0, 0 + i * 30, pictureBox1.Size.Width - 20,pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }
                // Отображение второй группы строк
                if ((i >= 9) && (i < 14))
                {
                    k = i - 9;
                    Font fn = new Font("Courier New", 36, FontStyle.Strikeout);
                    StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Black,new RectangleF(0 + k * 24, 0, pictureBox1.Size.Width - 20,pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }
                // Отображение третьей группы строк
                if (i == 14)
                {
                    Font fn = new Font("Arial", 72, FontStyle.Regular);
                    StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Green, new RectangleF(0, 0 + i * 24, pictureBox1.Size.Width - 20, pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }

            }
        }
    

    private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InFile_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearFile_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowText_Click(sender, e);
        }
    }
}
