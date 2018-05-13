namespace ScrumIt.Forms
{
    partial class EditTask
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
            this.addTaskTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.taskUserListLabel = new System.Windows.Forms.Label();
            this.estimatedTimeLabel = new System.Windows.Forms.Label();
            this.taskPriorityLabel = new System.Windows.Forms.Label();
            this.taskDescriptionLabel = new System.Windows.Forms.Label();
            this.estimatedTimeTextBox = new System.Windows.Forms.TextBox();
            this.priorityTextBox = new System.Windows.Forms.TextBox();
            this.taskDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.taskNameTextBox = new System.Windows.Forms.TextBox();
            this.showUsersButton = new System.Windows.Forms.Button();
            this.taskNameLabel = new System.Windows.Forms.Label();
            this.editTaskButton = new System.Windows.Forms.Button();
            this.userListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTaskTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addTaskTableLayoutPanel
            // 
            this.addTaskTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.addTaskTableLayoutPanel.ColumnCount = 2;
            this.addTaskTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.6392F));
            this.addTaskTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.3608F));
            this.addTaskTableLayoutPanel.Controls.Add(this.taskUserListLabel, 0, 4);
            this.addTaskTableLayoutPanel.Controls.Add(this.estimatedTimeLabel, 0, 3);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskPriorityLabel, 0, 2);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskDescriptionLabel, 0, 1);
            this.addTaskTableLayoutPanel.Controls.Add(this.estimatedTimeTextBox, 1, 3);
            this.addTaskTableLayoutPanel.Controls.Add(this.priorityTextBox, 1, 2);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskDescriptionTextBox, 1, 1);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskNameTextBox, 1, 0);
            this.addTaskTableLayoutPanel.Controls.Add(this.showUsersButton, 1, 4);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskNameLabel, 0, 0);
            this.addTaskTableLayoutPanel.Location = new System.Drawing.Point(31, 58);
            this.addTaskTableLayoutPanel.Name = "addTaskTableLayoutPanel";
            this.addTaskTableLayoutPanel.RowCount = 5;
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.addTaskTableLayoutPanel.Size = new System.Drawing.Size(450, 298);
            this.addTaskTableLayoutPanel.TabIndex = 2;
            // 
            // taskUserListLabel
            // 
            this.taskUserListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskUserListLabel.AutoSize = true;
            this.taskUserListLabel.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskUserListLabel.Location = new System.Drawing.Point(4, 267);
            this.taskUserListLabel.Name = "taskUserListLabel";
            this.taskUserListLabel.Size = new System.Drawing.Size(162, 30);
            this.taskUserListLabel.TabIndex = 14;
            this.taskUserListLabel.Text = "Przypisz do zadania";
            this.taskUserListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // estimatedTimeLabel
            // 
            this.estimatedTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.estimatedTimeLabel.AutoSize = true;
            this.estimatedTimeLabel.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.estimatedTimeLabel.Location = new System.Drawing.Point(4, 237);
            this.estimatedTimeLabel.Name = "estimatedTimeLabel";
            this.estimatedTimeLabel.Size = new System.Drawing.Size(162, 29);
            this.estimatedTimeLabel.TabIndex = 13;
            this.estimatedTimeLabel.Text = "Przewidziany czas";
            this.estimatedTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // taskPriorityLabel
            // 
            this.taskPriorityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskPriorityLabel.AutoSize = true;
            this.taskPriorityLabel.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskPriorityLabel.Location = new System.Drawing.Point(4, 207);
            this.taskPriorityLabel.Name = "taskPriorityLabel";
            this.taskPriorityLabel.Size = new System.Drawing.Size(162, 29);
            this.taskPriorityLabel.TabIndex = 12;
            this.taskPriorityLabel.Text = "Stopieñ skomplikowania";
            this.taskPriorityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // taskDescriptionLabel
            // 
            this.taskDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskDescriptionLabel.AutoSize = true;
            this.taskDescriptionLabel.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskDescriptionLabel.Location = new System.Drawing.Point(4, 31);
            this.taskDescriptionLabel.Name = "taskDescriptionLabel";
            this.taskDescriptionLabel.Size = new System.Drawing.Size(162, 175);
            this.taskDescriptionLabel.TabIndex = 11;
            this.taskDescriptionLabel.Text = "Opis Zadania";
            // 
            // estimatedTimeTextBox
            // 
            this.estimatedTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.estimatedTimeTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.estimatedTimeTextBox.Location = new System.Drawing.Point(173, 240);
            this.estimatedTimeTextBox.Name = "estimatedTimeTextBox";
            this.estimatedTimeTextBox.Size = new System.Drawing.Size(273, 16);
            this.estimatedTimeTextBox.TabIndex = 8;
            this.estimatedTimeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.estimatedTimeTextBox_KeyPress);
            // 
            // priorityTextBox
            // 
            this.priorityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.priorityTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.priorityTextBox.Location = new System.Drawing.Point(173, 210);
            this.priorityTextBox.Name = "priorityTextBox";
            this.priorityTextBox.Size = new System.Drawing.Size(273, 16);
            this.priorityTextBox.TabIndex = 7;
            this.priorityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priorityTextBox_KeyPress);
            // 
            // taskDescriptionTextBox
            // 
            this.taskDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskDescriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskDescriptionTextBox.Location = new System.Drawing.Point(173, 34);
            this.taskDescriptionTextBox.Multiline = true;
            this.taskDescriptionTextBox.Name = "taskDescriptionTextBox";
            this.taskDescriptionTextBox.Size = new System.Drawing.Size(273, 169);
            this.taskDescriptionTextBox.TabIndex = 6;
            // 
            // taskNameTextBox
            // 
            this.taskNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskNameTextBox.Location = new System.Drawing.Point(173, 4);
            this.taskNameTextBox.Name = "taskNameTextBox";
            this.taskNameTextBox.Size = new System.Drawing.Size(273, 16);
            this.taskNameTextBox.TabIndex = 5;
            // 
            // showUsersButton
            // 
            this.showUsersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showUsersButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.showUsersButton.FlatAppearance.BorderSize = 0;
            this.showUsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showUsersButton.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showUsersButton.Location = new System.Drawing.Point(173, 270);
            this.showUsersButton.Name = "showUsersButton";
            this.showUsersButton.Size = new System.Drawing.Size(273, 24);
            this.showUsersButton.TabIndex = 9;
            this.showUsersButton.Text = "Lista Uzytkowikow";
            this.showUsersButton.UseVisualStyleBackColor = true;
            this.showUsersButton.Click += new System.EventHandler(this.showUsersButton_Click);
            // 
            // taskNameLabel
            // 
            this.taskNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskNameLabel.AutoSize = true;
            this.taskNameLabel.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskNameLabel.Location = new System.Drawing.Point(4, 1);
            this.taskNameLabel.Name = "taskNameLabel";
            this.taskNameLabel.Size = new System.Drawing.Size(162, 29);
            this.taskNameLabel.TabIndex = 10;
            this.taskNameLabel.Text = "Nazwa Zadania";
            this.taskNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editTaskButton
            // 
            this.editTaskButton.FlatAppearance.BorderSize = 0;
            this.editTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editTaskButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editTaskButton.ForeColor = System.Drawing.Color.White;
            this.editTaskButton.Location = new System.Drawing.Point(31, 362);
            this.editTaskButton.Name = "editTaskButton";
            this.editTaskButton.Size = new System.Drawing.Size(450, 31);
            this.editTaskButton.TabIndex = 3;
            this.editTaskButton.Text = "Uaktualnij";
            this.editTaskButton.UseVisualStyleBackColor = true;
            this.editTaskButton.Click += new System.EventHandler(this.editTaskButton_Click);
            // 
            // userListMenuStrip
            // 
            this.userListMenuStrip.Name = "userListMenuStrip";
            this.userListMenuStrip.ShowCheckMargin = true;
            this.userListMenuStrip.Size = new System.Drawing.Size(83, 4);
            this.userListMenuStrip.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.userListMenuStrip_Closing);
            // 
            // EditTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 415);
            this.Controls.Add(this.editTaskButton);
            this.Controls.Add(this.addTaskTableLayoutPanel);
            this.Name = "EditTask";
            this.Text = "ScrumIt!";
            this.Load += new System.EventHandler(this.EditTask_Load);
            this.addTaskTableLayoutPanel.ResumeLayout(false);
            this.addTaskTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel addTaskTableLayoutPanel;
        private System.Windows.Forms.Label taskUserListLabel;
        private System.Windows.Forms.Label estimatedTimeLabel;
        private System.Windows.Forms.Label taskPriorityLabel;
        private System.Windows.Forms.Label taskDescriptionLabel;
        private System.Windows.Forms.TextBox estimatedTimeTextBox;
        private System.Windows.Forms.TextBox priorityTextBox;
        private System.Windows.Forms.TextBox taskDescriptionTextBox;
        private System.Windows.Forms.TextBox taskNameTextBox;
        private System.Windows.Forms.Button showUsersButton;
        private System.Windows.Forms.Label taskNameLabel;
        private System.Windows.Forms.Button editTaskButton;
        private System.Windows.Forms.ContextMenuStrip userListMenuStrip;
    }
}