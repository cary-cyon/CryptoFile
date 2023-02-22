using Crypto.Commands;
using Crypto.Service;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Crypto.ViewModel
{
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private List<string> _cryptoMethods;
        private string _currentPass;
        private string _key;
        private RelayCommand _setPathCommand;
        private RelayCommand _encryptCurrentFileCommand;
        private RelayCommand _decryptCurrentFileCommand;
        #region Commands
        public RelayCommand SetPathCommand
        {
            get
            {
                return _setPathCommand ??
                  (_setPathCommand = new RelayCommand(SetPath));
            }
        }
        public RelayCommand EncryptCurrentFileCommand
        {
            get 
            {
                return _encryptCurrentFileCommand ??
                (_encryptCurrentFileCommand = new RelayCommand(EncryptCurrentFile, CanEncrypt));
            }
        }
        public RelayCommand DecryptCurrentFileCommand
        {
            get
            {
                return _decryptCurrentFileCommand ??
                (_decryptCurrentFileCommand = new RelayCommand(DecryptCurrentFile, CanDecrypt));
            }
        }
        #endregion
        #region for bindings
        public List<string> CryptoMethods
        {
            get
            {
                return _cryptoMethods;
            }
            set
            {
                _cryptoMethods = value;
                OnPropertyChanged(nameof(CryptoMethods));
            }
        }
        public string CurrentPath
        {
            get
            {
                return _currentPass;
            }
            set
            {
                _currentPass = value;
                OnPropertyChanged(nameof(CurrentPath));
            }
        }
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        #endregion
        public ApplicationViewModel()
        {
            CryptoMethods = new List<string>() { "DES", "AES" };
        }
        private void SetPath(object obj)
        {
            OpenFileDialog opf = new();
            opf.InitialDirectory = "c:\\";
            opf.Filter = "txt files (*.txt)|*.txt|aes encypted files (*.aes)|*.aes|All files (*.*)|*.*";
            if (opf.ShowDialog() == true)
            {
                //Get the path of specified file and set to TextBlock
                CurrentPath = opf.FileName;
            }
        }
        private void EncryptCurrentFile(object obj)
        {
            AESCryptoService aes = new();
            aes.Encript(CurrentPath, Key);
        }
        private void DecryptCurrentFile(object obj)
        {
            AESCryptoService aes = new();
            aes.Decript(CurrentPath, Key);
        }
        private bool CanEncrypt(object obj)
        {
            if (CurrentPath == null  ||  Key == null || Key.Length != 16)
            {
                return false;
            }
            return true;
        }
        private bool CanDecrypt(object obj)
        {
            if (CurrentPath == null || Key == null || Key.Length != 16 || Path.GetExtension(CurrentPath)!=".aes")
            {
                return false;
            }
            return true;
        }
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
