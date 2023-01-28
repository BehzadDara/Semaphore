class Program
{
    /*
     initialCount is the number of resource accesses that will be allowed immediately. 
    Or, in other words, it is the number of times Wait can be called 
    without blocking immediately after the semaphore was instantiated.

    maximumCount is the highest count the semaphore can obtain. 
    It is the number of times Release can be called 
    without throwing an exception assuming initialCount count was zero. 
    If initialCount is set to the same value as maximumCount 
    then calling Release immediately after the semaphore was instantiated will throw an exception.
     */

    public static int initialCount = 3;
    public static int maximumCount = 5;
    public static Semaphore semaphore = new(initialCount, maximumCount);

    public static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            var threadObject = new Thread(Process)
            {
                Name = $"Thread: {i}"
            };

            threadObject.Start();
        }
    }

    private static void Process()
    {
        var threadName = Thread.CurrentThread.Name;

        Console.WriteLine($"{threadName} is waiting to enter the critical section.");
        semaphore.WaitOne();

        Console.WriteLine($"{threadName} is inside the critical section now.");
        Thread.Sleep(1000);

        Console.WriteLine($"{threadName} is releasing the critical section.");
        semaphore.Release();
    }

}