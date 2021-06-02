using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CourseWork
{
    public class Matrix
    {
        public static RichTextBox SolutionBox { get; set; } // вивід результату
        double[,] Data; // матриця коефіцієнтів
        /// <summary>
        /// Індексування матриці
        /// </summary>
        /// <param name="i">рядок</param>
        /// <param name="j">стовпець</param>
        /// <returns>A(i, j)</returns>
        public double this[int i, int j]
        {
            get { return Data[i, j]; }
            set { Data[i, j] = value; }
        }
        public int Rows { get; private set; } // к-ть рядків
        public int Columns { get; private set; } // к-ть стовпців
        public double Det { get; private set; } // детермінант матриці (заповнюється після виклику функції FindDeterminant())
        public int Size { get; private set; } // розмір (якщо матриця квадратна, якщо ні = -1)
        /// <summary>
        /// Конструктори
        /// </summary>
        public Matrix() { }
        public Matrix(int Size) { Data = new double[Size, Size]; this.Size = Size; Rows = Size; Columns = Size; }
        public Matrix(int Rows, int Columns) { Data = new double[Rows, Columns]; if (Rows == Columns) Size = Rows; else Size = -1; this.Rows = Rows; this.Columns = Columns; }
        public Matrix(Matrix matrix)
        {
            Size = matrix.Size;
            Columns = matrix.Columns;
            Rows = matrix.Rows;
            Data = new double[Rows, Columns];
            Det = matrix.Det;
            if (Rows == Columns) Size = Rows;
            else Size = -1;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Data[i, j] = matrix.Data[i, j];
                }
            }
        }
        /// <summary>
        /// Заміняє два рядки місцями
        /// </summary>
        /// <param name="firstrow">Перший рядок</param>
        /// <param name="secondrow">Другий рядок</param>
        private void SwapRows(int firstrow, int secondrow)
        {
            for (int j = 0; j < Columns; j++)
            {
                double temp = Data[firstrow, j];
                Data[firstrow, j] = Data[secondrow, j];
                Data[secondrow, j] = temp;
            }
        }
        /// <summary>
        /// Обернення матриці ітераційним методом Шульца
        /// </summary>
        public void Schultz()
        {
            int k = 0; // індекс ітерації
            double eps = 0.001; // точність методу Шульца
            IdentityMatrix E = new IdentityMatrix(Size); // одинична матриця
            Matrix transponated = new Matrix(this); // транспонована матриця
            transponated.Transponant();
            Matrix A1 = this * transponated; 
            Matrix currU = new Matrix(transponated); // теперішнє U
            double norm = A1.Norm(); ; // норма матриці
            if (SolutionBox != null)
            {
                SolutionBox.Text += "МЕТОД ШУЛЬЦА\n";
                SolutionBox.Text += "========================================\n";
                SolutionBox.Text += $"A1 = A*A^T\n";
                A1.Print();
                SolutionBox.Text += "========================================\n";
                A1.PrintNorm();
                SolutionBox.Text += "U1:\n";
                for (int i = 0; i < currU.Rows; i++)
                {
                    SolutionBox.Text += "(";
                    for (int j = 0; j < currU.Columns; j++)
                    {
                        SolutionBox.Text += $"{Math.Round(Data[i, j], 3)}/{Math.Round(norm, 1)}";
                        if (j == currU.Columns - 1) continue;
                        SolutionBox.Text += "; ";
                    }
                    SolutionBox.Text += ")\n";
                }
            }
            // знаходження U^0 (для користувача "U1")
            for (int i = 0; i < currU.Rows; i++)
            {
                for (int j = 0; j < currU.Columns; j++)
                {
                    currU.Data[i, j] = currU.Data[i, j] / norm;
                }
            }
            List<Matrix> U = new List<Matrix>();
            List<Matrix> Psi = new List<Matrix>();
            do
            {
                U.Add(currU);
                Psi.Add(E - this * U[k]);
                currU = U[k] * (E + Psi[k]);
                norm = Psi[k].Norm();
                k++;
                if (SolutionBox != null)
                {
                    if (k - 1 != 0) SolutionBox.Text += $"U{k} = U{k - 1}*(E+Ψ{k - 1})\n";
                    SolutionBox.Text += $"U{k}:\n";
                    U[k - 1].Print();
                    SolutionBox.Text += $"Ψ{k} = E-A*U{k}\n";
                    SolutionBox.Text += $"Ψ{k}:\n";
                    Psi[k - 1].Print();
                    Psi[k - 1].PrintNorm();
                    if (norm >= eps)
                    {
                        SolutionBox.Text += $"Норма Ψ{k} >= {eps}\n{norm} >= {eps} ==> продовжуємо алгоритм\n";
                    }
                    else SolutionBox.Text += $"Норма Ψ{k} < {eps}\n{norm} < {eps} ==> алгоритм закінчено\n";
                    SolutionBox.Text += "========================================\n";
                }
            } while (norm >= eps);

            // модифікація відповіді + повернення відповіді
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if ((Math.Abs(Math.Truncate(U[U.Count() - 1].Data[i, j])) + 1) - (Math.Abs(U[U.Count() - 1].Data[i, j])) <= eps)
                    {
                        // якщо наприклад 13 - 12.9999 <= 0.001, то округлити дані
                        Data[i, j] = Math.Round((U[U.Count() - 1]).Data[i, j]);
                    }
                    else if (!(Math.Abs((U[U.Count() - 1]).Data[i, j]) <= eps))
                    {
                        // якщо модуль числа > 0.001, то залишити, як є
                        Data[i, j] = (U[U.Count() - 1]).Data[i, j];
                    }
                    // інакше якщо модуль числа <= 0.001, то замінити нулем
                    else if (!(Math.Abs((U[U.Count() - 1]).Data[i, j]) > eps)) Data[i, j] = 0;
                }
            }
            if (SolutionBox != null)
            {
                SolutionBox.Text += "Результат:\n";
                Print();
                SolutionBox.Text += "========================================\n";
            }
        }
        /// <summary>
        /// Знаходження норми матриці
        /// </summary>
        /// <returns>Повертається норма матриці</returns>
        public double Norm()
        {
            double result = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result += Math.Pow(Data[i, j], 2);
                }
            }
            result = Math.Sqrt(result);
            return result;
        }
        public void PrintNorm()
        {
            if (SolutionBox != null)
            {
                SolutionBox.Text += "Норма матрицы = √(";
                double result = 0;
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        result += Math.Pow(Data[i, j], 2);
                        if (Math.Abs(Data[i, j]) >= 0.001)
                            SolutionBox.Text += $"({Math.Round(Data[i, j], 3)})^2";
                        else SolutionBox.Text += $"({Math.Round(Data[i, j], 5)})^2";
                        if (i != Size - 1 || j != Size - 1) SolutionBox.Text += "+";
                        else SolutionBox.Text += ")";
                    }
                }
                result = Math.Sqrt(result);
                SolutionBox.Text += $"={result}\n";
                SolutionBox.Text += "========================================\n";
            }
        }
        /// <summary>
        /// Додавання матриць
        /// </summary>
        /// <param name="a">Перша матриця</param>
        /// <param name="b">Друга матриця</param>
        /// <returns>a+b</returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows == b.Rows && a.Columns == b.Columns)
            {
                Matrix result = new Matrix(a.Rows, a.Columns);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        result.Data[i, j] = a.Data[i, j] + b.Data[i, j];
                    }
                }
                return result;
            }
            return null;
        }
        /// <summary>
        /// Віднімання матриць
        /// </summary>
        /// <param name="a">Перша матриця</param>
        /// <param name="b">Друга матриця</param>
        /// <returns>a-b</returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows == b.Rows && a.Columns == b.Columns)
            {
                Matrix result = new Matrix(a.Rows, a.Columns);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        result.Data[i, j] = a.Data[i, j] - b.Data[i, j];
                    }
                }
                return result;
            }
            return null;
        }
        /// <summary>
        /// Множення матриць
        /// </summary>
        /// <param name="a">Перша матриця</param>
        /// <param name="b">Друга матриця</param>
        /// <returns>a*b</returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns == b.Rows)
            {
                Matrix result = new Matrix(a.Rows, b.Columns);
                for (int i = 0; i < result.Rows; i++)
                {
                    for (int j = 0; j < result.Columns; j++)
                    {
                        result.Data[i, j] = 0;
                    }
                }
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < b.Columns; j++)
                    {
                        for (int k = 0; k < a.Columns; k++)
                        {
                            result.Data[i, j] += a.Data[i, k] * b.Data[k, j];
                        }
                    }
                }
                return result;
            }
            return null;
        }
        /// <summary>
        /// Транспонування матриці
        /// </summary>
        public void Transponant()
        {
            Matrix tempMatrix = new Matrix(this);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Data[i, j] = tempMatrix.Data[j, i];
                }
            }
        }
        /// <summary>
        /// Вивід матриці у TextRichBox (SolutionBox)
        /// </summary>
        public void Print()
        {
            if (SolutionBox != null)
            {
                for (int i = 0; i < Rows; i++)
                {
                    SolutionBox.Text += "(";
                    for (int j = 0; j < Columns; j++)
                    {
                        if (Math.Abs(Data[i, j]) >= 0.001)
                            SolutionBox.Text += Math.Round(Data[i, j], 3).ToString();
                        else SolutionBox.Text += Math.Round(Data[i, j], 5).ToString();
                        if (j == Columns - 1) continue;
                        SolutionBox.Text += "; ";
                    }
                    SolutionBox.Text += ")\n";
                }
            }
        }
        /// <summary>
        /// Обернення матриці методом Жордана-Гауса
        /// </summary>
        public void JordanGauss()
        {
            var AE = new ExtendedMatrix(this); // роширена матриця (A|E)
            if (SolutionBox != null)
            {
                SolutionBox.Text += "МЕТОД ЖОРДАНА-ГАУСА\n";
                SolutionBox.Text += "========================================\n";
                SolutionBox.Text += "Початкова матриця:\n";
                Print();
                SolutionBox.Text += "========================================\n";
                SolutionBox.Text += "Розширена матриця:\n";
                AE.Print();
            }
            double diagelem; // теперішній діагональний елемент
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                    {
                        diagelem = AE.Data[i, j];
                        if (diagelem == 0)
                        {
                            for (int m = i + 1; m < Size; m++) // якщо діагональний елемент = 0, міняти рядки місцями з нижніми
                            {
                                AE.SwapRows(i, m);
                                diagelem = AE.Data[i, j];
                                if (diagelem != 0)
                                {
                                    break;
                                }
                                else
                                {
                                    AE.SwapRows(i, m);
                                }
                            }
                            if (diagelem == 0)
                            {
                                // якщо діагональний елемент, що не дорівнює нулю після зміни рядків не знайшовся - рішення немає
                                // при det(A) != 0, це неможливо
                                return; 
                            }
                        }
                        if (diagelem != 1)
                        {
                            if (SolutionBox != null)
                            {
                                SolutionBox.Text += "========================================\n";
                                SolutionBox.Text += $"{i + 1}р. = {i + 1}р./{diagelem}\n";
                            }
                            for (int k = 0; k < AE.Columns; k++)
                            {
                                // ділимо весь рядок на діагональний елемент
                                AE.Data[i, k] = AE.Data[i, k] / diagelem;
                            }
                            AE.Print();
                        }
                        for (int currrow = 0; currrow < AE.Rows; currrow++)
                        {
                            if (currrow != i)
                            {
                                double ratio = AE.Data[currrow, j]; // коефіцієнт домноження рядка
                                if (SolutionBox != null)
                                {
                                    SolutionBox.Text += "========================================\n";
                                    SolutionBox.Text += $"ratio = [{currrow+1}, {j+1}]\n";
                                    SolutionBox.Text += $"ratio = {AE.Data[currrow, j]}\n";
                                    SolutionBox.Text += $"{currrow+1}р. = {currrow+1}р. - {i+1}р. * ratio\n";
                                    SolutionBox.Text += $"{currrow+1}р. = {currrow+1}р. - {i+1}р. * {ratio}\n";
                                }
                                // віднімається рядок від того, де знаходиться теперішній діагональний елемент * коефінієнт, щоб зробити нулі
                                // над та під діагональним елементом
                                for (int currcolumn = 0; currcolumn < AE.Columns; currcolumn++)
                                {
                                    AE.Data[currrow, currcolumn] = AE.Data[currrow, currcolumn] - AE.Data[i, currcolumn] * ratio;
                                }
                                AE.Print();
                            }
                        }
                        // після того як знайшло діагональний елемент в певному рядку, 
                        // щоб не ітерувалось просто так далі, цикл ломається
                        break;
                    }
                }
            }
            // повернення інвертованої матриці
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Data[i, j] = AE.Data[i, j + Size];
                }
            }
            if (SolutionBox != null)
            {
                SolutionBox.Text += "========================================\n";
                SolutionBox.Text += "Результат:\n";
                Print();
                SolutionBox.Text += "========================================\n";
            }
        }
        /// <summary>
        /// Генерація випадкової матриці
        /// </summary>
        public void GenerateData()
        {
            Random random = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Data[i, j] = random.Next(20);
                }
            }
            if (!ReversedExist())
            {
                GenerateData();
            }
        }
        /// <summary>
        /// Перевірка на те, чи існує обернена матриця
        /// </summary>
        /// <returns>Повертає true або false</returns>
        public bool ReversedExist()
        {
            Det = FindDeterminant();
            if (Det != 0)
            {
                if (SolutionBox != null)
                {
                    SolutionBox.Text += "det(A) != 0\n";
                    SolutionBox.Text += "========================================\n";
                }
                return true;
            }
            else if (SolutionBox != null)
            {
                SolutionBox.Text += "det(A) = 0 -> рішення немає.\n";
                SolutionBox.Text += "========================================\n";
            }
            return false;
        }
        /// <summary>
        /// Знаходження детермінанту методом прямого обходу Гауса
        /// </summary>
        /// <returns>Повертає детермінант</returns>А
        public double FindDeterminant()
        {
            if (SolutionBox != null)
            {
                SolutionBox.Text += "========================================\n";
                SolutionBox.Text += "ВИЗНАЧНИК МАТРИЦІ\n";
            }
            Det = 1;
            if (Size == 2)
            {
                Det = Data[0, 0] * Data[1, 1] - Data[1, 0] * Data[0, 1];
                if (SolutionBox != null)
                    SolutionBox.Text += $"det(A) = {Data[0, 0]} * {Data[1, 1]} - {Data[1, 0]} * {Data[0, 1]} = {Det}\n";
            }
            else
            {
                // прямий обхід Гауса, щоб зробити матрицю нижньо-трикутною
                double diagelem;
                Matrix copy = new Matrix(this);
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (i == j)
                        {
                            diagelem = copy.Data[i, j];
                            if (diagelem == 0)
                            {
                                int m;
                                for (m = i + 1; m < Size; m++)
                                {
                                    SwapRows(i, m);
                                    diagelem = copy.Data[i, j];
                                    if (diagelem != 0)
                                    {
                                        if (SolutionBox != null) SolutionBox.Text += $"row{i} <=> row{m}\n";
                                        break;
                                    }
                                    else
                                    {
                                        SwapRows(i, m);
                                    }
                                }
                                if (diagelem == 0)
                                {
                                    if (SolutionBox != null)
                                    {
                                        SolutionBox.Text += "немає рішення в даній ситуації\n";
                                        SolutionBox.Text += "========================================\n";
                                    }
                                    return 0;
                                }
                            }
                            for (int currrow = i + 1; currrow < Size; currrow++)
                            {
                                double ratio = -1 * copy.Data[currrow, j] / copy.Data[i, j];
                                
                                for (int currcolumn = 0; currcolumn < Size; currcolumn++)
                                {
                                    copy.Data[currrow, currcolumn] = copy.Data[i, currcolumn]*ratio + copy.Data[currrow, currcolumn];
                                }
                                if (SolutionBox != null)
                                {
                                    SolutionBox.Text += "========================================\n";
                                    SolutionBox.Text += $"{currrow + 1}р. = {i + 1}р. * ((-1)*A[{currrow + 1}, {j + 1}] / A[{i + 1}, {j + 1}]) + {currrow + 1}р.\n";
                                    SolutionBox.Text += $"{currrow + 1}р. = {i + 1}р. * ((-1)*{Data[currrow, j]} / {Data[i, j]}) + {currrow + 1}р.\n";
                                }
                                copy.Print();
                                
                            }
                            break;
                        }
                    }
                }
                if (SolutionBox != null)
                {
                    SolutionBox.Text += "========================================\n";
                    SolutionBox.Text += "det(A) = ";
                }
                // det = перемноження діагоналі
                for (int i = 0; i < Size; i++)
                {
                    Det *= copy.Data[i, i];
                    if (SolutionBox != null)
                    {
                        if (copy.Data[i, i].ToString()[0] != '-') SolutionBox.Text += copy.Data[i, i].ToString();
                        else SolutionBox.Text += $"({copy.Data[i, i]})";
                        if (i == Size - 1) continue;
                        SolutionBox.Text += "*";
                    }
                }
                if (SolutionBox != null)
                    SolutionBox.Text += $" = {Det}\n";
            }
            return Det;
        } 
    }
}
