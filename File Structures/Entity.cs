﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Structures
{
    /**
     *  +--- Name ---+--- File Address ---+--- Attrs Address ----+---- Data Address ----+--- NextEntityAddress ----+
     *        30               8                    8                      8                       8                = 62
     *        
     * 62 bytes in file per entity
     **/
    public class Entity
    {
        string name;
        long fileAddress;
        long attrsAddress;
        long dataAddress;
        long nextEntityAddress;

        public string Name { get => name; set => name = value.PadRight(30); }
        public long FileAddress { get => fileAddress; set => fileAddress = value; }
        public long AttrsAddress { get => attrsAddress; set => attrsAddress = value; }
        public long DataAddress { get => dataAddress; set => dataAddress = value; }
        public long NextEntityAddress { get => nextEntityAddress; set => nextEntityAddress = value; }

        public Entity(string name)
        {
            Name = name;
            FileAddress = 8;
            attrsAddress = -1;
            dataAddress = -1;
            nextEntityAddress = -1;
        }

        public Entity(string name, long fileAddress, long attrsAddress, long dataAddress, long nextEntityAddress) : this(name)
        {
            this.fileAddress = fileAddress;
            this.attrsAddress = attrsAddress;
            this.dataAddress = dataAddress;
            this.nextEntityAddress = nextEntityAddress;
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
