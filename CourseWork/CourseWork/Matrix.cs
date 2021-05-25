using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Matrix
    {
        double[,] data;
        int rows;
        int columns;
        int size;
        public Matrix() { }
        public Matrix(int size) { data = new double[size, size]; this.size = size; rows = size; columns = size; }
        public Matrix(int rows, int columns) { data = new double[rows, columns]; size = -1; this.rows = rows; this.columns = columns; }
        public Matrix(Matrix matrix)
        {
            size = matrix.size;
            columns = matrix.columns;
            rows = matrix.rows;
            data = new double[rows, columns];
            if (rows == columns) size = rows;
            else size = -1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    data[i, j] = matrix.data[i, j];
                }
            }
        }
        public void SetData(int i, int j, double value) { data[i, j] = value; }
        public double GetData(int i, int j) { return data[i, j]; }
        private void SwapRows(int firstrow, int secondrow)
        {
            for (int j = 0; j < columns; j++)
            {
                double temp = data[firstrow, j];
                data[firstrow, j] = data[secondrow, j];
                data[secondrow, j] = temp;
            }
        }
        public int GetSize() { return size; }
        public void Schultz()
        {
            int k = 0;
            double eps = 1e-5;
            int m = 1;
            Indentity E = new Indentity(size);
            Matrix transponated = new Matrix(this);
            transponated.Transponant();
            Matrix C1 = this * transponated;
            double temp = 0;
            for (int i = 0; i < C1.size; i++)
            {
                for (int j = 0; j < C1.size; j++)
                {
                    temp += Math.Pow(C1.data[i, j], 2);
                }
            }
            Matrix U = new Matrix(transponated);
            for (int i = 0; i < U.size; i++)
            {
                for (int j = 0; j < U.size; j++)
                {
                    U.data[i, j] = U.data[i, j] / temp;
                }
            }

        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.rows == b.rows && a.columns == b.columns)
            {
                Matrix temp = new Matrix(a.rows, a.columns);
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < a.columns; j++)
                    {
                        temp.data[i, j] = a.data[i, j] + b.data[i, j];
                    }
                }
                return temp;
            }
            return null;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.rows == b.rows && a.columns == b.columns)
            {
                Matrix temp = new Matrix(a.rows, a.columns);
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < a.columns; j++)
                    {
                        temp.data[i, j] = a.data[i, j] - b.data[i, j];
                    }
                }
                return temp;
            }
            return null;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.columns == b.rows)
            {
                Matrix temp = new Matrix(a.rows, b.columns);
                for (int r = 0; r < a.columns; r++)
                {
                    for (int i = 0; i < a.rows; i++)
                    {
                        for (int j = 0; j < b.columns; j++)
                        {
                            temp.data[i, j] = a.data[i, r] * b.data[r, j];
                        }
                    }
                }
                return temp;
            }
            return null;
        }
        public void Transponant()
        {
            Matrix tempMatrix = new Matrix(this);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = tempMatrix.data[j, i];
                }
            }
        }
        public void JordanGauss()
        {
            Matrix I = new Matrix(size, size * 2);
            // слева обычная матрица
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    I.data[i, j] = data[i, j];
                }
            }
            // справа единичная (I)
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        I.data[i, j + size] = 1;
                    }
                    else
                    {
                        I.data[i, j + size] = 0;
                    }
                }
            }
            double diagelem;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        diagelem = I.data[i, j];
                        if (diagelem == 0)
                        {
                            int m;
                            for (m = i + 1; m < size; m++)
                            {
                                SwapRows(i, m);
                                diagelem = I.data[i, j];
                                if (diagelem != 0)
                                {
                                    break;
                                }
                                else
                                {
                                    SwapRows(i, m);
                                }
                            }
                            if (diagelem == 0)
                            {
                                return;
                            }
                        }
                        for (int k = 0; k < size * 2; k++)
                        {
                            I.data[i, k] = I.data[i, k] / diagelem;
                        }
                        for (int currrow = 0; currrow < size; currrow++)
                        {
                            if (currrow != i)
                            {
                                double ratio = I.data[currrow, j] / I.data[i, j];
                                for (int currcolumn = 0; currcolumn < size * 2; currcolumn++)
                                {
                                    I.data[currrow, currcolumn] = I.data[currrow, currcolumn] - I.data[i, currcolumn] * ratio;
                                }
                            }
                        }
                        break;
                    }
                }
            }
            // return inversed matrix
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    data[i, j] = I.data[i, j + size];
                }
            }
        }
        public void GenerateData()
        {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    data[i, j] = random.Next(20);
                }
            }
            if (!ReversedExist())
            {
                GenerateData();
            }
        }
        public bool ReversedExist()
        {
            bool check = false;
            double det = Determinant();
            if (det != 0)
            {
                check = true;
            }
            return check;
        }
        public double Determinant()
        {
            double det = 1;
            if (size == 2)
            {
                det = GetData(0, 0) * GetData(1, 1) - GetData(1, 0) * GetData(0, 1);
            }
            else
            {
                // straight gauss
                double diagelem = 0;
                Matrix copy = new Matrix(this);
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i == j)
                        {
                            diagelem = copy.data[i, j];
                            if (diagelem == 0)
                            {
                                int m;
                                for (m = i + 1; m < size; m++)
                                {
                                    SwapRows(i, m);
                                    diagelem = copy.data[i, j];
                                    if (diagelem != 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        SwapRows(i, m);
                                    }
                                }
                                if (diagelem == 0)
                                {
                                    return 0;
                                }
                            }
                            for (int currrow = i + 1; currrow < size; currrow++)
                            {
                                double ratio = -1 * copy.data[currrow, j] / copy.data[i, j];
                                for (int currcolumn = 0; currcolumn < size; currcolumn++)
                                {
                                    copy.data[currrow, currcolumn] = copy.data[i, currcolumn]*ratio + copy.data[currrow, currcolumn];
                                }
                            }
                            break;
                        }
                    }
                }
                // finding det
                for (int i = 0; i < size; i++)
                {
                    det *= copy.data[i, i];
                }
            }
            return det;
        } 
        public class Indentity : Matrix
        {
            public Indentity(int size)
            {
                data = new double[size, size]; this.size = size;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i == j)
                        {
                            data[i, j] = 1;
                        }
                        else
                        {
                            data[i, j] = 0;
                        }
                    }
                }
                columns = size;
                rows = size;
            }
        }
    }
}
