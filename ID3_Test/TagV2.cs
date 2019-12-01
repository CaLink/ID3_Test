using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3_Test
{
    abstract class TagV2
    {
        public byte[] id = new byte[4];
        public byte[] byteSize = new byte[4];
        public byte[] flags = new byte[2];
        public byte[] encoding = new byte[3];
        public byte[] byteContent;

        public long Position { get; set; }
        public string ID { get; set; }
        public int Size { get; set; }
        public string Encoding { get; set; }
        public string Content { get; set; }


        public void ByteReader(byte[] array, BinaryReader br)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = br.ReadByte();
        }

        public int IntMaker(byte[] size)
        {
            return size[3] + (size[2] << 7) + (size[1] << 14) + (size[0] << 21);
        }

        public string GetContent(byte[] content)
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

        public void WriteInfo()
        {
            Console.WriteLine(ID);
            Console.WriteLine(Size);
            Console.WriteLine(Content);
            Console.WriteLine();

        }

    }
}
