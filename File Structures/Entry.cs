using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Structures
{
    [Serializable]
    public class Entry
    {
        string primaryValue;
        string foreignValue;
        string searchValue;
        string entityName;
        Dictionary<String, String> data;

        public string PrimaryValue { get => primaryValue; set => primaryValue = value; }
        public string ForeignValue { get => foreignValue; set => foreignValue = value; }
        public string SearchValue { get => searchValue; set => searchValue = value; }
        public string EntityName { get => entityName; set => entityName = value; }
        public Dictionary<String, String> Data { get => data; set => data = value; }

        public Entry()
        {
            Data = new Dictionary<String, String>();
        }

        /**
         * Copy constructor
         * 
         */
        public Entry(Entry entry)
        {
            Data = new Dictionary<String, String>();
            PrimaryValue = entry.PrimaryValue;
            ForeignValue = entry.ForeignValue;
            SearchValue = entry.SearchValue;
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
