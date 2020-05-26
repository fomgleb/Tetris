using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        const int blockSize = 25, mapHeight = 20, mapWidth = 10;
        public int[,] map = new int[mapHeight, mapWidth];

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawGrid(Graphics graphics)
        {
            for (int i = 0; i <= mapHeight; i++)
                graphics.DrawLine(Pens.Black, new Point(50, 50 + i * blockSize), new Point(50 + mapWidth * blockSize, 50 + i * blockSize));
            for (int i = 0; i <= mapWidth; i++)
                graphics.DrawLine(Pens.Black, new Point(50 + i * blockSize, 50), new Point(50 + i * blockSize, 50 + mapHeight * blockSize));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
        }
    }
}