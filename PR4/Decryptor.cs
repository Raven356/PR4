using System;
using System.Collections.Generic;
using System.Text;

namespace PR4
{
    class Decryptor
    {
        public string Decrypt(string message)
        {
            string[] mesArray = message.ToLower().Split(" ");
            string decryptedMessage = "";
            foreach(var word in mesArray)
            {
                foreach(var letter in word)
                {
                    char let;
                    if(letter == 97)
                    {
                        let = (char)122;
                    }
                    else
                    {
                        let = (char)(letter - 1);
                    }
                    decryptedMessage += let.ToString();
                }
                decryptedMessage += " ";
            }
            return decryptedMessage;
        }
    }
}
