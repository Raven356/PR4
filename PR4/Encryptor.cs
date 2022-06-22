using System;
using System.Collections.Generic;
using System.Text;

namespace PR4
{
    class Encryptor
    {
        public string Encrypt(string message)
        {
            string[] mesArray = message.ToLower().Split(" ");
            string encryptedMessage = "";
            foreach(var word in mesArray)
            {
                foreach(var letter in word)
                {
                    char let;
                    if (letter == 122)
                    {
                        let = (char)97;
                    }
                    else
                    {
                        let = (char)(letter + 1);
                                
                    }
                    encryptedMessage += let.ToString();
                }
                encryptedMessage += " ";
            }
            return encryptedMessage;
        }
    }
}
