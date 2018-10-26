using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication47
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the pair numbers:");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            if (y > x) { b = x; x = y; y = b; }
            double gcd = 1, lcm = 1;
            for (int i = 0; i < x; i++)
            {
                gcd *= Math.Pow(prime(x)[i], Math.Min(primex(x)[i], primey(x)[i]));
                lcm *= Math.Pow(prime(x)[i], Math.Max(primex(x)[i], primey(x)[i]));
            }
            Console.WriteLine("gcd"+gcd+"lcm"+lcm);
            Console.ReadLine();
                Console.ReadKey();
        }
        static List<int> prime(int x)
        {
            bool isPrime = true;
            List<int> a = new List<int>();
            for (int i = 1; i <= x; i++)
            {
                for (int j = 2; j <= x; j++)
                {

                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    a.Add(i);
                }
                isPrime = true;
            }
            return a;
        }
        static List<int> primex(List<int> x)
        {
            int b, d = 0;
            List<int> ax = new List<int>();
            for (int i = 0; i < x;)
            {
                x = x / prime(x)[i];
                d += 1;
                if (x % prime(x)[i] != 0)
                {
                    i++;
                    ax[i] = d;
                }
            }
            d = 0;
            return ax;
        }
        static List<int> primey(List<int> x) { 
         int b, d = 0;
        List<int> ay = new List<int>();
            for (int i = 0; i < y;)
            {
                y = y / prime(x)[i];
                d += 1;
                if (y % prime(x)[i] != 0)
                {
                    i++;
                    ay[i] = d;
                }
                return ay;
            }
        }
        }
    }
