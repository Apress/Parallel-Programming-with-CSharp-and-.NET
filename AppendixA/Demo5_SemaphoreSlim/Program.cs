using static System.Console;

SemaphoreSlim semSlim = new(0, 2);

for (int i = 1; i <= 5; i++)
{
    _ = Task.Run(() => Appointment.BookAppointment(semSlim));
}
// Let the patients wait
Thread.Sleep(2000);
int helpdeskMemberCount = semSlim.CurrentCount;
WriteLine($"Currently, {helpdeskMemberCount} helpdesk member(s) are available.");
WriteLine("Please wait...");
// Restore the Slimaphore count to its maximum value.
WriteLine("The helpdesk members have arrived and the booking procedure has started. ");
semSlim.Release(2);
helpdeskMemberCount = semSlim.CurrentCount;

//#region testing Semaphore
//Semaphore semaphore = new(0, 2);
//semaphore.Release();
//semaphore.WaitOne();
//#endregion

ReadKey();

class Appointment
{
    public static void BookAppointment(SemaphoreSlim sem)
    {
        try
        {
            //int patientId = (int)Task.CurrentId;
            int patientId = Task.CurrentId.HasValue ? (int)Task.CurrentId : 0;
            WriteLine($"Patient: {patientId} calls for an appointment booking.");
            sem.Wait();
            WriteLine($"**Patient: {patientId} is getting the appointment. **");
            // The booking time for different patients can be different
            Thread.Sleep(patientId * 500);
            WriteLine($"\tPatient: {patientId} disconnects the call.");
            sem.Release();
        }
        catch (Exception e)
        {
            WriteLine($"Something went wrong: {e.Message}");
        }
    }
}


