using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FineUploaderMulti
{
    public class UploadDocument
    {
        public string DocId { get; set; }
        public string DocName { get; set; }
        public bool Mandatory { get; set; }
        public bool AllowMulti { get; set; }
        public List<UploadFile> UploadFiles { get; set; }
        
    }

    public class UploadFile
    {
        public string DocId { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
    }
}