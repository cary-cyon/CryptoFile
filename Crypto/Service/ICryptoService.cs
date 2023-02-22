using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Service
{
    public interface ICryptoService
    {
        void Encript(string path, string key);
        void Decript(string path, string key);
    }
}
