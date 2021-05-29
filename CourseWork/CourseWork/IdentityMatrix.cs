using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class IdentityMatrix : Matrix
    {
        public IdentityMatrix(int size) : base(size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        SetData(i, j, 1);
                    }
                    else
                    {
                        SetData(i, j, 0);
                    }
                }
            }
        }
    }
}