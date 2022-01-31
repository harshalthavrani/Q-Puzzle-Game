//HThavraniQGame  
//Q Game Assignment 3  
//Revison History: Harshal Thavrani, 01-11-2021 - 04-12-2021, Created  
//Revison History: Harshal Thavrani, 06-11-2021 for A2 and 04-12-2021 for A3, Comment Added  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HThavraniQGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QGameControlPanel());
        }
    }
}
