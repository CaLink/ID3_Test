using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3_Test.Tags
{
    class MainTag : TagV2
    {
       
        public MainTag(BinaryReader br, byte[] id)
        {
            Position = br.BaseStream.Position;
            this.id = id;
            ID = GetContent(id);

            ByteReader(byteSize, br);
            Size = IntMaker(byteSize);

            ByteReader(flags, br);
            ByteReader(encoding, br);

            byteContent = new byte[Size - 3];
            ByteReader(byteContent, br);
            Content = GetContent(byteContent);

        }
    }
}


