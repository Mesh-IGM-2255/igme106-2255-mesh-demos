using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class SingleRNG
    {

        private static SingleRNG self;

        private Random rng;

        private SingleRNG()
        {
            rng = new Random(DateTime.Now.Millisecond);
            Console.Write("*");
        }

        public static SingleRNG Instance
        {
            get
            {
                if(self == null)
                {
                    self = new SingleRNG();
                }
                return self;
            }
        }

        public int Next(int min, int max)
        {
            return rng.Next(min, max);
        }


    }
}
