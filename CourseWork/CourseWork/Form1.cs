﻿using System;
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

        private void FillMatrix(double[,] Matrix, int size)
        {
            Matrix[0, 0] = Convert.ToDouble(elem00);
            Matrix[0, 1] = Convert.ToDouble(elem01);
            Matrix[1, 0] = Convert.ToDouble(elem10);
            Matrix[1, 1] = Convert.ToDouble(elem11);
            if(size > 2)
            {
                Matrix[0, 2] = Convert.ToDouble(elem02);
                Matrix[1, 2] = Convert.ToDouble(elem12);
                Matrix[2, 0] = Convert.ToDouble(elem20);
                Matrix[2, 1] = Convert.ToDouble(elem21);
                Matrix[2, 2] = Convert.ToDouble(elem22);
                if (size > 3)
                {
                    Matrix[0, 3] = Convert.ToDouble(elem03);
                    Matrix[1, 3] = Convert.ToDouble(elem13);
                    Matrix[2, 3] = Convert.ToDouble(elem23);
                    Matrix[3, 0] = Convert.ToDouble(elem30);
                    Matrix[3, 1] = Convert.ToDouble(elem31);
                    Matrix[3, 2] = Convert.ToDouble(elem32);
                    Matrix[3, 3] = Convert.ToDouble(elem33);
                    if (size > 4)
                    {
                        Matrix[0, 4] = Convert.ToDouble(elem04);
                        Matrix[1, 4] = Convert.ToDouble(elem14);
                        Matrix[2, 4] = Convert.ToDouble(elem24);
                        Matrix[3, 4] = Convert.ToDouble(elem34);
                        Matrix[4, 0] = Convert.ToDouble(elem40);
                        Matrix[4, 1] = Convert.ToDouble(elem41);
                        Matrix[4, 2] = Convert.ToDouble(elem42);
                        Matrix[4, 3] = Convert.ToDouble(elem43);
                        Matrix[4, 4] = Convert.ToDouble(elem44);
                    }
                }
            }
        }

        private void SaveResultMatrixToFile()
        {

        }

        private void solve_Click(object sender, EventArgs e)
        {
            double[,] Matrix;
            if (sizebox.SelectedItem != null && method.SelectedItem != null)
            {
                Matrix = InputProblem();
            }
        }
    }
}
