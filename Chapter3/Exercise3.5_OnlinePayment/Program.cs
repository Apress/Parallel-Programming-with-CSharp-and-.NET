using static System.Console;

Account account = new();
var tasks = new List<Task>();
for(int i=0;i<1000;i++)
{
    tasks.Add
     (
        Task.Run( () => account.Credit(5))
     );
}
Task.WaitAll([.. tasks]);
// Same as:
//Task.WaitAll(tasks.ToArray());

WriteLine($"The current balance is ${account.Balance}");

// The organization's account
class Account
{
    private int _balance;
    public int Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }
    public void Credit(int amount)
    {
        Interlocked.Add(ref _balance, amount);
    }
    // The following method is not used in this program
    public void Debit(int amount)
    {
        Interlocked.Add(ref _balance, -amount);
    }
}

