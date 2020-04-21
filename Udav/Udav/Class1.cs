using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Udav
{
    class Class1
    {


        public string[,] createMassive(int n, int m)
        {
            int i = 0, j = 0, a, b, s, d;
            string[,] mas = new string[n, m];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (i == 0 | j == 0 | i == n - 1 | j == m - 1)
                    {
                        mas[i, j] = "X";
                    }
                    else
                    {
                        mas[i, j] = " ";
                    }

                }


            }

            return mas;
        }
        public string move()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            string t = cki.Key.ToString();
            return t;
        }
        struct Point
        {
            int x, y;
            string e;
            public void SetXY(int nx, int ny, string ne)
            {
                x = nx;
                y = ny;
                e = ne;
            }
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
            public string E
            {
                get { return e; }
                set { e = value; }
            }
        }
        public void outputeMassive(string[,] mass, int p)
        {
            int g = 1, k = 0, soxx, soxy, o = 0;
            int perx = 0, pery = 0;
            int sh = 0;
            Point[] MP;
            MP = new Point[100];
            int[] masx = new int[1100];
            int[] masy = new int[1100];
            string puz;
            string t = " ";
            Class1 peridvig = new Class1();
            int n = mass.GetLength(0);
            int m = mass.GetLength(1);
            Random rand = new Random();
            string[] snake = new string[10000];
            int a, b, s, d;
            int isdes = 0;
            s = rand.Next(1, n - 2);
            d = rand.Next(1, m - 2);
            a = rand.Next(1, n - 2);
            b = rand.Next(1, m - 2);
            while (s == a && d == b)
            {
                s = rand.Next(1, n - 2);
                d = rand.Next(1, m - 2);
            }
            masx[0] = a;
            masy[0] = b;
            mass[a, b] = "S";
            mass[s, d] = "W";
            Console.Clear();
            do
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (mass[i, j] == "W")
                        {
                            isdes = 1;
                        }
                    }
                }
                if (isdes != 1)
                {
                    s = rand.Next(1, n - 2);
                    d = rand.Next(1, m - 2);
                    mass[s, d] = "W";
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(mass[i, j]);

                    }
                    Console.WriteLine();
                }
                if (Console.KeyAvailable == true)
                {
                    t = peridvig.move();
                }

                switch (t)
                {
                    case "UpArrow":
                        for (int i = 0; i < g; i++)
                        {
                            if (i == 0)
                            {

                                if (masx[0] == 0)
                                {
                                    if (mass[masx[0] + n - 1, masy[0]] == "S" | mass[masx[0] + n - 1, masy[0]] == "X")
                                    {
                                        o = 1;
                                    }
                                    puz = mass[masx[0], masy[0]];
                                    mass[masx[0], masy[0]] = mass[masx[0] + n - 1, masy[0]];
                                    mass[masx[0] + n - 1, masy[0]] = puz;
                                    perx = masx[0];
                                    pery = masy[0];
                                    masx[0] = masx[0] + n - 1;

                                }
                                else
                                {
                                    if (mass[masx[0] - 1, masy[0]] == "S" | mass[masx[0] - 1, masy[0]] == "X")
                                    {
                                        o = 1;
                                    }
                                    puz = mass[masx[0], masy[0]];
                                    mass[masx[0], masy[0]] = mass[masx[0] - 1, masy[0]];
                                    mass[masx[0] - 1, masy[0]] = puz;
                                    perx = masx[0];
                                    pery = masy[0];
                                    masx[0] = masx[0] - 1;

                                }

                                if (masx[0] == s && masy[0] == d)
                                {
                                    sh++;

                                }
                            }
                            if (i != 0)
                            {
                                puz = mass[masx[i], masy[i]];

                                mass[masx[i], masy[i]] = mass[perx, pery];
                                mass[perx, pery] = puz;
                                soxx = masx[i];
                                soxy = masy[i];
                                masx[i] = perx;
                                masy[i] = pery;
                                perx = soxx;
                                pery = soxy;


                            }

                            if (i == g - 1 && sh == 1)
                            {
                                masx[i + 1] = perx;
                                masy[i + 1] = pery;
                                mass[masx[i + 1], masy[i + 1]] = "S";
                                k++;
                            }




                        }

                        break;
                    case "DownArrow":
                        for (int i = 0; i < g; i++)
                        {


                            if (i == 0)
                            {
                                if (masx[0] == n - 1)
                                {
                                    if (mass[masx[0] - n + 1, masy[0]] == "S" | mass[masx[0] - n + 1, masy[0]] == "X")
                                    {
                                        o = 1;
                                    }
                                    puz = mass[masx[0], masy[0]];
                                    mass[masx[0], masy[0]] = mass[masx[0] - n + 1, masy[0]];
                                    mass[masx[0] - n + 1, masy[0]] = puz;
                                    perx = masx[0];
                                    pery = masy[0];
                                    masx[0] = masx[0] - n + 1;
                                }
                                else
                                {
                                    if (mass[masx[0] + 1, masy[0]] == "S" | mass[masx[0] + 1, masy[0]] == "X")
                                    {
                                        o = 1;
                                    }
                                    puz = mass[masx[0], masy[0]];
                                    mass[masx[0], masy[0]] = mass[masx[0] + 1, masy[0]];
                                    mass[masx[0] + 1, masy[0]] = puz;
                                    perx = masx[0];
                                    pery = masy[0];
                                    masx[0] = masx[0] + 1;

                                }

                                if (masx[0] == s && masy[0] == d)
                                {
                                    sh++;

                                }
                            }
                            else
                            {
                                puz = mass[masx[i], masy[i]];
                                mass[masx[i], masy[i]] = mass[perx, pery];
                                mass[perx, pery] = puz;
                                soxx = masx[i];
                                soxy = masy[i];
                                masx[i] = perx;
                                masy[i] = pery;
                                perx = soxx;
                                pery = soxy;
                            }
                            if (i == g - 1 && sh == 1)
                            {

                                masx[i + 1] = perx;
                                masy[i + 1] = pery;
                                mass[masx[i], masy[i + 1]] = "S";
                                k++;
                            }

                        }

                        break;
                    case "RightArrow":
                        for (int i = 0; i < g; i++)
                        {
                            if (i == 0)
                            {
                                if (masy[0] == m - 1)
                                {
                                    if (mass[masx[0], masy[0] - m + 1] == "S" | mass[masx[0], masy[0] - m + 1] == "X")
                                    {
                                        o = 1;
                                    }
                                    puz = mass[masx[0], masy[0]];
                                    mass[masx[0], masy[0]] = mass[masx[0], masy[0] - m + 1];
                                    mass[masx[0], masy[0] - m + 1] = puz;
                                    perx = masx[0];
                                    pery = masy[0];
                                    masy[0] = masy[0] - m + 1;

                                }
                                else
                                {
                                    if (mass[masx[0], masy[0] + 1] == "S" | mass[masx[0], masy[0] + 1] == "X")
                                    {
                                        o = 1;
                                    }
                                    puz = mass[masx[0], masy[0]];
                                    mass[masx[0], masy[0]] = mass[masx[0], masy[0] + 1];
                                    mass[masx[0], masy[0] + 1] = puz;
                                    perx = masx[0];
                                    pery = masy[0];
                                    masy[0] = masy[0] + 1;

                                }

                                if (masx[0] == s && masy[0] == d)
                                {
                                    sh++;

                                }
                            }
                            else
                            {
                                puz = mass[masx[i], masy[i]];
                                mass[masx[i], masy[i]] = mass[perx, pery];
                                mass[perx, pery] = puz;
                                soxx = masx[i];
                                soxy = masy[i];
                                masx[i] = perx;
                                masy[i] = pery;
                                perx = soxx;
                                pery = soxy;
                            }
                            if (i == g - 1 && sh == 1)
                            {

                                masx[i + 1] = perx;
                                masy[i + 1] = pery;
                                mass[masx[i + 1], masy[i + 1]] = "S";
                                k++;
                            }


                        }

                        break;
                    case "LeftArrow":
                        for (int i = 0; i < g; i++)
                        {
                            if (i == 0)
                            {
                                if (masy[0] == 0)
                                {
                                    if (mass[masx[0], masy[0] + m - 1] == "S" | mass[masx[0], masy[0] + m - 1] == "X")
                                    {
                                        o = 1;
                                    }
                                    puz = mass[masx[0], masy[0]];
                                    mass[masx[0], masy[0]] = mass[masx[0], masy[0] + m - 1];
                                    mass[masx[0], masy[0] + m - 1] = puz;
                                    perx = masx[0];
                                    pery = masy[0];
                                    masy[0] = masy[0] + m - 1;
                                }
                                else
                                {
                                    if (mass[masx[0], masy[0] - 1] == "S" | mass[masx[0], masy[0] - 1] == "X")
                                    {
                                        o = 1;
                                    }
                                    puz = mass[masx[0], masy[0]];
                                    mass[masx[0], masy[0]] = mass[masx[0], masy[0] - 1];
                                    mass[masx[0], masy[0] - 1] = puz;
                                    perx = masx[0];
                                    pery = masy[0];
                                    masy[0] = masy[0] - 1;
                                }

                                if (masx[0] == s && masy[0] == d)
                                {
                                    sh++;

                                }
                            }
                            else
                            {

                                puz = mass[masx[i], masy[i]];
                                mass[masx[i], masy[i]] = mass[perx, pery];
                                mass[perx, pery] = puz;
                                soxx = masx[i];
                                soxy = masy[i];
                                masx[i] = perx;
                                masy[i] = pery;
                                perx = soxx;
                                pery = soxy;
                            }

                            if (i == g - 1 && sh == 1)
                            {
                                masx[i + 1] = perx;
                                masy[i + 1] = pery;
                                mass[masx[i + 1], masy[i + 1]] = "S";
                                k++;

                            }

                        }
                        break;
                }
                Console.SetCursorPosition(0, 0);
                isdes = 0;
                sh = 0;
                if (k != 0)
                {
                    g++;
                }
                k = 0;
                switch (p)
                {
                    case 1:
                        Thread.Sleep(400);
                        break;
                    case 2:
                        Thread.Sleep(300);
                        break;
                    case 3:
                        Thread.Sleep(200);
                        break;
                }
                Thread.Sleep(300);
            } while (o == 0);

        }
    }
}
