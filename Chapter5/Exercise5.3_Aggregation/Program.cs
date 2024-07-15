using static System.Console;

int numberAbove20ComesFirst =
    Enumerable
    .Range(1, 50)
   // .AsParallel()
    //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
    //.WithDegreeOfParallelism(4) 
    .Where(x => x % 2 == 0)
    .Aggregate
     (
       20,
       (tempHighest, next) =>
       {
           if (tempHighest > 20)
           {
               return tempHighest;
           }
           else
           {
               int temp = tempHighest >= next ? tempHighest : next;
               WriteLine($"seed={tempHighest}, next={next},temp={temp}");
               return temp;
           }
       }
     );

WriteLine($"The number above 20 that appears first is: {numberAbove20ComesFirst}");





