using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3_Test
{
    class Program
    {
        static string way = @"C:\Users\SaSnyUser\Desktop\Test.mp3";
        //static List<byte> file = new List<byte>();



        static void Main(string[] args)
        {
            bool id3_type;
            ID3v2 test;

            using (FileStream fs = new FileStream(way, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
                id3_type = ID3_Info(br);

            if (id3_type)
            { 
                test = new ID3v2(way);
                test.Writer();
            }
          
        }


        static bool ID3_Info(BinaryReader br)
        {
            string ans;
            ans = ((char)br.ReadByte()).ToString() + ((char)br.ReadByte()).ToString() + ((char)br.ReadByte()).ToString();
            if (ans == "ID3")
                return true;
            else
                return false;
        }
    }
}
