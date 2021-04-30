using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CreateFirefoxRunning
{
    class Program
    {
        static string Key = "gPWoX4BZ";
        static string Output = "leducchinh";

        static void Main(string[] args)
        {
            EncryptFile(Path.Combine("data", "FirefoxPortable.exe"), Path.Combine("data", Output));
            File.Delete(Path.Combine("data", "FirefoxPortable.exe"));
        }
        static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(Key);

                string cryptFile = outputFile;
                using (FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create))
                {
                    RijndaelManaged RMCrypto = new RijndaelManaged();
                    using (CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write))
                    {
                        using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                        {
                            int data;
                            while ((data = fsIn.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
