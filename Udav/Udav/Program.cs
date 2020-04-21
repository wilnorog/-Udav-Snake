using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udav
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int n = 0, m = 0, f = 0;
            switch (a)
            {
                case 1:
                    n = 10; m = 10; f = 1;
                    ;
                    break;
                case 2:
                    n = 15; m = 15; f = 2; ;
                    break;
                case 3:
                    n = 20; m = 20; f = 3; ;
                    break;
            }

            Class1 snek = new Class1();
            snek.outputeMassive(snek.createMassive(n, m), f);
        }
    }
}
