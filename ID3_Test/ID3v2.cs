using ID3_Test.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3_Test
{
    class ID3v2 : TagV2
    {

        string way;
        public byte[] sign = new byte[3];
        public byte[] version = new byte[2];
        public byte flags;
        public byte[] byteSize = new byte[4];
        public int size;

        public MainTag TRCK;
        public MainTag TIT2;
        public MainTag TPE1;
        public MainTag TALB;
        public TCON TCON;
        public MainTag TYER;



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
            bool find = false;
            while ((br.BaseStream.Length - br.BaseStream.Position) >= 10)
            {
                ByteReader(sign, br);
                find = true;
                break;
            }

            if (find)
                if (GetContent(sign) == "ID3")
                {
                    ByteReader(version, br);
                    flags = br.ReadByte();
                    ByteReader(byteSize, br);
                    size = IntMaker(byteSize);

                    Console.WriteLine(GetContent(sign) + " " + GetContent(version));
                    Console.WriteLine(size);
                    Console.WriteLine();
                }
                else if (GetContent(sign) == "TAG")
                { }
                else
                {
                    Console.WriteLine("AAAAAAAAA STOP 000000000000 AAAAAAAAAAAAAAAA");
                }

        }



        void GetFrame_v2(BinaryReader br)
        {

        }



        void GetFrame_v34(BinaryReader br)
        {
            int findAll = 0;

            byte[] id = new byte[4];
            ByteReader(id, br);
            string temp = GetContent(id);

            while (findAll != 6 && ((br.BaseStream.Length - br.BaseStream.Position) >= 4))
            {
                switch (temp)
                {
                    case "TRCK": TRCK = new MainTag(br, id); findAll++; TRCK.WriteInfo(); break;
                    case "TIT2": TIT2 = new MainTag(br, id); findAll++; TIT2.WriteInfo(); break;
                    case "TPE1": TPE1 = new MainTag(br, id); findAll++; TPE1.WriteInfo(); break;
                    case "TALB": TALB = new MainTag(br, id); findAll++; TALB.WriteInfo(); break;
                    case "TYER": TYER = new MainTag(br, id); findAll++; TYER.WriteInfo(); break;
                    case "TCON": TCON = new TCON(br, id); findAll++; TCON.WriteInfo(); break;
                }

                id[0] = id[1];
                id[1] = id[2];
                id[2] = id[3];
                id[3] = br.ReadByte();
                temp = GetContent(id);
            }
        }

    }
}
