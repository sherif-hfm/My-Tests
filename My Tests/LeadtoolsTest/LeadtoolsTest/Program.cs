using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Forms.DocumentWriters;
using Leadtools.Svg;
using Leadtools.Documents;
using Leadtools.Caching;
using Leadtools.Annotations.Core;
using Leadtools.Forms.Ocr;
using Leadtools.Documents.Converters;
using System.IO;

namespace LeadtoolsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = File.ReadAllText(@"D:\Originals\Development tools\LEADTOOLS 19.0\Crack\full_license.key\full_license.key");
            var lic = File.ReadAllBytes(@"D:\Originals\Development tools\LEADTOOLS 19.0\Crack\full_license.key\full_license.lic");
            //RasterSupport.SetLicense(lic, key);
            DocumentConverterExample();
            Console.ReadLine();
        }

        public static void DocumentConverterExample()
        {
            using (DocumentConverter documentConverter = new DocumentConverter())
            {
                var inFile = @"d:\test.docx";
                var outFile = @"d:\test.pdf";
                var format = DocumentFormat.Pdf;
                var jobData = DocumentConverterJobs.CreateJobData(inFile, outFile, format);
                jobData.JobName = "conversion job";
                var job = documentConverter.Jobs.CreateJob(jobData);
                documentConverter.Jobs.RunJob(job);

                if (job.Status == DocumentConverterJobStatus.Success)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("{0} Errors", job.Status);
                    foreach (var error in job.Errors)
                    {
                        Console.WriteLine("  {0} at {1}: {2}", error.Operation, error.InputDocumentPageNumber, error.Error.Message);
                    }
                }
            }
        }
    }
}
