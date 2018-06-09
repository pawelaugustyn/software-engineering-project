namespace ScrumIt.Forms
{
    partial class UserInfo
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
            this.userPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.userLastNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userRoleLabel = new System.Windows.Forms.Label();
            this.userLastNameLabel = new System.Windows.Forms.Label();
            this.usrNameLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userLoginTextBox = new System.Windows.Forms.TextBox();
            this.userEmailLLabel = new System.Windows.Forms.Label();
            this.userEmailTextBox = new System.Windows.Forms.TextBox();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userPhotoPictureBox
            // 
            this.userPhotoPictureBox.Image = global::ScrumIt.Properties.Resources.sample;
            this.userPhotoPictureBox.Location = new System.Drawing.Point(330, 63);
            this.userPhotoPictureBox.Name = "userPhotoPictureBox";
            this.userPhotoPictureBox.Size = new System.Drawing.Size(170, 170);
            this.userPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPhotoPictureBox.TabIndex = 9;
            this.userPhotoPictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.userLastNameTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.userNameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.userRoleLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.userLastNameLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.usrNameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.userNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.userLoginTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.userEmailLLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.userEmailTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.roleComboBox, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 170);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // userLastNameTextBox
            // 
            this.userLastNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLastNameTextBox.BackColor = System.Drawing.Color.White;
            this.userLastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLastNameTextBox.Location = new System.Drawing.Point(143, 71);
            this.userLastNameTextBox.Name = "userLastNameTextBox";
            this.userLastNameTextBox.Size = new System.Drawing.Size(134, 29);
            this.userLastNameTextBox.TabIndex = 7;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameTextBox.BackColor = System.Drawing.Color.White;
            this.userNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userNameTextBox.Location = new System.Drawing.Point(143, 37);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(134, 29);
            this.userNameTextBox.TabIndex = 6;
            // 
            // userRoleLabel
            // 
            this.userRoleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userRoleLabel.AutoSize = true;
            this.userRoleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userRoleLabel.Location = new System.Drawing.Point(3, 136);
            this.userRoleLabel.Name = "userRoleLabel";
            this.userRoleLabel.Size = new System.Drawing.Size(134, 34);
            this.userRoleLabel.TabIndex = 0;
            this.userRoleLabel.Text = "Rola";
            // 
            // userLastNameLabel
            // 
            this.userLastNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLastNameLabel.AutoSize = true;
            this.userLastNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLastNameLabel.Location = new System.Drawing.Point(3, 68);
            this.userLastNameLabel.Name = "userLastNameLabel";
            this.userLastNameLabel.Size = new System.Drawing.Size(134, 34);
            this.userLastNameLabel.TabIndex = 2;
            this.userLastNameLabel.Text = "Nazwisko";
            // 
            // usrNameLabel
            // 
            this.usrNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrNameLabel.AutoSize = true;
            this.usrNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrNameLabel.Location = new System.Drawing.Point(3, 34);
            this.usrNameLabel.Name = "usrNameLabel";
            this.usrNameLabel.Size = new System.Drawing.Size(134, 34);
            this.usrNameLabel.TabIndex = 1;
            this.usrNameLabel.Text = "Imię";
            // 
            // userNameLabel
            // 
            this.userNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userNameLabel.Location = new System.Drawing.Point(3, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(134, 34);
            this.userNameLabel.TabIndex = 3;
            this.userNameLabel.Text = "Login";
            // 
            // userLoginTextBox
            // 
            this.userLoginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLoginTextBox.BackColor = System.Drawing.Color.White;
            this.userLoginTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLoginTextBox.Location = new System.Drawing.Point(143, 3);
            this.userLoginTextBox.Name = "userLoginTextBox";
            this.userLoginTextBox.Size = new System.Drawing.Size(134, 29);
            this.userLoginTextBox.TabIndex = 8;
            // 
            // userEmailLLabel
            // 
            this.userEmailLLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userEmailLLabel.AutoSize = true;
            this.userEmailLLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userEmailLLabel.Location = new System.Drawing.Point(3, 102);
            this.userEmailLLabel.Name = "userEmailLLabel";
            this.userEmailLLabel.Size = new System.Drawing.Size(134, 34);
            this.userEmailLLabel.TabIndex = 4;
            this.userEmailLLabel.Text = "Email";
            // 
            // userEmailTextBox
            // 
            this.userEmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userEmailTextBox.BackColor = System.Drawing.Color.White;
            this.userEmailTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userEmailTextBox.Location = new System.Drawing.Point(143, 105);
            this.userEmailTextBox.Name = "userEmailTextBox";
            this.userEmailTextBox.Size = new System.Drawing.Size(134, 29);
            this.userEmailTextBox.TabIndex = 9;
            // 
            // roleComboBox
            // 
            this.roleComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Location = new System.Drawing.Point(143, 139);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(134, 29);
            this.roleComboBox.TabIndex = 10;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 256);
            this.Controls.Add(this.userPhotoPictureBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserInfo";
            this.Text = "UserInfo";
            this.Load += new System.EventHandler(this.UserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox userPhotoPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox userLastNameTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label userRoleLabel;
        private System.Windows.Forms.Label userLastNameLabel;
        private System.Windows.Forms.Label usrNameLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox userLoginTextBox;
        private System.Windows.Forms.Label userEmailLLabel;
        private System.Windows.Forms.TextBox userEmailTextBox;
        private System.Windows.Forms.ComboBox roleComboBox;
    }
}