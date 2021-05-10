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
        readonly int size;
        public Matrix() { }
        public Matrix(int size) { data = new double[size, size]; this.size = size; }
        public void SetData(int i, int j, double value) { data[i, j] = value; }
        public double GetData(int i, int j) { return data[i, j]; }
        public int GetSize() { return size; }
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
            double det = FindDet();
            if (det != 0)
            {
                check = true;
            }
            return check;
        }
        public double FindDet()
        {
            double det = 0;
            if (size == 2)
            {
                det = GetData(0, 0) * GetData(1, 1) - GetData(1, 0) * GetData(0, 1);
            }
            else if (size == 3)
            {
                Matrix Minor = new Matrix(2);
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Minor.SetData(i, j, GetData(i + 1, j + 1));
                    }
                }
                /*Minor[0, 0] = Matrix[1, 1];
                Minor[0, 1] = Matrix[1, 2];
                Minor[1, 0] = Matrix[2, 1];
                Minor[1, 1] = Matrix[2, 2];*/
                double C00 = Math.Pow(-1, 2) * Minor.FindDet();
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 1)
                        {
                            Minor.SetData(i,j, GetData(i + 1, j + 1));
                        }
                        else
                        {
                            Minor.SetData(i, j, GetData(i + 1, j));
                        }

                    }
                }
                /*Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 2];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 2];*/
                double C01 = Math.Pow(-1, 3) * Minor.FindDet();
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Minor.SetData(i, j, GetData(i + 1, j));
                    }
                }
                /*Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 1];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 1];*/
                double C02 = Math.Pow(-1, 4) * Minor.FindDet();

                det = GetData(0, 0) * C00 + GetData(0, 1) * C01 + GetData(0, 2) * C02;
            }
            else if (size == 4)
            {
                Matrix Minor = new Matrix(3);
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Minor.SetData(i, j, GetData(i + 1, j + 1));
                    }
                }
                /*Minor[0, 0] = Matrix[1, 1];
                Minor[0, 1] = Matrix[1, 2];
                Minor[0, 2] = Matrix[1, 3];
                Minor[1, 0] = Matrix[2, 1];
                Minor[1, 1] = Matrix[2, 2];
                Minor[1, 2] = Matrix[2, 3];
                Minor[2, 0] = Matrix[3, 1];
                Minor[2, 1] = Matrix[3, 2];
                Minor[2, 2] = Matrix[3, 3];*/
                double C00 = Math.Pow(-1, 2) * Minor.FindDet();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 0)
                        {
                            Minor.SetData(i, j, GetData(i + 1, j));
                        }
                        else
                        {
                            Minor.SetData(i, j, GetData(i + 1, j + 1));
                        }
                    }
                }
                /*Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 2];
                Minor[0, 2] = Matrix[1, 3];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 2];
                Minor[1, 2] = Matrix[2, 3];
                Minor[2, 0] = Matrix[3, 0];
                Minor[2, 1] = Matrix[3, 2];
                Minor[2, 2] = Matrix[3, 3];*/
                double C01 = Math.Pow(-1, 3) * Minor.FindDet();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 2)
                        {
                            Minor.SetData(i, j, GetData(i + 1, j + 1));
                        }
                        else
                        {
                            Minor.SetData(i, j, GetData(i + 1, j));
                        }
                    }
                }
                /*Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 1];
                Minor[0, 2] = Matrix[1, 3];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 1];
                Minor[1, 2] = Matrix[2, 3];
                Minor[2, 0] = Matrix[3, 0];
                Minor[2, 1] = Matrix[3, 1];
                Minor[2, 2] = Matrix[3, 3];*/
                double C02 = Math.Pow(-1, 4) * Minor.FindDet();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Minor.SetData(i, j, GetData(i + 1, j));
                    }
                }
                /*Minor[0, 0] = Matrix[1, 0];
                Minor[0, 1] = Matrix[1, 1];
                Minor[0, 2] = Matrix[1, 2];
                Minor[1, 0] = Matrix[2, 0];
                Minor[1, 1] = Matrix[2, 1];
                Minor[1, 2] = Matrix[2, 2];
                Minor[2, 0] = Matrix[3, 0];
                Minor[2, 1] = Matrix[3, 1];
                Minor[2, 2] = Matrix[3, 2];*/
                double C03 = Math.Pow(-1, 5) * Minor.FindDet();
                det = C00 * GetData(0, 0) + C01 * GetData(0, 1) + C02 * GetData(0, 2) + C03 * GetData(0, 3);
            }
            else if (size == 5)
            {
                Matrix Minor = new Matrix(4);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Minor.SetData(i, j, GetData(i + 1, j + 1));
                    }
                }
                double C00 = Math.Pow(-1, 2) * Minor.FindDet();

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            Minor.SetData(i, j, GetData(i + 1, j));
                        }
                        else
                        {
                            Minor.SetData(i, j, GetData(i + 1, j + 1));
                        }
                    }
                }
                double C01 = Math.Pow(-1, 3) * Minor.FindDet();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j >= 2)
                        {
                            Minor.SetData(i, j, GetData(i + 1, j + 1));
                        }
                        else
                        {
                            Minor.SetData(i, j, GetData(i + 1, j));
                        }
                    }
                }
                double C02 = Math.Pow(-1, 4) * Minor.FindDet();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 3)
                        {
                            Minor.SetData(i, j, GetData(i + 1, j + 1));
                        }
                        else
                        {
                            Minor.SetData(i, j, GetData(i + 1, j));
                        }
                    }
                }
                double C03 = Math.Pow(-1, 5) * Minor.FindDet();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Minor.SetData(i, j, GetData(i + 1, j));
                    }
                }
                double C04 = Math.Pow(-1, 6) * Minor.FindDet();
                det = C00 * GetData(0, 0) + C01 * GetData(0, 1) + C02 * GetData(0, 2) + C03 * GetData(0, 3) + C04 * GetData(0, 4);
            }
            return det;
        }
    }
}
