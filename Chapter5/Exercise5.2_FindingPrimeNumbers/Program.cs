using static System.Console;

const int count = 100;
var numbers = Enumerable.Range(1, count);

var primes = numbers
   .AsParallel()
   .Where(x =>
    {
        if (x == 1) return false;
        if (x == 2) return true;
        var boundary = (int)Math.Floor(Math.Sqrt(x));
        for (int i = 2; i <= boundary; i++)
        {
            if (x % i == 0) return false;
        }
        return true;
    });
WriteLine("Prime numbers are:");
primes
    .ToList()
    .ForEach(primes => Write(primes + "\t"));


