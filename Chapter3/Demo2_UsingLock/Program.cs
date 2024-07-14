using static System.Console;

Account account = new();
var credit100 = Task.Run(
    () => account.Credit(100)
  );

var debit500 = Task.Run(
    () => account.Debit(500)
  );

var credit200 = Task.Run(
    () => account.Credit(200)
  );
var credit300 = Task.Run(
    () => account.Credit(300)
  );

var debit100 = Task.Run(
    () => account.Debit(100)
  );

Task.WaitAll(credit100, credit200, credit300, debit500, debit100);
WriteLine($"The current balance is ${account.Balance}");

#region Non-synchronized version
//class Account
//{
//    public decimal Balance { get; set; }
//    public void Credit(decimal amount)
//    {
//        Balance += amount;
//        WriteLine($"The balance after the credit of ${amount} is ${Balance}");
//    }
//    public void Debit(decimal amount)
//    {
//        Balance -= amount;
//        WriteLine($"The balance after the debit of ${amount} is ${Balance}");
//    }
//}
#endregion

#region Synchronized version using the lock statement
class Account
{
    public decimal Balance { get; set; }
    private readonly object _balanceLock = new();
    public void Credit(decimal amount)
    {
        lock (_balanceLock)
        {
            Balance += amount;
            WriteLine($"The balance after the credit of ${amount} is ${Balance}");
        }
    }
    public void Debit(decimal amount)
    {
        lock (_balanceLock)
        {
            Balance -= amount;
            WriteLine($"The balance after the debit of ${amount} is ${Balance}");
        }
    }
}
#endregion