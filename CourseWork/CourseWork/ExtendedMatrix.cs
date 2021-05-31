using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class ExtendedMatrix : Matrix
    {
        public ExtendedMatrix(Matrix matrix) : base(matrix.size, matrix.size*2)
        {
            // слева обычная матрица
            for (int i = 0; i < matrix.size; i++)
            {
                for (int j = 0; j < matrix.size; j++)
                {
                    this[i, j] = matrix[i, j];
                }
            }
            // единичная матрица справа
            for (int i = 0; i < matrix.size; i++)
            {
                for (int j = 0; j < matrix.size; j++)
                {
                    if (i == j)
                    {
                        this[i, j + matrix.size] = 1; 
                    }
                    else
                    {
                        this[i, j + matrix.size] = 0;
                    }
                }
            }
        }
    }
}
  


