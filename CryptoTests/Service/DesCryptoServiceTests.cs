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
    public class DesCryptoServiceTests
    {
        private string key = "lollollo";
        [TestMethod()]
        public void EncriptTest()
        {
            var des = new DesCryptoService();
            des.Encript("C:/Users/Vlad/source/repos/Crypto/CryptoTests/lol.txt", key);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void DecriptTest()
        {
            var des = new DesCryptoService();
            des.Decript("C:/Users/Vlad/source/repos/Crypto/CryptoTests/lol.des", key);
            Assert.IsTrue(true);
        }
    }
}