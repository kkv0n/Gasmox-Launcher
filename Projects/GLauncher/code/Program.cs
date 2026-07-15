using GLauncher.functions;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GLauncher.functions.GLauncher_functions;

namespace GLauncher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Core.Initialize(Path.Combine(L_PATHS.FOLDERS.Datadir, "libvlc", "win-x64"));

            
            
            GLauncher_functions funcs = new GLauncher_functions();




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GLauncher_main());
        }




    }
}
