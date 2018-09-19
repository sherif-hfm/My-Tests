using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public static class Dal
    {
        public static void CallStoredProcedure()
        {
            using (var context = new MyContext("ESERVICES"))
            {
                var prm1 = new SqlParameter("@MomraLicenseId", 2);
                var result = context.Database.ExecuteSqlCommand("UpdateAttachmentsStatus @MomraLicenseId", prm1);
            }
        }

        public static void GetData()
        {
            using (var context = new MyContext("ESERVICES"))
            {
                var result = context.Attachments.First();
                var result2 = (from a in context.Attachments group a by a.MomraLicenseId into g select g.Key).ToList<long>();
            }
        }

        public static void SaveData()
        {
            using (var context = new MyContext("ESERVICES"))
            {
                var Attachment = new Attachments() { MomraLicenseId = (long)2, RequestNumber = 200, RequestYear = 1438, AtachmentURL = "URL2", IsSaved = false };
                context.Attachments.Add(Attachment);
                context.SaveChanges();
            }
        }
    }
}
