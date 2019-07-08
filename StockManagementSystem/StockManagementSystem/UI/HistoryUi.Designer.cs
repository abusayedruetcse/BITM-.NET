namespace StockManagementSystem
{
    partial class HistoryUi
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
            this.historyDataGridView = new System.Windows.Forms.DataGridView();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Element = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stockOutLabel = new System.Windows.Forms.Label();
            this.stockInLabel = new System.Windows.Forms.Label();
            this.itemSetupLabel = new System.Windows.Forms.Label();
            this.companySetupLabel = new System.Windows.Forms.Label();
            this.categorySetupLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.tableRowNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAndTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // historyDataGridView
            // 
            this.historyDataGridView.AutoGenerateColumns = false;
            this.historyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.historyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SL,
            this.tableRowNoDataGridViewTextBoxColumn,
            this.Element,
            this.Email,
            this.dateAndTimeDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.tableNameDataGridViewTextBoxColumn});
            this.historyDataGridView.DataSource = this.historyBindingSource;
            this.historyDataGridView.Location = new System.Drawing.Point(261, 109);
            this.historyDataGridView.Name = "historyDataGridView";
            this.historyDataGridView.RowHeadersVisible = false;
            this.historyDataGridView.Size = new System.Drawing.Size(510, 277);
            this.historyDataGridView.TabIndex = 24;
            // 
            // SL
            // 
            this.SL.FillWeight = 50F;
            this.SL.HeaderText = "SI";
            this.SL.Name = "SL";
            // 
            // Element
            // 
            this.Element.DataPropertyName = "Element";
            this.Element.FillWeight = 93.27411F;
            this.Element.HeaderText = "Element";
            this.Element.Name = "Element";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.FillWeight = 120F;
            this.Email.HeaderText = "Email Address";
            this.Email.Name = "Email";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stockOutLabel);
            this.groupBox1.Controls.Add(this.stockInLabel);
            this.groupBox1.Controls.Add(this.itemSetupLabel);
            this.groupBox1.Controls.Add(this.companySetupLabel);
            this.groupBox1.Controls.Add(this.categorySetupLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 323);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Topics";
            // 
            // stockOutLabel
            // 
            this.stockOutLabel.AutoSize = true;
            this.stockOutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockOutLabel.Location = new System.Drawing.Point(27, 281);
            this.stockOutLabel.Name = "stockOutLabel";
            this.stockOutLabel.Size = new System.Drawing.Size(65, 16);
            this.stockOutLabel.TabIndex = 28;
            this.stockOutLabel.Text = "Stock Out";
            this.stockOutLabel.Click += new System.EventHandler(this.stockOutLabel_Click);
            // 
            // stockInLabel
            // 
            this.stockInLabel.AutoSize = true;
            this.stockInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockInLabel.Location = new System.Drawing.Point(27, 228);
            this.stockInLabel.Name = "stockInLabel";
            this.stockInLabel.Size = new System.Drawing.Size(55, 16);
            this.stockInLabel.TabIndex = 27;
            this.stockInLabel.Text = "Stock In";
            this.stockInLabel.Click += new System.EventHandler(this.stockInLabel_Click);
            // 
            // itemSetupLabel
            // 
            this.itemSetupLabel.AutoSize = true;
            this.itemSetupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemSetupLabel.Location = new System.Drawing.Point(27, 172);
            this.itemSetupLabel.Name = "itemSetupLabel";
            this.itemSetupLabel.Size = new System.Drawing.Size(71, 16);
            this.itemSetupLabel.TabIndex = 26;
            this.itemSetupLabel.Text = "Item Setup";
            this.itemSetupLabel.Click += new System.EventHandler(this.itemSetupLabel_Click);
            // 
            // companySetupLabel
            // 
            this.companySetupLabel.AutoSize = true;
            this.companySetupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companySetupLabel.Location = new System.Drawing.Point(27, 118);
            this.companySetupLabel.Name = "companySetupLabel";
            this.companySetupLabel.Size = new System.Drawing.Size(104, 16);
            this.companySetupLabel.TabIndex = 25;
            this.companySetupLabel.Text = "Company Setup";
            this.companySetupLabel.Click += new System.EventHandler(this.companySetupLabel_Click);
            // 
            // categorySetupLabel
            // 
            this.categorySetupLabel.AutoSize = true;
            this.categorySetupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorySetupLabel.Location = new System.Drawing.Point(27, 65);
            this.categorySetupLabel.Name = "categorySetupLabel";
            this.categorySetupLabel.Size = new System.Drawing.Size(101, 16);
            this.categorySetupLabel.TabIndex = 24;
            this.categorySetupLabel.Text = "Category Setup";
            this.categorySetupLabel.Click += new System.EventHandler(this.categorySetupLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "History";
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.Red;
            this.BackButton.Location = new System.Drawing.Point(-1, -1);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 27;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // tableRowNoDataGridViewTextBoxColumn
            // 
            this.tableRowNoDataGridViewTextBoxColumn.DataPropertyName = "TableRowNo";
            this.tableRowNoDataGridViewTextBoxColumn.FillWeight = 50F;
            this.tableRowNoDataGridViewTextBoxColumn.HeaderText = "ID";
            this.tableRowNoDataGridViewTextBoxColumn.Name = "tableRowNoDataGridViewTextBoxColumn";
            // 
            // dateAndTimeDataGridViewTextBoxColumn
            // 
            this.dateAndTimeDataGridViewTextBoxColumn.DataPropertyName = "DateAndTime";
            this.dateAndTimeDataGridViewTextBoxColumn.FillWeight = 93.27411F;
            this.dateAndTimeDataGridViewTextBoxColumn.HeaderText = "Date And Time";
            this.dateAndTimeDataGridViewTextBoxColumn.Name = "dateAndTimeDataGridViewTextBoxColumn";
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // tableNameDataGridViewTextBoxColumn
            // 
            this.tableNameDataGridViewTextBoxColumn.DataPropertyName = "TableName";
            this.tableNameDataGridViewTextBoxColumn.HeaderText = "TableName";
            this.tableNameDataGridViewTextBoxColumn.Name = "tableNameDataGridViewTextBoxColumn";
            this.tableNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // historyBindingSource
            // 
            this.historyBindingSource.DataSource = typeof(StockManagementSystem.Models.History);
            // 
            // HistoryUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 471);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.historyDataGridView);
            this.Name = "HistoryUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert and Update History";
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView historyDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label stockOutLabel;
        private System.Windows.Forms.Label stockInLabel;
        private System.Windows.Forms.Label itemSetupLabel;
        private System.Windows.Forms.Label companySetupLabel;
        private System.Windows.Forms.Label categorySetupLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.BindingSource historyBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableRowNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Element;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAndTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn;
    }
}