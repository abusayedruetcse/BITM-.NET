namespace StockManagementSystem
{
    partial class SearchUi
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
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyComboBox = new System.Windows.Forms.ComboBox();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.searchViewSummaryDataGridView = new System.Windows.Forms.DataGridView();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availableQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reorderLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PDFButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchViewSummaryDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DataSource = this.categoryBindingSource;
            this.categoryComboBox.DisplayMember = "Name";
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(263, 66);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(200, 21);
            this.categoryComboBox.TabIndex = 11;
            this.categoryComboBox.ValueMember = "ID";
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(StockManagementSystem.Models.Category);
            // 
            // companyComboBox
            // 
            this.companyComboBox.DataSource = this.companyBindingSource;
            this.companyComboBox.DisplayMember = "Name";
            this.companyComboBox.FormattingEnabled = true;
            this.companyComboBox.Location = new System.Drawing.Point(263, 27);
            this.companyComboBox.Name = "companyComboBox";
            this.companyComboBox.Size = new System.Drawing.Size(200, 21);
            this.companyComboBox.TabIndex = 10;
            this.companyComboBox.ValueMember = "ID";
            this.companyComboBox.SelectedIndexChanged += new System.EventHandler(this.companyComboBox_SelectedIndexChanged);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(StockManagementSystem.Models.Company);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Company";
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(387, 112);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 12;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // searchViewSummaryDataGridView
            // 
            this.searchViewSummaryDataGridView.AutoGenerateColumns = false;
            this.searchViewSummaryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchViewSummaryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchViewSummaryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SL,
            this.nameDataGridViewTextBoxColumn,
            this.CompanyName,
            this.CategoryName,
            this.availableQuantityDataGridViewTextBoxColumn,
            this.reorderLevelDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn,
            this.categoryIDDataGridViewTextBoxColumn,
            this.companyIDDataGridViewTextBoxColumn});
            this.searchViewSummaryDataGridView.DataSource = this.itemBindingSource;
            this.searchViewSummaryDataGridView.Location = new System.Drawing.Point(42, 188);
            this.searchViewSummaryDataGridView.Name = "searchViewSummaryDataGridView";
            this.searchViewSummaryDataGridView.RowHeadersVisible = false;
            this.searchViewSummaryDataGridView.Size = new System.Drawing.Size(539, 207);
            this.searchViewSummaryDataGridView.TabIndex = 13;
            // 
            // SL
            // 
            this.SL.DataPropertyName = "SL";
            this.SL.HeaderText = "SI";
            this.SL.Name = "SL";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Item";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "Company";
            this.CompanyName.HeaderText = "Company";
            this.CompanyName.Name = "CompanyName";
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "Category";
            this.CategoryName.HeaderText = "Category";
            this.CategoryName.Name = "CategoryName";
            // 
            // availableQuantityDataGridViewTextBoxColumn
            // 
            this.availableQuantityDataGridViewTextBoxColumn.DataPropertyName = "AvailableQuantity";
            this.availableQuantityDataGridViewTextBoxColumn.HeaderText = "Available Quantity";
            this.availableQuantityDataGridViewTextBoxColumn.Name = "availableQuantityDataGridViewTextBoxColumn";
            // 
            // reorderLevelDataGridViewTextBoxColumn
            // 
            this.reorderLevelDataGridViewTextBoxColumn.DataPropertyName = "ReorderLevel";
            this.reorderLevelDataGridViewTextBoxColumn.HeaderText = "Reorder Level";
            this.reorderLevelDataGridViewTextBoxColumn.Name = "reorderLevelDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // categoryIDDataGridViewTextBoxColumn
            // 
            this.categoryIDDataGridViewTextBoxColumn.DataPropertyName = "CategoryID";
            this.categoryIDDataGridViewTextBoxColumn.HeaderText = "CategoryID";
            this.categoryIDDataGridViewTextBoxColumn.Name = "categoryIDDataGridViewTextBoxColumn";
            this.categoryIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // companyIDDataGridViewTextBoxColumn
            // 
            this.companyIDDataGridViewTextBoxColumn.DataPropertyName = "CompanyID";
            this.companyIDDataGridViewTextBoxColumn.HeaderText = "CompanyID";
            this.companyIDDataGridViewTextBoxColumn.Name = "companyIDDataGridViewTextBoxColumn";
            this.companyIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(StockManagementSystem.Models.Item);
            // 
            // PDFButton
            // 
            this.PDFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PDFButton.Location = new System.Drawing.Point(505, 402);
            this.PDFButton.Name = "PDFButton";
            this.PDFButton.Size = new System.Drawing.Size(75, 23);
            this.PDFButton.TabIndex = 14;
            this.PDFButton.Text = "PDF";
            this.PDFButton.UseVisualStyleBackColor = true;
            this.PDFButton.Click += new System.EventHandler(this.PDFButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.Red;
            this.BackButton.Location = new System.Drawing.Point(-1, -1);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 15;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SearchUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 471);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.PDFButton);
            this.Controls.Add(this.searchViewSummaryDataGridView);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.companyComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SearchUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search and View Items Summary";
            this.Load += new System.EventHandler(this.SearchUi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchViewSummaryDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox companyComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView searchViewSummaryDataGridView;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.Button PDFButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn availableQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reorderLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button BackButton;
    }
}