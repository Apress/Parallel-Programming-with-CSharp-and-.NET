using static System.Console;
using Extensions;

WriteLine("Experimenting with an arbitrary function!");
Dictionary<int, int> multiplyByTwo = new()
{
    {1,2 },
    {2,4 },
    {3,6 },
    {4,8 },
    {5,10 }
};
multiplyByTwo.ForEach(x =>
  WriteLine($"f({x.Key})={x.Value}"));

namespace Extensions
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T>  sequence, Action<T> action)
        {
            if (action != null)
            {
                foreach (T item in sequence)
                {
                    action(item);
                }
            }
        }
    }
}

/*
 * This program produces the following output:
Experimenting with an arbitrary function!
f(1)=2
f(2)=4
f(3)=6
f(4)=8
f(5)=10
*/
