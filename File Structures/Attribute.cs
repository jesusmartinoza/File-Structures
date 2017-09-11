using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Structures
{
    /**
    *  +--- Name ---+--- Type ---+--- Length ----+---- Address ----+--- Index Address ----+--- Index Type ----+--- Next Address ----+
    *        30           1              4                8                  8                      4                  8            
    *        
    * 63 bytes in file per attribute
    **/
    class Attribute
    {
        public enum IndexType
        {
            nonType = 0,
            searchKey = 1,
            primaryKey = 2,
            foreignKey = 3,
            bPlusTree = 4,
            dynamicHash = 5
        }

        string name;
        char type;
        long length;
        long address;
        long indexAddress;
        IndexType indexType;
        long nexAttributeAddress;

        public Attribute(string name, char type, long length, long address, long indexAddress, IndexType indexType, long nexAttributeAddress)
        {
            this.name = name;
            this.type = type;
            this.length = length;
            this.address = address;
            this.indexAddress = indexAddress;
            this.indexType = indexType;
            this.nexAttributeAddress = nexAttributeAddress;
        }
    }
}
