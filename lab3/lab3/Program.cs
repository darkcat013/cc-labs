using System.Diagnostics;

var sizes = new int[] { 10000000, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000 };

static bool[] Algorithm1(int n, bool[] c)
{
    c[1] = false;
    int i = 2;
    int count = 0;
    while (i <= n)
    {
        if (c[i])
        {
            int j = 2 * i;
            while (j <= n)
            {
                c[j] = false;
                j += i;
                count++;
            }
        }
        i++;
    }
    return c;
}

static bool[] Algorithm2(int n, bool[] c)
{
    c[1] = false;
    int i = 2;
    int count = 0;
    while (i <= n)
    {
        int j = 2 * i;
        while (j <= n)
        {
            c[j] = false;
            j += i;
            count++;
        }
        i++;
    }
    return c;
}

static bool[] Algorithm3(int n, bool[] c)
{
    c[1] = false;
    int i = 2;
    int count = 0;
    while (i <= n)
    {
        if(c[i])
        {
            int j = i + 1;
            while (j <= n)
            {
                if(j % i ==0)
                {
                    c[j] = false;
                }
                count++;
                j++;
            }
        }
        i++;
    }
    Console.WriteLine(count);
    return c;
}

static bool[] Algorithm4(int n, bool[] c)
{
    c[1] = false;
    int i = 2;
    int count = 0;
    while (i <= n)
    {
        int j = 2;
        while(j < i)
        {
            if(i % j == 0)
            {
                c[i] = false;
            }
            count++;
            j++;
        }
        i++;
    }
    Console.WriteLine(count);
    return c;
}

static bool[] Algorithm5(int n, bool[] c)
{
    c[1] = false;
    int i = 2;
    int count = 0;
    while (i <= n)
    {
        int j = 2;
        while (j <= Math.Sqrt(i))
        {
            if (i % j == 0)
            {
                c[i] = false;
            }
            count++;
            j++;
        }
        i++;
    }
    Console.WriteLine(count);
    return c;
}


static void PrintPrimes(bool[] c)
{
    for (int j = 1; j < c.Length; j++)
    {
        if (c[j]) Console.WriteLine(j);
    }
}

List<int> results = new List<int>();
List<int> timeResults = new List<int>();

Stopwatch stopwatch = new Stopwatch();
for (int i = 0; i < 1; i++)
{
    Console.WriteLine(sizes[i]);
    bool[] c = Enumerable.Repeat(true, sizes[i] + 1).ToArray();
    c[0] = false;
    stopwatch.Start();
    bool[] primes = Algorithm3(sizes[i], c);
    stopwatch.Stop();
    results.Add(primes.Count(x => x));
    timeResults.Add((stopwatch.Elapsed.Minutes * 60000) + (stopwatch.Elapsed.Seconds * 1000) + stopwatch.Elapsed.Milliseconds);
}

foreach (var item in results)
{
    Console.WriteLine(item);
}
foreach (var item in timeResults)
{
    Console.WriteLine(item);
}
