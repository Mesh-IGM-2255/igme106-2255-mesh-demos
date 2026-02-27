namespace ValVsRef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            passByReference(player);
            Console.WriteLine(player.number);

            int myNum = 12;
            passByValue(myNum);
            Console.WriteLine(myNum);

            makePlayer().number = myNum;
        }

        static void passByValue(int number)
        {
            number = 42;
        }

        static void passByReference(Player p)
        {
            p.number = 42;
        }

        static Player makePlayer()
        {
            return new Player();
        }
    }
}
