using System;
using System.Diagnostics;
using System.Numerics;

namespace lab1
{
    static class Program
    {
        static BigInteger FibonacciIterative(int n)
        {
            BigInteger a = 1;
            BigInteger b = 1;
            BigInteger c = 2;
            if (n == 1 || n == 2)
            {
                return a;
            }
            else if (n == 3)
            {
                return c;
            }
            else
            {
                for (int i = 2; i < n; i++)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
            }
            return c;
        }

        static BigInteger FibonacciMatrix(int n)
        {
            BigInteger[,] F = new BigInteger[,] { { 1, 1 }, { 1, 0 } };
            F.PowMatrix(n - 1);
            return F[0, 0];
        }

        static void MultiplyMatrix(this BigInteger[,] F, BigInteger[,] M)
        {
            BigInteger x = F[0, 0] * M[0, 0] + F[0, 1] * M[1, 0];
            BigInteger y = F[0, 0] * M[0, 1] + F[0, 1] * M[1, 1];
            BigInteger z = F[1, 0] * M[0, 0] + F[1, 1] * M[1, 0];
            BigInteger w = F[1, 0] * M[0, 1] + F[1, 1] * M[1, 1];

            F[0, 0] = x;
            F[0, 1] = y;
            F[1, 0] = z;
            F[1, 1] = w;
        }
        static void PowMatrix(this BigInteger[,] F, int n)
        {
            long i;
            BigInteger[,] M = new BigInteger[,] { { 1, 1 }, { 1, 0 } };

            for (i = 2; i <= n; i++)
            {
                F.MultiplyMatrix(M);
            }
        }

        static BigInteger FibonacciDerivedFormula(int n, BigInteger[] f)
        {
            if (n == 0)
                return 0;

            if (n == 1 || n == 2)
                return (f[n] = 1);

            if (f[n] != 0)
                return f[n];

            int k = (n & 1) == 1 ? (n + 1) / 2 : n / 2;

            f[n] = (n & 1) == 1 ? (FibonacciDerivedFormula(k, f) * FibonacciDerivedFormula(k, f) +
                                   FibonacciDerivedFormula(k - 1, f) * FibonacciDerivedFormula(k - 1, f))
                                : (2 * FibonacciDerivedFormula(k - 1, f) + FibonacciDerivedFormula(k, f)) *
                                                    FibonacciDerivedFormula(k, f);

            return f[n];
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int n = Convert.ToInt32(Console.ReadLine());
            BigInteger result;

            //Console.WriteLine("ITERATIVE");
            //stopwatch.Start();
            //result = FibonacciIterative(n);
            //stopwatch.Stop();

            //Console.WriteLine($"{(stopwatch.Elapsed.Minutes * 60000) + (stopwatch.Elapsed.Seconds * 1000) + stopwatch.Elapsed.Milliseconds}");
            ////Console.WriteLine(result);
            //stopwatch.Restart();

            //Console.WriteLine("MATRIX FORM");

            //stopwatch.Start();
            //result = FibonacciMatrix(n);
            //stopwatch.Stop();

            //Console.WriteLine($"{(stopwatch.Elapsed.Minutes * 60000) + (stopwatch.Elapsed.Seconds * 1000) + stopwatch.Elapsed.Milliseconds}");
            ////Console.WriteLine(result);
            //stopwatch.Restart();

            Console.WriteLine("DERIVED FORMULA");

            stopwatch.Start();
            result = FibonacciDerivedFormula(n, new BigInteger[n+1]);
            stopwatch.Stop();

            Console.WriteLine($"{(stopwatch.Elapsed.Minutes * 60000) + (stopwatch.Elapsed.Seconds * 1000) + stopwatch.Elapsed.Milliseconds}");

            //Console.WriteLine(result);
        }
    }
}