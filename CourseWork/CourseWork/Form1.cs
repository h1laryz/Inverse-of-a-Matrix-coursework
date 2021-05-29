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


namespace CourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
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
            method.Items.Add("Жордана-Гауса");
            method.Items.Add("Шульца");
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            solutionBox.BorderStyle = BorderStyle.None;
        }
        private void numericSize_ValueChanged(object sender, EventArgs e)
        {
            if(numericSize.Value < 2)
            {
                numericSize.Value = 2;
            }
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
        public void FillMatrix(Matrix matrix)
        {
            for (int i = 0; i < numericSize.Value; i++)
            {
                for (int j = 0; j < numericSize.Value; j++)
                {
                    try
                    {
                        double temp = Convert.ToDouble(gridInputMatrix[j, i].Value);
                        matrix.SetData(i, j, temp);
                    }
                    catch
                    {
                        MessageBox.Show("Введіть коректні дані, будь ласка");
                    }
                }
            }
        }
        private void FillElements(DataGridView dataGrid, Matrix matrix)
        {
            numericSize.Value = matrix.GetSize();
            for (int i = 0; i < matrix.GetSize(); i++)
            {
                for (int j = 0; j < matrix.GetSize(); j++)
                {
                    dataGrid[j, i].Value = matrix.GetData(i, j).ToString();
                }
            }
        }
        private Matrix InputMatrixFromForm()
        {
            Matrix matrix = new Matrix(Convert.ToInt32(numericSize.Value));
            FillMatrix(matrix);
            return matrix;
        }
        private void generateButton_Click(object sender, EventArgs e)
        {
            Matrix matrix;
            Matrix.solutionBox = null;
            if (Convert.ToInt32(numericSize.Value) != 0)
            {
                int size = Convert.ToInt32(numericSize.Value);
                matrix = new Matrix(size);
                matrix.GenerateData();
                FillElements(gridInputMatrix, matrix);
            }
        }
        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                InputMatrixFromFile(openFileDialog1.FileName);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString();
            time = time.Replace(':', '.');
            saveFileDialog1.FileName = $"Обернення матриці {time}.txt";
            saveFileDialog1.Filter = "Text File | *.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (solutionBox.Text != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, solutionBox.Text);
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
        private void InputMatrixFromFile(string path)
        {
            if (new FileInfo(path).Length != 0)
            {
                String[] str = File.ReadAllLines(path);
                Matrix matrix = new Matrix(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    string curr = str[i];
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (curr.IndexOf(' ') >= 0)
                        {
                            matrix.SetData(i, j, Convert.ToDouble(curr.Substring(0, curr.IndexOf(' '))));
                            curr = curr.Remove(0, curr.IndexOf(' ') + 1);
                        }
                        else
                        {
                            matrix.SetData(i, j, Convert.ToDouble(curr.Substring(0, curr.Length)));
                            curr = curr.Remove(0, curr.Length);
                        }
                    }
                }
                FillElements(gridInputMatrix, matrix);
            }
        }
        private void solveButton_Click(object sender, EventArgs e)
        {
            Matrix matrix;
            if (Convert.ToInt32(numericSize.Value) != 0 && method.SelectedItem != null)
            {
                matrix = InputMatrixFromForm();
                solutionBox.Text = "Початкова матриця A: \n";
                Matrix.solutionBox = solutionBox;
                matrix.Print();
                if (matrix.ReversedExist())
                {
                    labelDeterminant.Text = matrix.GetDet().ToString();
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
                    labelDeterminant.Text = matrix.GetDet().ToString();
                    labelDeterminant.ForeColor = Color.Red;
                    MessageBox.Show("Матрица не имеет решения");
                }
            }
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = ((string[])(e.Data.GetData(DataFormats.FileDrop)))[0];
            InputMatrixFromFile(filePath);
        }
    }
}
