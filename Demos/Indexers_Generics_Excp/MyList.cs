using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers_Generics_Excp
{
    internal class MyList<TData>
    {
        // The data for the list and a constant for the initial size
        private TData[] data;
        private const int InitCapacity = 2;

        // auto-property where the get is public, but not the set
        public int Count { get; private set; }
        public string ListName {  get; private set; }

        public TData First { get { return data[0]; } }

        // Gets or sets the data at index i
        public TData this[int i]
        {
            get
            {
                // Ensure the index is valid
                if (i < 0 || i >= Count)
                {
                    throw new IndexOutOfRangeException(
                      "Your index is bad");
                }

                return data[i];
            }

            set
            {
                // Ensure the index is valid
                if (i < 0 || i >= Count)
                {
                    throw new IndexOutOfRangeException(
                      "Your index is bad");
                }

                data[i] = value;
            }
        }

        // Creates a basic list
        public MyList(string name)
        {
            data = new TData[InitCapacity];
            ListName = name;
            Count = 0;
        }

        // Adds an item to the list
        public void Add(TData item)
        {
            // If we're out of space, make a bigger array,
            // copy the data over, then make our data field refer
            // to the new, bigger array
            if (Count == data.Length)
            {
                TData[] newData = new TData[data.Length * 2];
                for (int i = 0; i < data.Length; i++)
                {
                    newData[i] = data[i];
                }
                data = newData;
            }

            // Add the new element & increment the count
            data[Count] = item;
            Count++;
        }

        public TData Get(int index)
        {
            return data[index];
        }

        public void Default()
        {
            for(int i = 0; i < Count; i++)
            {
                data[i] = default(TData);
            }
        }
    }
}
