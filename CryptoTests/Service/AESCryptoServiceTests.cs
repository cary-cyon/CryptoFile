using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crypto.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Service.Tests
{
    [TestClass()]
    public class AESCryptoServiceTests
    {
        private string key = "lollollolollollo";
        [TestMethod()]
        public void DecriptTest()
        {
            var aes = new AESCryptoService();
            aes.Decript("C:/Users/Vlad/source/repos/Crypto/CryptoTests/lol.aes", key);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void EncriptTest()
        {
            var aes = new AESCryptoService();
            aes.Encript("C:/Users/Vlad/source/repos/Crypto/CryptoTests/lol.txt", key);
            Assert.IsTrue(true);
        }
    }
}