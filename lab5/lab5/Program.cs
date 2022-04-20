using System.Diagnostics;
using System.Numerics;

static string Spigot(int digits)
{
    digits++;

    uint[] x = new uint[digits * 10 / 3 + 2];
    uint[] r = new uint[digits * 10 / 3 + 2];

    uint[] pi = new uint[digits];

    for (int j = 0; j < x.Length; j++)
        x[j] = 20;

    for (int i = 0; i < digits; i++)
    {
        uint carry = 0;
        for (int j = 0; j < x.Length; j++)
        {
            uint num = (uint)(x.Length - j - 1);
            uint dem = num * 2 + 1;

            x[j] += carry;

            uint q = x[j] / dem;
            r[j] = x[j] % dem;

            carry = q * num;
        }


        pi[i] = (x[^1] / 10);


        r[x.Length - 1] = x[^1] % 10; ;

        for (int j = 0; j < x.Length; j++)
            x[j] = r[j] * 10;
    }

    var result = "";

    uint c = 0;

    for (int i = pi.Length - 1; i >= 0; i--)
    {
        pi[i] += c;
        c = pi[i] / 10;

        result = (pi[i] % 10).ToString() + result;
    }

    return result;
}


//Pi = 4 * (2 * arctan(1/3) + arctan(1/7))
//arctan(x) = x - x^3/3 + x^5/5 - x^7/7 + x^9/9 - ...
static BigInteger Hutton(int digits, int iterations)
{
    var magnitude = BigInteger.Pow(10, digits);
    var sum3 = BigInteger.Zero;
    var sum7 = BigInteger.Zero;
    bool sign = true;
    var totalIterations = (iterations * 2) + 1;
    for (int i = 1; i<=totalIterations; i += 2)
    {
        var current3 = magnitude / (BigInteger.Pow(3, i) * i);
        var current7 = magnitude / (BigInteger.Pow(7, i) * i);
        if (sign)
        {
            sum3 += current3;
            sum7 += current7;
        }
        else
        {
            sum3 -= current3;
            sum7 -= current7;
        }
        sign = !sign;
    }
    return (4 * (2 * sum3 + sum7));
}

Spigot(2);
var a = File.ReadAllText("pi100k.txt");
int n = 10000;
int step = n / 20;
int iStep = step / 20;
var iterations = iStep;
Stopwatch s = new();
List<char> results = new();
List<int> timeResults = new();
for (int i = 0; i <= n; i += step)
{
    s.Start();
    var result = Hutton(i + 10, i + iterations);
    s.Stop();
    iterations += iStep;
    results.Add(result.ToString()[i]);
    if (results.Last() != a[i]) throw new Exception($"Not the same {results.Last()}, {a[i]}");
    timeResults.Add((s.Elapsed.Minutes * 60000) + (s.Elapsed.Seconds * 1000) + s.Elapsed.Milliseconds);
    Console.WriteLine(i+1);
}
Console.WriteLine("results");
foreach (var item in results)
{
    Console.WriteLine(item);
}
Console.WriteLine("time");
foreach (var item in timeResults)
{
    Console.WriteLine(item);
}

//Spigot(i + 10)
//Hutton(i + 10, i+500)