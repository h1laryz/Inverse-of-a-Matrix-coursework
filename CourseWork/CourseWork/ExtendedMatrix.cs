using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class ExtendedMatrix : Matrix
    {
        public ExtendedMatrix(Matrix matrix) : base(matrix.GetSize(), matrix.GetSize()*2)
        {
            // слева обычная матрица
            for (int i = 0; i < matrix.GetSize(); i++)
            {
                for (int j = 0; j < matrix.GetSize(); j++)
                {
                    SetData(i, j, matrix.GetData(i, j));
                }
            }
            // единичная матрица справа
            for (int i = 0; i < matrix.GetSize(); i++)
            {
                for (int j = 0; j < matrix.GetSize(); j++)
                {
                    if (i == j)
                    {
                        SetData(i, j + matrix.GetSize(), 1);
                    }
                    else
                    {
                        SetData(i, j + matrix.GetSize(), 0);
                    }
                }
            }
        }
    }
}
  


