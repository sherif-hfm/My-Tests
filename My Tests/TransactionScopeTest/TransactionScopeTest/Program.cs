using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TransactionScopeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveFiles();
        }

        private static void SaveFiles()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                /* Perform transactional work here */
                File.WriteAllText(@"d:\TransactionScopeTest1.txt", "TransactionScopeTest1");
                File.WriteAllText(@"d:\TransactionScopeTest2.txt", "TransactionScopeTest2");
                scope.Complete();
            }
        }
    }
}
