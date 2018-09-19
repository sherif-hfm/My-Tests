using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Web.Configuration;

namespace FileConvertService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FileConvertSrv : IFileConvertSrv
    {
        public byte[] DocToImageConvert(byte[] _docData)
        {
            try
            {
                //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Start1");
                string tmpFolder = WebConfigurationManager.AppSettings["tmpFolder"];
                byte[] data = null; ;
                var fileId = Guid.NewGuid().ToString();
                var fileName = tmpFolder + fileId + ".docx";
                File.WriteAllBytes(fileName, _docData);
                //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Save docs file OK");
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "PrintTo";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Try start Process");
                    process.Start();
                    process.WaitForExit();
                }
                Thread.Sleep(3000);
                //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Try find file");
                var file = Directory.GetFiles(tmpFolder, "*" + fileId + "*.jpg");
                if (file.Length > 0)
                {
                    //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "find file");
                    data = File.ReadAllBytes(file[0]);
                    //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Try delete docx");
                    File.Delete(fileName);
                    //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Try delete image");
                    File.Delete(file[0]);
                }

                return data;
            }
            catch (Exception ex)
            {
                //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Error " + ex.Message);
                return null;
            }
        }

        public void OpenMsWordTest()
        {
            File.AppendAllText(@"D:\DocFlowFiles\log.txt", "Start .... " );
            using (Process process = new Process())
            {
                string tmpFolder = WebConfigurationManager.AppSettings["tmpFolder"];
                var fileName = tmpFolder + "test.docx";
                process.StartInfo.FileName = fileName;
                process.StartInfo.Verb = "PrintTo";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                File.AppendAllText(@"D:\DocFlowFiles\log.txt", "Try Start Process .... ");
                process.Start();
                process.WaitForExit();
            }
        }
    }
}
