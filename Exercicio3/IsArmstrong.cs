using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3
{
    public static class Armstrong
    {
        public static bool IsArmstrong(this int i)
        {
            // https://www.javatpoint.com/armstrong-number-in-c
            int n = i;
            int tmp = n;
            int sum = 0;
            int r;

            while (n > 0)
            {
                r = n % 10;
                sum = sum + (r * r * r);
                n = n / 10;
            }

            return (tmp == sum);
        }
    }
}
