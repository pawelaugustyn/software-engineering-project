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
            this.userListComboBox = new System.Windows.Forms.ComboBox();
            this.backlogComboBox = new System.Windows.Forms.ComboBox();
            this.currentSprintButton = new MetroFramework.Controls.MetroButton();
            this.historyComboBox = new System.Windows.Forms.ComboBox();
            this.properiesComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addTaskButton = new MetroFramework.Controls.MetroButton();
            this.taskPanel = new System.Windows.Forms.Panel();
            this.metroUserControl1 = new MetroFramework.Controls.MetroUserControl();
            this.taskDescriptionButton = new MetroFramework.Controls.MetroButton();
            this.taskNameLabel = new MetroFramework.Controls.MetroLabel();
            this.taskPriorityLabel = new MetroFramework.Controls.MetroLabel();
            this.taskTimeLabel = new MetroFramework.Controls.MetroLabel();
            this.userPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.taskPanel);
            this.panel1.Location = new System.Drawing.Point(23, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1295, 403);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            // taskPanel
            // 
            this.taskPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taskPanel.Controls.Add(this.userPhotoPictureBox);
            this.taskPanel.Controls.Add(this.taskTimeLabel);
            this.taskPanel.Controls.Add(this.taskPriorityLabel);
            this.taskPanel.Controls.Add(this.taskNameLabel);
            this.taskPanel.Controls.Add(this.taskDescriptionButton);
            this.taskPanel.Location = new System.Drawing.Point(46, 37);
            this.taskPanel.Name = "taskPanel";
            this.taskPanel.Size = new System.Drawing.Size(183, 195);
            this.taskPanel.TabIndex = 0;
            // 
            // metroUserControl1
            // 
            this.metroUserControl1.Location = new System.Drawing.Point(827, 606);
            this.metroUserControl1.Name = "metroUserControl1";
            this.metroUserControl1.Size = new System.Drawing.Size(150, 150);
            this.metroUserControl1.TabIndex = 4;
            // 
            // taskDescriptionButton
            // 
            this.taskDescriptionButton.Location = new System.Drawing.Point(94, 157);
            this.taskDescriptionButton.Name = "taskDescriptionButton";
            this.taskDescriptionButton.Size = new System.Drawing.Size(75, 23);
            this.taskDescriptionButton.TabIndex = 0;
            this.taskDescriptionButton.Text = "Opis";
            this.taskDescriptionButton.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // taskNameLabel
            // 
            this.taskNameLabel.AutoSize = true;
            this.taskNameLabel.Location = new System.Drawing.Point(13, 13);
            this.taskNameLabel.Name = "taskNameLabel";
            this.taskNameLabel.Size = new System.Drawing.Size(34, 19);
            this.taskNameLabel.TabIndex = 1;
            this.taskNameLabel.Text = "Task";
            // 
            // taskPriorityLabel
            // 
            this.taskPriorityLabel.AutoSize = true;
            this.taskPriorityLabel.Location = new System.Drawing.Point(13, 44);
            this.taskPriorityLabel.Name = "taskPriorityLabel";
            this.taskPriorityLabel.Size = new System.Drawing.Size(51, 19);
            this.taskPriorityLabel.TabIndex = 2;
            this.taskPriorityLabel.Text = "Priority";
            // 
            // taskTimeLabel
            // 
            this.taskTimeLabel.AutoSize = true;
            this.taskTimeLabel.Location = new System.Drawing.Point(13, 77);
            this.taskTimeLabel.Name = "taskTimeLabel";
            this.taskTimeLabel.Size = new System.Drawing.Size(99, 19);
            this.taskTimeLabel.TabIndex = 3;
            this.taskTimeLabel.Text = "Estimeted Time";
            // 
            // userPhotoPictureBox
            // 
            this.userPhotoPictureBox.Image = global::ScrumIt.Properties.Resources.image;
            this.userPhotoPictureBox.Location = new System.Drawing.Point(12, 101);
            this.userPhotoPictureBox.Name = "userPhotoPictureBox";
            this.userPhotoPictureBox.Size = new System.Drawing.Size(76, 79);
            this.userPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPhotoPictureBox.TabIndex = 4;
            this.userPhotoPictureBox.TabStop = false;
            // 
            // CurrentSprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.metroUserControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.properiesComboBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CurrentSprint";
            this.Text = "currentSprint";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.taskPanel.ResumeLayout(false);
            this.taskPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton currentSprintButton;
        private System.Windows.Forms.ComboBox userListComboBox;
        private System.Windows.Forms.ComboBox backlogComboBox;
        private System.Windows.Forms.ComboBox historyComboBox;
        private System.Windows.Forms.ComboBox properiesComboBox;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton addTaskButton;
        private System.Windows.Forms.Panel taskPanel;
        private System.Windows.Forms.PictureBox userPhotoPictureBox;
        private MetroFramework.Controls.MetroLabel taskTimeLabel;
        private MetroFramework.Controls.MetroLabel taskPriorityLabel;
        private MetroFramework.Controls.MetroLabel taskNameLabel;
        private MetroFramework.Controls.MetroButton taskDescriptionButton;
        private MetroFramework.Controls.MetroUserControl metroUserControl1;
    }
}