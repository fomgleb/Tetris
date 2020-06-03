using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainForm : Form
    {
        int blockSize = 25; // размер одного блока на карте в пикселях

        const int matrixHeight = 20, matrixWidth = 10; // ширина матрицы, высота матрицы
        public int[,] matrix = new int[matrixWidth, matrixHeight]; // массив циферок, это матрица.
        Shape currentShape = new Shape(4, 0, new Random().Next(1, 8)); // текущая фигура

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
            for (int x = 0; x < matrixWidth; x++)
                for (int y = 0; y < matrixHeight; y++)
                {
                    if (matrix[x, y] == 1)
                        graphics.FillRectangle(Brushes.Red, 50 + x * blockSize + 2, 50 + y * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[x, y] == 2)
                        graphics.FillRectangle(Brushes.Blue, 50 + x * blockSize + 2, 50 + y * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[x, y] == 2)
                        graphics.FillRectangle(Brushes.Orange, 50 + x * blockSize + 2, 50 + y * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[x, y] == 3)
                        graphics.FillRectangle(Brushes.Brown, 50 + x * blockSize + 2, 50 + y * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[x, y] == 4)
                        graphics.FillRectangle(Brushes.Green, 50 + x * blockSize + 2, 50 + y * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[x, y] == 5)
                        graphics.FillRectangle(Brushes.Purple, 50 + x * blockSize + 2, 50 + y * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[x, y] == 6)
                        graphics.FillRectangle(Brushes.Black, 50 + x * blockSize + 2, 50 + y * blockSize + 2, blockSize - 2, blockSize - 2);
                    else if (matrix[x, y] == 7)
                        graphics.FillRectangle(Brushes.Violet, 50 + x * blockSize + 2, 50 + y * blockSize + 2, blockSize - 2, blockSize - 2);
                }
        }

        private void RemoveShape() // удаляет фигуру с главной матрицы
        {
            for (int x = currentShape.X; x < currentShape.X + currentShape.MatrixWidth; x++)
                for (int y = currentShape.Y; y < currentShape.Y + currentShape.MatrixHeight; y++)
                    if (x >= 0 && y >= 0 && x < matrixWidth && y < matrixHeight)
                        if (currentShape.Matrix[x - currentShape.X, y - currentShape.Y] != 0)
                            matrix[x, y] = 0;
        }

        private void Merge() // Переносит матрицу фигуры на основную матрицу
        {
            for (int x = 0; x < currentShape.MatrixWidth; x++)
                for (int y = 0; y < currentShape.MatrixHeight; y++)
                    if (currentShape.Matrix[x, y] != 0)
                        matrix[currentShape.X + x, currentShape.Y + y] = currentShape.Matrix[x, y];
        }

        private bool VerticalCollide() // возвращает true, если снизу фигуры конец карты или другая фигура
        {
            for (int x = currentShape.X; x < currentShape.X + currentShape.MatrixWidth; x++)
                for (int y = currentShape.Y; y < currentShape.Y + currentShape.MatrixHeight; y++)
                    if (currentShape.Matrix[x - currentShape.X, y - currentShape.Y] != 0)
                    {
                        if (y + 1 >= matrixHeight) // Если следующий y за пределами карты, то true
                            return true;

                        if (matrix[x, y + 1] != 0 && (y - currentShape.Y + 1 >= currentShape.MatrixHeight || currentShape.Matrix[x - currentShape.X, y - currentShape.Y + 1] == 0))
                            return true;
                    }
            return false;
        }

        private bool HorizontalCollide(int dir) // возвращает true, если справа(dir == 1) или слева(dir == -1) есть другая фиругра или конец карты
        {
            if (currentShape.ShapeNumber == 1)
                Console.WriteLine();

            for (int x = currentShape.X; x < currentShape.X + currentShape.MatrixWidth; x++)
                for (int y = currentShape.Y; y < currentShape.Y + currentShape.MatrixHeight; y++)
                    if (currentShape.Matrix[x - currentShape.X, y - currentShape.Y] != 0)
                    {
                        if (x + 1 * dir > matrixWidth - 1 || x + 1 * dir < 0) // если фигура соприкосается с концом карты
                            return true;

                        if (matrix[x + 1 * dir, y] != 0) // если блоки фигуры соприкасаются с другими блоками справа или слева
                        {
                            if (x - currentShape.X + 1 >= currentShape.MatrixWidth)
                                return true;

                            if (x - currentShape.X - 1 < 0)
                                return true;

                            if (currentShape.Matrix[x - currentShape.X + 1 * dir, y - currentShape.Y] == 0)
                                return true;
                        }
                    }
            return false;
        }

        private bool Overlay(Shape shape) // возвращает true, если находит наложение на другие фигуры
        {                
            for (int x = 0; x < shape.MatrixWidth; x++)
                for (int y = 0; y < shape.MatrixHeight; y++)
                    if (shape.Matrix[x, y] != 0) // проверяем только фигуру, а не пространство вокруг неё
                    {
                        if (y + shape.Y >= matrixHeight || x + shape.X >= matrixWidth || x + shape.X <= -1) // проверяет за картой ли фигура
                            return true;

                        if (matrix[x + shape.X, y + shape.Y] != 0) // проверка наложения на другую фигуру
                            return true;
                    }
            return false;   
        }

        private void DeleteFullRow() // находит и уберает полные строки при этом сдвигая все верхние строки на 1 вниз
        {
            for (int y = 0; y < matrixHeight; y++)
            {
                for (int x = 0; x < matrixWidth; x++)
                {
                    if (matrix[x, y] == 0) // если этот блок равняется нулю
                        break; // , то переходим к следующему ряду, так как этот уже не будет полностью заполнен
                    else if(x == matrixWidth - 1) // иначе если это последний блок в ряду
                    {
                        for (x = 0; x < matrixWidth; x++) // обнуляем все числа в ряду
                            matrix[x, y] = 0;

                        for ( y -= 1; y > -1; y--) // опускаем все блоки над обнуленым рядом на 1
                            for ( x = 0; x < matrixWidth; x++)
                                matrix[x, y + 1] = matrix[x, y];

                        removedRowsLabel.Text = Convert.ToString(Convert.ToInt32(removedRowsLabel.Text) + 1);
                        scoreLabel.Text = Convert.ToString(Convert.ToInt32(scoreLabel.Text) + 50);
                    }
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
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

                case Keys.Up:
                    RemoveShape();
                    Shape tempShape = new Shape(currentShape.X, currentShape.Y, currentShape.ShapeNumber);

                    tempShape.Matrix = currentShape.Matrix;
                    tempShape.Rotate();

                    if (!Overlay(tempShape))
                        currentShape.Rotate();
                    break;
            }
            Merge();
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void timer_Tick(object sender, EventArgs e) // происходит при тике таймера
        {
            if (VerticalCollide())
            {
                if (currentShape.Y <= 0)
                {
                    timer.Stop();

                    ClearMatrix();

                    MessageBox.Show($"Your score {scoreLabel.Text}", "Message", MessageBoxButtons.OK);

                    scoreLabel.Text = "0";
                    removedRowsLabel.Text = "0";

                    timer.Start();
                }
                else
                {
                    currentShape = new Shape(4, 0, new Random().Next(1, 8));
                    scoreLabel.Text = Convert.ToString(Convert.ToInt32(scoreLabel.Text) + 5); // +5 к очкам
                }
            }
            else
            {
                RemoveShape(); // удаляет фигуру с главной матрицы
                currentShape.MoveDown(); // изменяет координату Y в классе Shape на +1
            }

            DeleteFullRow();
            Merge(); // переноси уже опущеную на один блок фигуру
            Invalidate(); 
        }

        private void ClearMatrix()
        {
            for (int x = 0; x < matrixWidth; x++)
                for (int y = 0; y < matrixHeight; y++)
                    matrix[x, y] = 0;
        }
    }
}