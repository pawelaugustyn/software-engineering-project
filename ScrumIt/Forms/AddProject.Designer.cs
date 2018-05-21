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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.newProjectNameMetroTextBox = new MetroFramework.Controls.MetroTextBox();
            this.newProjectMetroButton = new MetroFramework.Controls.MetroButton();
            this.newProjectColorDialog = new System.Windows.Forms.ColorDialog();
            this.SelectProjectColorButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.1771F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.8229F));
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.newProjectNameMetroTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.newProjectMetroButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.SelectProjectColorButton, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(42, 82);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 151);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(3, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(212, 60);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Nazwa:";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(3, 60);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(212, 60);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Kolor:";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // newProjectNameMetroTextBox
            // 
            this.newProjectNameMetroTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newProjectNameMetroTextBox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.newProjectNameMetroTextBox.Location = new System.Drawing.Point(221, 3);
            this.newProjectNameMetroTextBox.Name = "newProjectNameMetroTextBox";
            this.newProjectNameMetroTextBox.Size = new System.Drawing.Size(335, 54);
            this.newProjectNameMetroTextBox.TabIndex = 4;
            this.newProjectNameMetroTextBox.Text = "podaj nazwę...";
            // 
            // newProjectMetroButton
            // 
            this.newProjectMetroButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newProjectMetroButton.Location = new System.Drawing.Point(221, 123);
            this.newProjectMetroButton.Name = "newProjectMetroButton";
            this.newProjectMetroButton.Size = new System.Drawing.Size(335, 25);
            this.newProjectMetroButton.TabIndex = 5;
            this.newProjectMetroButton.Text = "Zatwierdź";
            this.newProjectMetroButton.Click += new System.EventHandler(this.newProjectMetroButton_Click);
            // 
            // SelectProjectColorButton
            // 
            this.SelectProjectColorButton.BackColor = System.Drawing.Color.Red;
            this.SelectProjectColorButton.Location = new System.Drawing.Point(228, 70);
            this.SelectProjectColorButton.Margin = new System.Windows.Forms.Padding(10);
            this.SelectProjectColorButton.Name = "SelectProjectColorButton";
            this.SelectProjectColorButton.Size = new System.Drawing.Size(40, 40);
            this.SelectProjectColorButton.TabIndex = 6;
            this.SelectProjectColorButton.UseVisualStyleBackColor = false;
            this.SelectProjectColorButton.Click += new System.EventHandler(this.SelectProjectColorButton_Click);
            // 
            // AddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddProject";
            this.Text = "Scrum it!";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ColorDialog newProjectColorDialog;
        private MetroFramework.Controls.MetroTextBox newProjectNameMetroTextBox;
        private MetroFramework.Controls.MetroButton newProjectMetroButton;
        private System.Windows.Forms.Button SelectProjectColorButton;
    }
}