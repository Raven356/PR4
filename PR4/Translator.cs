using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace PR4
{
    class Translator
    {
        public string Translate(string word, string toLanguage, string fromLanguage)
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client" +
                $"=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            using var webClient = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            
            var result = webClient.DownloadString(url);
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
        }
    }
}
