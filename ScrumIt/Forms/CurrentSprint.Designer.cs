using System.Drawing;

namespace ScrumIt.Forms
{
    partial class CurrentSprint
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
            this.addTaskButton = new MetroFramework.Controls.MetroButton();
            this.userListComboBox = new System.Windows.Forms.ComboBox();
            this.backlogComboBox = new System.Windows.Forms.ComboBox();
            this.currentSprintButton = new MetroFramework.Controls.MetroButton();
            this.historyComboBox = new System.Windows.Forms.ComboBox();
            this.properiesComboBox = new System.Windows.Forms.ComboBox();
            this.scrumBoardPanel = new System.Windows.Forms.Panel();
            this.taskPanel = new System.Windows.Forms.Panel();
            this.taskNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.userPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.taskTimeLabel = new MetroFramework.Controls.MetroLabel();
            this.taskDescriptionButton = new MetroFramework.Controls.MetroButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.scrumBoardPanel.SuspendLayout();
            this.taskPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.addTaskButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.userListComboBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.backlogComboBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.currentSprintButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.historyComboBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 115);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1295, 34);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // addTaskButton
            // 
            this.addTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addTaskButton.Location = new System.Drawing.Point(1039, 3);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(253, 28);
            this.addTaskButton.TabIndex = 4;
            this.addTaskButton.Text = "Dodaj Zadanie";
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // userListComboBox
            // 
            this.userListComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userListComboBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userListComboBox.FormattingEnabled = true;
            this.userListComboBox.Location = new System.Drawing.Point(780, 3);
            this.userListComboBox.Name = "userListComboBox";
            this.userListComboBox.Size = new System.Drawing.Size(253, 21);
            this.userListComboBox.TabIndex = 3;
            this.userListComboBox.Text = "Lista użytkowników";
            // 
            // backlogComboBox
            // 
            this.backlogComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backlogComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backlogComboBox.FormattingEnabled = true;
            this.backlogComboBox.Location = new System.Drawing.Point(521, 3);
            this.backlogComboBox.Name = "backlogComboBox";
            this.backlogComboBox.Size = new System.Drawing.Size(253, 23);
            this.backlogComboBox.TabIndex = 2;
            this.backlogComboBox.Text = "Backlog";
            // 
            // currentSprintButton
            // 
            this.currentSprintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentSprintButton.Location = new System.Drawing.Point(3, 3);
            this.currentSprintButton.Name = "currentSprintButton";
            this.currentSprintButton.Size = new System.Drawing.Size(253, 28);
            this.currentSprintButton.TabIndex = 0;
            this.currentSprintButton.Text = "Obecny Sprint";
            // 
            // historyComboBox
            // 
            this.historyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.historyComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.historyComboBox.FormattingEnabled = true;
            this.historyComboBox.Location = new System.Drawing.Point(262, 3);
            this.historyComboBox.Name = "historyComboBox";
            this.historyComboBox.Size = new System.Drawing.Size(253, 23);
            this.historyComboBox.TabIndex = 1;
            this.historyComboBox.Text = "History";
            // 
            // properiesComboBox
            // 
            this.properiesComboBox.FormattingEnabled = true;
            this.properiesComboBox.Items.AddRange(new object[] {
            "Projekty",
            "Dane Użytkownika",
            "Wyloguj"});
            this.properiesComboBox.Location = new System.Drawing.Point(1197, 35);
            this.properiesComboBox.Name = "properiesComboBox";
            this.properiesComboBox.Size = new System.Drawing.Size(121, 21);
            this.properiesComboBox.TabIndex = 2;
            // 
            // scrumBoardPanel
            // 
            this.scrumBoardPanel.Controls.Add(this.taskPanel);
            this.scrumBoardPanel.Location = new System.Drawing.Point(23, 166);
            this.scrumBoardPanel.Name = "scrumBoardPanel";
            this.scrumBoardPanel.Size = new System.Drawing.Size(1295, 477);
            this.scrumBoardPanel.TabIndex = 3;
            this.scrumBoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // taskPanel
            // 
            this.taskPanel.BackColor = System.Drawing.Color.White;
            this.taskPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taskPanel.Controls.Add(this.panel1);
            this.taskPanel.Controls.Add(this.taskNameTextBox);
            this.taskPanel.Controls.Add(this.userPhotoPictureBox);
            this.taskPanel.Controls.Add(this.taskTimeLabel);
            this.taskPanel.Controls.Add(this.taskDescriptionButton);
            this.taskPanel.Location = new System.Drawing.Point(21, 64);
            this.taskPanel.Name = "taskPanel";
            this.taskPanel.Size = new System.Drawing.Size(384, 79);
            this.taskPanel.TabIndex = 0;
            // 
            // taskNameTextBox
            // 
            this.taskNameTextBox.BackColor = System.Drawing.Color.White;
            this.taskNameTextBox.CustomBackground = true;
            this.taskNameTextBox.Location = new System.Drawing.Point(85, 3);
            this.taskNameTextBox.Multiline = true;
            this.taskNameTextBox.Name = "taskNameTextBox";
            this.taskNameTextBox.Size = new System.Drawing.Size(270, 68);
            this.taskNameTextBox.TabIndex = 5;
            this.taskNameTextBox.Text = "Nazwa tasku ktora moze okazac sie dluuuuuuga";
            // 
            // userPhotoPictureBox
            // 
            this.userPhotoPictureBox.Image = global::ScrumIt.Properties.Resources.image;
            this.userPhotoPictureBox.Location = new System.Drawing.Point(13, 3);
            this.userPhotoPictureBox.Name = "userPhotoPictureBox";
            this.userPhotoPictureBox.Size = new System.Drawing.Size(66, 68);
            this.userPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPhotoPictureBox.TabIndex = 4;
            this.userPhotoPictureBox.TabStop = false;
            // 
            // taskTimeLabel
            // 
            this.taskTimeLabel.AutoSize = true;
            this.taskTimeLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.taskTimeLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.taskTimeLabel.Location = new System.Drawing.Point(360, 56);
            this.taskTimeLabel.Name = "taskTimeLabel";
            this.taskTimeLabel.Size = new System.Drawing.Size(13, 15);
            this.taskTimeLabel.TabIndex = 3;
            this.taskTimeLabel.Text = "5";
            this.taskTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taskDescriptionButton
            // 
            this.taskDescriptionButton.Location = new System.Drawing.Point(361, 3);
            this.taskDescriptionButton.Name = "taskDescriptionButton";
            this.taskDescriptionButton.Size = new System.Drawing.Size(12, 22);
            this.taskDescriptionButton.TabIndex = 0;
            this.taskDescriptionButton.Text = "?";
            this.taskDescriptionButton.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(591, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(736, 32);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(35, 13);
            this.labelTest.TabIndex = 6;
            this.labelTest.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 79);
            this.panel1.TabIndex = 1;
            // 
            // CurrentSprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scrumBoardPanel);
            this.Controls.Add(this.properiesComboBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CurrentSprint";
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "currentSprint";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.scrumBoardPanel.ResumeLayout(false);
            this.taskPanel.ResumeLayout(false);
            this.taskPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton currentSprintButton;
        private System.Windows.Forms.ComboBox userListComboBox;
        private System.Windows.Forms.ComboBox backlogComboBox;
        private System.Windows.Forms.ComboBox historyComboBox;
        private System.Windows.Forms.ComboBox properiesComboBox;
        private System.Windows.Forms.Panel scrumBoardPanel;
        private MetroFramework.Controls.MetroButton addTaskButton;
        private System.Windows.Forms.Panel taskPanel;
        private System.Windows.Forms.PictureBox userPhotoPictureBox;
        private MetroFramework.Controls.MetroLabel taskTimeLabel;
        private MetroFramework.Controls.MetroButton taskDescriptionButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTest;
        private MetroFramework.Controls.MetroTextBox taskNameTextBox;
        private System.Windows.Forms.Panel panel1;
    }
}