using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SSLCertificateFind
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var cer = store.Certificates.Find(X509FindType.FindByThumbprint, "3A4E8824E64D7DBFF52450091AB5B7161D6DA91C", false)[0];
            var key = cer.GetRSAPrivateKey();
        }
    }
}
