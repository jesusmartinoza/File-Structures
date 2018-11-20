using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Structures
{
    [Serializable]
    public class Entity
    {
        private string name;
        private Dictionary<String, Entry> entries;
        private Dictionary<String, Attribute> attributes;

        public string Name { get => name; set => name = value; }
        public Dictionary<String, Attribute> Attributes { get => attributes; set => attributes = value; }
        public Dictionary<String, Entry> Entries { get => entries; set => entries = value; }

        public Entity(string name)
        {
            Name = name;
            attributes = new Dictionary<String, Attribute>();
            entries = new Dictionary<String, Entry>();
        }

        /**
         * The name is the only attribute that can't be repeated.
         * */
        public override bool Equals(object obj)
        {
            var entity = obj as Entity;
            return entity != null && Name == entity.Name;
        }
    }
}
