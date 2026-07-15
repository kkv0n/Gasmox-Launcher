using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace GUpdater
{
    internal class Main_updater
    {
        static void Main(string[] args) //update gasmoxian launcher files (move the files)
        {
            
            string maindir; //launcher root folder

            if (args.Length > 0) //takes the launcher root folder as argument
            {
                Console.WriteLine("UPDATING GASMOXIAN LAUNCHER FILES...");

                if (!Directory.Exists(args[0]))
                {
                    Console.WriteLine("Can't find the specified directory:");
                    Console.WriteLine(args[0]);
                    return;
                }

                //wait until the launcher is totally closed
                System.Threading.Thread.Sleep(3000);

                maindir = args[0];
                string updated_folder = Path.Combine(maindir, "data", "temp", "update");
                string[] subfolders = Directory.GetDirectories(updated_folder, "*.*", SearchOption.AllDirectories); //search all subfolders
                List<string> folders = subfolders.ToList();
                folders.Insert(0, updated_folder); //add the root folder to the folder list

                for (int fo = 0; fo < folders.Count; fo++)
                {
                    string[] files = Directory.GetFiles(folders[fo]); //get a list of files inside this folder

                    //get the relative path
                    string folderdest = Path.Combine(maindir, folders[fo].Substring(updated_folder.Length).TrimStart('\\', '/'));

                    if (!Directory.Exists(folderdest)) //if the folder dont exist then create one
                        Directory.CreateDirectory(folderdest);


                    for (int fi = 0; fi < files.Length; fi++)
                    {
                        string destination = Path.Combine(folderdest, Path.GetFileName(files[fi])); //move to the desired folder

                        Console.WriteLine($"MOVING FILE: {Path.GetFileName(files[fi])}");

                        if (File.Exists(destination)) File.Delete(destination); //avoid app crashes, if the same file exists then delete it before moving the new one

                        File.Move(files[fi], destination); 

                        Console.WriteLine("DONE");

                    }



                }

                //delete temp folders
                for (int del = 0; del < folders.Count; del++)
                {

                    if (!Directory.Exists(folders[del])) continue;

                    //delete all temp folders even if they are not empty

                        Console.WriteLine($"DELETING TEMP FOLDER: {folders[del]} ");

                        Directory.Delete(folders[del], true);
                }

                Console.WriteLine("OPENING GASMOX LAUNCHER...");

                Process.Start(Path.Combine(maindir, "GLauncher.exe")); //restart the launcher

                Environment.Exit(0); //close the cmd

            }
            else
            {
                //if no arguments
                Console.WriteLine("no args detected, exiting...");
                Environment.Exit(0);               
            }
        }
    }
}
