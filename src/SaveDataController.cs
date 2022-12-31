using System;
using System.IO;
using Fun;
#nullable disable

namespace SaveDataController 
{
    class SaveData 
    {
        public static void PathVarManager() 
        {   
            string appLocation = AppDomain.CurrentDomain.BaseDirectory;
            string[] wholeFile = File.ReadAllLines(Path.Combine(appLocation, "res", "SaveData.txt"));

            if (wholeFile[3] == "3****" && wholeFile[1] == "1****") 
            {
                string pathVar = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                string newPathVar;

                wholeFile[1] = pathVar;
                newPathVar = pathVar + appLocation + ";";
                wholeFile[3] = newPathVar;
                File.WriteAllLines(Path.Combine(appLocation, "res", "SaveData.txt"), wholeFile);
                Environment.SetEnvironmentVariable("PATH", newPathVar, EnvironmentVariableTarget.User);

                FunText.BotImageHead();

                Console.WriteLine("Added to local PATH variable! :)\n");
                Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                
                Console.ReadKey();
            }
        } 
    }

    
}