using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainForm : Form
    {
        const int blockSize = 25, matrixHeight = 20, matrixWidth = 10; // Размер одной клетки, ширина карты, высота карты
        public int[,] matrix = new int[matrixWidth, matrixHeight]; // массив циферок, это сама карта
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
                            if (x - currentShape.X + 1 * dir >= currentShape.MatrixWidth - 1 || x - currentShape.X - 1 * dir < 0) // если проверяемый блок не выходит за рамки матрицы фигуры
                            {
                                if (currentShape.Matrix[x - currentShape.X + 1 * dir, y - currentShape.Y] == 0) // если проверяемый блок летящей фигуры не есть самим блоком летящей фигуры
                                    return true;
                            }
                            else
                                return true;
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

        private void DeleteFullRow()
        {
            int saveMatrixHeight;
            bool fullRow = false;

            for (int y = 0; y < matrixHeight; y++)
            {
                for (int x = 0; x < matrixWidth; x++)
                {
                    if (matrix[x, y] == 0) // если этот блок равняется нулю, то переходим к следующему ряду, так как в этом уже не будет полностью заполненого ряда
                        break;
                    else if(x == matrixWidth - 1)
                    {
                        for (x = 0; x < matrixWidth; x++)
                        {
                            matrix[x, y] = 0;
                        }
                    }


                }

                

                //if (fullRow == true)
                //{
                //    for (int k = 0; k < matrixWidth; k++)
                //        matrix[k, saveMatrixHeight] = 0;
                //}
                //else
                //    saveMatrixHeight = y;
            }
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

            DeleteFullRow();
            Merge(); // переноси уже опущеную на один блок фигуру
            Invalidate(); // вызывает перерисовку
        }
    }
}