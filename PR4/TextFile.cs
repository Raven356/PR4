using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PR4
{
    class TextFile
    {
        public string Path { get; set; }

        public void CreateFile()
        {
            try
            {
                using StreamWriter streamWriter = new StreamWriter(Path, false);
                streamWriter.Write("");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddInfo(string logInfo)
        {
            try
            {
                using StreamWriter streamWriter = new StreamWriter(Path, true);
                streamWriter.Write(logInfo + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string ReadInfo()
        {
            try
            {
                using StreamReader streamReader = new StreamReader(Path);
                return streamReader.ReadToEnd();
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}
