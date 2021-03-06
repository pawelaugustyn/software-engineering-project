﻿namespace ScrumIt.Forms
{
    partial class UserPanel
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
            this.userRoleLabel = new System.Windows.Forms.Label();
            this.usrNameLabel = new System.Windows.Forms.Label();
            this.userLastNameLabel = new System.Windows.Forms.Label();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RoleTextBox = new System.Windows.Forms.TextBox();
            this.userLastNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userLoginTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userEmailLLabel = new System.Windows.Forms.Label();
            this.userEmailTextBox = new System.Windows.Forms.TextBox();
            this.changePasswordLayoutTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmNewPasswordLabel = new System.Windows.Forms.Label();
            this.confirmNewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.submitPasswordChangeButton = new System.Windows.Forms.Button();
            this.loadPictureDialog = new System.Windows.Forms.OpenFileDialog();
            this.changeUserDataButton = new System.Windows.Forms.Button();
            this.userPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.changePasswordLayoutTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPictureBox)).BeginInit();
            this.SuspendLayout();
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
            this.userRoleLabel.Size = new System.Drawing.Size(106, 34);
            this.userRoleLabel.TabIndex = 0;
            this.userRoleLabel.Text = "Rola";
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
            this.usrNameLabel.Size = new System.Drawing.Size(106, 34);
            this.usrNameLabel.TabIndex = 1;
            this.usrNameLabel.Text = "Imie";
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
            this.userLastNameLabel.Size = new System.Drawing.Size(106, 34);
            this.userLastNameLabel.TabIndex = 2;
            this.userLastNameLabel.Text = "Nazwisko";
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.BackColor = System.Drawing.Color.Silver;
            this.changePasswordButton.FlatAppearance.BorderSize = 0;
            this.changePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePasswordButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changePasswordButton.ForeColor = System.Drawing.Color.White;
            this.changePasswordButton.Location = new System.Drawing.Point(201, 228);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(169, 35);
            this.changePasswordButton.TabIndex = 3;
            this.changePasswordButton.Text = "Zmień hasło";
            this.changePasswordButton.UseVisualStyleBackColor = false;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel1.Controls.Add(this.RoleTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.userLastNameTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.userNameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.userLastNameLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.usrNameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.userLoginTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.userNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.userEmailLLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.userRoleLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.userEmailTextBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 170);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // RoleTextBox
            // 
            this.RoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoleTextBox.BackColor = System.Drawing.Color.White;
            this.RoleTextBox.Enabled = false;
            this.RoleTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RoleTextBox.Location = new System.Drawing.Point(115, 139);
            this.RoleTextBox.Name = "RoleTextBox";
            this.RoleTextBox.ReadOnly = true;
            this.RoleTextBox.Size = new System.Drawing.Size(232, 29);
            this.RoleTextBox.TabIndex = 10;
            // 
            // userLastNameTextBox
            // 
            this.userLastNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLastNameTextBox.BackColor = System.Drawing.Color.White;
            this.userLastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLastNameTextBox.Location = new System.Drawing.Point(115, 71);
            this.userLastNameTextBox.Name = "userLastNameTextBox";
            this.userLastNameTextBox.Size = new System.Drawing.Size(232, 29);
            this.userLastNameTextBox.TabIndex = 7;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameTextBox.BackColor = System.Drawing.Color.White;
            this.userNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userNameTextBox.Location = new System.Drawing.Point(115, 37);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(232, 29);
            this.userNameTextBox.TabIndex = 6;
            // 
            // userLoginTextBox
            // 
            this.userLoginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLoginTextBox.BackColor = System.Drawing.Color.White;
            this.userLoginTextBox.Enabled = false;
            this.userLoginTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLoginTextBox.Location = new System.Drawing.Point(115, 3);
            this.userLoginTextBox.Name = "userLoginTextBox";
            this.userLoginTextBox.ReadOnly = true;
            this.userLoginTextBox.Size = new System.Drawing.Size(232, 29);
            this.userLoginTextBox.TabIndex = 8;
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
            this.userNameLabel.Size = new System.Drawing.Size(106, 34);
            this.userNameLabel.TabIndex = 3;
            this.userNameLabel.Text = "Login";
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
            this.userEmailLLabel.Size = new System.Drawing.Size(106, 34);
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
            this.userEmailTextBox.Location = new System.Drawing.Point(115, 105);
            this.userEmailTextBox.Name = "userEmailTextBox";
            this.userEmailTextBox.Size = new System.Drawing.Size(232, 29);
            this.userEmailTextBox.TabIndex = 9;
            // 
            // changePasswordLayoutTablePanel
            // 
            this.changePasswordLayoutTablePanel.ColumnCount = 2;
            this.changePasswordLayoutTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.28571F));
            this.changePasswordLayoutTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.71429F));
            this.changePasswordLayoutTablePanel.Controls.Add(this.newPasswordLabel, 0, 0);
            this.changePasswordLayoutTablePanel.Controls.Add(this.newPasswordTextBox, 1, 0);
            this.changePasswordLayoutTablePanel.Controls.Add(this.confirmNewPasswordLabel, 0, 1);
            this.changePasswordLayoutTablePanel.Controls.Add(this.confirmNewPasswordTextBox, 1, 1);
            this.changePasswordLayoutTablePanel.Location = new System.Drawing.Point(23, 263);
            this.changePasswordLayoutTablePanel.Name = "changePasswordLayoutTablePanel";
            this.changePasswordLayoutTablePanel.RowCount = 2;
            this.changePasswordLayoutTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.changePasswordLayoutTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.changePasswordLayoutTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.changePasswordLayoutTablePanel.Size = new System.Drawing.Size(350, 70);
            this.changePasswordLayoutTablePanel.TabIndex = 5;
            this.changePasswordLayoutTablePanel.Visible = false;
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
            this.newPasswordLabel.Size = new System.Drawing.Size(155, 35);
            this.newPasswordLabel.TabIndex = 2;
            this.newPasswordLabel.Text = "Nowe Hasło";
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newPasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newPasswordTextBox.Location = new System.Drawing.Point(164, 3);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(183, 29);
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
            this.confirmNewPasswordLabel.Size = new System.Drawing.Size(155, 35);
            this.confirmNewPasswordLabel.TabIndex = 3;
            this.confirmNewPasswordLabel.Text = "Powtórz nowe hasło";
            // 
            // confirmNewPasswordTextBox
            // 
            this.confirmNewPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmNewPasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.confirmNewPasswordTextBox.Location = new System.Drawing.Point(164, 38);
            this.confirmNewPasswordTextBox.Name = "confirmNewPasswordTextBox";
            this.confirmNewPasswordTextBox.Size = new System.Drawing.Size(183, 29);
            this.confirmNewPasswordTextBox.TabIndex = 12;
            this.confirmNewPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // submitPasswordChangeButton
            // 
            this.submitPasswordChangeButton.BackColor = System.Drawing.Color.Silver;
            this.submitPasswordChangeButton.FlatAppearance.BorderSize = 0;
            this.submitPasswordChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitPasswordChangeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.submitPasswordChangeButton.ForeColor = System.Drawing.Color.White;
            this.submitPasswordChangeButton.Location = new System.Drawing.Point(389, 298);
            this.submitPasswordChangeButton.Name = "submitPasswordChangeButton";
            this.submitPasswordChangeButton.Size = new System.Drawing.Size(121, 35);
            this.submitPasswordChangeButton.TabIndex = 6;
            this.submitPasswordChangeButton.Text = "Zmień hasło";
            this.submitPasswordChangeButton.UseVisualStyleBackColor = false;
            this.submitPasswordChangeButton.Visible = false;
            this.submitPasswordChangeButton.Click += new System.EventHandler(this.submitPasswordChangeButton_Click);
            // 
            // loadPictureDialog
            // 
            this.loadPictureDialog.FileName = "loadPictureDialog";
            // 
            // changeUserDataButton
            // 
            this.changeUserDataButton.BackColor = System.Drawing.Color.Silver;
            this.changeUserDataButton.FlatAppearance.BorderSize = 0;
            this.changeUserDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeUserDataButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeUserDataButton.ForeColor = System.Drawing.Color.White;
            this.changeUserDataButton.Location = new System.Drawing.Point(23, 228);
            this.changeUserDataButton.Name = "changeUserDataButton";
            this.changeUserDataButton.Size = new System.Drawing.Size(169, 35);
            this.changeUserDataButton.TabIndex = 7;
            this.changeUserDataButton.Text = "Zaktualizuj dane";
            this.changeUserDataButton.UseVisualStyleBackColor = false;
            this.changeUserDataButton.Click += new System.EventHandler(this.changeUserDataButton_Click);
            // 
            // userPhotoPictureBox
            // 
            this.userPhotoPictureBox.Location = new System.Drawing.Point(398, 29);
            this.userPhotoPictureBox.Name = "userPhotoPictureBox";
            this.userPhotoPictureBox.Size = new System.Drawing.Size(112, 122);
            this.userPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPhotoPictureBox.TabIndex = 0;
            this.userPhotoPictureBox.TabStop = false;
            this.userPhotoPictureBox.Click += new System.EventHandler(this.userPhotoPictureBox_Click);
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 354);
            this.Controls.Add(this.changeUserDataButton);
            this.Controls.Add(this.submitPasswordChangeButton);
            this.Controls.Add(this.changePasswordLayoutTablePanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.userPhotoPictureBox);
            this.Controls.Add(this.changePasswordButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserPanel";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "ScrumIt!";
            this.Load += new System.EventHandler(this.UserPanel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.changePasswordLayoutTablePanel.ResumeLayout(false);
            this.changePasswordLayoutTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox userPhotoPictureBox;
        private System.Windows.Forms.Label userRoleLabel;
        private System.Windows.Forms.Label usrNameLabel;
        private System.Windows.Forms.Label userLastNameLabel;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel changePasswordLayoutTablePanel;
        private System.Windows.Forms.Label confirmNewPasswordLabel;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.Button submitPasswordChangeButton;
        private System.Windows.Forms.TextBox userEmailTextBox;
        private System.Windows.Forms.TextBox userLoginTextBox;
        private System.Windows.Forms.TextBox userLastNameTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label userEmailLLabel;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox confirmNewPasswordTextBox;
        private System.Windows.Forms.OpenFileDialog loadPictureDialog;
        private System.Windows.Forms.Button changeUserDataButton;
        private System.Windows.Forms.TextBox RoleTextBox;
    }
}