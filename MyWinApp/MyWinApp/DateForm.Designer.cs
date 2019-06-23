namespace MyWinApp
{
    partial class DateForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.currentDateTextBox = new System.Windows.Forms.TextBox();
            this.currentDateLabel = new System.Windows.Forms.Label();
            this.GetDateButton = new System.Windows.Forms.Button();
            this.GetTimeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentTimeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateOfBirthTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.fromBirthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.toBirthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.displayDataGridView = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.displayDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(324, 179);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // currentDateTextBox
            // 
            this.currentDateTextBox.Location = new System.Drawing.Point(155, 48);
            this.currentDateTextBox.Name = "currentDateTextBox";
            this.currentDateTextBox.Size = new System.Drawing.Size(123, 20);
            this.currentDateTextBox.TabIndex = 1;
            // 
            // currentDateLabel
            // 
            this.currentDateLabel.AutoSize = true;
            this.currentDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDateLabel.Location = new System.Drawing.Point(49, 48);
            this.currentDateLabel.Name = "currentDateLabel";
            this.currentDateLabel.Size = new System.Drawing.Size(82, 16);
            this.currentDateLabel.TabIndex = 2;
            this.currentDateLabel.Text = "Current Date";
            // 
            // GetDateButton
            // 
            this.GetDateButton.Location = new System.Drawing.Point(324, 48);
            this.GetDateButton.Name = "GetDateButton";
            this.GetDateButton.Size = new System.Drawing.Size(75, 23);
            this.GetDateButton.TabIndex = 3;
            this.GetDateButton.Text = "Get Date";
            this.GetDateButton.UseVisualStyleBackColor = true;
            this.GetDateButton.Click += new System.EventHandler(this.GetDateButton_Click);
            // 
            // GetTimeButton
            // 
            this.GetTimeButton.Location = new System.Drawing.Point(324, 96);
            this.GetTimeButton.Name = "GetTimeButton";
            this.GetTimeButton.Size = new System.Drawing.Size(75, 23);
            this.GetTimeButton.TabIndex = 6;
            this.GetTimeButton.Text = "Get Time";
            this.GetTimeButton.UseVisualStyleBackColor = true;
            this.GetTimeButton.Click += new System.EventHandler(this.GetTimeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current Time";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new System.Drawing.Point(155, 96);
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new System.Drawing.Size(123, 20);
            this.currentTimeTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date of Birth";
            // 
            // dateOfBirthTimePicker
            // 
            this.dateOfBirthTimePicker.CustomFormat = "yyyy/ MM/ dd";
            this.dateOfBirthTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateOfBirthTimePicker.Location = new System.Drawing.Point(155, 144);
            this.dateOfBirthTimePicker.Name = "dateOfBirthTimePicker";
            this.dateOfBirthTimePicker.Size = new System.Drawing.Size(88, 20);
            this.dateOfBirthTimePicker.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(479, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Search in Between Two Birth Dates";
            // 
            // fromBirthDateTimePicker
            // 
            this.fromBirthDateTimePicker.CustomFormat = "yyyy/ MM/ dd";
            this.fromBirthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromBirthDateTimePicker.Location = new System.Drawing.Point(546, 80);
            this.fromBirthDateTimePicker.Name = "fromBirthDateTimePicker";
            this.fromBirthDateTimePicker.Size = new System.Drawing.Size(88, 20);
            this.fromBirthDateTimePicker.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(484, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "From";
            // 
            // toBirthDateTimePicker
            // 
            this.toBirthDateTimePicker.CustomFormat = "yyyy/ MM/ dd";
            this.toBirthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toBirthDateTimePicker.Location = new System.Drawing.Point(546, 116);
            this.toBirthDateTimePicker.Name = "toBirthDateTimePicker";
            this.toBirthDateTimePicker.Size = new System.Drawing.Size(88, 20);
            this.toBirthDateTimePicker.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(484, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "To";
            // 
            // displayDataGridView
            // 
            this.displayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateOfBirth});
            this.displayDataGridView.Location = new System.Drawing.Point(482, 207);
            this.displayDataGridView.Name = "displayDataGridView";
            this.displayDataGridView.Size = new System.Drawing.Size(152, 150);
            this.displayDataGridView.TabIndex = 14;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(559, 157);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 15;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.HeaderText = "Date Of Birth";
            this.DateOfBirth.Name = "DateOfBirth";
            // 
            // DateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.displayDataGridView);
            this.Controls.Add(this.toBirthDateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fromBirthDateTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateOfBirthTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GetTimeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentTimeTextBox);
            this.Controls.Add(this.GetDateButton);
            this.Controls.Add(this.currentDateLabel);
            this.Controls.Add(this.currentDateTextBox);
            this.Controls.Add(this.SaveButton);
            this.Name = "DateForm";
            this.Text = "DateForm";
            ((System.ComponentModel.ISupportInitialize)(this.displayDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox currentDateTextBox;
        private System.Windows.Forms.Label currentDateLabel;
        private System.Windows.Forms.Button GetDateButton;
        private System.Windows.Forms.Button GetTimeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentTimeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateOfBirthTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fromBirthDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker toBirthDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView displayDataGridView;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
    }
}