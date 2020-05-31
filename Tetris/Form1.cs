using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainForm : Form
    {
        const int blockSize = 25, matrixHeight = 20, matrixWidth = 10; // Размер одной клетки, ширина карты, высота карты
        public int[,] matrix = new int[matrixHeight, matrixWidth]; // массив циферок, это сама карта
        Shape currentShape = new Shape(6, 0, new Random().Next(1, 8)); // текущая фигура

        public MainForm()
        {
            InitializeComponent();

            Merge();
            Invalidate(); // вызывает перерисовку формы, и поле этого вызывается Form1_Paint

            timer.Interval = 600;
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
                {
                    if (matrix[height, width] == 1)
                        graphics.FillRectangle(Brushes.Red, 50 + width * blockSize + 2, 50 + height * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[height, width] == 2)
                        graphics.FillRectangle(Brushes.Blue, 50 + width * blockSize + 2, 50 + height * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[height, width] == 2)
                        graphics.FillRectangle(Brushes.Orange, 50 + width * blockSize + 2, 50 + height * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[height, width] == 3)
                        graphics.FillRectangle(Brushes.Brown, 50 + width * blockSize + 2, 50 + height * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[height, width] == 4)
                        graphics.FillRectangle(Brushes.Green, 50 + width * blockSize + 2, 50 + height * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[height, width] == 5)
                        graphics.FillRectangle(Brushes.Purple, 50 + width * blockSize + 2, 50 + height * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[height, width] == 6)
                        graphics.FillRectangle(Brushes.Black, 50 + width * blockSize + 2, 50 + height * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[height, width] == 7)
                        graphics.FillRectangle(Brushes.Violet, 50 + width * blockSize + 2, 50 + height * blockSize + 2, blockSize - 2, blockSize - 2);
                }
        }

        private void RemoveShape() // удаляет фигуру с главной матрицы
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.MatrixHeight; i++)
                for (int j = currentShape.X; j < currentShape.X + currentShape.MatrixWidth; j++)
                    if (i >= 0 && j >= 0 && i < matrixHeight && j < matrixWidth)
                        if (currentShape.Matrix[i - currentShape.Y, j - currentShape.X] != 0)
                            matrix[i, j] = 0;
        }

        private void Merge() // Переносит матрицу фигуры на основную матрицу
        {
            for (int y = 0; y < currentShape.MatrixHeight; y++)
                for (int x = 0; x < currentShape.MatrixWidth; x++)
                    if (currentShape.Matrix[y, x] != 0)
                        matrix[currentShape.Y + y, currentShape.X + x] = currentShape.Matrix[y, x];
        }

        private bool VerticalCollide() // возвращает true, если снизу фигуры конец карты или другая фигура
        {
            for (int y = currentShape.Y + currentShape.MatrixHeight - 1; y >= currentShape.Y; y--)
                for (int x = currentShape.X; x < currentShape.X + currentShape.MatrixWidth; x++)
                    if (currentShape.Matrix[y - currentShape.Y, x - currentShape.X] != 0)
                    {
                        if (y + 1 == matrixHeight)
                            return true;
                        try
                        {
                            if (matrix[y + 1, x] != 0 && currentShape.Matrix[y - currentShape.Y + 1, x - currentShape.X] == 0)
                                return true;
                        }
                        catch (Exception)
                        {
                            return true;
                        }
                    }
            return false;
        }

        private bool HorizontalCollide(int dir)
        {
            for (int y = currentShape.Y; y < currentShape.Y + currentShape.MatrixHeight; y++)
                for (int x = currentShape.X; x < currentShape.X + currentShape.MatrixWidth; x++)
                    if (currentShape.Matrix[y - currentShape.Y, x - currentShape.X] != 0)
                    {
                        if (x + 1 * dir > matrixWidth - 1 || x + 1 * dir < 0)
                            return true;

                        if (matrix[y, x + 1 * dir] != 0)
                        {
                            if (x - currentShape.X + 1 * dir >= currentShape.MatrixWidth - 1 || currentShape.Matrix[y - currentShape.Y, x - currentShape.X + 1] != 0)
                                return true;
                        }
                    }
            return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // реагирует на нажатия клавиш
        {
            RemoveShape();

            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (!HorizontalCollide(1))
                        currentShape.MoveRight();
                    break;

                case Keys.Left:
                    if (!HorizontalCollide(-1))
                        currentShape.MoveLeft();
                    break;

                case Keys.Down:
                    if (!VerticalCollide())
                        currentShape.MoveDown();
                    break;
            }
            Merge();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)  
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void timer_Tick(object sender, EventArgs e) // происходит при тике таймера
        {

            if (VerticalCollide())
            {
                currentShape = new Shape(4, 0, new Random().Next(1,8));
            }
            else
            {
                RemoveShape(); // удаляет фигуру с главной матрицы
                currentShape.MoveDown(); // изменяет координату Y в классе Shape на +1
            }

            Merge(); // переноси уже опущеную на один блок фигуру
            Invalidate(); // вызывает перерисовку
        }
    }
}