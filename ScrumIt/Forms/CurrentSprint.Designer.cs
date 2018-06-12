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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.backlogButton = new System.Windows.Forms.Button();
            this.currentSprintButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.userListButton = new System.Windows.Forms.Button();
            this.properiesComboBox = new System.Windows.Forms.ComboBox();
            this.scrumBoardPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.historyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backlogMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.userListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertiesComboBox = new MetroFramework.Controls.MetroComboBox();
            this.progressBar = new System.Windows.Forms.Panel();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.toDoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.doingTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.doneTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Controls.Add(this.addTaskButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.backlogButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.currentSprintButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.historyButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.userListButton, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 74);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1313, 42);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // addTaskButton
            // 
            this.addTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addTaskButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addTaskButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addTaskButton.FlatAppearance.BorderSize = 0;
            this.addTaskButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.addTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTaskButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addTaskButton.ForeColor = System.Drawing.Color.White;
            this.addTaskButton.Location = new System.Drawing.Point(1051, 3);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(259, 36);
            this.addTaskButton.TabIndex = 9;
            this.addTaskButton.Text = "Dodaj zadanie";
            this.addTaskButton.UseVisualStyleBackColor = true;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // backlogButton
            // 
            this.backlogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backlogButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.backlogButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backlogButton.FlatAppearance.BorderSize = 0;
            this.backlogButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.backlogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backlogButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backlogButton.ForeColor = System.Drawing.Color.White;
            this.backlogButton.Location = new System.Drawing.Point(527, 3);
            this.backlogButton.Name = "backlogButton";
            this.backlogButton.Size = new System.Drawing.Size(256, 36);
            this.backlogButton.TabIndex = 12;
            this.backlogButton.Text = "Backlog";
            this.backlogButton.UseVisualStyleBackColor = true;
            this.backlogButton.Click += new System.EventHandler(this.backlogButton_Click);
            // 
            // currentSprintButton
            // 
            this.currentSprintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentSprintButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.currentSprintButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.currentSprintButton.FlatAppearance.BorderSize = 0;
            this.currentSprintButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.currentSprintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentSprintButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentSprintButton.ForeColor = System.Drawing.Color.White;
            this.currentSprintButton.Location = new System.Drawing.Point(3, 3);
            this.currentSprintButton.Name = "currentSprintButton";
            this.currentSprintButton.Size = new System.Drawing.Size(256, 36);
            this.currentSprintButton.TabIndex = 4;
            this.currentSprintButton.Text = "Obecny Sprint";
            this.currentSprintButton.UseVisualStyleBackColor = true;
            this.currentSprintButton.Click += new System.EventHandler(this.currentSprintButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.historyButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.historyButton.FlatAppearance.BorderSize = 0;
            this.historyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.historyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.historyButton.ForeColor = System.Drawing.Color.White;
            this.historyButton.Location = new System.Drawing.Point(265, 3);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(256, 36);
            this.historyButton.TabIndex = 10;
            this.historyButton.Text = "Inne Sprinty";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // userListButton
            // 
            this.userListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userListButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userListButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.userListButton.FlatAppearance.BorderSize = 0;
            this.userListButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.userListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userListButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userListButton.ForeColor = System.Drawing.Color.White;
            this.userListButton.Location = new System.Drawing.Point(789, 3);
            this.userListButton.Name = "userListButton";
            this.userListButton.Size = new System.Drawing.Size(256, 36);
            this.userListButton.TabIndex = 11;
            this.userListButton.Text = "Lista użytkowników";
            this.userListButton.UseVisualStyleBackColor = true;
            this.userListButton.Click += new System.EventHandler(this.userListButton_Click);
            // 
            // properiesComboBox
            // 
            this.properiesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.properiesComboBox.FormattingEnabled = true;
            this.properiesComboBox.Items.AddRange(new object[] {
            "Projekty",
            "Dane Użytkownika",
            "Wyloguj"});
            this.properiesComboBox.Location = new System.Drawing.Point(1422, 6);
            this.properiesComboBox.Name = "properiesComboBox";
            this.properiesComboBox.Size = new System.Drawing.Size(146, 21);
            this.properiesComboBox.TabIndex = 2;
            // 
            // scrumBoardPanel
            // 
            this.scrumBoardPanel.AutoScroll = true;
            this.scrumBoardPanel.Location = new System.Drawing.Point(27, 157);
            this.scrumBoardPanel.Name = "scrumBoardPanel";
            this.scrumBoardPanel.Size = new System.Drawing.Size(1313, 479);
            this.scrumBoardPanel.TabIndex = 3;
            this.scrumBoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // headerPanel
            // 
            this.headerPanel.Location = new System.Drawing.Point(26, 122);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1314, 35);
            this.headerPanel.TabIndex = 7;
            this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Location = new System.Drawing.Point(26, 632);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1314, 21);
            this.bottomPanel.TabIndex = 9;
            this.bottomPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bottomPanel_Paint);
            // 
            // historyMenuStrip
            // 
            this.historyMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.historyMenuStrip.MinimumSize = new System.Drawing.Size(295, 26);
            this.historyMenuStrip.Name = "historyMenuStrip";
            this.historyMenuStrip.Size = new System.Drawing.Size(295, 26);
            // 
            // backlogMenuStrip
            // 
            this.backlogMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backlogMenuStrip.MinimumSize = new System.Drawing.Size(295, 26);
            this.backlogMenuStrip.Name = "backlogMenuStrip";
            this.backlogMenuStrip.Size = new System.Drawing.Size(295, 26);
            // 
            // userListMenuStrip
            // 
            this.userListMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userListMenuStrip.MinimumSize = new System.Drawing.Size(295, 26);
            this.userListMenuStrip.Name = "userListMenuStrip";
            this.userListMenuStrip.Size = new System.Drawing.Size(295, 26);
            // 
            // propertiesComboBox
            // 
            this.propertiesComboBox.FormattingEnabled = true;
            this.propertiesComboBox.ItemHeight = 23;
            this.propertiesComboBox.Location = new System.Drawing.Point(1176, 4);
            this.propertiesComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.propertiesComboBox.Name = "propertiesComboBox";
            this.propertiesComboBox.Size = new System.Drawing.Size(150, 29);
            this.propertiesComboBox.TabIndex = 11;
            this.propertiesComboBox.SelectedIndexChanged += new System.EventHandler(this.propertiesComboBox_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(27, 672);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1313, 26);
            this.progressBar.TabIndex = 12;
            this.progressBar.Paint += new System.Windows.Forms.PaintEventHandler(this.progressBar_Paint);
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.BackColor = System.Drawing.Color.White;
            this.projectNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectNameTextBox.Location = new System.Drawing.Point(1078, 716);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.ReadOnly = true;
            this.projectNameTextBox.Size = new System.Drawing.Size(262, 22);
            this.projectNameTextBox.TabIndex = 13;
            this.projectNameTextBox.Text = "ProjectName";
            this.projectNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DateTextBox
            // 
            this.DateTextBox.BackColor = System.Drawing.Color.White;
            this.DateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DateTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateTextBox.Location = new System.Drawing.Point(794, 716);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.ReadOnly = true;
            this.DateTextBox.Size = new System.Drawing.Size(278, 22);
            this.DateTextBox.TabIndex = 14;
            this.DateTextBox.Text = "ProjectDate";
            this.DateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // maxTextBox
            // 
            this.maxTextBox.BackColor = System.Drawing.Color.White;
            this.maxTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.maxTextBox.Location = new System.Drawing.Point(189, 717);
            this.maxTextBox.MaxLength = 3;
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.ReadOnly = true;
            this.maxTextBox.Size = new System.Drawing.Size(30, 22);
            this.maxTextBox.TabIndex = 15;
            this.maxTextBox.Text = "000";
            this.maxTextBox.MouseEnter += new System.EventHandler(this.maxTextBox_MouseEnter);
            // 
            // toDoTextBox
            // 
            this.toDoTextBox.BackColor = System.Drawing.Color.White;
            this.toDoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toDoTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toDoTextBox.Location = new System.Drawing.Point(26, 716);
            this.toDoTextBox.MaxLength = 3;
            this.toDoTextBox.Name = "toDoTextBox";
            this.toDoTextBox.ReadOnly = true;
            this.toDoTextBox.Size = new System.Drawing.Size(32, 22);
            this.toDoTextBox.TabIndex = 16;
            this.toDoTextBox.Text = "000";
            this.toDoTextBox.MouseEnter += new System.EventHandler(this.toDoTextBox_MouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(55, 717);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "/";
            // 
            // doingTextBox
            // 
            this.doingTextBox.BackColor = System.Drawing.Color.White;
            this.doingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.doingTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.doingTextBox.Location = new System.Drawing.Point(77, 717);
            this.doingTextBox.MaxLength = 3;
            this.doingTextBox.Name = "doingTextBox";
            this.doingTextBox.ReadOnly = true;
            this.doingTextBox.Size = new System.Drawing.Size(32, 22);
            this.doingTextBox.TabIndex = 18;
            this.doingTextBox.Text = "000";
            this.doingTextBox.MouseEnter += new System.EventHandler(this.doingTextBox_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(106, 716);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "/";
            // 
            // doneTextBox
            // 
            this.doneTextBox.BackColor = System.Drawing.Color.White;
            this.doneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.doneTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.doneTextBox.Location = new System.Drawing.Point(128, 717);
            this.doneTextBox.MaxLength = 3;
            this.doneTextBox.Name = "doneTextBox";
            this.doneTextBox.ReadOnly = true;
            this.doneTextBox.Size = new System.Drawing.Size(32, 22);
            this.doneTextBox.TabIndex = 20;
            this.doneTextBox.Text = "000";
            this.doneTextBox.MouseEnter += new System.EventHandler(this.doneTextBox_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(166, 716);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 21);
            this.label3.TabIndex = 21;
            this.label3.Text = "z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(225, 716);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "punktów";
            // 
            // CurrentSprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.doneTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.doingTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDoTextBox);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.DateTextBox);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.propertiesComboBox);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.scrumBoardPanel);
            this.Controls.Add(this.properiesComboBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "CurrentSprint";
            this.Padding = new System.Windows.Forms.Padding(23, 60, 23, 20);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "ScrumIt!";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CurrentSprint_FormClosing);
            this.Load += new System.EventHandler(this.CurrentSprint_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox properiesComboBox;
        private System.Windows.Forms.Panel scrumBoardPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button currentSprintButton;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button backlogButton;
        private System.Windows.Forms.Button userListButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ContextMenuStrip historyMenuStrip;
        private System.Windows.Forms.ContextMenuStrip backlogMenuStrip;
        private System.Windows.Forms.ContextMenuStrip userListMenuStrip;
        private MetroFramework.Controls.MetroComboBox propertiesComboBox;
        private System.Windows.Forms.Panel progressBar;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.TextBox toDoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox doingTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox doneTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}