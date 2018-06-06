namespace ScrumIt.Forms
{
    partial class ManageProject
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.showUsersButton = new System.Windows.Forms.Button();
            this.taskUserListLabel = new System.Windows.Forms.Label();
            this.changeNameButton = new System.Windows.Forms.Label();
            this.changeCollorLabel = new System.Windows.Forms.Label();
            this.changeNameTextBox = new System.Windows.Forms.TextBox();
            this.changeColorButton = new System.Windows.Forms.Button();
            this.userListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editProjectButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.addSprintButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.showUsersButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.taskUserListLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.changeNameButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.changeCollorLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.changeNameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.changeColorButton, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 105);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // showUsersButton
            // 
            this.showUsersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showUsersButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.showUsersButton.FlatAppearance.BorderSize = 0;
            this.showUsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showUsersButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showUsersButton.Location = new System.Drawing.Point(205, 73);
            this.showUsersButton.Name = "showUsersButton";
            this.showUsersButton.Size = new System.Drawing.Size(197, 29);
            this.showUsersButton.TabIndex = 16;
            this.showUsersButton.Text = "Lista Użytkowików";
            this.showUsersButton.UseVisualStyleBackColor = true;
            this.showUsersButton.Click += new System.EventHandler(this.showUsersButton_Click);
            // 
            // taskUserListLabel
            // 
            this.taskUserListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskUserListLabel.AutoSize = true;
            this.taskUserListLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskUserListLabel.Location = new System.Drawing.Point(3, 70);
            this.taskUserListLabel.Name = "taskUserListLabel";
            this.taskUserListLabel.Size = new System.Drawing.Size(196, 35);
            this.taskUserListLabel.TabIndex = 15;
            this.taskUserListLabel.Text = "Przypisz do projektu";
            this.taskUserListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // changeNameButton
            // 
            this.changeNameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeNameButton.AutoSize = true;
            this.changeNameButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeNameButton.Location = new System.Drawing.Point(3, 0);
            this.changeNameButton.Name = "changeNameButton";
            this.changeNameButton.Size = new System.Drawing.Size(196, 35);
            this.changeNameButton.TabIndex = 0;
            this.changeNameButton.Text = "Zmień nazwę projektu";
            this.changeNameButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // changeCollorLabel
            // 
            this.changeCollorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeCollorLabel.AutoSize = true;
            this.changeCollorLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeCollorLabel.Location = new System.Drawing.Point(3, 35);
            this.changeCollorLabel.Name = "changeCollorLabel";
            this.changeCollorLabel.Size = new System.Drawing.Size(196, 35);
            this.changeCollorLabel.TabIndex = 1;
            this.changeCollorLabel.Text = "Zmień kolor projektu";
            this.changeCollorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // changeNameTextBox
            // 
            this.changeNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeNameTextBox.Location = new System.Drawing.Point(205, 3);
            this.changeNameTextBox.Name = "changeNameTextBox";
            this.changeNameTextBox.Size = new System.Drawing.Size(197, 29);
            this.changeNameTextBox.TabIndex = 2;
            // 
            // changeColorButton
            // 
            this.changeColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeColorButton.BackColor = System.Drawing.Color.Red;
            this.changeColorButton.Location = new System.Drawing.Point(205, 38);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(197, 29);
            this.changeColorButton.TabIndex = 17;
            this.changeColorButton.UseVisualStyleBackColor = false;
            this.changeColorButton.Click += new System.EventHandler(this.changeColoButton_Click);
            // 
            // userListMenuStrip
            // 
            this.userListMenuStrip.Name = "userListMenuStrip";
            this.userListMenuStrip.ShowCheckMargin = true;
            this.userListMenuStrip.Size = new System.Drawing.Size(83, 4);
            this.userListMenuStrip.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.userListMenuStrip_Closing);
            // 
            // editProjectButton
            // 
            this.editProjectButton.BackColor = System.Drawing.Color.Silver;
            this.editProjectButton.FlatAppearance.BorderSize = 0;
            this.editProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editProjectButton.ForeColor = System.Drawing.Color.White;
            this.editProjectButton.Location = new System.Drawing.Point(23, 183);
            this.editProjectButton.Name = "editProjectButton";
            this.editProjectButton.Size = new System.Drawing.Size(405, 31);
            this.editProjectButton.TabIndex = 4;
            this.editProjectButton.Text = "Uaktualnij";
            this.editProjectButton.UseVisualStyleBackColor = false;
            this.editProjectButton.Click += new System.EventHandler(this.editTaskButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(23, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(405, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Usuń projekt";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addSprintButton
            // 
            this.addSprintButton.BackColor = System.Drawing.Color.Silver;
            this.addSprintButton.FlatAppearance.BorderSize = 0;
            this.addSprintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSprintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addSprintButton.ForeColor = System.Drawing.Color.White;
            this.addSprintButton.Location = new System.Drawing.Point(23, 257);
            this.addSprintButton.Name = "addSprintButton";
            this.addSprintButton.Size = new System.Drawing.Size(405, 31);
            this.addSprintButton.TabIndex = 6;
            this.addSprintButton.Text = "Dodaj Sprint";
            this.addSprintButton.UseVisualStyleBackColor = false;
            this.addSprintButton.Click += new System.EventHandler(this.addSprintButton_Click);
            // 
            // ManageProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 308);
            this.Controls.Add(this.addSprintButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.editProjectButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageProject";
            this.Resizable = false;
            this.Text = "ScrumIt!";
            this.Load += new System.EventHandler(this.ManageProject_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label changeNameButton;
        private System.Windows.Forms.Label changeCollorLabel;
        private System.Windows.Forms.TextBox changeNameTextBox;
        private System.Windows.Forms.Label taskUserListLabel;
        private System.Windows.Forms.Button showUsersButton;
        private System.Windows.Forms.ContextMenuStrip userListMenuStrip;
        private System.Windows.Forms.Button editProjectButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button changeColorButton;
        private System.Windows.Forms.Button addSprintButton;
    }
}