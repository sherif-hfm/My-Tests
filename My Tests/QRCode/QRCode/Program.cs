using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QRCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate();
        }

        private static void Generate()
        {
            var qrEncoder = new Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.L);
            var qrCode = qrEncoder.Encode("OK");
            var ms = new System.IO.MemoryStream();
            SolidBrush brush = new SolidBrush(Color.Black);
            
            var renderer = new Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer(new Gma.QrCodeNet.Encoding.Windows.Render.FixedCodeSize(400, Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Four), brush, Brushes.White);
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Jpeg, ms);
            
            using (FileStream file = new FileStream(@"d:\QR.jpg", FileMode.Create, System.IO.FileAccess.Write))
                ms.WriteTo(file);
           
        }
    }
}
