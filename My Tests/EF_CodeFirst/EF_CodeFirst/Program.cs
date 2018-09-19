using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst
{
    class Program
    {
        
        static void Main(string[] args)
        {
          
            //SqlDAL.Dal.GetData();
            //SqlDAL.Dal.SaveData();
            SqlDAL.Dal.CallStoredProcedure();
        }


    }

    
}
