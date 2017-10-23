using System;
using System.Collections.Generic;
using System.IO;

namespace File_Structures
{
    class File
    {
        private string fileName;
        private FileStream fs;
        private BinaryWriter bw;
        private BinaryReader br;

        public FileStream Fs { get => fs; set => fs = value; }

        public File(string fileName)
        {
            this.fileName = fileName;
            Open();

            if (Fs.Length == 0) {
                bw.Write((long)-1);
            }
            Close();
        }

        /**
         * Init FileStream, Binary Writer and Binary Reader
         * */
        public void Open()
        {
            Fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bw = new BinaryWriter(Fs);
            br = new BinaryReader(Fs);
        }

         /**
         * Close FileStream, Binary Writer and Binary Reader
         * */
        public void Close()
        {
            Fs.Close();
            bw.Close();
            br.Close();
        }

        /**
         * Read entities from file
         * */
        public SortedList<string, Entity> GetEntities()
        {
            var list = new SortedList<string, Entity>();

            Open();

            long nextEntityPtr = br.ReadInt64(); // Init with file header

            while (nextEntityPtr != -1)
            {
                br.BaseStream.Seek(nextEntityPtr, SeekOrigin.Begin);

                string name = br.ReadString().Trim();
                long fileAddress = br.ReadInt64();
                long attrsAddress = br.ReadInt64();
                long dataAddress = br.ReadInt64();
                nextEntityPtr = br.ReadInt64();

                list.Add(name, new Entity(name, fileAddress, attrsAddress, dataAddress, nextEntityPtr));
            }
            Close();

            return list;
        }

        /**
         * Go to every entity and the read the attributes
         * */
        public List<Attribute> GetAttributes()
        {
            var list = new List<Attribute>();

            Open();

            long nextEntityPtr = br.ReadInt64(); // Init with file header

            while (nextEntityPtr != -1)
            {
                br.BaseStream.Seek(nextEntityPtr, SeekOrigin.Begin);

                string name = br.ReadString().Trim();
                long fileAddress = br.ReadInt64();
                long attrsAddress = br.ReadInt64();
                long dataAddress = br.ReadInt64();
                nextEntityPtr = br.ReadInt64();

                // Go to attributes
                while(attrsAddress != -1)
                {
                    br.BaseStream.Seek(attrsAddress, SeekOrigin.Begin);
                    string attrName = br.ReadString().Trim();
                    long attrAddress = br.ReadInt64();
                    char type = br.ReadChar();
                    int length = br.ReadInt32();
                    long indexAddress = br.ReadInt64();
                    int indexType = br.ReadInt32();
                    attrsAddress = br.ReadInt64();

                    list.Add(new Attribute(attrName, attrAddress, type, length, indexAddress, (Attribute.IndexType)indexType, attrsAddress, name));
                }
            }
            Close();

            return list;
        }

        /**
         * Go to entity and the read data
         * */
        public Dictionary<string, Entry> GetEntriesFrom(Entity entity, List<Attribute> attributes)
        {
            var dic = new Dictionary<string, Entry>();

            Open();

            long dataPtr = entity.DataAddress;

            while (dataPtr != -1)
            {
                br.BaseStream.Seek(dataPtr, SeekOrigin.Begin);
                Entry entry = new Entry(attributes.Count);
                entry.FileAddress = br.ReadInt64();

                for(int i = 0; i < attributes.Count; i++)
                {
                    if (attributes[i].Type == 'S')
                        entry.Data[i + 1] = br.ReadString();
                    else
                        entry.Data[i + 1] = br.ReadInt32();

                    switch (attributes[i].IndexTypeV)
                    {
                        case Attribute.IndexType.primaryKey:
                            entry.PrimaryValue = entry.Data[i + 1].ToString();
                            break;
                        case Attribute.IndexType.searchKey:
                            entry.SearchValue = entry.Data[i + 1].ToString();
                            break;
                    }
                }

                entry.NextEntryAddress = br.ReadInt64();
                dataPtr = entry.NextEntryAddress;

                dic.Add(entry.PrimaryValue, entry);
            }
            Close();

            return dic;
        }

        /**
        * Write given attribute in file
        * */
        public void WriteAttribute(Attribute attr)
        {
            Open();

            bw.BaseStream.Seek(attr.FileAddress, SeekOrigin.Begin);
            bw.Write(attr.Name);
            bw.Write(attr.FileAddress);
            bw.Write(attr.Type);
            bw.Write(attr.Length);
            bw.Write(attr.IndexAddress);
            bw.Write((int) attr.IndexTypeV);
            bw.Write(attr.NexAttributeAddress);

            Close();
        }

        /**
         * Write given entry in file
         * */
        public void WriteEntry(Entry entry)
        {
            Open();

            bw.BaseStream.Seek(entry.FileAddress, SeekOrigin.Begin);

            foreach (object d in entry.Data)
                if (d is string)
                    bw.Write(d.ToString());
                else if (d is int)
                    bw.Write((int)d);
                else
                    bw.Write((long)d);

            Close();
        }

        /**
         * Write given entity in file
         * */
        public void WriteEntity(Entity entity)
        {
            Open();

            bw.BaseStream.Seek(entity.FileAddress, SeekOrigin.Begin);
            bw.Write(entity.Name);
            bw.Write(entity.FileAddress);
            bw.Write(entity.AttrsAddress);
            bw.Write(entity.DataAddress);
            bw.Write(entity.NextEntityAddress);

            Close();
        }

        /**
         * Change file header
         * @param {long} header - New header
         * */
        public void SetHeader(long header)
        {
            Open();
            bw.Write(header);
            Close();
        }

        /**
         * Get file header
         * */
        public long GetHeader()
        {
            long header;

            Open();
            header = br.ReadInt64();
            Close();

            return header;
        }

        /**
         * Get file size
         * */
        public long GetSize()
        {
            Open();
            long size = Fs.Length;
            Close();

            return size;
        }
    }
}
