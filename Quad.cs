//HThavraniQGame 
//Q Game Assignment 3
//Revison History: Harshal Thavrani, 01-11-2021 - 04-12-2021, Created
//Revison History: Harshal Thavrani, 06-11-2021 for A2 and 04-12-2021 for A3, Comment Added
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HThavraniQGame
{

    //Creating Component class which uses picturebox as a component
    public class Quad : PictureBox
    {
        //declaring picturebox properties as a string variable
        public string quadColor { get; set; }
        public string quadType { get; set; }
        public string quadNumber { get; set; }
        public bool selected { get; set; }

              
    }
}
