//HThavraniQGame 
//Q Game Assignment 2
//Revison History: Harshal Thavrani, 01-11-2021, Created
//Revison History: Harshal Thavrani, 06-11-2021, Comment Added
using System;
using HThavraniQGame.Properties;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HThavraniQGame
{
    public partial class DesignForm : Form
    {

        //Quad shape's Constants
        private const int up = 100;
        private const int left = 150;
        private const int breadth = 50;
        private const int height = 50;
        private const int space = 2;
        //GLobal Varaibles
        int row, column, wallcount, doorcount, boxcount;
        PictureBox[,] grid = null;
        //Creating the object from the Build class which will later co relate with the component class
        Build build = new Build();
        /// <summary>
        /// quad shape color options
        /// </summary>
        public enum QuadColors
        {
            blank,
            black,
            red,
            green,
        }
        /// <summary>
        /// quad shape type options
        /// </summary>
        public enum QuadTypes
        {
            blank,
            wall,
            door,
            box
        }
        /// <summary>
        /// quad shape content number such as wall = 1, red door=2, green door=3 and so on.
        /// </summary>
        public enum QuadNumbers
        {
            none,
            blackwall,
            reddoor,
            greendoor,
            redbox,
            greenbox
        }
        public DesignForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This Method Genrates the set of rows and columns made of picturebox that user wants.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //declaring variables
            string message;
            message = "";
            try
            {
                //if the number of rows is not integer store the error
                if (!int.TryParse(txtrow.Text, out row))
                {
                    message += "The user input of Rows must be an integer. \n";
                    //MessageBox.Show("The Rows and Columns must be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //if the number of columns is not integer store the error
                if (!int.TryParse(txtcol.Text, out column))
                {
                    message += "The user input of Column must be an integer. \n";
                    //MessageBox.Show("The Rows and Columns must be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //if the number of rows and columns is integer then make the picture box set
                if (message == "")
                {
                    int X = left;
                    int Y = up;
                    grid = new PictureBox[row, column];
                    //using for loop to make the picturebox set from the user input data  
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            //using the component class Quad where the component is picture box 
                            Quad quad = new Quad();
                            //determining picturebox properties of the Quad component class
                            quad.Left = X;
                            quad.Top = Y;
                            quad.Height = height;
                            quad.Width = breadth;
                            quad.BorderStyle = BorderStyle.FixedSingle;
                            quad.BackColor = Color.LightGray;
                            //storing the enum values which will help determine
                            //the specific tool type in the next methods
                            quad.quadColor = QuadColors.blank.ToString();
                            quad.quadType = QuadTypes.blank.ToString();
                            quad.quadNumber = ((int)QuadNumbers.none).ToString();
                            quad.Click += new EventHandler(Quad_Click);
                            this.Controls.Add(quad);
                            X += breadth + space;
                            Application.DoEvents();
                            Thread.Sleep(25);
                            grid[i, j] = quad;
                        }
                        Y += height + space;
                        X = left;
                    }
                }
                //else make show the value of stored error
                else
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// This Method collects the content information from the toolbox to determine which tool is selected by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolDesigner_Click(object sender, EventArgs e)
        {
            try
            {
                //using switch case to determine which content to store if that button is selcted
                switch (((Button)sender).Name)
                {
                    //storing content values in the buttons
                    case "btnNone":
                        //Equalizing the simple class properties with
                        //the enum properties and storing them in a string
                        build.quadColor = QuadColors.blank.ToString();
                        build.quadType = QuadTypes.blank.ToString();
                        build.quadNumber = ((int)QuadNumbers.none).ToString();
                        break;
                    case "btnWall":
                        build.quadColor = QuadColors.black.ToString();
                        build.quadType = QuadTypes.wall.ToString();
                        build.quadNumber = ((int)QuadNumbers.blackwall).ToString();
                        break;
                    case "btnRedDoor":
                        build.quadColor = QuadColors.red.ToString();
                        build.quadType = QuadTypes.door.ToString();
                        build.quadNumber = ((int)QuadNumbers.reddoor).ToString();
                        break;
                    case "btnGreenDoor":
                        build.quadColor = QuadColors.green.ToString();
                        build.quadType = QuadTypes.door.ToString();
                        build.quadNumber = ((int)QuadNumbers.greendoor).ToString();
                        break;
                    case "btnRedBox":
                        build.quadColor = QuadColors.red.ToString();
                        build.quadType = QuadTypes.box.ToString();
                        build.quadNumber = ((int)QuadNumbers.redbox).ToString();
                        break;
                    case "btnGreenBox":
                        build.quadColor = QuadColors.green.ToString();
                        build.quadType = QuadTypes.box.ToString();
                        build.quadNumber = ((int)QuadNumbers.greenbox).ToString();
                        break;
                    default:
                        MessageBox.Show(((Button)sender).Name);
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// This method assigns a picture to the quad shape based of the tool selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quad_Click(object sender, EventArgs e)
        {
            try
            {
                Quad quad = new Quad();
                quad = (Quad)sender;
                //Co-Relating (Equalizing) the properties of the component class and the simple class 
                quad.quadColor = build.quadColor;
                quad.quadType = build.quadType;
                quad.quadNumber = build.quadNumber;
                //converting the content values that we stored from the ToolDesigner_Click method into string
                string image = $"{quad.quadColor} {quad.quadType}";
                //using switch statement to help that string to store the image value
                //and also storing the wall counts, door counts and box count to show at the end
                switch (image)
                {
                    case "blank blank":
                        quad.BackColor = Color.LightGray;
                        quad.Image = null;
                        break;
                    case "black wall":
                        quad.Image = Resources.wall;
                        //wallcount++;
                        break;
                    case "red door":
                        quad.Image = Resources.red_door;
                        //doorcount++;
                        break;
                    case "green door":
                        quad.Image = Resources.green_door;
                        //doorcount++;
                        break;
                    case "red box":
                        quad.Image = Resources.red_box;
                        //boxcount++;
                        break;
                    case "green box":
                        quad.Image = Resources.green_box;
                        //boxcount++;
                        break;
                    default:
                        quad.BackColor = Color.LightGray;
                        quad.Image = null;
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// This method stores the specific content value for the tools that we display in the saved file
        /// </summary>
        private string contentnumber(PictureBox picture)
        {
            try
            {
                Quad quad = new Quad();
                quad = (Quad)picture;
                //converting the content values that we stored from the ToolDesigner_Click method into string
                string image = $"{quad.quadColor} {quad.quadType}";
                //using switch statement to help that string to store the image value
                //and also storing the wall counts, door counts and box count to show at the end
                switch (image)
                {
                    case "blank blank":
                        quad.quadNumber = ((int)QuadNumbers.none).ToString();
                        break;
                    case "black wall":
                        quad.quadNumber = ((int)QuadNumbers.blackwall).ToString();
                        wallcount++;
                        break;
                    case "red door":
                        quad.quadNumber = ((int)QuadNumbers.reddoor).ToString();
                        doorcount++;
                        break;
                    case "green door":
                        quad.quadNumber = ((int)QuadNumbers.greendoor).ToString();
                        doorcount++;
                        break;
                    case "red box":
                        quad.quadNumber = ((int)QuadNumbers.redbox).ToString();
                        boxcount++;
                        break;
                    case "green box":
                        quad.quadNumber = ((int)QuadNumbers.greenbox).ToString();
                        boxcount++;
                        break;
                    default:
                        quad.quadNumber = "-1";
                        break;
                }
                return quad.quadNumber;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// This method saves the level as a .txt file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveLevel(object sender, EventArgs e)
        {
            try
            {
                //prompts the user to select a location for saving a file.
                SaveFileDialog savelevel = new SaveFileDialog();
                savelevel.Filter = "QGAME File (*.qgame)|*.qgame|All Files (*.*)|*.*";
                if (savelevel.ShowDialog() == DialogResult.OK)
                {
                    //Writes the number of rows and columns collected by the btngenerate method in a text file.
                    using (StreamWriter writer = new StreamWriter(savelevel.FileName, false))
                    {
                        writer.WriteLine($"{row}");
                        writer.WriteLine($"{column}");

                    }
                    //Writes the specific number of rows, columns and the tool selcted which is
                    //collected by the Quad_Click and contentnumber method in a text file.
                    using (StreamWriter writer = new StreamWriter(savelevel.FileName, true))
                    {
                        Quad quad = new Quad();
                        string temp = "";
                        //using for loop to determine each row and each column.
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < column; j++)
                            {
                                //using another for loop to determine value of each row,column and specifc tool
                                writer.WriteLine(i);
                                writer.WriteLine(j);
                                temp = contentnumber(grid[i, j]);
                                writer.WriteLine(temp);
                                //writer.WriteLine("");
                            }
                        }

                    }
                    //Shows the number of walls, doors and boxes collected
                    //by the Quad_Click method in a message box
                    MessageBox.Show($"File Saved Successfully: \nTotal number of walls:{wallcount} " +
                        $"\nTotal number of doors:{doorcount} \nTotal number of boxes:{boxcount}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}



