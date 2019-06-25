namespace StockManagementSystem
{
    partial class MenuUi
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
            this.categorySetupLabel = new System.Windows.Forms.Label();
            this.companySetupLabel = new System.Windows.Forms.Label();
            this.itemSetupLabel = new System.Windows.Forms.Label();
            this.stockInLabel = new System.Windows.Forms.Label();
            this.stockOutLabel = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this.viewLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // categorySetupLabel
            // 
            this.categorySetupLabel.AutoSize = true;
            this.categorySetupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorySetupLabel.Location = new System.Drawing.Point(177, 48);
            this.categorySetupLabel.Name = "categorySetupLabel";
            this.categorySetupLabel.Size = new System.Drawing.Size(101, 16);
            this.categorySetupLabel.TabIndex = 14;
            this.categorySetupLabel.Text = "Category Setup";
            this.categorySetupLabel.Click += new System.EventHandler(this.categorySetupLabel_Click);
            // 
            // companySetupLabel
            // 
            this.companySetupLabel.AutoSize = true;
            this.companySetupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companySetupLabel.Location = new System.Drawing.Point(177, 101);
            this.companySetupLabel.Name = "companySetupLabel";
            this.companySetupLabel.Size = new System.Drawing.Size(104, 16);
            this.companySetupLabel.TabIndex = 15;
            this.companySetupLabel.Text = "Company Setup";
            this.companySetupLabel.Click += new System.EventHandler(this.companySetupLabel_Click);
            // 
            // itemSetupLabel
            // 
            this.itemSetupLabel.AutoSize = true;
            this.itemSetupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemSetupLabel.Location = new System.Drawing.Point(177, 155);
            this.itemSetupLabel.Name = "itemSetupLabel";
            this.itemSetupLabel.Size = new System.Drawing.Size(71, 16);
            this.itemSetupLabel.TabIndex = 16;
            this.itemSetupLabel.Text = "Item Setup";
            this.itemSetupLabel.Click += new System.EventHandler(this.itemSetupLabel_Click);
            // 
            // stockInLabel
            // 
            this.stockInLabel.AutoSize = true;
            this.stockInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockInLabel.Location = new System.Drawing.Point(177, 211);
            this.stockInLabel.Name = "stockInLabel";
            this.stockInLabel.Size = new System.Drawing.Size(55, 16);
            this.stockInLabel.TabIndex = 17;
            this.stockInLabel.Text = "Stock In";
            this.stockInLabel.Click += new System.EventHandler(this.stockInLabel_Click);
            // 
            // stockOutLabel
            // 
            this.stockOutLabel.AutoSize = true;
            this.stockOutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockOutLabel.Location = new System.Drawing.Point(177, 264);
            this.stockOutLabel.Name = "stockOutLabel";
            this.stockOutLabel.Size = new System.Drawing.Size(65, 16);
            this.stockOutLabel.TabIndex = 18;
            this.stockOutLabel.Text = "Stock Out";
            this.stockOutLabel.Click += new System.EventHandler(this.stockOutLabel_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new System.Drawing.Point(177, 308);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(178, 16);
            this.searchLabel.TabIndex = 19;
            this.searchLabel.Text = "Search View Items Summary";
            this.searchLabel.Click += new System.EventHandler(this.searchLabel_Click);
            // 
            // viewLabel
            // 
            this.viewLabel.AutoSize = true;
            this.viewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLabel.Location = new System.Drawing.Point(177, 349);
            this.viewLabel.Name = "viewLabel";
            this.viewLabel.Size = new System.Drawing.Size(204, 16);
            this.viewLabel.TabIndex = 20;
            this.viewLabel.Text = "View Between Two Dates Report";
            this.viewLabel.Click += new System.EventHandler(this.viewLabel_Click);
            // 
            // MenuUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 470);
            this.Controls.Add(this.viewLabel);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.stockOutLabel);
            this.Controls.Add(this.stockInLabel);
            this.Controls.Add(this.itemSetupLabel);
            this.Controls.Add(this.companySetupLabel);
            this.Controls.Add(this.categorySetupLabel);
            this.Name = "MenuUi";
            this.Text = "Menu List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label categorySetupLabel;
        private System.Windows.Forms.Label companySetupLabel;
        private System.Windows.Forms.Label itemSetupLabel;
        private System.Windows.Forms.Label stockInLabel;
        private System.Windows.Forms.Label stockOutLabel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label viewLabel;
    }
}