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
            string wantPath = "default";

            if (wholeFile[3] == "3****" && wholeFile[1] == "1****") 
            {
                while (wantPath != "y" && wantPath != "n") 
                {
                    Console.WriteLine("Y: Do you want to add HelloWorld command on to the PATH variable for global use? (Recommended)");
                    Console.WriteLine("N: Do you only want to use it in the current directory?");
                    wantPath = Console.ReadLine();
                    wantPath= wantPath.ToLower();

                    if (wantPath == "y") 
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
                        Console.WriteLine("SET-UP COMPLETED!");
                        Console.WriteLine("PRESS ANY KEY TO CONTINUE\n");
                        
                        Console.ReadKey();
                    }
                    else if (wantPath == "n")
                    {
                        wholeFile[1] = "Did not want PATH";
                        wholeFile[3] = "Did not want PATH";
                        File.WriteAllLines(Path.Combine(appLocation, "res", "SaveData.txt"), wholeFile);

                        FunText.BotImageHead();

                        Console.WriteLine("Did not add app to local PATH variable");
                        Console.WriteLine("Only for current directory use");
                        Console.WriteLine("SET-UP COMPLETED! :)");
                        Console.WriteLine("PRESS ANY KEY TO CONTINUE\n");

                        Console.ReadKey();
                    }
                }
             
            }
        } 
    }

    
}