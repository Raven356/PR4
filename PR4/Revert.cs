using System;
using System.Collections.Generic;
using System.Text;

namespace PR4
{
    class Revert
    {
        public string RevertChanges(TextFile logFile, string message)
        {
            string answer = "";
            try
            {
                
                foreach (var word in message.Split("\n"))
                {
                    if (string.IsNullOrEmpty(word))
                        continue;
                    answer = word;
                    string[] moves = logFile.ReadInfo().Split("\n");
                    for(int i = moves.Length - 1; i >= 0; i--)
                    {

                        switch (moves[i])
                        {
                            case "encrypted":
                                answer = new Decryptor().Decrypt(answer);
                                break;
                            case "decrypted":
                                answer = new Encryptor().Encrypt(answer);
                                break;
                            case "":
                                break;
                            default:
                                string[] languages = moves[i].Split("-");
                                answer = new Translator().Translate(answer, languages[1], languages[0]);
                                break;
                        }

                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return answer;
        }
    }
}
