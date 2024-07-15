using static System.Console;

#region The sequential version
string input = "abcde";
int position = 0;
foreach (char c in input)
{
    WriteLine($"{c} is in position:{position++}");
}
#endregion

WriteLine("========");

#region The parallel version

Parallel.ForEach
 (
  input,
  (char c, ParallelLoopState state, long position) =>
   {
     WriteLine($"{c} is in position:{position++}");
    }
  );
#endregion

