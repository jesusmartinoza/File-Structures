using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Structures
{
    public class Entry
    {
        string primaryValue;
        string searchValue;
        object[] data;

        public string PrimaryValue { get => primaryValue; set => primaryValue = value; }
        public string SearchValue { get => searchValue; set => searchValue = value; }
        public object[] Data { get => data; set => data = value; }

        public Entry(int dataLength)
        {
            Data = new object[dataLength];
        }
    }
}
