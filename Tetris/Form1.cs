using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        const int blockSize = 25, mapHeight = 20, mapWidth = 10; // Размер одной клетки, ширина карты, высота карты
        public int[,] map = new int[mapWidth, mapHeight]; // массив циферок, это сама карта
        Shape currentShape = new Shape(6, 5, new Random().Next(0, 7)); // текущая фигура

        public Form1()
        {
            InitializeComponent();

            Merge();

            timer.Interval = 1000;
            timer.Start();
        }

        private void DrawGrid(Graphics graphics) // рисует сетку, и принимает graphics(На чём рисовать)
        {
            for (int i = 0; i <= mapHeight; i++)
                graphics.DrawLine(Pens.Black, new Point(50, 50 + i * blockSize), new Point(50 + mapWidth * blockSize, 50 + i * blockSize)); // рисует горизонтальные линии
            for (int i = 0; i <= mapWidth; i++)
                graphics.DrawLine(Pens.Black, new Point(50 + i * blockSize, 50), new Point(50 + i * blockSize, 50 + mapHeight * blockSize)); // рисует вертикальные линии
        }

        private void DrawMap(Graphics graphics)
        {
            

            for (int y = 0; y < mapHeight; y++)
                for (int x = 0; x < mapWidth; x++)
                    if (map[x, y] != 0)
                        graphics.FillRectangle(Brushes.Yellow, 50 + x * blockSize+1, 50 + y * blockSize+1, blockSize-1, blockSize-1);
        }

        private void Merge()
        {
            for (int x = 0; x < currentShape.MatrixWidth; x++)
                for (int y = 0; y < currentShape.MatrixHeight; y++)
                    if (currentShape.Matrix[x, y] != 0)
                        map[currentShape.X + x, currentShape.Y + y] = currentShape.Matrix[x, y];
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int x = 0; x < mapWidth; x++)
                for (int y = 0; y < mapHeight; y++)
                    map[x, y] = 0;

            currentShape.MoveDown();
            Merge();
            Invalidate();
        }
    }
}