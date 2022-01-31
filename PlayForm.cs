//HThavraniQGame 
//Q Game Assignment 3
//Revison History: Harshal Thavrani, 01-11-2021 - 04-12-2021, Created
//Revison History: Harshal Thavrani, 06-11-2021 for A2 and 04-12-2021 for A3, Comment Added
using HThavraniQGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HThavraniQGame
{
    public partial class PlayForm : Form
    {
        //Quad shape's Constants
        private const int up = 30;
        private const int left = 175;
        private const int breadth = 50;
        private const int height = 50;
        private const int space = 2;
        //GLobal Varaibles
        Quad currentquad = new Quad();
        List<string> levelList = new List<string>();
        int numberofrows, numberofcols;
        int loadCounter = 0;
        int counter;
        List<string> Llist = new List<string>();
        int moves = 0;
        int boxes = 0;
        bool correctDoor = false;
        bool isBox = false;
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
        public PlayForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Enables the ↑ ↓ → ← controls and text boxes
        /// </summary>
        public void EnableControls()
        {
            btnUp.Enabled = true;
            btnDown.Enabled = true;
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            txtBoxes.Enabled = true;
            txtMoves.Enabled = true;
        }
        /// <summary>
        /// Disables the ↑ ↓ → ← controls and text boxes
        /// </summary>
        public void DisableControls()
        {
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
            txtBoxes.Enabled = false;
            txtMoves.Enabled = false;
        }
        /// <summary>
        /// checks to see if a quad is selected or not. Also, returns if it is a box or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quad_Click(object sender, EventArgs e)
        {
            //for each quad in quad control Array turn the boolean value of quad selcted to false.
            foreach (Quad quad in this.Controls.OfType<Quad>().ToArray())
            {
                quad.selected = false;
            }
            //padding the quad
            currentquad.Padding = new System.Windows.Forms.Padding(all: 0);
            currentquad.BackColor = Color.Transparent;
            //if quad type is box return isbox true.
            if (((Quad)sender).quadType == QuadTypes.box.ToString())
            {
                isBox = true;
                //editing the quad property
                currentquad.Padding = new System.Windows.Forms.Padding(all: 0);
                currentquad.BackColor = Color.Transparent;

                currentquad = (Quad)sender;
                currentquad.selected = true;

                currentquad.Padding = new System.Windows.Forms.Padding(all: 2);
                currentquad.BackColor = Color.Blue;
            }
            //else bool value is false.
            else
            {
                isBox = false;
            }
        }

        /// <summary>
        /// Load a level form the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newquad();
            //open file dialog
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "QGAME File (*.qgame)|*.qgame|All files (*.*)|*.*";
            //if file is okay
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   
                    string record;
                    //add the contents of file in a list.
                    using (StreamReader reader = new StreamReader(openfile.FileName))
                    {
                        while ((record = reader.ReadLine()) != null)
                        {
                           levelList.Add(record);

                           
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong loading.");
                }
                //add the contents of a list in an array.
                string[] loadArray = levelList.ToArray();
                //the first value of the array equal number of rows.
                numberofrows = int.Parse(Regex.Match(loadArray[0], @"\d+").Value);
                //the second value of the array equal number of columns.
                numberofcols = int.Parse(Regex.Match(loadArray[1], @"\d+").Value);
                //remove the first and second value from the array which lefts the array with row,column,content type vlaues. 
                levelList.RemoveAt(0);
                levelList.RemoveAt(0);
                //storing the edited list in a new string array.
                string[] lArray = levelList.ToArray();
                Llist.AddRange(levelList);
                //declaring new int array with length of number of rows x number of columns
                //this array will help in storing values of content type only.
                int[] a = new int[numberofrows*numberofcols];
                int count = 1;
                for (int i = 0; i < a.Length; i++)
                {
                    //formula to store value of content type in the new int array
                    counter = (3 * count) - 1;
                    a[i] = counter;
                    count++;
                }
                int x = left;
                int y = up;
                loadCounter = 0;
                //creating grid from the given rows and values fetched from the file.
                for (int i = 0; i < numberofrows; i++)
                {
                    for (int j = 0; j < numberofcols; j++)
                    {
                        Quad quad = new Quad();
                        quad.Left = x;
                        quad.Top = y;
                        quad.Height = height;
                        quad.Width = breadth;
                        quad.SizeMode = PictureBoxSizeMode.StretchImage;
                        quad.Click += new EventHandler(Quad_Click);
                        //using switch case to find specific content type
                        switch (lArray[a[loadCounter]])
                        {
                            case "0":
                                quad.BackColor = Color.LightGray;
                                quad.quadColor = QuadColors.blank.ToString();
                                quad.quadType = QuadTypes.blank.ToString();
                                break;
                            case "1":
                                quad.Image = Resources.wall;
                                quad.quadColor = QuadColors.black.ToString();
                                quad.quadType = QuadTypes.wall.ToString();
                                break;
                            case "2":
                                quad.Image = Resources.red_door;
                                quad.quadColor = QuadColors.red.ToString();
                                quad.quadType = QuadTypes.door.ToString();
                                break;
                            case "3":
                                quad.Image = Resources.green_door;
                                quad.quadColor = QuadColors.green.ToString();
                                quad.quadType = QuadTypes.door.ToString();
                                break;
                            case "4":
                                quad.Image = Resources.red_box;
                                quad.quadColor = QuadColors.red.ToString();
                                quad.quadType = QuadTypes.box.ToString();
                                break;
                            case "5":
                                quad.Image = Resources.green_box;
                                quad.quadColor = QuadColors.green.ToString();
                                quad.quadType = QuadTypes.box.ToString();
                                break;
                            default:
                                quad.BackColor = Color.LightGray;
                                quad.quadColor = QuadColors.blank.ToString();
                                quad.quadType = QuadTypes.blank.ToString();
                                break;
                        }
                        loadCounter++;
                        this.Controls.Add(quad);

                        x += breadth + space;

                        Application.DoEvents();
                        Thread.Sleep(50);
                    }
                    y += height + space;
                    x = left;
                }
                foreach (Quad tile in this.Controls.OfType<Quad>().ToArray())
                {
                    if (tile.quadType == QuadTypes.blank.ToString())
                    {
                        this.Controls.Remove(tile);
                        Application.DoEvents();
                        Thread.Sleep(25);
                    }
                }
                foreach (Quad tile in this.Controls.OfType<Quad>().ToArray())
                {
                    if (tile.quadType == QuadTypes.box.ToString())
                    {
                        boxes++;
                    }
                }
                txtBoxes.Text = boxes.ToString();
                EnableControls();
                levelList.Clear();
                Llist.Clear();
                //Array.Empty(loadArray);
                //Array.Clear(loadArray, 0, loadArray.Length);
                //Array.Clear(lArray, 0, lArray.Length);
                //Array.Clear(a, 0, a.Length);
                loadArray = Array.Empty<string>();
                lArray = Array.Empty<string>();
                //lArray = levelList.ToArray();
            }

        }
        /// <summary>
        /// moves the current quad to bottom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (isBox)
            {
                lblMoves.Select();
                moves++;
                txtMoves.Text = moves.ToString();
                DisableControls();
                while (!Collision("down"))
                {     currentquad.Top += space; 
                      Application.DoEvents();
                      Thread.Sleep(10);

                }
                if (correctDoor)
                {
                    this.Controls.Remove(currentquad);
                    boxes--;
                    txtBoxes.Text = boxes.ToString();
                }

                EnableControls();
            }
            else
            {
                MessageBox.Show("Please select a box first.");
            }
            CheckWin();
        }
        /// <summary>
        /// moves the current quad to left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (isBox)
            {
                lblMoves.Select();
                moves++;
                txtMoves.Text = moves.ToString();
                DisableControls();
                while (!Collision("left"))
                {
                        currentquad.Left -= space;
                        Application.DoEvents();
                        Thread.Sleep(10);


                }
                if (correctDoor)
                {
                    this.Controls.Remove(currentquad);
                    boxes--;
                    txtBoxes.Text = boxes.ToString();
                }
                EnableControls();
            }
            else
            {
                MessageBox.Show("Please select a box first.");
            }
            CheckWin();
        }
        /// <summary>
        /// moves the current quad to right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (isBox)
            {
                lblMoves.Select();
                moves++;
                txtMoves.Text = moves.ToString();
                DisableControls();
                while (!Collision("right"))
                {
                        currentquad.Left += space;
                        Application.DoEvents();
                        Thread.Sleep(10);

                }
                if (correctDoor)
                {
                    this.Controls.Remove(currentquad);
                    boxes--;
                    txtBoxes.Text = boxes.ToString();
                }
                EnableControls();
            }
            else
            {
                MessageBox.Show("Please select a box first.");
            }
            CheckWin();
        }
        /// <summary>
        /// checks for colliding quads
        /// </summary>
        /// <returns></returns>
        public bool Collision(string direction)
        {
            //for each quad in quad controls array check if a quad's direction(string) is up,down,left or right.
            foreach (Quad quad in this.Controls.OfType<Quad>().ToArray())
            {
                switch (direction)
                {
                    case "up":
                        if (currentquad.Left == quad.Left && currentquad.Top == (quad.Bottom + space) && !quad.selected)
                        {
                            if (quad.quadType == QuadTypes.door.ToString() && currentquad.quadColor == quad.quadColor)
                            {
                                correctDoor = true;
                            }
                            return true;
                        }
                        break;
                    case "down":
                        if (currentquad.Left == quad.Left && currentquad.Bottom == (quad.Top - space) && !quad.selected)
                        {
                            if (quad.quadType == QuadTypes.door.ToString() && currentquad.quadColor == quad.quadColor)
                            {
                                correctDoor = true;
                            }
                            return true;
                        }
                        break;
                    case "left":
                        if (currentquad.Left == (quad.Right + space) && currentquad.Top == quad.Top && !quad.selected)
                        {
                            if (quad.quadType == QuadTypes.door.ToString() && currentquad.quadColor == quad.quadColor)
                            {
                                correctDoor = true;
                            }
                            return true;
                        }
                        break;
                    case "right":
                        if (currentquad.Right == (quad.Left - space) && currentquad.Top == quad.Top && !quad.selected)
                        {
                            if (quad.quadType == QuadTypes.door.ToString() && currentquad.quadColor == quad.quadColor)
                            {
                                correctDoor = true;
                            }
                            return true;
                        }
                        break;
                }
            }
            correctDoor = false;
            return false;
        } 
        /// <summary>
          /// moves the current quad to top
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (isBox)
            {
                lblMoves.Select();
                moves++;
                txtMoves.Text = moves.ToString();
                DisableControls();
                while (!Collision("up"))
                {
                        currentquad.Top -= space;
                        Application.DoEvents();
                        Thread.Sleep(10);
                }
                if (correctDoor)
                {
                    this.Controls.Remove(currentquad);
                    boxes--;
                    txtBoxes.Text = boxes.ToString();
                }
                EnableControls();
            }
            else
            {
                MessageBox.Show("Please select a box first.");
            }
            CheckWin();
        }
        /// <summary>
        /// closes theplay form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        /// <summary>
        /// checks to see if all box type quads are gone
        /// </summary>
        /// <returns></returns>
        public bool CheckWin()
        {
            //for each Quad in Quad Controls Array
            foreach (Quad quad in this.Controls.OfType<Quad>().ToArray())
            {
                //if quad type = quad type box return false
                if (quad.quadType == QuadTypes.box.ToString())
                {
                    return false;
                }
            }
            MessageBox.Show("Congratulations. You Won this level. Game Ends.");
            newquad();
            return true;
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
            boxes = 0;
            moves = 0;
        }

        public void newquad()
        {
            levelList = new List<string>(); 
            Llist = new List<string>(); 
            //for each Quad in Quad Controls Array
            foreach (Quad quad in this.Controls.OfType<Quad>().ToArray())
            {
                //remove quad
                quad.Dispose();
                this.Controls.Remove(quad);
            }
            DisableControls();
            txtBoxes.Text = "";
            txtMoves.Text = "";
        }
    }
}
