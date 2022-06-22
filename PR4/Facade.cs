using System;
using System.Collections.Generic;
using System.Text;

namespace PR4
{
    class Facade
    {
        private readonly Encryptor _encryptor = new Encryptor();
        private readonly Decryptor _decryptor = new Decryptor();
        private readonly Translator _translator = new Translator();
        private readonly Revert _revert = new Revert();

        public string TranslateText(string message, TextFile logFile)
        {
            Print print = new Print();
            print.PrintOnScreen("Type language from to example en-uk");
            string[] languages = Console.ReadLine().Split("-");
            string answer = _translator.Translate(message, languages[1], languages[0]);
            logFile.AddInfo($"{languages[1]}-{languages[0]}");
            return answer;
        }

        public string EncryptText(string message, TextFile logFile)
        {
            string answer = _encryptor.Encrypt(message);
            logFile.AddInfo("encrypted");
            return answer;
        }

        public string DecryptText(string message, TextFile logFile)
        {
            string answer = _decryptor.Decrypt(message);
            logFile.AddInfo("decrypted");
            return answer;
        }

        public string RevertChanges(TextFile logFile, TextFile resultFile)
        {
            return _revert.RevertChanges(logFile, resultFile.ReadInfo());
        }
    }
}
