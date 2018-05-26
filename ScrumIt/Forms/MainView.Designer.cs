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
            this.infoLabel = new System.Windows.Forms.Label();
            this.propertiesComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel.Location = new System.Drawing.Point(47, 132);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(185, 29);
            this.infoLabel.TabIndex = 7;
            this.infoLabel.Text = "Wybierz projekt:";
            // 
            // propertiesComboBox
            // 
            this.propertiesComboBox.FormattingEnabled = true;
            this.propertiesComboBox.ItemHeight = 24;
            this.propertiesComboBox.Location = new System.Drawing.Point(1099, 53);
            this.propertiesComboBox.Name = "propertiesComboBox";
            this.propertiesComboBox.Size = new System.Drawing.Size(224, 30);
            this.propertiesComboBox.TabIndex = 8;
            this.propertiesComboBox.SelectedIndexChanged += new System.EventHandler(this.propertiesComboBox_SelectedIndexChanged);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.propertiesComboBox);
            this.Controls.Add(this.infoLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainView";
            this.Padding = new System.Windows.Forms.Padding(20, 60, 20, 10);
            this.Text = "Scrum It!";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label infoLabel;
        private MetroFramework.Controls.MetroComboBox propertiesComboBox;
    }
}