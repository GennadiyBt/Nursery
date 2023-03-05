namespace NurseryServise.Services
{
    public class Counter : IDisposable
    {
        static int count = 0;
        public Counter() { count++; }

        public void Dispose()
        {
            Console.WriteLine("Resurse closed");
        }
    }
}
