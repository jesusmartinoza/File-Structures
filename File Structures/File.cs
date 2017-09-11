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

        public void Open()
        {
            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
        }

        public void Close()
        {
            fs.Close();
            bw.Close();
            br.Close();
        }

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

        public void SetHeader(long header)
        {
            Open();

            bw.Write(header);

            Close();
        }
        public long GetSize()
        {
            Open();
            long size = fs.Length;
            Close();

            return size - 1;
        }
    }
}
