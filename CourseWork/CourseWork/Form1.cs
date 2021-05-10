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
            sizebox.Items.Add("2x2");
            sizebox.Items.Add("3x3");
            sizebox.Items.Add("4x4");
            sizebox.Items.Add("5x5");
            sizebox.SelectedItem = "5x5";
            method.Items.Add("Шульца");
            method.Items.Add("Гауса-Жордана");
            if(sizebox.SelectedIndex != -1)
            {
                HideExtra();
            }
        }
        private void HideExtra()
        {
            if (sizebox.SelectedItem.ToString() == "2x2")
            {
                elem02.Hide();
                elem03.Hide();
                elem04.Hide();
                elem12.Hide();
                elem13.Hide();
                elem14.Hide();
                row3.Hide();
                row4.Hide();
                row5.Hide();
            }
            else if (sizebox.SelectedItem.ToString() == "3x3")
            {
                if (!elem02.Visible)
                {
                    elem02.Show();
                    elem12.Show();
                    row3.Show();
                }
                elem03.Hide();
                elem04.Hide();
                elem13.Hide();
                elem14.Hide();
                elem23.Hide();
                elem24.Hide();
                row4.Hide();
                row5.Hide();
            }
            else if (sizebox.SelectedItem.ToString() == "4x4")
            {
                if (!elem02.Visible)
                {
                    elem02.Show();
                    elem12.Show();
                    row3.Show();
                }
                if (!elem03.Visible)
                {
                    elem03.Show();
                    elem13.Show();
                    elem23.Show();
                    row4.Show();
                }
                elem04.Hide();
                elem14.Hide();
                elem24.Hide();
                elem34.Hide();
                row5.Hide();
            }
            else if (sizebox.SelectedItem.ToString() == "5x5")
            {
                if (!elem02.Visible)
                {
                    elem02.Show();
                    elem12.Show();
                    row3.Show();
                }
                if (!elem03.Visible)
                {
                    elem03.Show();
                    elem13.Show();
                    elem23.Show();
                    row4.Show();
                }
                if (!elem04.Visible)
                {
                    elem04.Show();
                    elem14.Show();
                    elem24.Show();
                    elem34.Show();
                    row5.Show();
                }
            }
        }

        private void sizebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideExtra();
        }

        public void FillMatrix(Matrix matrix, int size)
        {
            try
            {
                matrix.SetData(0, 0, Convert.ToDouble(elem00.Text));
                matrix.SetData(0, 1, Convert.ToDouble(elem01.Text));
                matrix.SetData(1, 0, Convert.ToDouble(elem10.Text));
                matrix.SetData(1, 1, Convert.ToDouble(elem11.Text));
                if (size > 2)
                {
                    matrix.SetData(0, 2, Convert.ToDouble(elem02.Text));
                    matrix.SetData(1, 2, Convert.ToDouble(elem12.Text));
                    matrix.SetData(2, 0, Convert.ToDouble(elem20.Text));
                    matrix.SetData(2, 1, Convert.ToDouble(elem21.Text));
                    matrix.SetData(2, 2, Convert.ToDouble(elem22.Text));
                    if (size > 3)
                    {
                        matrix.SetData(0, 3, Convert.ToDouble(elem03.Text));
                        matrix.SetData(1, 3, Convert.ToDouble(elem13.Text));
                        matrix.SetData(2, 3, Convert.ToDouble(elem23.Text));
                        matrix.SetData(3, 0, Convert.ToDouble(elem30.Text));
                        matrix.SetData(3, 1, Convert.ToDouble(elem31.Text));
                        matrix.SetData(3, 2, Convert.ToDouble(elem32.Text));
                        matrix.SetData(3, 3, Convert.ToDouble(elem33.Text));
                        if (size > 4)
                        {
                            matrix.SetData(0, 4, Convert.ToDouble(elem04.Text));
                            matrix.SetData(1, 4, Convert.ToDouble(elem14.Text));
                            matrix.SetData(2, 4, Convert.ToDouble(elem24.Text));
                            matrix.SetData(3, 4, Convert.ToDouble(elem34.Text));
                            matrix.SetData(4, 0, Convert.ToDouble(elem40.Text));
                            matrix.SetData(4, 1, Convert.ToDouble(elem41.Text));
                            matrix.SetData(4, 2, Convert.ToDouble(elem42.Text));
                            matrix.SetData(4, 3, Convert.ToDouble(elem43.Text));
                            matrix.SetData(4, 4, Convert.ToDouble(elem44.Text));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Введіть коректні дані");
            }
        }

        private void SaveResultMatrixToFile()
        {

        }

        private void solve_Click(object sender, EventArgs e)
        {
            Matrix matrix;
            if (sizebox.SelectedItem != null && method.SelectedItem != null)
            {
                matrix = InputMatrixFromForm();
            }
        }

        private Matrix InputMatrixFromForm()
        {
            if (sizebox.SelectedItem.ToString() == "2x2")
            {
                Matrix matrix = new Matrix(2);
                FillMatrix(matrix, 2);
                return matrix;
            }
            else if (sizebox.SelectedItem.ToString() == "3x3")
            {
                Matrix matrix = new Matrix(3);
                FillMatrix(matrix, 3);
                return matrix;
            }
            else if (sizebox.SelectedItem.ToString() == "4x4")
            {
                Matrix matrix = new Matrix(4);
                FillMatrix(matrix, 4);
                return matrix;
            }
            else if (sizebox.SelectedItem.ToString() == "5x5")
            {
                Matrix matrix = new Matrix(5);
                FillMatrix(matrix, 5);
                return matrix;
            }
            return null;
        }

        
        private void FillElements(Matrix matrix)
        {
            elem00.Text = Convert.ToString(matrix.GetData(0,0));
            elem01.Text = Convert.ToString(matrix.GetData(0, 1));
            elem10.Text = Convert.ToString(matrix.GetData(1, 0));
            elem11.Text = Convert.ToString(matrix.GetData(1, 1));
            if (matrix.GetSize() > 2)
            {
                elem02.Text = Convert.ToString(matrix.GetData(0, 2));
                elem12.Text = Convert.ToString(matrix.GetData(1, 2));
                elem20.Text = Convert.ToString(matrix.GetData(2, 0));
                elem21.Text = Convert.ToString(matrix.GetData(2, 1));
                elem22.Text = Convert.ToString(matrix.GetData(2, 2));
                if (matrix.GetSize() > 3)
                {
                    elem03.Text = Convert.ToString(matrix.GetData(0, 3));
                    elem13.Text = Convert.ToString(matrix.GetData(1, 3));
                    elem23.Text = Convert.ToString(matrix.GetData(2, 3));
                    elem30.Text = Convert.ToString(matrix.GetData(3, 0));
                    elem31.Text = Convert.ToString(matrix.GetData(3, 1));
                    elem32.Text = Convert.ToString(matrix.GetData(3, 2));
                    elem33.Text = Convert.ToString(matrix.GetData(3, 3));
                    if (matrix.GetSize() > 4)
                    {
                        elem04.Text = Convert.ToString(matrix.GetData(0, 4));
                        elem14.Text = Convert.ToString(matrix.GetData(1, 4));
                        elem24.Text = Convert.ToString(matrix.GetData(2, 4));
                        elem34.Text = Convert.ToString(matrix.GetData(3, 4));
                        elem40.Text = Convert.ToString(matrix.GetData(4, 0));
                        elem41.Text = Convert.ToString(matrix.GetData(4, 1));
                        elem42.Text = Convert.ToString(matrix.GetData(4, 2));
                        elem43.Text = Convert.ToString(matrix.GetData(4, 3));
                        elem44.Text = Convert.ToString(matrix.GetData(4, 4));
                    }
                }
            }
        }
        private void generate_Click(object sender, EventArgs e)
        {
            Matrix matrix;
            if (sizebox.SelectedItem != null)
            {
                int size = Convert.ToInt32(sizebox.SelectedItem.ToString().Substring(0, 1));
                matrix = new Matrix(size);
                matrix.GenerateData();
                FillElements(matrix);
            }
        }

        private void buttonDet_Click(object sender, EventArgs e)
        {
            Matrix matrix = InputMatrixFromForm();
            double det = matrix.FindDet();
            labelDet.Text = det.ToString();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (new FileInfo(openFileDialog1.FileName).Length != 0)
                {
                    String[] str = File.ReadAllLines(openFileDialog1.FileName);
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
                    FillElements(matrix);
                }
            }
        }
    }
}
