﻿namespace StockManagementSystem
{
    partial class FeatureList
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
            this.CategoryButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CategoryButton
            // 
            this.CategoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryButton.Location = new System.Drawing.Point(163, 70);
            this.CategoryButton.Name = "CategoryButton";
            this.CategoryButton.Size = new System.Drawing.Size(252, 30);
            this.CategoryButton.TabIndex = 7;
            this.CategoryButton.Text = "Category Setup";
            this.CategoryButton.UseVisualStyleBackColor = true;
            this.CategoryButton.Click += new System.EventHandler(this.CategoryButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(163, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Company Setup";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(163, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(252, 30);
            this.button2.TabIndex = 9;
            this.button2.Text = "Item Setup";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(163, 235);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(252, 30);
            this.button3.TabIndex = 10;
            this.button3.Text = "Stock In";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(163, 291);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(252, 30);
            this.button4.TabIndex = 11;
            this.button4.Text = "Stock Out";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(163, 344);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(252, 30);
            this.button5.TabIndex = 12;
            this.button5.Text = "Search & View Items Summary";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(163, 399);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(252, 30);
            this.button6.TabIndex = 13;
            this.button6.Text = "View Between Two Dates Report";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // FeatureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 470);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CategoryButton);
            this.Name = "FeatureList";
            this.Text = "Feature List";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CategoryButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}