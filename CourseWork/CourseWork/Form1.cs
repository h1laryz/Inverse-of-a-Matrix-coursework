using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

        

        private void FillMatrix(double[,] Matrix, int size)
        {
            try
            {
                Matrix[0, 0] = Convert.ToDouble(elem00.Text);
                Matrix[0, 1] = Convert.ToDouble(elem01.Text);
                Matrix[1, 0] = Convert.ToDouble(elem10.Text);
                Matrix[1, 1] = Convert.ToDouble(elem11.Text);
                if (size > 2)
                {
                    Matrix[0, 2] = Convert.ToDouble(elem02.Text);
                    Matrix[1, 2] = Convert.ToDouble(elem12.Text);
                    Matrix[2, 0] = Convert.ToDouble(elem20.Text);
                    Matrix[2, 1] = Convert.ToDouble(elem21.Text);
                    Matrix[2, 2] = Convert.ToDouble(elem22.Text);
                    if (size > 3)
                    {
                        Matrix[0, 3] = Convert.ToDouble(elem03.Text);
                        Matrix[1, 3] = Convert.ToDouble(elem13.Text);
                        Matrix[2, 3] = Convert.ToDouble(elem23.Text);
                        Matrix[3, 0] = Convert.ToDouble(elem30.Text);
                        Matrix[3, 1] = Convert.ToDouble(elem31.Text);
                        Matrix[3, 2] = Convert.ToDouble(elem32.Text);
                        Matrix[3, 3] = Convert.ToDouble(elem33.Text);
                        if (size > 4)
                        {
                            Matrix[0, 4] = Convert.ToDouble(elem04.Text);
                            Matrix[1, 4] = Convert.ToDouble(elem14.Text);
                            Matrix[2, 4] = Convert.ToDouble(elem24.Text);
                            Matrix[3, 4] = Convert.ToDouble(elem34.Text);
                            Matrix[4, 0] = Convert.ToDouble(elem40.Text);
                            Matrix[4, 1] = Convert.ToDouble(elem41.Text);
                            Matrix[4, 2] = Convert.ToDouble(elem42.Text);
                            Matrix[4, 3] = Convert.ToDouble(elem43.Text);
                            Matrix[4, 4] = Convert.ToDouble(elem44.Text);
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

        private double[,] GenerateMatrix(int size)
        {
            Random random = new Random();
            double[,] Matrix;
            Matrix = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Matrix[i,j] = random.Next(20);
                }
            }
            if (!ReversedExist(Matrix, size))
            {
                Matrix = GenerateMatrix(size);
            }
            return Matrix;
        }

        private void solve_Click(object sender, EventArgs e)
        {
            double[,] Matrix;
            if (sizebox.SelectedItem != null && method.SelectedItem != null)
            {
                Matrix = InputProblem();
            }
        }

        private bool ReversedExist(double[,] Matrix, int size)
        {
            bool check = false;
            double det = FindDet(Matrix, size);
            if (det != 0)
            {
                check = true;
            }
            return check;
        }

        private double FindDet(double[,] Matrix, int size)
        {
            double det = 0;
            if (size == 2)
            {
                det = Matrix[0, 0] * Matrix[1, 1] - Matrix[1, 0] * Matrix[0, 1];
            }
            else if (size == 3)
            {
                double[,] Minor = new double[2, 2];
                /*for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Minor[i, j] = Matrix[i + 1, j + 1];
                    }
                }*/
                Minor[0, 0] = Matrix[1, 1];
                Minor[0, 1] = Matrix[1, 2];
                Minor[1, 0] = Matrix[2, 1];
                Minor[1, 1] = Matrix[2, 2];
                double C00 = FindDet(Minor, 2);
                /*for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 1)
                        {
                            Minor[i, j] = Matrix[i + 1, j + 1];
                        }
                        else
                        {
                            Minor[i, j] = Matrix[i + 1, j];
                        }
                        
                    }
                }*/
                Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 2];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 2];
                double C01 = FindDet(Minor, 2);
                /*for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Minor[i, j] = Matrix[i + 1, j];
                    }
                }*/
                Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 1];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 1];
                double C02 = FindDet(Minor, 2);

                det = Matrix[0, 0] * C00 + Matrix[0, 1] * C01 + Matrix[0, 2] * C02;
            }
            else if (size == 4)
            {
                double[,] Minor = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Minor[i, j] = Matrix[i + 1, j + 1];
                    }
                }
                Minor[0, 0] = Matrix[1, 1];
                Minor[0, 1] = Matrix[1, 2];
                Minor[0, 2] = Matrix[1, 3];
                Minor[1, 0] = Matrix[2, 1];
                Minor[1, 1] = Matrix[2, 2];
                Minor[1, 2] = Matrix[2, 3];
                Minor[2, 0] = Matrix[3, 1];
                Minor[2, 1] = Matrix[3, 2];
                Minor[2, 2] = Matrix[3, 3];
                double C00 = FindDet(Minor, 3);
                /*for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 0)
                        {
                            Minor[i, j] = Matrix[i + 1, j];
                        }
                        else
                        {
                            Minor[i, j] = Matrix[i + 1, j + 1];
                        }
                    }
                }*/
                Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 2];
                Minor[0, 2] = Matrix[1, 3];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 2];
                Minor[1, 2] = Matrix[2, 3];
                Minor[2, 0] = Matrix[3, 0];
                Minor[2, 1] = Matrix[3, 2];
                Minor[2, 2] = Matrix[3, 3];
                double C01 = FindDet(Minor, 3);
                /*for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 2)
                        {
                            Minor[i, j] = Matrix[i + 1, j + 1];
                        }
                        else
                        {
                            Minor[i, j] = Matrix[i + 1, j];
                        }
                    }
                }*/
                Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 1];
                Minor[0, 2] = Matrix[1, 3];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 1];
                Minor[1, 2] = Matrix[2, 3];
                Minor[2, 0] = Matrix[3, 0];
                Minor[2, 1] = Matrix[3, 1];
                Minor[2, 2] = Matrix[3, 3];
                double C02 = FindDet(Minor, 3);
                /*for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Minor[i, j] = Matrix[i + 1, j];
                    }
                }*/
                Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 1];
                Minor[0, 2] = Matrix[1, 2];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 1];
                Minor[1, 2] = Matrix[2, 2];
                Minor[2, 0] = Matrix[3, 0];
                Minor[2, 1] = Matrix[3, 1];
                Minor[2, 2] = Matrix[3, 2];
                double C03 = FindDet(Minor, 3);
                det = C00 * Matrix[0, 0] + C01 * Matrix[0, 1] + C02 * Matrix[0, 2] + C03 * Matrix[0, 3]; 
            }
            else if (size==5)
            {
                double[,] Minor = new double[4, 4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Minor[i, j] = Matrix[i + 1, j + 1];
                    }
                }
                double C00 = FindDet(Minor, 4);

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            Minor[i, j] = Matrix[i + 1, j];
                        }
                        else
                        {
                            Minor[i, j] = Matrix[i + 1, j + 1];
                        }
                    }
                }
                double C01 = FindDet(Minor, 4);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j >= 2)
                        {
                            Minor[i, j] = Matrix[i + 1, j + 1];
                        }
                        else
                        {
                            Minor[i, j] = Matrix[i + 1, j];
                        }
                    }
                }
                double C02 = FindDet(Minor, 4);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j==4)
                        {
                            Minor[i, j] = Matrix[i + 1, j + 1];
                        }
                        else
                        {
                            Minor[i, j] = Matrix[i + 1, j];
                        }
                    }
                }
                double C03 = FindDet(Minor, 4);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Minor[i, j] = Matrix[i + 1, j];
                    }
                }
                double C04 = FindDet(Minor, 4);
                det = C00 * Matrix[0, 0] + C01 * Matrix[0, 1] + C02 * Matrix[0, 2] + C03 * Matrix[0, 3] + C04 * Matrix[0, 4];
            }
            return det;
        }

        private double[,] InputProblem()
        {
            double[,] Matrix;
            if (sizebox.SelectedItem.ToString() == "2x2")
            {
                Matrix = new double[2, 2];
                FillMatrix(Matrix, 2);
                return Matrix;
            }
            else if (sizebox.SelectedItem.ToString() == "3x3")
            {
                Matrix = new double[3, 3];
                FillMatrix(Matrix, 3);
                return Matrix;
            }
            else if (sizebox.SelectedItem.ToString() == "4x4")
            {
                Matrix = new double[4, 4];
                FillMatrix(Matrix, 4);
                return Matrix;
            }
            else if (sizebox.SelectedItem.ToString() == "5x5")
            {
                Matrix = new double[5, 5];
                FillMatrix(Matrix, 5);
                return Matrix;
            }
            return null;
        }

        private void FillElements(double[,] Matrix, int size)
        {
            elem00.Text = Convert.ToString(Matrix[0, 0]);
            elem01.Text = Convert.ToString(Matrix[0, 1]);
            elem10.Text = Convert.ToString(Matrix[1, 0]);
            elem11.Text = Convert.ToString(Matrix[1, 1]);
            if (size > 2)
            {
                elem02.Text = Convert.ToString(Matrix[0, 2]);
                elem12.Text = Convert.ToString(Matrix[1, 2]);
                elem20.Text = Convert.ToString(Matrix[2, 0]);
                elem21.Text = Convert.ToString(Matrix[2, 1]);
                elem22.Text = Convert.ToString(Matrix[2, 2]);
                if (size > 3)
                {
                    elem03.Text = Convert.ToString(Matrix[0, 3]);
                    elem13.Text = Convert.ToString(Matrix[1, 3]);
                    elem23.Text = Convert.ToString(Matrix[2, 3]);
                    elem30.Text = Convert.ToString(Matrix[3, 0]);
                    elem31.Text = Convert.ToString(Matrix[3, 1]);
                    elem32.Text = Convert.ToString(Matrix[3, 2]);
                    elem33.Text = Convert.ToString(Matrix[3, 3]);
                    if (size > 4)
                    {
                        elem04.Text = Convert.ToString(Matrix[0, 4]);
                        elem14.Text = Convert.ToString(Matrix[1, 4]);
                        elem24.Text = Convert.ToString(Matrix[2, 4]);
                        elem34.Text = Convert.ToString(Matrix[3, 4]);
                        elem40.Text = Convert.ToString(Matrix[4, 0]);
                        elem41.Text = Convert.ToString(Matrix[4, 1]);
                        elem42.Text = Convert.ToString(Matrix[4, 2]);
                        elem43.Text = Convert.ToString(Matrix[4, 3]);
                        elem44.Text = Convert.ToString(Matrix[4, 4]);
                    }
                }
            }
        }

        private void generate_Click(object sender, EventArgs e)
        {
            double[,] Matrix;
            if (sizebox.SelectedItem != null)
            {
                int size = Convert.ToInt32(sizebox.SelectedItem.ToString().Substring(0, 1));
                Matrix = GenerateMatrix(size);
                FillElements(Matrix, size);
            }
        }

        private void buttonDet_Click(object sender, EventArgs e)
        {
            double[,] Matrix = InputProblem();
            int size = Convert.ToInt32(sizebox.SelectedItem.ToString().Substring(0, 1));
            double det = FindDet(Matrix, size);
            labelDet.Text = det.ToString();
        }
    }
}
