using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTimePassApi.Models
{
    public class ServiceResultInfo<T>
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public T ResultSet { get; set; }
    }
}