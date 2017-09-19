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
    public class Attribute
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
        long fileAddress;
        char type;
        long length;
        long indexAddress;
        IndexType indexType;
        long nexAttributeAddress;

        public string Name { get => name; set => name = value; }
        public long FileAddress { get => fileAddress; set => fileAddress = value; }
        public char Type { get => type; set => type = value; }
        public long Length { get => length; set => length = value; }
        public long IndexAddress { get => indexAddress; set => indexAddress = value; }
        public IndexType IndexTypeV { get => indexType; set => indexType = value; }
        public long NexAttributeAddress { get => nexAttributeAddress; set => nexAttributeAddress = value; }

        public Attribute(string name, char type, long length, IndexType indexType)
        {
            this.Name = name;
            this.Type = type;
            this.Length = length;
            this.IndexTypeV = indexType;
            this.FileAddress = -1;
            this.IndexAddress = -1;
            this.NexAttributeAddress = -1;
        }
    }
}
