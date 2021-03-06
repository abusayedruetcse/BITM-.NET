﻿namespace MyWinApp
{
    partial class ArrayExercise
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
            this.AddButton = new System.Windows.Forms.Button();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.showRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ReverseButton = new System.Windows.Forms.Button();
            this.SumButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.DuplicateButton = new System.Windows.Forms.Button();
            this.UniqueButton = new System.Windows.Forms.Button();
            this.MaxMinButton = new System.Windows.Forms.Button();
            this.OddEvenButton = new System.Windows.Forms.Button();
            this.AscDescButton = new System.Windows.Forms.Button();
            this.InsertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(286, 71);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(113, 71);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(154, 20);
            this.numberTextBox.TabIndex = 1;
            // 
            // showRichTextBox
            // 
            this.showRichTextBox.Location = new System.Drawing.Point(113, 108);
            this.showRichTextBox.Name = "showRichTextBox";
            this.showRichTextBox.Size = new System.Drawing.Size(248, 287);
            this.showRichTextBox.TabIndex = 2;
            this.showRichTextBox.Text = "";
            // 
            // ReverseButton
            // 
            this.ReverseButton.Location = new System.Drawing.Point(385, 108);
            this.ReverseButton.Name = "ReverseButton";
            this.ReverseButton.Size = new System.Drawing.Size(75, 23);
            this.ReverseButton.TabIndex = 3;
            this.ReverseButton.Text = "Reverse";
            this.ReverseButton.UseVisualStyleBackColor = true;
            this.ReverseButton.Click += new System.EventHandler(this.ReverseButton_Click);
            // 
            // SumButton
            // 
            this.SumButton.Location = new System.Drawing.Point(385, 138);
            this.SumButton.Name = "SumButton";
            this.SumButton.Size = new System.Drawing.Size(75, 23);
            this.SumButton.TabIndex = 4;
            this.SumButton.Text = "Sum";
            this.SumButton.UseVisualStyleBackColor = true;
            this.SumButton.Click += new System.EventHandler(this.SumButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(385, 168);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(75, 23);
            this.CopyButton.TabIndex = 5;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // DuplicateButton
            // 
            this.DuplicateButton.Location = new System.Drawing.Point(385, 198);
            this.DuplicateButton.Name = "DuplicateButton";
            this.DuplicateButton.Size = new System.Drawing.Size(75, 23);
            this.DuplicateButton.TabIndex = 6;
            this.DuplicateButton.Text = "Duplicate";
            this.DuplicateButton.UseVisualStyleBackColor = true;
            this.DuplicateButton.Click += new System.EventHandler(this.DuplicateButton_Click);
            // 
            // UniqueButton
            // 
            this.UniqueButton.Location = new System.Drawing.Point(385, 228);
            this.UniqueButton.Name = "UniqueButton";
            this.UniqueButton.Size = new System.Drawing.Size(75, 23);
            this.UniqueButton.TabIndex = 7;
            this.UniqueButton.Text = "Unique";
            this.UniqueButton.UseVisualStyleBackColor = true;
            this.UniqueButton.Click += new System.EventHandler(this.UniqueButton_Click);
            // 
            // MaxMinButton
            // 
            this.MaxMinButton.Location = new System.Drawing.Point(385, 258);
            this.MaxMinButton.Name = "MaxMinButton";
            this.MaxMinButton.Size = new System.Drawing.Size(75, 23);
            this.MaxMinButton.TabIndex = 8;
            this.MaxMinButton.Text = "MaxMin";
            this.MaxMinButton.UseVisualStyleBackColor = true;
            this.MaxMinButton.Click += new System.EventHandler(this.MaxMinButton_Click);
            // 
            // OddEvenButton
            // 
            this.OddEvenButton.Location = new System.Drawing.Point(385, 288);
            this.OddEvenButton.Name = "OddEvenButton";
            this.OddEvenButton.Size = new System.Drawing.Size(75, 23);
            this.OddEvenButton.TabIndex = 9;
            this.OddEvenButton.Text = "OddEven";
            this.OddEvenButton.UseVisualStyleBackColor = true;
            this.OddEvenButton.Click += new System.EventHandler(this.OddEvenButton_Click);
            // 
            // AscDescButton
            // 
            this.AscDescButton.Location = new System.Drawing.Point(385, 318);
            this.AscDescButton.Name = "AscDescButton";
            this.AscDescButton.Size = new System.Drawing.Size(75, 23);
            this.AscDescButton.TabIndex = 10;
            this.AscDescButton.Text = "AscDesc";
            this.AscDescButton.UseVisualStyleBackColor = true;
            this.AscDescButton.Click += new System.EventHandler(this.AscDescButton_Click);
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(385, 348);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 11;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // ArrayExercise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.AscDescButton);
            this.Controls.Add(this.OddEvenButton);
            this.Controls.Add(this.MaxMinButton);
            this.Controls.Add(this.UniqueButton);
            this.Controls.Add(this.DuplicateButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.SumButton);
            this.Controls.Add(this.ReverseButton);
            this.Controls.Add(this.showRichTextBox);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.AddButton);
            this.Name = "ArrayExercise";
            this.Text = "StoreArray";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.RichTextBox showRichTextBox;
        private System.Windows.Forms.Button ReverseButton;
        private System.Windows.Forms.Button SumButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button DuplicateButton;
        private System.Windows.Forms.Button UniqueButton;
        private System.Windows.Forms.Button MaxMinButton;
        private System.Windows.Forms.Button OddEvenButton;
        private System.Windows.Forms.Button AscDescButton;
        private System.Windows.Forms.Button InsertButton;
    }
}