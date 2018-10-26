using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gauessjurdanElemenation
{
    class Program
    {
        static void matrix(int a, int b, double[,] x)
        {
            for (int i = 0; i <x.GetLength(0); i++)
            {
                for (int z = 0; z < x.GetLength(1); z++)
                {
                    if((i<a&&a>=b)||(i>a&&a<b))
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("   " + (x[i, z]) + "   ");
                        Console.ResetColor();
                    }
                    else if (i == a || z == b)
                    {
                        Console.BackgroundColor = ConsoleColor.White ;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("   " + (x[i, z]) + "   ");
                        Console.ResetColor();
                    }
                    else Console.Write("   " +(x[i, z]) + "   ");
                }
                Console.WriteLine();
            }
        }
        static void gauess_jurdan(int a, int b, double[,] x)
        {
           double r = 0, n = 0;  double[] arr = new double[b];
            Console.WriteLine("the solution is :");
            for (int j = 0; j < b - 1; j++)
                for (int i = 0; i < a; i++)
                {
                    if (x[j, j] == 1)
                    {
                        for (int q = 0; q < b; q++)
                        {
                            arr[q] = x[j, q];
                        }
                    }
                    if (i == j)
                    {
                        if (x[i, j] == 1)
                        {
                            continue;
                        }
                        else if (x[i, j] != 1)
                        {
                            if (x[i, j] == 0)
                            {
                                for (int z = 0; z < a; z++)
                                {
                                    if (x[z, j] == 1)
                                    {
                                        n = z;
                                        for (int q = 0; q < b; q++)
                                        {
                                            r = x[z, q];
                                            x[z, q] = x[i, q];
                                            x[i, q] = r;
                                        }
                                        Console.WriteLine("R" + (i + 1) + "=" + "R" + (n+ 1));
                                        matrix(i,j,x);
                                    }
                                }
                            }
                            else if (x[i, j] != 0 && x[i, j] != 1&&x[i,i]!=1)
                            {
                               
                              Console.WriteLine("R" + (i + 1) + "=" + (r) + "*" + "R" + (i + 1));
                                r = 1 / x[i, j];
                               
                                    for (int q = 0; q < b; q++)
                                        
                                    x[i, q] *=r;
                                matrix(i,j,x);
                            }
                        }
                    }
                    else if (i > j)
                    {
                        if (x[i, j] == 0) { continue; }
                        else
                        {
                            if (x[i, j] < 0)
                            {
                                r = -1*x[i, j]; Console.WriteLine("R" + (i + 1) + "=" + "R" + (i + 1) + "+" + (-x[i, j]) + "R" + j+1);
                                for (int q = 0; q < b; q++)
                                {
                                    arr[q] *= r;
                                    x[i, q] += arr[q];
                                }
                                
                                matrix(i,j,x);
                            }
                            else if (x[i, j] > 0)
                            {
                                r = x[i, j];
                                Console.WriteLine("R" + (i + 1) + "=" + "R" + (i + 1) + "-" + x[i, j] + "R" +j+1);
                                for (int q = 0; q < b; q++)
                                {
                                    arr[q] *= x[i,j];
                                    x[i, q] -= arr[q];
                                }
                                matrix(i,j,x);
                            }

                        }
                    }
                }
            for (int j = b - 2; j >= 0; j--)
                for (int i = a -1; i >=0; i--)
                {
                   
                        if (x[j, j] == 1)
                        {
                        for (int q = 0; q < b; q++)
                            arr[q] = x[j, q];

                        }
                    
                    if(i!=j&&x[i,j]!=0)
                    {
                        if (x[i, j] < 0)
                        {
                            Console.WriteLine("R" + (i + 1) + "=" + "R" + (i + 1) + "+" + -x[i, j] + "R" + (i+2));
                            for (int q = 0; q < b; q++)
                                arr[q] *=(-1* x[i, j]);
                            for (int q = 0; q < b; q++) { 
                                x[i, q] += arr[q];
                        }
                            matrix(i,j,x);
                            }
                            else if (x[i, j] > 0)
                            {
                            r = x[i, j];
                                Console.WriteLine("R" + (i + 1) + "=" + "R" + (i + 1) + "-" + x[i, j] + "R" +(i+2));
                                for (int q = 0; q < b; q++)
                                    arr[q] *= x[i,j];
                            for (int q = 0; q < b; q++)
                            {
                                x[i, q] -= arr[q]; 
                            }
                                matrix(i,j,x);
                        }
                    }
                    if (a > b - 1)
                        if(i>b-1)
                            for (int z = 0; z < b-1; z++)
                                x[i, z] *= 0;
                }
            Console.WriteLine("the solution is :");
            for (int i = 0; i < a; i++)
            {
                if (x[i, i] == 0 && x[i, (b - 1)] !=0 )
                {
                    Console.WriteLine("the system has no solution");
                    break;
                }
                else if (x[i, i] != 0 && x[i, (b - 1)] != 0)
                {
                    Console.WriteLine("X" + (i + 1) + "=" +Math.Round(  x[i, b - 1]));
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter the row number:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the column number:");
            int b = int.Parse(Console.ReadLine());
            double[,] x = new double[a, b];
            for (int i = 0; i < a; i++)
                for (int z = 0; z < b; z++)
                {
                    Console.WriteLine("enter the element[a" + (i + 1) + (z + 1) + "]:");
                    x[i, z] = double.Parse(Console.ReadLine());
                    try
                    {

                        x[i] = System.InvalidCastException;

                    }
                    catch (System.InvalidCastException i) { Console.WriteLine("\r"); }
                }
            Console.WriteLine("the augmanted matrix is:");
            for (int i = 0; i < a; i++)
            {
                for (int z = 0; z < b; z++)
                    Console.Write("   " + Math.Round(x[i, z]) + "   ");
                Console.WriteLine();
                }
                    Console.WriteLine("the system is :");
            for (int i = 0; i < a; i++)
            {
                for (int z = 0; z < b; z++)
                {
                    if (z == b - 1)
                        Console.Write("=" + x[i, z]);
                    else if (x[i, z] == 0)
                        Console.Write(" ");
                    else if (z==0)
                        Console.Write(x[i, z] + "x" + (z + 1));
                    else if (z != 0)
                    {
                        if (x[i, z] == 1)
                            Console.Write("+ x" + (z + 1));
                        else if (x[i, z] > 0)
                            Console.Write("+" + x[i, z] + "x" + (z + 1));
                        else if (z == 0)
                        {
                            if (x[i, z] == 1)
                                Console.Write("x" + (z + 1));
                            else if (x[i, z] > 0)
                                Console.Write(x[i, z] + "x" + (z + 1));
                        }
                    }
                }
                Console.WriteLine();
            }
            gauess_jurdan(a, b, x);
            Console.ReadKey();
        }
    }
}
