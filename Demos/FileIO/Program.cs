using System.Reflection.PortableExecutable;

namespace FileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> animalData = new List<string>();

            // ~~~~~~~~ READING ~~~~~~~~~~~~~~~~
            StreamReader input = null;
            try
            {
                // Open file stream of data
                input = new StreamReader("../../../dataFile.txt");

                // Start with an empty (or null, it doesn't matter now!)
                // string to hold read file data 
                string line = "";

                // 1. The ReadLine runs and the result is assigned to line
                // 2. The value of the assignment (the string ref) is compared to null
                // --> If ReadLine returns null, the loop stops.
                // --> If it returns a valid reference, we go into the loop and use it!
                while ((line = input.ReadLine()) != null)
                {
                    animalData.Add(line);

                    string[] animalInfo = line.Split(',');
                    Console.WriteLine($"A {animalInfo[0]} has {animalInfo[1]} limbs");

                    // Do not call ReadLine here
                    // The body of the loop now focuses 
                    // on using the line
                }

            }
            catch (Exception e)
            {
                // print a message?
            }

            // Close
            if (input != null)
            {
                input.Close();
            }

            // ~~~~~~~~ WRITING ~~~~~~~~~~~~~~~~

            // Open
            StreamWriter output = null;
            try
            {
                output = new StreamWriter("../../../saveData.txt");
                foreach(string line in animalData)
                {
                    output.WriteLine(line);
                }
            }
            catch (Exception e)
            {
            }

            // Close
            if (output != null)
            {
                output.Close();
            }

        }
    }
}
