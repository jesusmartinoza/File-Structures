using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;
using Shields.GraphViz.Components;
using Shields.GraphViz.Models;
using Shields.GraphViz.Services;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Structures
{
    [Serializable]
    public class Attribute
    {
        public enum IndexType
        {
            nonType = 0,
            searchKey = 10,
            primaryKey = 1,
            foreignKey = 2,
            bPlusTree = 40,
            dynamicHash = 50
        }

        string name;
        IndexType indexType;
        string entityName;
        char type; // String or Int
        int length;
        string foreignName; // String if value is a foreignKey

        public string Name { get => name; set => name = value; }
        public IndexType IndexTypeV { get => indexType; set => indexType = value; }
        public string EntityName { get => entityName; set => entityName = value; }
        public char Type { get => type; set => type = value; }
        public int Length { get => length; set => length = value; }
        public string ForeignName { get => foreignName; set => foreignName = value; }

        /**
         *  Constructor used to create an attribute in memory.
         *  By default all addresses are -1
         */
        public Attribute(string name, char type, int length, IndexType indexType, string entityName)
        {
            Name = name;
            Type = type;
            Length = length;
            IndexTypeV = indexType;
            EntityName = entityName.Trim();
        }
    }
}
