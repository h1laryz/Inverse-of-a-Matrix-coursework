using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    /// <summary>
    /// Розширена матриця
    /// </summary>
    public class ExtendedMatrix : Matrix
    {
        public ExtendedMatrix(Matrix matrix) : base(matrix.Size, matrix.Size*2)
        {
            // слева обычная матрица
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    this[i, j] = matrix[i, j];
                }
            }
            // единичная матрица справа
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    if (i == j)
                    {
                        this[i, j + matrix.Size] = 1; 
                    }
                    else
                    {
                        this[i, j + matrix.Size] = 0;
                    }
                }
            }
        }
    }
}
  


