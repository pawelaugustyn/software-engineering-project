namespace ScrumIt.Forms
{
    partial class Register
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
            this.changePasswordLayoutTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmNewPasswordLabel = new System.Windows.Forms.Label();
            this.confirmNewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.userPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.changePasswordLayoutTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPictureBox)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.TabIndex = 5;
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
            // changePasswordLayoutTablePanel
            // 
            this.changePasswordLayoutTablePanel.ColumnCount = 2;
            this.changePasswordLayoutTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.changePasswordLayoutTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.changePasswordLayoutTablePanel.Controls.Add(this.newPasswordLabel, 0, 0);
            this.changePasswordLayoutTablePanel.Controls.Add(this.newPasswordTextBox, 1, 0);
            this.changePasswordLayoutTablePanel.Controls.Add(this.confirmNewPasswordLabel, 0, 1);
            this.changePasswordLayoutTablePanel.Controls.Add(this.confirmNewPasswordTextBox, 1, 1);
            this.changePasswordLayoutTablePanel.Location = new System.Drawing.Point(23, 239);
            this.changePasswordLayoutTablePanel.Name = "changePasswordLayoutTablePanel";
            this.changePasswordLayoutTablePanel.RowCount = 2;
            this.changePasswordLayoutTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.changePasswordLayoutTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.changePasswordLayoutTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.changePasswordLayoutTablePanel.Size = new System.Drawing.Size(280, 70);
            this.changePasswordLayoutTablePanel.TabIndex = 6;
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newPasswordLabel.Location = new System.Drawing.Point(3, 0);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(134, 35);
            this.newPasswordLabel.TabIndex = 2;
            this.newPasswordLabel.Text = "Hasło";
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newPasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newPasswordTextBox.Location = new System.Drawing.Point(143, 3);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(134, 29);
            this.newPasswordTextBox.TabIndex = 11;
            this.newPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmNewPasswordLabel
            // 
            this.confirmNewPasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmNewPasswordLabel.AutoSize = true;
            this.confirmNewPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.confirmNewPasswordLabel.Location = new System.Drawing.Point(3, 35);
            this.confirmNewPasswordLabel.Name = "confirmNewPasswordLabel";
            this.confirmNewPasswordLabel.Size = new System.Drawing.Size(134, 35);
            this.confirmNewPasswordLabel.TabIndex = 3;
            this.confirmNewPasswordLabel.Text = "Powtórz hasło";
            // 
            // confirmNewPasswordTextBox
            // 
            this.confirmNewPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmNewPasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.confirmNewPasswordTextBox.Location = new System.Drawing.Point(143, 38);
            this.confirmNewPasswordTextBox.Name = "confirmNewPasswordTextBox";
            this.confirmNewPasswordTextBox.Size = new System.Drawing.Size(134, 29);
            this.confirmNewPasswordTextBox.TabIndex = 12;
            this.confirmNewPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.Silver;
            this.registerButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.registerButton.FlatAppearance.BorderSize = 0;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.registerButton.ForeColor = System.Drawing.Color.White;
            this.registerButton.Location = new System.Drawing.Point(330, 269);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(170, 40);
            this.registerButton.TabIndex = 8;
            this.registerButton.Text = "Stwórz konto";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registeButton_Click);
            // 
            // userPhotoPictureBox
            // 
            this.userPhotoPictureBox.Image = global::ScrumIt.Properties.Resources.sample;
            this.userPhotoPictureBox.Location = new System.Drawing.Point(330, 63);
            this.userPhotoPictureBox.Name = "userPhotoPictureBox";
            this.userPhotoPictureBox.Size = new System.Drawing.Size(170, 170);
            this.userPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPhotoPictureBox.TabIndex = 7;
            this.userPhotoPictureBox.TabStop = false;
            this.userPhotoPictureBox.Click += new System.EventHandler(this.userPhotoPictureBox_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 344);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.userPhotoPictureBox);
            this.Controls.Add(this.changePasswordLayoutTablePanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Register";
            this.Resizable = false;
            this.Text = "ScrumIt!";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Register_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.changePasswordLayoutTablePanel.ResumeLayout(false);
            this.changePasswordLayoutTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox userEmailTextBox;
        private System.Windows.Forms.TextBox userLoginTextBox;
        private System.Windows.Forms.TextBox userLastNameTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label userLastNameLabel;
        private System.Windows.Forms.Label usrNameLabel;
        private System.Windows.Forms.Label userRoleLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label userEmailLLabel;
        private System.Windows.Forms.TableLayoutPanel changePasswordLayoutTablePanel;
        private System.Windows.Forms.Label confirmNewPasswordLabel;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox confirmNewPasswordTextBox;
        private System.Windows.Forms.PictureBox userPhotoPictureBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.ComboBox roleComboBox;
    }
}