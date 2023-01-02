using System;
using System.IO;
#nullable disable

namespace FileManager 
{
    class FileCopier 
    {
        public static string DirectoryManager(string flag) 
        {
            string placementDirectory; 

            if (flag == "default") 
            {
                Console.WriteLine("Enter Project Directory [Press ENTER if already in directory]: ");
                placementDirectory = Console.ReadLine();
            }
            else 
            {
                placementDirectory = flag;
            }
            
            
            if (!Path.IsPathRooted(placementDirectory))
            {
                placementDirectory = Path.Combine(Directory.GetCurrentDirectory(), placementDirectory);
            }

            while (!Directory.Exists(placementDirectory)) 
            {
                Console.WriteLine("ERROR! Could not find Directory :( \nTry again: ");
                placementDirectory = Console.ReadLine();

                if (!Path.IsPathRooted(placementDirectory))
                {
                    placementDirectory = Path.Combine(Directory.GetCurrentDirectory(), placementDirectory);
                }
            }
  
            //Console.WriteLine("The Directory to go to: " + placementDirectory);
            return placementDirectory;

        }

        public static string ProjectFolderMaker(string directoryPath, string flag)
        {
            string wantFolder;
            string folderName;

            if (flag == "default") 
            {
                Console.WriteLine("\nDo you want to create a Project Folder?: [Y/N]");
                wantFolder = Console.ReadLine();
                wantFolder = wantFolder?.ToUpper();
            }
            else 
            {
                wantFolder = flag;
                wantFolder = wantFolder?.ToUpper();
            }

            if (wantFolder?.ToUpper() == "Y") 
            {
                Console.WriteLine("Name the Project Folder: ");
                folderName = Console.ReadLine();
                directoryPath = Path.Combine(directoryPath, folderName);
                Directory.CreateDirectory(directoryPath);
            }
            
            while (wantFolder != "Y" && wantFolder != "N") 
            {
                Console.WriteLine("Couldn't catch that response. Do you want to create a Project Folder?: [Y/N]");
                wantFolder = Console.ReadLine();
                wantFolder = wantFolder?.ToUpper();

                if (wantFolder?.ToUpper() == "Y") 
                {
                    Console.WriteLine("Name the Project Folder: ");
                    folderName = Console.ReadLine();
                    directoryPath = directoryPath + Path.Combine(directoryPath, folderName);
                    Directory.CreateDirectory(directoryPath); 
                }
            }

            Console.WriteLine("The Directory of project: " + directoryPath);
            return directoryPath; 
        }

        public static string LangList() 
        {
            string Names = "Python\nJava\nHaxe\nC# (CS)\nC++ (cpp)\nC\nJavaScript";
            Console.WriteLine(Names);
            return Names;
        }

        public static void DirectoryCopier(string srcDir, string tarDir) 
        {
            //Copies all the content of a directory, note not the sub-directory contents :(
            string[] folders = Directory.GetDirectories(srcDir);
            string[] files = Directory.GetFiles(srcDir);

            foreach (string file in files)
            {
                File.Copy(file, Path.Combine(tarDir, Path.GetFileName(file)), true);
            }

            foreach (string folder in folders)
            {
                string folderDirName = new DirectoryInfo(folder).Name;
                
                Directory.CreateDirectory(Path.Combine(tarDir, folderDirName));
            }
        }

        public static void DataBase(string directoryPlace, string flag) 
        {
            string selection;
            string appLocation = AppDomain.CurrentDomain.BaseDirectory;
            
            if (flag == "default") 
            {
                Console.WriteLine("\nList of Languages: ");
                LangList();
                Console.WriteLine("\nWhat Language Would You Like?: ");
                
                selection = Console.ReadLine();
                selection = selection?.ToLower();
            }
            else 
            {
                selection = flag;
                selection = selection?.ToLower();
            }
            
            switch (selection) 
            {
                case "python":
                    if (!File.Exists(Path.Combine(directoryPlace, "hello.py"))) 
                    {
                        File.Copy(Path.Combine(appLocation, "CodeBank", "hello.py"), Path.Combine(directoryPlace, "hello.py"));
                        Console.WriteLine("Hello World - Python Generated!");
                    }
                    else 
                    {
                        Console.WriteLine("That File Already Exist!");
                    }
                    break;
                case "java":
                    if (!File.Exists(Path.Combine(directoryPlace, "HelloWorld.java")))
                    {
                        File.Copy(Path.Combine(appLocation, "CodeBank", "HelloWorld.java"), Path.Combine(directoryPlace, "HelloWorld.java"));
                        Console.WriteLine("Hello World - Java Generated!");
                    }
                    else 
                    {
                        Console.WriteLine("That File Already Exist!");
                    }
                    break;
                case "haxe":
                    if (!File.Exists(Path.Combine(directoryPlace, "Main.hx")))
                    {
                        File.Copy(Path.Combine(appLocation, "CodeBank", "Main.hx"), Path.Combine(directoryPlace, "Main.hx"));
                        Console.WriteLine("Hello World - Haxe Generated!");
                    }
                    else 
                    {
                        Console.WriteLine("That File Already Exist!");
                    }
                    break;
                case "cs":
                    string projectCSFile = Path.Combine(appLocation, "CodeBank", "HelloWorldC#");
                    FileCopier.DirectoryCopier(projectCSFile, directoryPlace);
                    FileCopier.DirectoryCopier(Path.Combine(projectCSFile, "src"), Path.Combine(directoryPlace, "src"));
                    FileCopier.DirectoryCopier(Path.Combine(projectCSFile, "res"), Path.Combine(directoryPlace, "res"));
                    File.Move(Path.Combine(directoryPlace, "HelloWorldCS.txt"), Path.Combine(directoryPlace, "HelloWorldCS.csproj"));
                    Console.WriteLine("Hello World Project - C# Generated!");
                    break;
                case "cpp":
                    if (!File.Exists(Path.Combine(directoryPlace, "main.cpp")))
                    {
                        File.Copy(Path.Combine(appLocation, "CodeBank", "main.cpp"), Path.Combine(directoryPlace, "main.cpp"));
                        Console.WriteLine("Hello World - C++ Generated!");
                    }
                    else 
                    {
                        Console.WriteLine("That File Already Exist!");
                    }
                    break;
                case "c":
                    if (!File.Exists(Path.Combine(directoryPlace, "main.c")))
                    {
                        File.Copy(Path.Combine(appLocation, "CodeBank", "main.c"), Path.Combine(directoryPlace, "main.c"));
                        Console.WriteLine("Hello World - C Generated!");
                    }
                    else 
                    {
                        Console.WriteLine("That File Already Exist!");
                    }
                    break;
                case "javascript":
                    if (!File.Exists(Path.Combine(directoryPlace, "hello-world.js")))
                    {
                        File.Copy(Path.Combine(appLocation, "CodeBank", "hello-world.js"), Path.Combine(directoryPlace, "hello-world.js"));
                        Console.WriteLine("Hello World - JavaScript Generated!");
                    }
                    else 
                    {
                        Console.WriteLine("That File Already Exist!");
                    }
                    break;
                default:
                    Console.WriteLine("Sorry but that does not seem to exist in my database :(");
                    break;
            }
        }


    }

    
}