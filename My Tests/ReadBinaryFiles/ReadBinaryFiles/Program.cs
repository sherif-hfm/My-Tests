using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBinaryFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var file1 = File.ReadAllBytes(@"E:\zXz\bordertypelistinfo.cs.zXz");
            var file2 = File.ReadAllBytes(@"E:\zXz2\bordertypelistinfo.cs.zXz");
            for(int index=0; index < 30; index++)
            {
                Console.WriteLine(file1[index] + "\t" + file2[index] );
            }
            Console.ReadLine();
        }
    }
}
