using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace File_Structures
{
    class File
    {
        private string fileName;
        private FileStream fs;
        private BinaryWriter bw;
        private BinaryReader br;

        public File(string fileName)
        {
            this.fileName = fileName;
            Open();

            if (fs.Length == 0) {
                bw.Write((long)-1);
            }
            Close();
        }

        /**
         * Init FileStream, Binary Writer and Binary Reader
         * */
        public void Open()
        {
            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
        }

         /**
         * Close FileStream, Binary Writer and Binary Reader
         * */
        public void Close()
        {
            fs.Close();
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
            long size = fs.Length;
            Close();

            return size;
        }
    }
}
