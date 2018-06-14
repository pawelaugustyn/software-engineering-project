namespace ScrumIt.Forms
{
    partial class AddTaskFromBacklog
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
            this.estimatedTimeLabel = new System.Windows.Forms.Label();
            this.taskPriorityLabel = new System.Windows.Forms.Label();
            this.taskDescriptionLabel = new System.Windows.Forms.Label();
            this.estimatedTimeTextBox = new System.Windows.Forms.TextBox();
            this.priorityTextBox = new System.Windows.Forms.TextBox();
            this.taskDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.taskNameTextBox = new System.Windows.Forms.TextBox();
            this.taskNameLabel = new System.Windows.Forms.Label();
            this.addTaskButton = new System.Windows.Forms.Button();
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
            this.addTaskTableLayoutPanel.Controls.Add(this.estimatedTimeLabel, 0, 3);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskPriorityLabel, 0, 2);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskDescriptionLabel, 0, 1);
            this.addTaskTableLayoutPanel.Controls.Add(this.estimatedTimeTextBox, 1, 3);
            this.addTaskTableLayoutPanel.Controls.Add(this.priorityTextBox, 1, 2);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskDescriptionTextBox, 1, 1);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskNameTextBox, 1, 0);
            this.addTaskTableLayoutPanel.Controls.Add(this.taskNameLabel, 0, 0);
            this.addTaskTableLayoutPanel.Location = new System.Drawing.Point(41, 71);
            this.addTaskTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTaskTableLayoutPanel.Name = "addTaskTableLayoutPanel";
            this.addTaskTableLayoutPanel.RowCount = 4;
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.addTaskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.addTaskTableLayoutPanel.Size = new System.Drawing.Size(600, 367);
            this.addTaskTableLayoutPanel.TabIndex = 1;
            // 
            // estimatedTimeLabel
            // 
            this.estimatedTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.estimatedTimeLabel.AutoSize = true;
            this.estimatedTimeLabel.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.estimatedTimeLabel.Location = new System.Drawing.Point(5, 329);
            this.estimatedTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.estimatedTimeLabel.Name = "estimatedTimeLabel";
            this.estimatedTimeLabel.Size = new System.Drawing.Size(216, 37);
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
            this.taskPriorityLabel.Location = new System.Drawing.Point(5, 292);
            this.taskPriorityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.taskPriorityLabel.Name = "taskPriorityLabel";
            this.taskPriorityLabel.Size = new System.Drawing.Size(216, 36);
            this.taskPriorityLabel.TabIndex = 12;
            this.taskPriorityLabel.Text = "Priorytet";
            this.taskPriorityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // taskDescriptionLabel
            // 
            this.taskDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskDescriptionLabel.AutoSize = true;
            this.taskDescriptionLabel.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskDescriptionLabel.Location = new System.Drawing.Point(5, 38);
            this.taskDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.taskDescriptionLabel.Name = "taskDescriptionLabel";
            this.taskDescriptionLabel.Size = new System.Drawing.Size(216, 253);
            this.taskDescriptionLabel.TabIndex = 11;
            this.taskDescriptionLabel.Text = "Opis Zadania";
            // 
            // estimatedTimeTextBox
            // 
            this.estimatedTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.estimatedTimeTextBox.Enabled = false;
            this.estimatedTimeTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.estimatedTimeTextBox.Location = new System.Drawing.Point(230, 333);
            this.estimatedTimeTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.estimatedTimeTextBox.Name = "estimatedTimeTextBox";
            this.estimatedTimeTextBox.Size = new System.Drawing.Size(364, 20);
            this.estimatedTimeTextBox.TabIndex = 8;
            // 
            // priorityTextBox
            // 
            this.priorityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.priorityTextBox.Enabled = false;
            this.priorityTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.priorityTextBox.Location = new System.Drawing.Point(230, 296);
            this.priorityTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.priorityTextBox.Name = "priorityTextBox";
            this.priorityTextBox.Size = new System.Drawing.Size(364, 20);
            this.priorityTextBox.TabIndex = 7;
            // 
            // taskDescriptionTextBox
            // 
            this.taskDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskDescriptionTextBox.Enabled = false;
            this.taskDescriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskDescriptionTextBox.Location = new System.Drawing.Point(230, 42);
            this.taskDescriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.taskDescriptionTextBox.Multiline = true;
            this.taskDescriptionTextBox.Name = "taskDescriptionTextBox";
            this.taskDescriptionTextBox.Size = new System.Drawing.Size(364, 208);
            this.taskDescriptionTextBox.TabIndex = 6;
            // 
            // taskNameTextBox
            // 
            this.taskNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskNameTextBox.Enabled = false;
            this.taskNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskNameTextBox.Location = new System.Drawing.Point(230, 5);
            this.taskNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.taskNameTextBox.Name = "taskNameTextBox";
            this.taskNameTextBox.Size = new System.Drawing.Size(364, 20);
            this.taskNameTextBox.TabIndex = 5;
            // 
            // taskNameLabel
            // 
            this.taskNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskNameLabel.AutoSize = true;
            this.taskNameLabel.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.taskNameLabel.Location = new System.Drawing.Point(5, 1);
            this.taskNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.taskNameLabel.Name = "taskNameLabel";
            this.taskNameLabel.Size = new System.Drawing.Size(216, 36);
            this.taskNameLabel.TabIndex = 10;
            this.taskNameLabel.Text = "Nazwa Zadania";
            this.taskNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addTaskButton
            // 
            this.addTaskButton.BackColor = System.Drawing.Color.Silver;
            this.addTaskButton.FlatAppearance.BorderSize = 0;
            this.addTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTaskButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addTaskButton.ForeColor = System.Drawing.Color.White;
            this.addTaskButton.Location = new System.Drawing.Point(41, 446);
            this.addTaskButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(600, 38);
            this.addTaskButton.TabIndex = 2;
            this.addTaskButton.Text = "Dodaj do sprintu";
            this.addTaskButton.UseVisualStyleBackColor = false;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // userListMenuStrip
            // 
            this.userListMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.userListMenuStrip.Name = "userListMenuStrip";
            this.userListMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // AddTaskFromBacklog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.addTaskTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTaskFromBacklog";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.Text = "ScrumIt!";
            this.Load += new System.EventHandler(this.AddTaskFromBacklog_Load);
            this.addTaskTableLayoutPanel.ResumeLayout(false);
            this.addTaskTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel addTaskTableLayoutPanel;
        private System.Windows.Forms.Label estimatedTimeLabel;
        private System.Windows.Forms.Label taskPriorityLabel;
        private System.Windows.Forms.Label taskDescriptionLabel;
        private System.Windows.Forms.TextBox estimatedTimeTextBox;
        private System.Windows.Forms.TextBox priorityTextBox;
        private System.Windows.Forms.TextBox taskDescriptionTextBox;
        private System.Windows.Forms.TextBox taskNameTextBox;
        private System.Windows.Forms.Label taskNameLabel;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.ContextMenuStrip userListMenuStrip;
    }
}