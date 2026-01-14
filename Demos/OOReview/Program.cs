namespace OOReview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 4;
            int[] nums = new int[3];
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + ": "+ IsEven(i));
            }

            DoStuff();
        }


        public static void DoStuff()
        {
            double a = 12;
            double b = 5;
            double c = 1;
            double d = 2;
           // DoStuff();
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }


    }
}
