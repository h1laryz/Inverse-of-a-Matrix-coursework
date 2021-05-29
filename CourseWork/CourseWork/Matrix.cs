using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public class Matrix
    {
        public static RichTextBox solutionBox { get; set; }
        double[,] data;
        int rows;
        int columns;
        double det;
        int size;
        public Matrix() { }
        public Matrix(int size) { data = new double[size, size]; this.size = size; rows = size; columns = size; }
        public Matrix(int rows, int columns) { data = new double[rows, columns]; if (rows == columns) size = rows; else size = -1; this.rows = rows; this.columns = columns; }
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
            //double eps = 0.0000000001;
            double eps = 0.001;
            IdentityMatrix E = new IdentityMatrix(size);
            Matrix transponated = new Matrix(this);
            transponated.Transponant();
            Matrix A1 = this * transponated;
            Matrix currU = new Matrix(transponated);
            double norm;
            if (solutionBox != null)
            {
                solutionBox.Text += "МЕТОД ШУЛЬЦА\n";
                solutionBox.Text += "========================================\n";
                solutionBox.Text += $"A1 = A*A^T\n";
                A1.Print();
                solutionBox.Text += "========================================\n";
                norm = A1.Norm();
                solutionBox.Text += "U1:\n";
                for (int i = 0; i < currU.rows; i++)
                {
                    solutionBox.Text += "(";
                    for (int j = 0; j < currU.columns; j++)
                    {
                        solutionBox.Text += $"{Math.Round(data[i, j], 3)}/{Math.Round(norm, 1)}";
                        if (j == currU.columns - 1) continue;
                        solutionBox.Text += "; ";
                    }
                    solutionBox.Text += ")\n";
                }
            }
            else norm = A1.Norm();
            // U^0
            for (int i = 0; i < currU.size; i++)
            {
                for (int j = 0; j < currU.size; j++)
                {
                    currU.data[i, j] = currU.data[i, j] / norm;
                }
            }

            List<Matrix> U = new List<Matrix>();
            List<Matrix> Psi = new List<Matrix>();
            do
            {
                U.Add(currU);
                Psi.Add(E - this * U[k]);
                if (solutionBox != null)
                {
                    if (k != 0) solutionBox.Text += $"U{k+1} = U{k}*(E+Ψ{k})\n";
                    solutionBox.Text += $"U{k+1}:\n";
                    U[k].Print();
                    solutionBox.Text += $"Ψ{k+1} = E-A*U{k+1}\n";
                    solutionBox.Text += $"Ψ{k+1}:\n";
                    Psi[k].Print();
                }
                currU = U[k] * (E + Psi[k]);
                k++;
                norm = Psi[k - 1].Norm();
                if (solutionBox != null)
                {
                    if (norm >= eps)
                    {
                        solutionBox.Text += $"Норма Ψ{k} >= {eps}\n{norm} >= {eps} ==> продовжуємо алгоритм\n";
                    }
                    else solutionBox.Text += $"Норма Ψ{k} < {eps}\n{norm} < {eps} ==> алгоритм закінчено\n";
                    solutionBox.Text += "========================================\n";
                }
            } while (norm >= eps);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((Math.Abs(Math.Truncate(U[U.Count() - 1].data[i, j])) + 1) - (Math.Abs(U[U.Count() - 1].data[i, j])) <= eps)
                    {
                        data[i, j] = Math.Round((U[U.Count() - 1]).data[i, j]);
                    }
                    else if (!(Math.Abs((U[U.Count() - 1]).data[i, j]) <= eps))
                    {
                        data[i, j] = (U[U.Count() - 1]).data[i, j];
                    }
                    else data[i, j] = 0;
                }
            }
            if (solutionBox != null) solutionBox.Text += "Результат:\n";
            Print();
        }
        public double Norm()
        {
            if (solutionBox != null) solutionBox.Text += "Норма матрицы = √(";
            double result = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result += Math.Pow(data[i, j], 2);
                    if (solutionBox != null)
                    {
                        if (Math.Abs(data[i, j]) >= 0.001)
                            solutionBox.Text += $"({Math.Round(data[i, j], 3)})^2";
                        else solutionBox.Text += $"({Math.Round(data[i, j], 5)})^2";

                        if (i != size - 1 || j != size - 1) solutionBox.Text += "+";
                        else solutionBox.Text += ")";
                    }
                }
            }
            result = Math.Sqrt(result);
            if (solutionBox != null)
            {
                solutionBox.Text += $"={result}";
                solutionBox.Text += "========================================\n";
            }
            return result;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.rows == b.rows && a.columns == b.columns)
            {
                Matrix result = new Matrix(a.rows, a.columns);
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < a.columns; j++)
                    {
                        result.data[i, j] = a.data[i, j] + b.data[i, j];
                    }
                }
                return result;
            }
            return null;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.rows == b.rows && a.columns == b.columns)
            {
                Matrix result = new Matrix(a.rows, a.columns);
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < a.columns; j++)
                    {
                        result.data[i, j] = a.data[i, j] - b.data[i, j];
                    }
                }
                return result;
            }
            return null;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.columns == b.rows)
            {
                Matrix result = new Matrix(a.rows, b.columns);
                for (int i = 0; i < result.rows; i++)
                {
                    for (int j = 0; j < result.columns; j++)
                    {
                        result.data[i, j] = 0;
                    }
                }
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        for (int k = 0; k < a.columns; k++)
                        {
                            result.data[i, j] += a.data[i, k] * b.data[k, j];
                        }
                    }
                }
                return result;
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
        public void Print()
        {
            if (solutionBox != null)
            {
                for (int i = 0; i < rows; i++)
                {
                    solutionBox.Text += "(";
                    for (int j = 0; j < columns; j++)
                    {
                        if (Math.Abs(data[i, j]) >= 0.001)
                            solutionBox.Text += Math.Round(data[i, j], 3).ToString();
                        else solutionBox.Text += Math.Round(data[i, j], 5).ToString();
                        if (j == columns - 1) continue;
                        solutionBox.Text += "; ";
                    }
                    solutionBox.Text += ")\n";
                }
            }
        }
        public void JordanGauss()
        {
            var I = new ExtendedMatrix(this);
            if (solutionBox != null)
            {
                solutionBox.Text += "МЕТОД ЖОРДАНА-ГАУСА\n";
                solutionBox.Text += "========================================\n";
                solutionBox.Text += "Початкова матриця:\n";
                Print();
                solutionBox.Text += "========================================\n";
                solutionBox.Text += "Розширена матриця:\n";
                I.Print();
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
                        if (diagelem != 1)
                        {
                            if (solutionBox != null)
                            {
                                solutionBox.Text += "========================================\n";
                                solutionBox.Text += $"{i + 1}р. = {i + 1}р./{diagelem}\n";
                            }
                            for (int k = 0; k < size * 2; k++)
                            {
                                I.data[i, k] = I.data[i, k] / diagelem;
                            }
                            I.Print();
                        }
                        for (int currrow = 0; currrow < size; currrow++)
                        {
                            if (currrow != i)
                            {
                                //double ratio = I.data[currrow, j] / I.data[i, j];
                                double ratio = I.data[currrow, j];
                                if (solutionBox != null)
                                {
                                    solutionBox.Text += "========================================\n";
                                    //solutionBox.Text += $"ratio = I[{currrow+1}, {j+1}]/I[{i+1}, {j+1}]\n";
                                    //solutionBox.Text += $"ratio = {I.data[currrow, j]}/{I.data[i, j]} = {ratio}\n";
                                    solutionBox.Text += $"ratio = I[{currrow+1}, {j+1}]\n";
                                    solutionBox.Text += $"ratio = {I.data[currrow, j]}\n";
                                    solutionBox.Text += $"{currrow}р. = {currrow}р. - {i}р. * ratio\n";
                                    solutionBox.Text += $"{currrow}р. = {currrow}р. - {i}р. * {ratio}\n";
                                }
                                for (int currcolumn = 0; currcolumn < size * 2; currcolumn++)
                                {
                                    I.data[currrow, currcolumn] = I.data[currrow, currcolumn] - I.data[i, currcolumn] * ratio;
                                }
                                I.Print();
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
            if (solutionBox != null)
            {
                solutionBox.Text += "========================================\n";
                solutionBox.Text += "Результат:\n";
                Print();
                solutionBox.Text += "========================================\n";
            }
        }
        public double GetDet()
        {
            return det;
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
            det = Determinant();
            if (det != 0)
            {
                if (solutionBox != null)
                {
                    solutionBox.Text += "det(A) != 0\n";
                    solutionBox.Text += "========================================\n";
                }
                return true;
            }
            if (solutionBox != null)
                solutionBox.Text += "det(A) = 0 -> рішення немає.\n";
            return false;
        }
        public double Determinant()
        {
            if (solutionBox != null)
            {
                solutionBox.Text += "========================================\n";
                solutionBox.Text += "ВИЗНАЧНИК МАТРИЦІ\n";
            }
            det = 1;
            if (size == 2)
            {
                det = data[0, 0] * data[1, 1] - data[1, 0] * data[0, 1];
                if (solutionBox != null)
                    solutionBox.Text += $"det(A) = {data[0, 0]} * {data[1, 1]} - {data[1, 0]} * {data[0, 1]} = {det}\n";
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
                                        if (solutionBox != null) solutionBox.Text += $"row{i} <=> row{m}\n";
                                        break;
                                    }
                                    else
                                    {
                                        SwapRows(i, m);
                                    }
                                }
                                if (diagelem == 0)
                                {
                                    if (solutionBox != null) solutionBox.Text += "немає рішення\n";
                                    return 0;
                                }
                            }
                            for (int currrow = i + 1; currrow < size; currrow++)
                            {
                                double ratio = -1 * copy.data[currrow, j] / copy.data[i, j];
                                
                                for (int currcolumn = 0; currcolumn < size; currcolumn++)
                                {
                                    copy.data[currrow, currcolumn] = copy.data[i, currcolumn]*ratio + copy.data[currrow, currcolumn];
                                    //solutionBox.Text += $"A[{currrow}, {currcolumn}] = A[{i}, {currcolumn}] * (-1)*A{"
                                }
                                if (solutionBox != null)
                                {
                                    solutionBox.Text += "========================================\n";
                                    solutionBox.Text += $"{currrow + 1}р. = {i + 1}р. * ((-1)*A[{currrow + 1}, {j + 1}] / A[{i + 1}, {j + 1}]) + {currrow + 1}р.\n";
                                    solutionBox.Text += $"{currrow + 1}р. = {i + 1}р. * ((-1)*{data[currrow, j]} / {data[i, j]}) + {currrow + 1}р.\n";
                                }
                                copy.Print();
                                
                            }
                            break;
                        }
                    }
                }
                // finding det
                if (solutionBox != null)
                {
                    solutionBox.Text += "========================================\n";
                    solutionBox.Text += "det(A) = ";
                }
                for (int i = 0; i < size; i++)
                {
                    det *= copy.data[i, i];
                    if (solutionBox != null)
                    {
                        if (copy.data[i, i].ToString()[0] != '-') solutionBox.Text += copy.data[i, i].ToString();
                        else solutionBox.Text += $"({copy.data[i, i]})";
                        if (i == size - 1) continue;
                        solutionBox.Text += "*";
                    }
                }
                if (solutionBox != null)
                    solutionBox.Text += $" = {det}\n";
            }
            return det;
        } 
    }
}
