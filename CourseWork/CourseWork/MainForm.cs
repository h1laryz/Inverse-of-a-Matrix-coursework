using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace CourseWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        // метод задання стандартних параметрів для форми
        private void MainForm_Load(object sender, EventArgs e)
        {
            numericSize.Minimum = 2;
            solutionBox.ReadOnly = true;
            gridInputMatrix.AllowUserToAddRows = false;
            gridResultMatrix.AllowUserToAddRows = false;
            numericSize.Value = 2;
            gridInputMatrix.BackgroundColor = SystemColors.Control;
            gridResultMatrix.BackgroundColor = SystemColors.Control;
            gridInputMatrix.BorderStyle = BorderStyle.None;
            gridResultMatrix.BorderStyle = BorderStyle.None;
            gridInputMatrix.RowHeadersWidth = 54;
            gridResultMatrix.RowHeadersWidth = 54;
            gridResultMatrix.ReadOnly = true;
            method.Items.Add("Жордана-Гауса");
            method.Items.Add("Шульца");
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            solutionBox.BorderStyle = BorderStyle.None;
            openFileDialog1.Filter = "Text File | *.txt";
            saveFileDialog1.Filter = "Text File | *.txt";
            gridInputMatrix.AllowUserToOrderColumns = false;
            gridResultMatrix.AllowUserToOrderColumns = false;
            gridInputMatrix.AllowUserToAddRows = false;
            gridResultMatrix.AllowUserToAddRows = false;
            gridInputMatrix.AllowUserToDeleteRows = false;
            gridResultMatrix.AllowUserToDeleteRows = false;
            gridInputMatrix.AllowUserToResizeRows = false;
            gridResultMatrix.AllowUserToResizeRows = false;
        }
        // метод, що підбиває розмір таблиць до обраного користувачем
        private void numericSize_ValueChanged(object sender, EventArgs e)
        {
            solutionBox.Text = "";
            labelDeterminant.Text = "";
            gridInputMatrix.Columns.Clear();
            gridResultMatrix.Columns.Clear();
            gridInputMatrix.Rows.Clear();
            gridResultMatrix.Rows.Clear();
            for (int i = 0; i < numericSize.Value; i++)
            {
                gridInputMatrix.Columns.Add(Convert.ToString(i), Convert.ToString(i + 1));
                gridResultMatrix.Columns.Add(Convert.ToString(i), Convert.ToString(i + 1));
                gridInputMatrix.Columns[i].Width = 40;
                gridResultMatrix.Columns[i].Width = 40;
                gridInputMatrix.Rows.Add();
                gridResultMatrix.Rows.Add();
            }
            for (int i = 0; i < numericSize.Value; i++)
            {
                gridInputMatrix.Rows[i].HeaderCell.Value = (i + 1).ToString();
                gridResultMatrix.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
        // метод, що заповнює матрицю з вхідної таблиці
        private void FillMatrix(Matrix matrix)
        {
            for (int i = 0; i < numericSize.Value; i++)
            {
                for (int j = 0; j < numericSize.Value; j++)
                {
                    matrix[i, j] = Convert.ToDouble(gridInputMatrix[j, i].Value);
                }
            }
        }
        // метод, що заповнює елементи у таблицю з матриці
        private void FillElements(DataGridView dataGrid, Matrix matrix)
        {
            numericSize.Value = matrix.Size;
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    dataGrid[j, i].Value = matrix[i, j].ToString();
                }
            }
        }
        // метод реалізації кнопки генерації даних
        private void generateButton_Click(object sender, EventArgs e)
        {
            Matrix matrix;
            Matrix.SolutionBox = null;
            if (Convert.ToInt32(numericSize.Value) != 0)
            {
                int size = Convert.ToInt32(numericSize.Value);
                matrix = new Matrix(size);
                matrix.GenerateData();
                FillElements(gridInputMatrix, matrix);
            }
        }
        // метод реалізації кнопки імпорт даних
        private void importButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                InputMatrixFromFile(openFileDialog1.FileName);
            }
        }
        // метод реалізації кнопки зберігання розв'язку у файл
        private void saveButton_Click(object sender, EventArgs e)
        {
            bool isEmpty = true;
            if (gridResultMatrix[0, 0].Value.ToString() != "") isEmpty = false;
            if (!isEmpty || solutionBox.Text != "")
            {
                string time = DateTime.Now.ToString();
                time = time.Replace(':', '.');
                time = time.Replace('/', '.');
                saveFileDialog1.FileName = $"Обернення матриці {time}.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (solutionBox.Text != "")
                    {
                        File.WriteAllText(saveFileDialog1.FileName, solutionBox.Text);
                        if (!isEmpty)
                        {
                            bool lowAccuracy = false;
                            for (int i = 0; i < gridResultMatrix.RowCount; i++)
                            {
                                for (int j = 0; j < gridResultMatrix.ColumnCount; j++)
                                {
                                    double temp = Convert.ToDouble(gridResultMatrix[j, i].Value);
                                    if (temp != Math.Round(temp, 3))
                                    // якщо результат з RichTextBox != результат з матриці gridResultView
                                    {
                                        lowAccuracy = true; // помічена низька точність
                                        break; // щоб просто так не ітерувалось алгоритм ломається при першому знаходженні низької точності
                                    }
                                }
                                if (lowAccuracy) break; // аналогічно з верхнім break 
                            }
                            // запис більш точної відповіді у файл
                            if (lowAccuracy)
                            {
                                File.AppendAllText(saveFileDialog1.FileName, "Більш точний результат:\n");
                                string currRow;
                                for (int i = 0; i < gridResultMatrix.RowCount; i++)
                                {
                                    currRow = "(";
                                    for (int j = 0; j < gridResultMatrix.ColumnCount; j++)
                                    {
                                        currRow += gridResultMatrix[j, i].Value.ToString();
                                        if (j != gridResultMatrix.ColumnCount - 1)
                                            currRow += "; ";
                                        else currRow += ")\n";
                                    }
                                    File.AppendAllText(saveFileDialog1.FileName, currRow);
                                }
                            }
                        }
                    }
                    else
                    {
                        string currRow;
                        for (int i = 0; i < gridResultMatrix.RowCount; i++)
                        {
                            currRow = "(";
                            for (int j = 0; j < gridResultMatrix.ColumnCount; j++)
                            {
                                currRow += gridResultMatrix[j, i].Value.ToString();
                                if (j != gridResultMatrix.ColumnCount - 1)
                                    currRow += "; ";
                                else currRow += ")\n";
                            }
                            File.AppendAllText(saveFileDialog1.FileName, currRow);
                        }
                    }
                }
            } else MessageBox.Show("Програма ще не знаходила рішень");
        }
        // метод імпортування матриці з файлу
        private void InputMatrixFromFile(string path)
        {
            if (path.Contains(".txt"))
            {
                if (new FileInfo(path).Length != 0)
                {
                    String[] str = File.ReadAllLines(path);
                    // очищення файлу від зайвих пробілів
                    for (int i = 0; i < str.Length; i++)
                    {
                        string temp = str[i];
                        while (temp[temp.Length - 1] == ' ') temp = temp.Remove(temp.Length - 1, 1);
                        while (temp.Contains("  "))
                        {
                            temp = temp.Replace("  ", " ");
                        }
                        str[i] = temp;
                    }
                    // перевірка на квадратність даних
                    for (int i = 0; i < str.Length; i++)
                    {
                        string temp = str[i];
                        if (str.Length != temp.Length + 1 - temp.Replace(" ", "").Length)
                        {
                            MessageBox.Show("Імпортуйте файл з коректними даними");
                            return;
                        }
                    }
                    Matrix matrix = new Matrix(str.Length);
                    for (int i = 0; i < str.Length; i++)
                    {
                        string curr = str[i];
                        // якщо знаходиться буква - алгоритм закінчується
                        if (Regex.Matches(curr, @"[a-zA-Z]").Count != 0)
                        {
                            MessageBox.Show("Імпортуйте файл з коректними даними");
                            return;
                        }
                        // запис у матрицю даних зі стрінгу
                        for (int j = 0; j < str.Length; j++)
                        {
                            if (curr.IndexOf(' ') >= 0)
                            {
                                matrix[i, j] = Convert.ToDouble(curr.Substring(0, curr.IndexOf(' ')));
                                curr = curr.Remove(0, curr.IndexOf(' ') + 1);
                            }
                            else
                            {
                                matrix[i, j] = Convert.ToDouble(curr.Substring(0, curr.Length));
                                curr = curr.Remove(0, curr.Length);
                            }
                        }
                    }
                    FillElements(gridInputMatrix, matrix);
                }
                else
                {
                    MessageBox.Show("Імпорт неможливий: файл є пустим");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Програмне забезпечення підтримує імпорт файлів тільки формату \".txt\"");
                return;
            }
        }
        // метод реалізації кнопки розв'язку
        private void solveButton_Click(object sender, EventArgs e)
        {
            Matrix matrix;
            if (Convert.ToInt32(numericSize.Value) != 0 && method.SelectedItem != null)
            {
                matrix = new Matrix(Convert.ToInt32(numericSize.Value));
                try { FillMatrix(matrix); }
                catch { MessageBox.Show("Введіть коректні дані в таблицю"); return; }
                if (checkShowSolution.Checked)
                {
                    solutionBox.Text = "Початкова матриця A: \n";
                    Matrix.SolutionBox = solutionBox;
                }
                else
                {
                    Matrix.SolutionBox = null;
                    solutionBox.Text = "";
                }
                matrix.Print();
                if (matrix.ReversedExist())
                {
                    labelDeterminant.Text = matrix.Det.ToString();
                    labelDeterminant.ForeColor = Color.Black;
                    if (method.SelectedItem.ToString() == "Шульца")
                    {
                        matrix.Schultz();
                        FillElements(gridResultMatrix, matrix);
                    }
                    else if (method.SelectedItem.ToString() == "Жордана-Гауса")
                    {
                        matrix.JordanGauss();
                        FillElements(gridResultMatrix, matrix);
                    }
                }
                else
                {
                    labelDeterminant.Text = matrix.Det.ToString();
                    labelDeterminant.ForeColor = Color.Red;
                    MessageBox.Show("Матриця не має рішення");
                }
            }
            else MessageBox.Show("Оберіть метод розв'язання");
        }
        // методи реалізації перетягування файлу на програму 
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = ((string[])(e.Data.GetData(DataFormats.FileDrop)))[0];
            InputMatrixFromFile(filePath);
        }
        // метод, який спрацьовує, коли дані в матриці були змінені (стирає усі рішення)
        private void gridInputMatrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            labelDeterminant.Text = "";
            solutionBox.Text = "";
            for (int i = 0; i < gridResultMatrix.RowCount; i++)
            {
                for (int j = 0; j < gridResultMatrix.ColumnCount; j++)
                {
                    gridResultMatrix[j, i].Value = "";
                }
            }
        }
    }
}
