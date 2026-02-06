namespace Indexers_Generics_Excp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> listNames = new List<string>();


            //MyStringList names = new MyStringList();
            MyList<string> names = new MyList<string>("names");
            names.Add("Shiro");
            names.Add("Pax");
            names.Add("Lacey");

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    //Console.WriteLine("- "+names.Get(i));
                    Console.WriteLine("- " + names[i]); // names.Get(i)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            MyList<int> nums = new MyList<int>("nums");
            nums.Add(1);
            nums.Add(2);

            MyList<Player> pList = new MyList<Player>("p");
            pList.Add(new Player());
            pList.Add(null);

        }
    }
}
