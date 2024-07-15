using static System.Console;
using CustomExceptions;

//var numbers = ParallelEnumerable.Range(0, 100);
var numbers = Enumerable.Range(0, 100);
try
{

   // var results =
    numbers
      .AsParallel()
     .Where(x => x % 10 == 0)
     .Select(
         x =>
         {
             int temp = x * x;
             if (temp > 6400)
                 throw new ExceedsCustomLimitException($"The calculated value {temp} exceeds 6400");
             WriteLine($"{x} is processed by task:[{Task.CurrentId}]");
             return temp;
         }
     )
    .ForAll(num => WriteLine($"The calculated number is: {num}"));  
}

catch (AggregateException ae)
{
    // Approach-1
    foreach (Exception e in ae.InnerExceptions)
    {
        WriteLine($"Error Type: {e.GetType().Name}, Message: {e.Message}");
    }

    ////Approach-2
    //ae.Handle(e =>
    //{
    //    WriteLine($"Error Type:{e.GetType().Name}, Message:{e.Message}");
    //    return true;
    //});
}


namespace CustomExceptions
{
    public class ExceedsCustomLimitException : Exception
    {
        public ExceedsCustomLimitException()
        {
            // Some other code, if any
        }

        public ExceedsCustomLimitException(string message)
            : base(message)
        {
            // Some other code, if any
        }

        public ExceedsCustomLimitException(string message, Exception inner)
            : base(message, inner)
        {
            // Some other code, if any
        }
    }
}
