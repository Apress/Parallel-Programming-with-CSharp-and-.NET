using static System.Console;

var sample1 = new Lazy<Sample>(
    () => { return new Sample(5); }
    );

var sample2 = new Sample(10);
ReadKey();
WriteLine(sample1.Value.Flag);
ReadKey();

class Sample
{
    public int Flag { get; init; }
    public Sample(int  flag)
    {
        Flag = flag;
    }
    // It also can have some big data such as:
    // public int[] Data = new int[5000];

}
