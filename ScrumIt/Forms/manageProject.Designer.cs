﻿namespace ScrumIt.Forms
{
    partial class ManageProject
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
            this.changeNameButton = new System.Windows.Forms.Label();
            this.changeCollorButton = new System.Windows.Forms.Label();
            this.changeNameTextBox = new System.Windows.Forms.TextBox();
            this.changeColorTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.changeColorTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.changeNameButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.changeCollorButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.changeNameTextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 105);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // changeNameButton
            // 
            this.changeNameButton.AutoSize = true;
            this.changeNameButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeNameButton.Location = new System.Drawing.Point(3, 0);
            this.changeNameButton.Name = "changeNameButton";
            this.changeNameButton.Size = new System.Drawing.Size(164, 21);
            this.changeNameButton.TabIndex = 0;
            this.changeNameButton.Text = "Zmień nazwę projektu";
            // 
            // changeCollorButton
            // 
            this.changeCollorButton.AutoSize = true;
            this.changeCollorButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeCollorButton.Location = new System.Drawing.Point(3, 34);
            this.changeCollorButton.Name = "changeCollorButton";
            this.changeCollorButton.Size = new System.Drawing.Size(156, 21);
            this.changeCollorButton.TabIndex = 1;
            this.changeCollorButton.Text = "Zmień kolor projektu";
            // 
            // changeNameTextBox
            // 
            this.changeNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeNameTextBox.Location = new System.Drawing.Point(205, 3);
            this.changeNameTextBox.Name = "changeNameTextBox";
            this.changeNameTextBox.Size = new System.Drawing.Size(197, 29);
            this.changeNameTextBox.TabIndex = 2;
            // 
            // changeColorTextBox
            // 
            this.changeColorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeColorTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeColorTextBox.Location = new System.Drawing.Point(205, 37);
            this.changeColorTextBox.Name = "changeColorTextBox";
            this.changeColorTextBox.Size = new System.Drawing.Size(197, 29);
            this.changeColorTextBox.TabIndex = 3;
            // 
            // ManageProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageProject";
            this.Resizable = false;
            this.Text = "ScrumIt!";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox changeColorTextBox;
        private System.Windows.Forms.Label changeNameButton;
        private System.Windows.Forms.Label changeCollorButton;
        private System.Windows.Forms.TextBox changeNameTextBox;
    }
}