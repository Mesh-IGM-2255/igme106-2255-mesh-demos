namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numTests = 100;

            for(int i = 0; i<numTests; i++)
            {
                Random rng = new Random(DateTime.Now.Millisecond);
                Console.Write("*");
                Console.Write(rng.Next(1, 10000));

                SingleRNG rngS = SingleRNG.Instance;
                Console.WriteLine("\t\t"+rngS.Next(1, 10000));
            }
        }
    }
}
