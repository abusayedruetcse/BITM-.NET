namespace CustomerAccountSystem
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
            this.entryLabel = new System.Windows.Forms.Label();
            this.transactionLabel = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // entryLabel
            // 
            this.entryLabel.AutoSize = true;
            this.entryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLabel.Location = new System.Drawing.Point(281, 112);
            this.entryLabel.Name = "entryLabel";
            this.entryLabel.Size = new System.Drawing.Size(201, 16);
            this.entryLabel.TabIndex = 0;
            this.entryLabel.Text = "Save Customer and Account Info";
            this.entryLabel.Click += new System.EventHandler(this.entryLabel_Click);
            // 
            // transactionLabel
            // 
            this.transactionLabel.AutoSize = true;
            this.transactionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionLabel.Location = new System.Drawing.Point(281, 152);
            this.transactionLabel.Name = "transactionLabel";
            this.transactionLabel.Size = new System.Drawing.Size(79, 16);
            this.transactionLabel.TabIndex = 1;
            this.transactionLabel.Text = "Transaction";
            this.transactionLabel.Click += new System.EventHandler(this.transactionLabel_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new System.Drawing.Point(281, 197);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(212, 16);
            this.searchLabel.TabIndex = 2;
            this.searchLabel.Text = "Search Customer and Account Info";
            this.searchLabel.Click += new System.EventHandler(this.searchLabel_Click);
            // 
            // IndexUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.transactionLabel);
            this.Controls.Add(this.entryLabel);
            this.Name = "IndexUi";
            this.Text = "Index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label entryLabel;
        private System.Windows.Forms.Label transactionLabel;
        private System.Windows.Forms.Label searchLabel;
    }
}

