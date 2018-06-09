namespace ScrumIt.Forms
{
    partial class AddProject
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
            this.newProjectColorDialog = new System.Windows.Forms.ColorDialog();
            this.addProjectButton = new System.Windows.Forms.Button();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.changeColorButton = new System.Windows.Forms.Button();
            this.endSprintDateLabel = new System.Windows.Forms.Label();
            this.endSprintTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addProjectButton
            // 
            this.addProjectButton.BackColor = System.Drawing.Color.Silver;
            this.addProjectButton.FlatAppearance.BorderSize = 0;
            this.addProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addProjectButton.ForeColor = System.Drawing.Color.White;
            this.addProjectButton.Location = new System.Drawing.Point(32, 184);
            this.addProjectButton.Name = "addProjectButton";
            this.addProjectButton.Size = new System.Drawing.Size(383, 31);
            this.addProjectButton.TabIndex = 2;
            this.addProjectButton.Text = "Dodaj";
            this.addProjectButton.UseVisualStyleBackColor = false;
            this.addProjectButton.Click += new System.EventHandler(this.addProjectButton_Click);
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectNameLabel.Location = new System.Drawing.Point(27, 70);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(144, 25);
            this.projectNameLabel.TabIndex = 8;
            this.projectNameLabel.Text = "Nazwa Projektu";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.colorLabel.Location = new System.Drawing.Point(27, 106);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(132, 25);
            this.colorLabel.TabIndex = 9;
            this.colorLabel.Text = "Kolor projektu";
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectNameTextBox.Location = new System.Drawing.Point(185, 70);
            this.projectNameTextBox.MaxLength = 22;
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(230, 33);
            this.projectNameTextBox.TabIndex = 10;
            // 
            // changeColorButton
            // 
            this.changeColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeColorButton.BackColor = System.Drawing.Color.Red;
            this.changeColorButton.Location = new System.Drawing.Point(185, 106);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(230, 34);
            this.changeColorButton.TabIndex = 18;
            this.changeColorButton.UseVisualStyleBackColor = false;
            this.changeColorButton.Click += new System.EventHandler(this.SelectProjectColorButton_Click);
            // 
            // endSprintDateLabel
            // 
            this.endSprintDateLabel.AutoSize = true;
            this.endSprintDateLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endSprintDateLabel.Location = new System.Drawing.Point(27, 143);
            this.endSprintDateLabel.Name = "endSprintDateLabel";
            this.endSprintDateLabel.Size = new System.Drawing.Size(143, 25);
            this.endSprintDateLabel.TabIndex = 19;
            this.endSprintDateLabel.Text = "Koniec I sprintu";
            // 
            // endSprintTextBox
            // 
            this.endSprintTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endSprintTextBox.Location = new System.Drawing.Point(185, 143);
            this.endSprintTextBox.Name = "endSprintTextBox";
            this.endSprintTextBox.Size = new System.Drawing.Size(230, 33);
            this.endSprintTextBox.TabIndex = 20;
            this.endSprintTextBox.Text = "rrrr-mm-dd";
            // 
            // AddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 234);
            this.Controls.Add(this.endSprintTextBox);
            this.Controls.Add(this.endSprintDateLabel);
            this.Controls.Add(this.changeColorButton);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.projectNameLabel);
            this.Controls.Add(this.addProjectButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProject";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Resizable = false;
            this.Text = "Scrum it!";
            this.Load += new System.EventHandler(this.AddProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog newProjectColorDialog;
        private System.Windows.Forms.Button addProjectButton;
        private System.Windows.Forms.Label projectNameLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Button changeColorButton;
        private System.Windows.Forms.Label endSprintDateLabel;
        private System.Windows.Forms.TextBox endSprintTextBox;
    }
}