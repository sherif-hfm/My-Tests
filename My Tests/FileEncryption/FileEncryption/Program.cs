using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            EncryptFile(@"D:\ECMA-262.pdf", @"D:\ECMA-Enc.pdf", "1234567890AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz11");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds ;
            Console.WriteLine(elapsedMs.ToString());
            Console.ReadLine();
        }

        private static void EncryptFile(string inputFile, string outputFile, string password)
        {
            var KeySize = 128;
            var BlockSize = 128;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] PassBytes = ue.GetBytes(password);

            var keyBytes = new Rfc2898DeriveBytes(PassBytes, saltBytes, 1000);
            var AESKey = keyBytes.GetBytes(KeySize / 8);
            var AESIV = keyBytes.GetBytes(BlockSize / 8);

            string cryptFile = outputFile;
            using (FileStream fileCrypt = new FileStream(cryptFile, FileMode.Create))
            {
                using (AesManaged encrypt = new AesManaged())
                {
                    using (CryptoStream cs = new CryptoStream(fileCrypt, encrypt.CreateEncryptor(AESKey, AESIV), CryptoStreamMode.Write))
                    {
                        using (FileStream fileInput = new FileStream(inputFile, FileMode.Open))
                        {
                            encrypt.KeySize = KeySize;
                            encrypt.BlockSize = BlockSize;
                            int data;
                            while ((data = fileInput.ReadByte()) != -1)
                                cs.WriteByte((byte)data);
                        }
                    }
                }
            }
        }
    }
}
