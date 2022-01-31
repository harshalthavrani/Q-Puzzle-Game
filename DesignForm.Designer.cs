
namespace HThavraniQGame
{
    partial class DesignForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblrow = new System.Windows.Forms.Label();
            this.txtrow = new System.Windows.Forms.TextBox();
            this.txtcol = new System.Windows.Forms.TextBox();
            this.lblcol = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnWall = new System.Windows.Forms.Button();
            this.btnGreenBox = new System.Windows.Forms.Button();
            this.btnRedBox = new System.Windows.Forms.Button();
            this.btnGreenDoor = new System.Windows.Forms.Button();
            this.btnRedDoor = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1294, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveLevel);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // lblrow
            // 
            this.lblrow.AutoSize = true;
            this.lblrow.BackColor = System.Drawing.Color.Black;
            this.lblrow.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrow.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblrow.Location = new System.Drawing.Point(2, 31);
            this.lblrow.Name = "lblrow";
            this.lblrow.Size = new System.Drawing.Size(83, 39);
            this.lblrow.TabIndex = 1;
            this.lblrow.Text = "Rows";
            // 
            // txtrow
            // 
            this.txtrow.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrow.Location = new System.Drawing.Point(91, 35);
            this.txtrow.Name = "txtrow";
            this.txtrow.Size = new System.Drawing.Size(162, 35);
            this.txtrow.TabIndex = 2;
            // 
            // txtcol
            // 
            this.txtcol.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcol.Location = new System.Drawing.Point(413, 35);
            this.txtcol.Name = "txtcol";
            this.txtcol.Size = new System.Drawing.Size(162, 35);
            this.txtcol.TabIndex = 4;
            // 
            // lblcol
            // 
            this.lblcol.AutoSize = true;
            this.lblcol.BackColor = System.Drawing.Color.Black;
            this.lblcol.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcol.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblcol.Location = new System.Drawing.Point(284, 30);
            this.lblcol.Name = "lblcol";
            this.lblcol.Size = new System.Drawing.Size(123, 39);
            this.lblcol.TabIndex = 5;
            this.lblcol.Text = "Columns";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Black;
            this.btnGenerate.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerate.Location = new System.Drawing.Point(796, 31);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(176, 51);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnNone
            // 
            this.btnNone.Image = global::HThavraniQGame.Properties.Resources.none;
            this.btnNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNone.Location = new System.Drawing.Point(13, 97);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(165, 60);
            this.btnNone.TabIndex = 7;
            this.btnNone.Text = "None";
            this.btnNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.ToolDesigner_Click);
            // 
            // btnWall
            // 
            this.btnWall.Image = global::HThavraniQGame.Properties.Resources.wall;
            this.btnWall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWall.Location = new System.Drawing.Point(13, 172);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(165, 60);
            this.btnWall.TabIndex = 8;
            this.btnWall.Text = "Wall";
            this.btnWall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWall.UseVisualStyleBackColor = true;
            this.btnWall.Click += new System.EventHandler(this.ToolDesigner_Click);
            // 
            // btnGreenBox
            // 
            this.btnGreenBox.Image = global::HThavraniQGame.Properties.Resources.green_box;
            this.btnGreenBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGreenBox.Location = new System.Drawing.Point(13, 488);
            this.btnGreenBox.Name = "btnGreenBox";
            this.btnGreenBox.Size = new System.Drawing.Size(165, 60);
            this.btnGreenBox.TabIndex = 12;
            this.btnGreenBox.Text = "Green Box";
            this.btnGreenBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGreenBox.UseVisualStyleBackColor = true;
            this.btnGreenBox.Click += new System.EventHandler(this.ToolDesigner_Click);
            // 
            // btnRedBox
            // 
            this.btnRedBox.Image = global::HThavraniQGame.Properties.Resources.red_box;
            this.btnRedBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedBox.Location = new System.Drawing.Point(13, 407);
            this.btnRedBox.Name = "btnRedBox";
            this.btnRedBox.Size = new System.Drawing.Size(165, 60);
            this.btnRedBox.TabIndex = 11;
            this.btnRedBox.Text = "Red Box";
            this.btnRedBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedBox.UseVisualStyleBackColor = true;
            this.btnRedBox.Click += new System.EventHandler(this.ToolDesigner_Click);
            // 
            // btnGreenDoor
            // 
            this.btnGreenDoor.Image = global::HThavraniQGame.Properties.Resources.green_door;
            this.btnGreenDoor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGreenDoor.Location = new System.Drawing.Point(13, 329);
            this.btnGreenDoor.Name = "btnGreenDoor";
            this.btnGreenDoor.Size = new System.Drawing.Size(165, 60);
            this.btnGreenDoor.TabIndex = 10;
            this.btnGreenDoor.Text = "Green Door";
            this.btnGreenDoor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGreenDoor.UseVisualStyleBackColor = true;
            this.btnGreenDoor.Click += new System.EventHandler(this.ToolDesigner_Click);
            // 
            // btnRedDoor
            // 
            this.btnRedDoor.Image = global::HThavraniQGame.Properties.Resources.red_door;
            this.btnRedDoor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedDoor.Location = new System.Drawing.Point(13, 250);
            this.btnRedDoor.Name = "btnRedDoor";
            this.btnRedDoor.Size = new System.Drawing.Size(165, 60);
            this.btnRedDoor.TabIndex = 9;
            this.btnRedDoor.Text = "Red Door";
            this.btnRedDoor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedDoor.UseVisualStyleBackColor = true;
            this.btnRedDoor.Click += new System.EventHandler(this.ToolDesigner_Click);
            // 
            // DesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1294, 566);
            this.Controls.Add(this.btnGreenBox);
            this.Controls.Add(this.btnRedBox);
            this.Controls.Add(this.btnGreenDoor);
            this.Controls.Add(this.btnRedDoor);
            this.Controls.Add(this.btnWall);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblcol);
            this.Controls.Add(this.txtcol);
            this.Controls.Add(this.txtrow);
            this.Controls.Add(this.lblrow);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DesignForm";
            this.Text = "DesignForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lblrow;
        private System.Windows.Forms.TextBox txtrow;
        private System.Windows.Forms.TextBox txtcol;
        private System.Windows.Forms.Label lblcol;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnWall;
        private System.Windows.Forms.Button btnRedDoor;
        private System.Windows.Forms.Button btnGreenDoor;
        private System.Windows.Forms.Button btnRedBox;
        private System.Windows.Forms.Button btnGreenBox;
    }
}