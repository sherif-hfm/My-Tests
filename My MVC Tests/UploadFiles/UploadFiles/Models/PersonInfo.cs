using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UploadFiles.Models
{
    public class PersonInfo
    {
        public string PersonName { get; set; }

        public HttpPostedFileBase Image1 { get; set; }

        public HttpPostedFileBase Image2 { get; set; }

    }
}