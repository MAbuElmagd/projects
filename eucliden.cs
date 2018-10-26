using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication40
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the pair numbers:");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int b;
            if (y > x) { b = x;x = y;y = b; }
            int z,c, q;
            c = x; q = y;z = x % y;
            for (int i = 0; i < x; i++)
            {
                if (z == 0)
                {
                    Console.WriteLine(c + "=" + c / q + "*" + q + "+" + z);
                    Console.WriteLine("gcd("+x+","+y+")="+q);
                    Console.WriteLine("lcm("+x+", "+y+") = "+x*q);
                    break; }
                else
                {
                    Console.WriteLine(c + "=" + c / q + "*" + q + "+" + z);
                    c = q; q = z; z = c % q;
                }
            }
            Console.ReadKey();
        }
    }
}
