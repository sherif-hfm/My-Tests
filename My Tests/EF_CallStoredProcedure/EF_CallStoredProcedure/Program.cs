using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CallStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDBEntities db = new TestDBEntities();
            var result = db.GetItemByID("1");
            var itemName = result.First().ItemName;
        }
    }
}
