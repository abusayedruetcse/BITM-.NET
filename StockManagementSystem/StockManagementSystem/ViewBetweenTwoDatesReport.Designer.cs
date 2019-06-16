namespace StockManagementSystem
{
    partial class ViewBetweenTwoDatesReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.soldRadioButton = new System.Windows.Forms.RadioButton();
            this.damagedRadioButton = new System.Windows.Forms.RadioButton();
            this.lostRadioButton = new System.Windows.Forms.RadioButton();
            this.SearchButton = new System.Windows.Forms.Button();
            this.viewReportDataGridView = new System.Windows.Forms.DataGridView();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.viewReportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date";
            // 
            // soldRadioButton
            // 
            this.soldRadioButton.AutoSize = true;
            this.soldRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soldRadioButton.Location = new System.Drawing.Point(125, 128);
            this.soldRadioButton.Name = "soldRadioButton";
            this.soldRadioButton.Size = new System.Drawing.Size(54, 20);
            this.soldRadioButton.TabIndex = 2;
            this.soldRadioButton.TabStop = true;
            this.soldRadioButton.Text = "Sold";
            this.soldRadioButton.UseVisualStyleBackColor = true;
            // 
            // damagedRadioButton
            // 
            this.damagedRadioButton.AutoSize = true;
            this.damagedRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damagedRadioButton.Location = new System.Drawing.Point(237, 128);
            this.damagedRadioButton.Name = "damagedRadioButton";
            this.damagedRadioButton.Size = new System.Drawing.Size(87, 20);
            this.damagedRadioButton.TabIndex = 3;
            this.damagedRadioButton.TabStop = true;
            this.damagedRadioButton.Text = "Damaged";
            this.damagedRadioButton.UseVisualStyleBackColor = true;
            // 
            // lostRadioButton
            // 
            this.lostRadioButton.AutoSize = true;
            this.lostRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lostRadioButton.Location = new System.Drawing.Point(352, 128);
            this.lostRadioButton.Name = "lostRadioButton";
            this.lostRadioButton.Size = new System.Drawing.Size(51, 20);
            this.lostRadioButton.TabIndex = 4;
            this.lostRadioButton.TabStop = true;
            this.lostRadioButton.Text = "Lost";
            this.lostRadioButton.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(352, 171);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // viewReportDataGridView
            // 
            this.viewReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewReportDataGridView.Location = new System.Drawing.Point(35, 248);
            this.viewReportDataGridView.Name = "viewReportDataGridView";
            this.viewReportDataGridView.Size = new System.Drawing.Size(511, 164);
            this.viewReportDataGridView.TabIndex = 6;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.CustomFormat = "dd/mm/yyyy";
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDateTimePicker.Location = new System.Drawing.Point(237, 37);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(94, 20);
            this.fromDateTimePicker.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "  /  /     ";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(237, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(94, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // ViewBetweenTwoDatesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 453);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.viewReportDataGridView);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.lostRadioButton);
            this.Controls.Add(this.damagedRadioButton);
            this.Controls.Add(this.soldRadioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewBetweenTwoDatesReport";
            this.Text = "View Between Two Dates Report";
            ((System.ComponentModel.ISupportInitialize)(this.viewReportDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton soldRadioButton;
        private System.Windows.Forms.RadioButton damagedRadioButton;
        private System.Windows.Forms.RadioButton lostRadioButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView viewReportDataGridView;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}