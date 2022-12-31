using System;
using System.IO;
using FileManager;
using SaveDataController;
using Fun;
#nullable disable

namespace HelloWorld 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");

            string langFlag = "default";
            string dirFlag = "default";
            string wantFolderFlag = "default";
            bool showFlag = false;

            if (args.Length > 1) 
            {
                for (int i = 0; i < args.Length; i++) 
                {
                    if (args[i] == "-l") 
                    {
                        langFlag = args[i + 1];
                    }
                    if (args[i] == "-o") 
                    {
                        dirFlag = args[i + 1];
                    }
                    if (args[i] == "-c") 
                    {
                        dirFlag = Directory.GetCurrentDirectory();
                    }
                    if (args[i] == "-f") 
                    {
                        wantFolderFlag = args[i + 1];
                    }
                    if (args[i] == "-s") 
                    {
                        showFlag = true;
                    }
                }
            }

            string projectDirectory;

            FunText.HelloWorldText();

            if(showFlag == true) 
            {
                FunText.BotImageHead();
            }

            SaveData.PathVarManager();

            projectDirectory = FileCopier.DirectoryManager(dirFlag);

            projectDirectory = FileCopier.ProjectFolderMaker(projectDirectory, wantFolderFlag);

            FileCopier.DataBase(projectDirectory, langFlag);

            Console.ReadKey();
        }

    }


}