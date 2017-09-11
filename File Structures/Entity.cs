using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Structures
{
    class Entity
    {
        string name;
        long fileAddress;
        long attrsAddress;
        long dataAddress;
        long nextEntityAddress;

        public Entity(string name)
        {
            this.Name = name;
        }

        public Entity(string name, long fileAddress, long attributesAddress, long dataAddress, long nextEntityAddress)
        {
            this.Name = name;
            this.FileAddress = fileAddress;
            this.AttrsAddress = attributesAddress;
            this.DataAddress = dataAddress;
            this.NextEntityAddress = nextEntityAddress;
        }

        public string Name { get => name; set => name = value; }
        public long FileAddress { get => fileAddress; set => fileAddress = value; }
        public long AttrsAddress { get => attrsAddress; set => attrsAddress = value; }
        public long DataAddress { get => dataAddress; set => dataAddress = value; }
        public long NextEntityAddress { get => nextEntityAddress; set => nextEntityAddress = value; }

        /**
         * The name is the only attribute that can't be repeated.
         * */
        public override bool Equals(object obj)
        {
            var entity = obj as Entity;
            return entity != null &&
                   Name == entity.Name;
        }
    }
}
