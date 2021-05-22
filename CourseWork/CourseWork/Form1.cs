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
            //MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            richTextBox1.BorderStyle = BorderStyle.None;
            //gridInputMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            /*gridInputMatrix.Width = 153;
            gridInputMatrix.Height = 65;*/
        }
        private void numericSize_ValueChanged(object sender, EventArgs e)
        {
            gridInputMatrix.Columns.Clear();
            gridResultMatrix.Columns.Clear();
            gridInputMatrix.Rows.Clear();
            gridResultMatrix.Rows.Clear();
            for (int i = 0; i < numericSize.Value; i++)
            {
                gridInputMatrix.Columns.Add(Convert.ToString(i), Convert.ToString(i + 1));
                gridResultMatrix.Columns.Add(Convert.ToString(i), Convert.ToString(i + 1));
                //gridInputMatrix.Columns[i].Width = 30;
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
                        double temp = Convert.ToDouble(gridInputMatrix[i, j].Value);
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
                    dataGrid[i, j].Value = matrix.GetData(i, j).ToString();
                }
            }
        }
        private Matrix InputMatrixFromForm()
        {
            Matrix matrix = new Matrix(Convert.ToInt32(numericSize.Value));
            FillMatrix(matrix);
            return matrix;
        }
        private void generate_Click(object sender, EventArgs e)
        {
            Matrix matrix;
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
        private void SaveSolutionToFile()
        {

        }
        private void solve_Click(object sender, EventArgs e)
        {
            Matrix matrix;
            if (Convert.ToInt32(numericSize.Value) != 0 && method.SelectedItem != null)
            {
                matrix = InputMatrixFromForm();
                if (matrix.ReversedExist())
                {
                    if (method.SelectedItem.ToString() == "Шульца")
                    {
                        matrix.Schultz();
                        FillElements(gridResultMatrix, matrix);
                    }
                    else if (method.SelectedItem.ToString() == "Жордана-Гауса")
                    {
                        /*List<string> Text;*/
                        matrix.JordanGauss();
                        FillElements(gridResultMatrix, matrix);
                    }
                }
                else
                {
                    MessageBox.Show("Матрица не имеет решения");
                }
            }
        }
        private void buttonDet_Click(object sender, EventArgs e)
        {
            Matrix matrix = InputMatrixFromForm();
            double det = matrix.Determinant();
            labelDeterminant.Text = det.ToString();
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
