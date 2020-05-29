using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        const int blockSize = 25, matrixHeight = 20, matrixWidth = 10; // Размер одной клетки, ширина карты, высота карты
        public int[,] matrix = new int[matrixHeight, matrixWidth]; // массив циферок, это сама карта
        Shape currentShape = new Shape(4, 0, new Random().Next(1, 8)); // текущая фигура

        public Form1()
        {
            InitializeComponent();

            Merge();
            Invalidate(); // вызывает перерисовку формы, и поле этого вызывается Form1_Paint

            timer.Interval = 1000;
            timer.Start();
        }

        private void DrawGrid(Graphics graphics) // рисует сетку, и принимает graphics(На чём рисовать)
        {
            for (int i = 0; i <= matrixHeight; i++)
                graphics.DrawLine(Pens.Black, new Point(50, 50 + i * blockSize), new Point(50 + matrixWidth * blockSize, 50 + i * blockSize)); // рисует горизонтальные линии
            for (int i = 0; i <= matrixWidth; i++)
                graphics.DrawLine(Pens.Black, new Point(50 + i * blockSize, 50), new Point(50 + i * blockSize, 50 + matrixHeight * blockSize)); // рисует вертикальные линии
        }

        private void DrawMap(Graphics graphics)// Рисует карту
        {
            for (int height = 0; height < matrixHeight; height++)
                for (int width = 0; width < matrixWidth; width++)
                    if (matrix[height, width] != 0)
                        graphics.FillRectangle(Brushes.Red, 50 + width * blockSize+2, 50 + height * blockSize+2, blockSize-2, blockSize-2);
        }

        private void ClearMatrix() // обнуляет все занчения в матрице
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.MatrixHeight; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.MatrixWidth; j++)
                {
                    if (i >= 0 && j >= 0 && i < matrixHeight && j < matrixWidth)
                    {
                        if (currentShape.Matrix[i - currentShape.Y, j - currentShape.X] != 0)
                        {
                            matrix[i, j] = 0;
                        }
                    }
                }
            }
        }

        private void Merge() // Переносит матрицу фигуры на основную матрицу
        {
            for (int y = 0; y < currentShape.MatrixHeight; y++)
                for (int x = 0; x < currentShape.MatrixWidth; x++)
                    if (currentShape.Matrix[y, x] != 0)
                        matrix[currentShape.Y + y, currentShape.X + x] = currentShape.Matrix[y, x];
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ClearMatrix();

            switch (e.KeyCode)
            {
                case Keys.Right: currentShape.MoveRight(); break;
                case Keys.Left: currentShape.MoveLeft(); break;
            }
            Merge();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) 
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ClearMatrix();

            currentShape.MoveDown();

            Merge();
            Invalidate();
        }
    }
}