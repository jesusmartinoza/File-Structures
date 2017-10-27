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
        string foreignValue;
        string searchValue;
        object[] data;

        public string PrimaryValue { get => primaryValue; set => primaryValue = value; }
        public string ForeignValue { get => foreignValue; set => foreignValue = value; }
        public string SearchValue { get => searchValue; set => searchValue = value; }
        public object[] Data { get => data; set => data = value; }
        public long NextEntryAddress { get => (long)Data[Data.Length - 1]; set => Data[Data.Length - 1] = value; }
        public long FileAddress { get => (long)Data[0]; set => Data[0] = value; }

        public Entry(int dataLength)
        {
            Data = new object[dataLength + 2]; // File Address and Next Entry Address
            FileAddress = -1;
            NextEntryAddress = -1;
        }
        
    }
}
