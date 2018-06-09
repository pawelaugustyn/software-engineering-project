namespace ScrumIt.Forms
{
    partial class DeleteUser
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
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.userListButton = new System.Windows.Forms.Button();
            this.userListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.BackColor = System.Drawing.Color.Silver;
            this.deleteUserButton.FlatAppearance.BorderSize = 0;
            this.deleteUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteUserButton.ForeColor = System.Drawing.Color.White;
            this.deleteUserButton.Location = new System.Drawing.Point(12, 104);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(278, 31);
            this.deleteUserButton.TabIndex = 11;
            this.deleteUserButton.Text = "Usuń";
            this.deleteUserButton.UseVisualStyleBackColor = false;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // userListButton
            // 
            this.userListButton.BackColor = System.Drawing.Color.Silver;
            this.userListButton.FlatAppearance.BorderSize = 0;
            this.userListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userListButton.ForeColor = System.Drawing.Color.White;
            this.userListButton.Location = new System.Drawing.Point(12, 63);
            this.userListButton.Name = "userListButton";
            this.userListButton.Size = new System.Drawing.Size(278, 31);
            this.userListButton.TabIndex = 12;
            this.userListButton.Text = "Wybierz użytkownika";
            this.userListButton.UseVisualStyleBackColor = false;
            this.userListButton.Click += new System.EventHandler(this.userListButton_Click);
            // 
            // userListMenuStrip
            // 
            this.userListMenuStrip.Name = "userListMenuStrip";
            this.userListMenuStrip.ShowCheckMargin = true;
            this.userListMenuStrip.Size = new System.Drawing.Size(83, 4);
            // 
            // DeleteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 164);
            this.Controls.Add(this.userListButton);
            this.Controls.Add(this.deleteUserButton);
            this.Name = "DeleteUser";
            this.Text = "ScrumIt!";
            this.Load += new System.EventHandler(this.DeleteUser_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Button userListButton;
        private System.Windows.Forms.ContextMenuStrip userListMenuStrip;
    }
}