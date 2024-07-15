using static System.Console;
using CustomExceptions;

var numbers = Enumerable.Range(0, 100);
CancellationTokenSource cancellationTokenSource = new();
CancellationToken token = cancellationTokenSource.Token;
try
{
    numbers
      .AsParallel()
     .Where(x => x % 10 == 0)
     .WithCancellation(token)
     .Select(
         x =>
            {
                int temp = x * x;
                int random = new Random().Next(0, 2);
                if (temp > 6400)
                {
                    if (random % 2 == 0)
                    {
                        throw new ExceedsCustomLimitException($"The calculated value {temp} exceeds 6400");
                    }
                    else
                    {
                        cancellationTokenSource.Cancel();
                    }
                }
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
        WriteLine($"Error Type: {e.GetType().Name}, Message:{e.Message}");
    }

    ////Approach-2
    //ae.Handle(e =>
    //{
    //    WriteLine($"Error Type:{e.GetType().Name}, Message:{e.Message}");
    //    return true;
    //});
}
catch (OperationCanceledException oce)
{
    WriteLine($"Error: {oce.Message}");
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


