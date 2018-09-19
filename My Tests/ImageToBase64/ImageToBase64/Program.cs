using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageToBase64
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageConvert();
        }

        private static void ImageConvert()
        {
            string path = @"C:\Users\shhamdy.ITAMANA\Desktop\Ameen.jpg";
            var byteDate = File.ReadAllBytes(path);
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    var base64Len = base64String.Length;
                }
            }
        }
    }
}
;