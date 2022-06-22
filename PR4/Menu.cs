using System;
using System.Collections.Generic;
using System.Text;

namespace PR4
{
    class Menu
    {
        public void MenuFunc()
        {
            Print print = new Print();
            TextFile logFile = new TextFile { Path = "log.txt" };
            logFile.CreateFile();
            TextFile resultFile = new TextFile { Path = "result.txt" };
            resultFile.CreateFile();
            Facade facade = new Facade();

            print.PrintOnScreen("Type message");
            string message = Console.ReadLine();
            while (true)
            {
                try
                {
                    print.PrintOnScreen("1 - translate, 2 - encrypt, 3 - decrypt, " +
                        "4 - write in file, 5 - revert, 0 - exit");
                    uint answer = uint.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 0:
                            return;
                        case 1:
                            message = facade.TranslateText(message, logFile);
                            print.PrintOnScreen(message);
                            break;
                        case 2:
                            message = facade.EncryptText(message, logFile);
                            print.PrintOnScreen(message);
                            break;
                        case 3:
                            message = facade.DecryptText(message, logFile);
                            print.PrintOnScreen(message);
                            break;
                        case 4:
                            resultFile.AddInfo(message);
                            break;
                        case 5:
                            print.PrintOnScreen(facade.RevertChanges(logFile, resultFile));
                            break;
                        default:
                            throw new ArgumentException("Wrong Input");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
