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
        string bPlusValue;
        object[] data;

        public string PrimaryValue { get => primaryValue; set => primaryValue = value; }
        public string ForeignValue { get => foreignValue; set => foreignValue = value; }
        public string SearchValue { get => searchValue; set => searchValue = value; }
        public object[] Data { get => data; set => data = value; }
        public long NextEntryAddress { get => (long)Data[Data.Length - 1]; set => Data[Data.Length - 1] = value; }
        public long FileAddress { get => (long)Data[0]; set => Data[0] = value; }
        public string BPlusValue { get => bPlusValue; set => bPlusValue = value; }

        public Entry(int dataLength)
        {
            Data = new object[dataLength + 2]; // File Address and Next Entry Address
            FileAddress = -1;
            NextEntryAddress = -1;
        }

        /**
         * Copy constructor
         * 
         */
        public Entry(Entry entry)
        {
            Data = new object[entry.Data.Length];
            entry.Data.CopyTo(Data, 0);
            FileAddress = entry.FileAddress;
            PrimaryValue = entry.PrimaryValue;
            ForeignValue = entry.ForeignValue;
            SearchValue = entry.SearchValue;
            NextEntryAddress = entry.NextEntryAddress;
            BPlusValue = entry.BPlusValue;
        }

        /**
         * Compare entry using searchValue
         */
        public int CompareTo(Entry entry)
        {
            if (SearchValue == null || entry.SearchValue == null)
                return 1;
            else
                return String.Compare(SearchValue, entry.SearchValue, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
