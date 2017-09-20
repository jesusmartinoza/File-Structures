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
        int length;
        long indexAddress;
        IndexType indexType;
        long nexAttributeAddress;
        string entityName;

        public string Name { get => name; set => name = value.PadRight(30); }
        public long FileAddress { get => fileAddress; set => fileAddress = value; }
        public char Type { get => type; set => type = value; }
        public int Length { get => length; set => length = value; }
        public long IndexAddress { get => indexAddress; set => indexAddress = value; }
        public IndexType IndexTypeV { get => indexType; set => indexType = value; }
        public long NexAttributeAddress { get => nexAttributeAddress; set => nexAttributeAddress = value; }
        public string EntityName { get => entityName; set => entityName = value; }

        public Attribute(string name, char type, int length, IndexType indexType, string entityName)
        {
            Name = name;
            Type = type;
            Length = length;
            IndexTypeV = indexType;
            EntityName = entityName.Trim();
            FileAddress = -1;
            IndexAddress = -1;
            NexAttributeAddress = -1;
        }

        /**
         * Constructor used when read from file
         * */
        public Attribute(string name, long fileAddress, char type, int length, long indexAddress, IndexType indexType, long nexAttributeAddress, string entityName)
        {
            this.name = name;
            this.fileAddress = fileAddress;
            this.type = type;
            this.length = length;
            this.indexAddress = indexAddress;
            this.indexType = indexType;
            this.nexAttributeAddress = nexAttributeAddress;
            this.entityName = entityName;
        }
    }
}
