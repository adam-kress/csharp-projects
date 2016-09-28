using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetMostRecentDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\some\path";
            DirectoryInfo latestDir = new DirectoryInfo(path).GetDirectories()
                       .OrderByDescending(d => d.LastWriteTimeUtc).First();
            Console.WriteLine(latestDir);
            Console.ReadLine();
        }
    }
}