using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace File_Structures
{
    [Serializable]
    public class File
    {

        private string name;
        private Dictionary<String, Entity> entities;

        public string Name { get => name; set => name = value; }
        public Dictionary<String, Entity> Entities { get => entities; set => entities = value; }

        public File()
        {
            this.entities = new Dictionary<string, Entity>();
        }

        public File(string fileName)
        {
            name = fileName;
            entities = new Dictionary<string, Entity>();
        }

        /**
         * Open file from path
         */
        public void Open(String path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@path + "/" + name + ".dic", FileMode.Open, FileAccess.Read);
            File f = (File)formatter.Deserialize(stream);

            name = f.Name;
            entities = f.entities;

            stream.Close();
        }

        /**
         * Store file instance into pyshical file
         */
        public void Save(String path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@path + "/" + name + ".dic", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, this);
            stream.Close();
        }
        
        /**
         * Go to every entity and the read the attributes
         * */
        public List<Attribute> GetAttributes()
        {
            var list = new List<Attribute>();

            foreach (KeyValuePair<string, Entity> kvp in Entities)
            {
                Entity e = kvp.Value;
                list.AddRange(e.Attributes.Values);
            }

            return list;
        }

        /**
         * Find entries from entityName
         * */
        public List<Entry> GetEntriesFrom(String entityName)
        {
            var list = new List<Entry>();

            foreach (KeyValuePair<string, Entity> kvp in Entities)
            {
                Entity e = kvp.Value;

                if(e.Name == entityName)
                    list.AddRange(e.Entries.Values);
            }
            
            return list;
        }

        /**
        * Write given attribute in file
        * */
        public bool AddAttribute(Attribute attr)
        {
            Entity parent = entities[attr.EntityName];
            bool success = true;

            if (parent.Attributes.ContainsKey(attr.Name))
                success = false;
            else
                parent.Attributes.Add(attr.Name, attr);

            return success;
        }

        /**
         * Write given entry in file
         * */
        public bool AddEntry(Entry entry)
        {
            Entity parent = entities[entry.EntityName];
            bool success = true;

            if (parent.Entries.ContainsKey(entry.PrimaryValue))
                success = false;
            else
                parent.Entries.Add(entry.PrimaryValue, entry);

            return success;
        }

        /**
         * Write given entity in file
         * */
        public bool AddEntity(String entityName)
        {
            bool success = true;

            if (entities.ContainsKey(entityName))
                success =  false;
            else
                entities.Add(entityName, new Entity(entityName));

            return success;
        }
    }
}
