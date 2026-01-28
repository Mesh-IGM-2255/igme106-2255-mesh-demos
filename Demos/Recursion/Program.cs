namespace Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factorial - recursive: " + Factorial(5));
            Console.WriteLine("Factorial - iterative: " + Factorial_iterative(5));
        }



        static int Factorial(int n)
        {
            // base case
            if(n<=1)
            {
                return 1;
            }
            //         recursive call -- WITH state change towards base case 
            return n * Factorial(n-1);
        }

        static int Factorial_iterative(int n)
        {
            int result = 1;
//            for(int i=1; i<=n; i++)
            while(n>0)
            {
                result *= n;
                n--;
            }
            return result;
        }
    }
}
