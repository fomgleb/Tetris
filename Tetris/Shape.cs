﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; } // координаты нахождения начала матрицы фигуры на главной матрице 
        public int MatrixWidth { get; private set; } // ширина матрицы
        public int MatrixHeight { get; private set; } // высота матрицы
        public int ShapeNumber { get; private set; } // выбраная фигура
        public int[,] Matrix { get; set; }

        public Shape(int x, int y, int shapeNumber)
        {
            X = x;
            Y = y;
            ShapeNumber = shapeNumber;
            GenerateShape(shapeNumber);
        }

        private void GenerateShape(int shapeNumber)
        {
            if (shapeNumber == 1)
            {
                MatrixWidth = 4;
                MatrixHeight = 4;
                Matrix = new int[4, 4] 
                {
                    {0,1,0,0},
                    {0,1,0,0},
                    {0,1,0,0},
                    {0,1,0,0}
                };

            }
            else if (shapeNumber == 2)
            {
                MatrixWidth = 3;
                MatrixHeight = 3;
                Matrix = new int[3, 3]
                {
                    {0,2,0},
                    {0,2,0},
                    {2,2,0}
                };
            }
            else if (shapeNumber == 3)
            {
                MatrixWidth = 3;
                MatrixHeight = 3;
                Matrix = new int[3, 3]
                {
                    {3,3,0},
                    {0,3,0},
                    {0,3,0}
                };
            }
            else if (shapeNumber == 4)
            {
                MatrixWidth = 3;
                MatrixHeight = 3;
                Matrix = new int[3, 3]
                {
                    {0,4,0},
                    {4,4,0},
                    {0,4,0}
                };
            }
            else if (shapeNumber == 5)
            {
                MatrixWidth = 3;
                MatrixHeight = 3;
                Matrix = new int[3, 3]
                {
                    {0,5,0},
                    {5,5,0},
                    {5,0,0}
                };
            }
            else if (shapeNumber == 6)
            {
                MatrixWidth = 3;
                MatrixHeight = 3;
                Matrix = new int[3, 3]
                {
                    {6,0,0},
                    {6,6,0},
                    {0,6,0}
                };
            }
            else if (shapeNumber == 7)
            {
                MatrixWidth = 2;
                MatrixHeight = 2;
                Matrix = new int[2, 2]
                {
                    {7,7},
                    {7,7}
                };
            }
        }

        public void Rotate()
        {
            //switch (ShapeNumber)
            //{
            //    case 1:
            //        ShapeNumber = 101;
            //        Matrix = new int[4, 4]
            //        {
            //            {0,1,0,0},
            //            {0,1,0,0},
            //            {0,1,0,0},
            //            {0,1,0,0}
            //        };
            //        break;
            //    case 101:
            //        ShapeNumber = 1;
            //        Matrix = new int[4, 4]
            //        {
            //            {0,0,0,0},
            //            {1,1,1,1},
            //            {0,0,0,0},
            //            {0,0,0,0}
            //        };
            //        break;
            //}

            int[,] tempMatrix = new int[MatrixWidth, MatrixHeight];
            for (int i = 0; i < MatrixWidth; i++)
                for (int j = 0; j < MatrixHeight; j++)
                {
                    tempMatrix[i, j] = Matrix[j, MatrixHeight - 1 - i];
                }
            Matrix = tempMatrix;

            
        }

        public void MoveDown()
        {
            Y++;
        }

        public void MoveRight()
        {
            X++;
        }

        public void MoveLeft()
        {
            X--;
        }
    }
}
