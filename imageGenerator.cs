using System;
using System.Collections.Generic;
using ImageMagick;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MilitarySiteThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {

            string edition = SetDate(+1);

            MilitarySite firstSite = new MilitarySite();
            firstSite.srcPath = @"D:\path\to\source\" + edition + @"\images\";
            firstSite.destPath = @"D:\path\to\destination\img\";
            firstSite.paperPrefix = "site_1_";

            MilitarySite secondSite = new MilitarySite();
            secondSite.srcPath = @"D:\path\to\source\" + edition + @"\images\";
            secondSite.destPath = @"D:\path\to\destination\img\";
            secondSite.paperPrefix = "site_2_";

            MilitarySite thirdSite = new MilitarySite();
            thirdSite.srcPath = @"D:\path\to\source\" + edition + @"\images\";
            thirdSite.destPath = @"D:\path\to\destination\img\";
            thirdSite.paperPrefix = "site_3_";

            //Console.WriteLine("Source: {0}p01.jpg \n Dest: {1}{2}" + edition + ".jpg", firstSite.srcPath, firstSite.destPath, firstSite.paperPrefix);

            CreatePath(firstSite.destPath);
            CreatePath(secondSite.destPath);
            CreatePath(thirdSite.destPath);

            Resizeimages(firstSite.srcPath, firstSite.destPath, firstSite.paperPrefix, edition);
            Resizeimages(secondSite.srcPath, secondSite.destPath, secondSite.paperPrefix, edition);
            Resizeimages(thirdSite.srcPath, thirdSite.destPath, thirdSite.paperPrefix, edition);

            //Console.ReadLine();
        }

        private static void Resizeimages(string theSource, string theDestination, string prefix, string formattedDate)
        {
            try
            {
                // Resize thumb_300.jpg
                using (MagickImage image = new MagickImage(theSource + "p01.jpg"))
                {
                    MagickGeometry size = new MagickGeometry(250, 0);
                    //size.IgnoreAspectRatio = true;
                    image.Quality = 100;
                    image.Resize(size);
                    image.Write(theDestination + prefix + formattedDate + ".jpg");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        private static string SetDate(double numberOfDays)
        {
            DateTime today = System.DateTime.Now;
            DateTime futureDate = today.AddDays(numberOfDays);
            DateTime dateOnly = futureDate.Date;

            string edition = dateOnly.ToString("yyyyMMdd");
            return edition;
        }
        private static void CreatePath(string thePath)
        {
            Directory.CreateDirectory(thePath);
        }
    }
    class MilitarySite
    {
        public string srcPath { get; set; }
        public string destPath { get; set; }
        public string paperPrefix { get; set; }
    }
}
