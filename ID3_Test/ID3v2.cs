using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3_Test
{
    class ID3v2
    {
        string way;
        public byte[] sign = new byte[3];
        public byte[] version = new byte[2];
        public byte flags;
        public byte[] byteSize = new byte[4];
        public int size;


        public ID3v2(string way)
        {
            using (FileStream fs = new FileStream(way, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                this.way = way;
                GetHeader(this.way,br);
                GetFrame_v34(br);
            }
        }

        void GetHeader(string way,BinaryReader br)
        {
            
            {
                ByteReader(sign, br);
                ByteReader(version, br);
                flags = br.ReadByte();
                ByteReader(byteSize, br);
                size = BitConverter.ToInt32(byteSize, 3);                
            }
        }

        void ByteReader(byte[] array,BinaryReader br)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = br.ReadByte();
            }
        }

        void GetFrame_v2(BinaryReader br)
        {
            
        }

        

        void GetFrame_v34(BinaryReader br)
        {

           // while (size > br.BaseStream.Position)
            {
                byte[] id = new byte[4];
                int size; // Какие-то лютые траблы с Size'ом
                byte[] flags = new byte[2];
                byte[] content;

             
                ByteReader(id, br);
                size = br.ReadInt32();
                ByteReader(flags, br);

                content = new byte[size];
                ByteReader(content, br);

            }
        }

        public void Writer()
        {
            foreach (byte item in sign)
                Console.Write(item + " ");
            Console.WriteLine();
            foreach (byte item in sign)
                Console.Write((char)item + " ");
            Console.WriteLine();

            foreach (byte item in version)
                Console.Write(item + " ");
            Console.WriteLine();
            foreach (byte item in version)
                Console.Write((char)item + " ");
            Console.WriteLine();

            Console.WriteLine(flags);
            Console.WriteLine(flags.ToString());

            Console.WriteLine(size);

        }
    }
}
