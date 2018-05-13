namespace ScrumIt.Forms
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.propertiesComboBox = new System.Windows.Forms.ComboBox();
            this.projectsList = new MetroFramework.Controls.MetroTextBox();
            this.chooseProjectTextBox = new MetroFramework.Controls.MetroTextBox();
            this.whichProjectTextBox = new MetroFramework.Controls.MetroTextBox();
            this.projectButton = new MetroFramework.Controls.MetroButton();
            this.infoTextBox = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // propertiesComboBox
            // 
            this.propertiesComboBox.FormattingEnabled = true;
            this.propertiesComboBox.Location = new System.Drawing.Point(727, 64);
            this.propertiesComboBox.Name = "propertiesComboBox";
            this.propertiesComboBox.Size = new System.Drawing.Size(228, 24);
            this.propertiesComboBox.TabIndex = 0;
            // 
            // projectsList
            // 
            this.projectsList.Location = new System.Drawing.Point(50, 200);
            this.projectsList.Multiline = true;
            this.projectsList.Name = "projectsList";
            this.projectsList.ReadOnly = true;
            this.projectsList.Size = new System.Drawing.Size(400, 230);
            this.projectsList.TabIndex = 1;
            this.projectsList.Text = resources.GetString("projectsList.Text");
            // 
            // chooseProjectTextBox
            // 
            this.chooseProjectTextBox.Location = new System.Drawing.Point(50, 453);
            this.chooseProjectTextBox.Name = "chooseProjectTextBox";
            this.chooseProjectTextBox.ReadOnly = true;
            this.chooseProjectTextBox.Size = new System.Drawing.Size(170, 30);
            this.chooseProjectTextBox.TabIndex = 2;
            this.chooseProjectTextBox.Text = "Podaj numer projektu:";
            // 
            // whichProjectTextBox
            // 
            this.whichProjectTextBox.Location = new System.Drawing.Point(226, 453);
            this.whichProjectTextBox.Name = "whichProjectTextBox";
            this.whichProjectTextBox.Size = new System.Drawing.Size(50, 30);
            this.whichProjectTextBox.TabIndex = 3;
            this.whichProjectTextBox.Text = "nr";
            // 
            // projectButton
            // 
            this.projectButton.Location = new System.Drawing.Point(325, 453);
            this.projectButton.Name = "projectButton";
            this.projectButton.Size = new System.Drawing.Size(69, 30);
            this.projectButton.TabIndex = 4;
            this.projectButton.Text = "OK";
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(50, 135);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.Size = new System.Drawing.Size(200, 30);
            this.infoTextBox.TabIndex = 5;
            this.infoTextBox.Text = "Wybierz projekt:";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.projectButton);
            this.Controls.Add(this.whichProjectTextBox);
            this.Controls.Add(this.chooseProjectTextBox);
            this.Controls.Add(this.projectsList);
            this.Controls.Add(this.propertiesComboBox);
            this.Name = "MainView";
            this.Padding = new System.Windows.Forms.Padding(20, 60, 20, 10);
            this.Text = "Scrum It!";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox propertiesComboBox;
        private MetroFramework.Controls.MetroTextBox projectsList;
        private MetroFramework.Controls.MetroTextBox chooseProjectTextBox;
        private MetroFramework.Controls.MetroTextBox whichProjectTextBox;
        private MetroFramework.Controls.MetroButton projectButton;
        private MetroFramework.Controls.MetroTextBox infoTextBox;
    }
}