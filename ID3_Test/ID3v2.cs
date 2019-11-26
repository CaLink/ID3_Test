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
                GetHeader(this.way, br);
                GetFrame_v34(br);
            }
        }

        void GetHeader(string way, BinaryReader br)
        {

            {
                ByteReader(sign, br);
                ByteReader(version, br);
                flags = br.ReadByte();
                ByteReader(byteSize, br);
                size = IntMaker(byteSize);

                Console.WriteLine(GetContent(sign) + " " + GetContent(version));
                Console.WriteLine(size +'\n');

            }
        }

        

        void GetFrame_v2(BinaryReader br)
        {

        }



        void GetFrame_v34(BinaryReader br)
        {

            while (1 > 0)
            {
                byte[] id = new byte[4];
                byte[] byteSize = new byte[4];
                int size; // Какие-то лютые траблы с Size'ом
                byte[] flags = new byte[2];
                byte[] byteContent;
                string content;


                ByteReader(id, br);
                ByteReader(byteSize, br);
                size = IntMaker(byteSize);
                ByteReader(flags, br);
                byteContent = new byte[size];
                ByteReader(byteContent, br);
                content = GetContent(byteContent);


                Console.WriteLine(GetContent(id));
                Console.WriteLine(size);
                Console.WriteLine(content + '\n');

            }
        }

       

        void ByteReader(byte[] array, BinaryReader br)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = br.ReadByte();
            }
        }

        int IntMaker(byte[] size)
        {
            return size[3] + (size[2] << 7) + (size[1] << 14) + (size[0] << 21);
        }

        string GetContent(byte[] content)
        {
            string ans = "";
            for (int i = 0; i < content.Length; i++)
            {
                if (((char)content[i]) == '\0')
                    continue;
                ans += ((char)content[i]).ToString();
            }
            return ans;
        }
    }
}
