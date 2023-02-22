using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Service
{
    public class DesCryptoService : ICryptoService
    {
        private DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

        public void Decript(string path, string key)
        {
            FileStream fsInput = new FileStream(path, FileMode.Open, FileAccess.Read);
            var outPath = path.Replace(Path.GetExtension(path), ".out");
            FileStream fsOutput = new FileStream(outPath, FileMode.Create, FileAccess.Write);
            try
            {
                DES.Padding = PaddingMode.None | PaddingMode.PKCS7;
                makeTransform(fsInput, fsOutput, key, DES.CreateDecryptor());
            }
            finally
            {
                fsOutput.Close();
                fsInput.Close();
            }
        }

        public void Encript(string path, string key)
        {
            FileStream fsInput = new FileStream(path, FileMode.Open, FileAccess.Read);
            var outPath =  path.Replace(Path.GetExtension(path), ".des");
            FileStream fsOutput = new FileStream(outPath, FileMode.Create, FileAccess.Write);
            try
            {
                DES.Padding = PaddingMode.None | PaddingMode.PKCS7;
                makeTransform(fsInput, fsOutput, key, DES.CreateEncryptor());
            }
            finally
            {
                fsOutput.Close();
                fsInput.Close();
            }
        }
        private void makeTransform(FileStream input, FileStream output, string key, ICryptoTransform transform)
        {
            DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
            CryptoStream cryptoStream = new CryptoStream(output, transform, CryptoStreamMode.Write);
            byte[] byteArrayInput = new byte[input.Length];
            int col = input.Read(byteArrayInput, 0, byteArrayInput.Length);
            cryptoStream.Write(byteArrayInput, 0, col);
            cryptoStream.Dispose();
            cryptoStream.Close();
        }
    }
}
