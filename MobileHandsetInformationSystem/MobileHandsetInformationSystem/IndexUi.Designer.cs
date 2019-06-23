namespace MobileHandsetInformationSystem
{
    partial class IndexUi
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
            this.saveLabel = new System.Windows.Forms.Label();
            this.searchRangeLabel = new System.Windows.Forms.Label();
            this.searchIMEILabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveLabel
            // 
            this.saveLabel.AutoSize = true;
            this.saveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLabel.Location = new System.Drawing.Point(179, 125);
            this.saveLabel.Name = "saveLabel";
            this.saveLabel.Size = new System.Drawing.Size(206, 16);
            this.saveLabel.TabIndex = 1;
            this.saveLabel.Text = "Save Mobile Handset Information";
            this.saveLabel.Click += new System.EventHandler(this.saveLabel_Click);
            // 
            // searchRangeLabel
            // 
            this.searchRangeLabel.AutoSize = true;
            this.searchRangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchRangeLabel.Location = new System.Drawing.Point(179, 172);
            this.searchRangeLabel.Name = "searchRangeLabel";
            this.searchRangeLabel.Size = new System.Drawing.Size(245, 16);
            this.searchRangeLabel.TabIndex = 2;
            this.searchRangeLabel.Text = "Search Mobile Handset by Price Range";
            this.searchRangeLabel.Click += new System.EventHandler(this.searchRangeLabel_Click);
            // 
            // searchIMEILabel
            // 
            this.searchIMEILabel.AutoSize = true;
            this.searchIMEILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchIMEILabel.Location = new System.Drawing.Point(179, 225);
            this.searchIMEILabel.Name = "searchIMEILabel";
            this.searchIMEILabel.Size = new System.Drawing.Size(196, 16);
            this.searchIMEILabel.TabIndex = 3;
            this.searchIMEILabel.Text = "Search Mobile Handset by IMEI";
            this.searchIMEILabel.Click += new System.EventHandler(this.searchIMEILabel_Click);
            // 
            // IndexUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchIMEILabel);
            this.Controls.Add(this.searchRangeLabel);
            this.Controls.Add(this.saveLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "IndexUi";
            this.Text = "Index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label saveLabel;
        private System.Windows.Forms.Label searchRangeLabel;
        private System.Windows.Forms.Label searchIMEILabel;
    }
}

