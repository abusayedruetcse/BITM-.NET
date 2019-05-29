namespace MyWinApp
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
            // ArrayExercise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}