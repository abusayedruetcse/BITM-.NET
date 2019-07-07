namespace StockManagementSystem
{
    partial class SystemSetupUi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.serverNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.oldDBRadioButton = new System.Windows.Forms.RadioButton();
            this.newDBRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newDBRadioButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.oldDBRadioButton);
            this.groupBox1.Controls.Add(this.messageLabel);
            this.groupBox1.Controls.Add(this.runButton);
            this.groupBox1.Controls.Add(this.databaseNameTextBox);
            this.groupBox1.Controls.Add(this.serverNameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(93, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 262);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock Management System Installation Environment";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.ForeColor = System.Drawing.Color.Red;
            this.messageLabel.Location = new System.Drawing.Point(23, 141);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 16);
            this.messageLabel.TabIndex = 5;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(278, 212);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 28);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Location = new System.Drawing.Point(139, 164);
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.Size = new System.Drawing.Size(232, 22);
            this.databaseNameTextBox.TabIndex = 3;
            // 
            // serverNameTextBox
            // 
            this.serverNameTextBox.Location = new System.Drawing.Point(139, 43);
            this.serverNameTextBox.Name = "serverNameTextBox";
            this.serverNameTextBox.Size = new System.Drawing.Size(232, 22);
            this.serverNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database Name";
            // 
            // oldDBRadioButton
            // 
            this.oldDBRadioButton.AutoSize = true;
            this.oldDBRadioButton.Location = new System.Drawing.Point(139, 110);
            this.oldDBRadioButton.Name = "oldDBRadioButton";
            this.oldDBRadioButton.Size = new System.Drawing.Size(110, 20);
            this.oldDBRadioButton.TabIndex = 6;
            this.oldDBRadioButton.Text = "Old Database";
            this.oldDBRadioButton.UseVisualStyleBackColor = true;
            // 
            // newDBRadioButton
            // 
            this.newDBRadioButton.AutoSize = true;
            this.newDBRadioButton.Location = new System.Drawing.Point(255, 110);
            this.newDBRadioButton.Name = "newDBRadioButton";
            this.newDBRadioButton.Size = new System.Drawing.Size(116, 20);
            this.newDBRadioButton.TabIndex = 7;
            this.newDBRadioButton.Text = "New Database";
            this.newDBRadioButton.UseVisualStyleBackColor = true;
            // 
            // SystemSetupUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 406);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SystemSetupUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Management System Setup Environment";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox databaseNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton newDBRadioButton;
        private System.Windows.Forms.RadioButton oldDBRadioButton;
    }
}