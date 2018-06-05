namespace ScrumIt.Forms
{
    partial class AddSprint
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
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startSprintDateTextBox = new System.Windows.Forms.TextBox();
            this.endSprintDateTextBox = new System.Windows.Forms.TextBox();
            this.addSprintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startDateLabel
            // 
            this.startDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startDateLabel.Location = new System.Drawing.Point(23, 60);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(180, 21);
            this.startDateLabel.TabIndex = 1;
            this.startDateLabel.Text = "Data rozpoczęcia sprintu";
            this.startDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // endDateLabel
            // 
            this.endDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endDateLabel.Location = new System.Drawing.Point(23, 90);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(183, 21);
            this.endDateLabel.TabIndex = 2;
            this.endDateLabel.Text = "Data zakończenia sprintu";
            this.endDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startSprintDateTextBox
            // 
            this.startSprintDateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startSprintDateTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startSprintDateTextBox.Location = new System.Drawing.Point(209, 57);
            this.startSprintDateTextBox.Name = "startSprintDateTextBox";
            this.startSprintDateTextBox.Size = new System.Drawing.Size(122, 29);
            this.startSprintDateTextBox.TabIndex = 3;
            this.startSprintDateTextBox.Text = "rrrr-mm-dd";
            // 
            // endSprintDateTextBox
            // 
            this.endSprintDateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endSprintDateTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endSprintDateTextBox.Location = new System.Drawing.Point(209, 92);
            this.endSprintDateTextBox.Name = "endSprintDateTextBox";
            this.endSprintDateTextBox.Size = new System.Drawing.Size(122, 29);
            this.endSprintDateTextBox.TabIndex = 4;
            this.endSprintDateTextBox.Text = "rrrr-mm-dd";
            // 
            // addSprintButton
            // 
            this.addSprintButton.BackColor = System.Drawing.Color.Silver;
            this.addSprintButton.FlatAppearance.BorderSize = 0;
            this.addSprintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSprintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addSprintButton.ForeColor = System.Drawing.Color.White;
            this.addSprintButton.Location = new System.Drawing.Point(23, 127);
            this.addSprintButton.Name = "addSprintButton";
            this.addSprintButton.Size = new System.Drawing.Size(308, 31);
            this.addSprintButton.TabIndex = 5;
            this.addSprintButton.Text = "Dodaj";
            this.addSprintButton.UseVisualStyleBackColor = false;
            this.addSprintButton.Click += new System.EventHandler(this.addSprintButton_Click);
            // 
            // AddSprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 179);
            this.Controls.Add(this.addSprintButton);
            this.Controls.Add(this.endSprintDateTextBox);
            this.Controls.Add(this.startSprintDateTextBox);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.startDateLabel);
            this.Name = "AddSprint";
            this.Text = "ScrumIt!";
            this.Load += new System.EventHandler(this.AddSprint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.TextBox startSprintDateTextBox;
        private System.Windows.Forms.TextBox endSprintDateTextBox;
        private System.Windows.Forms.Button addSprintButton;
    }
}