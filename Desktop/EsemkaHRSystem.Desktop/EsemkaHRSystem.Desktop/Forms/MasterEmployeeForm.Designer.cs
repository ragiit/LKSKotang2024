namespace EsemkaHRSystem.Desktop
{
    partial class MasterEmployeeForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbEmployeeStatus = new System.Windows.Forms.ComboBox();
            this.tbSalary = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PhotoGrid = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Master Employee";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PhotoGrid,
            this.EditGrid});
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(19, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1022, 268);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(738, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Search";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(791, 77);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(250, 21);
            this.tbSearch.TabIndex = 14;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbIdCardNumber_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbName);
            this.groupBox2.Controls.Add(this.cbDepartment);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtEndDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtStartDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbEmployeeStatus);
            this.groupBox2.Controls.Add(this.tbSalary);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Location = new System.Drawing.Point(19, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 185);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Employee";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(23, 40);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(250, 21);
            this.tbName.TabIndex = 53;
            // 
            // cbDepartment
            // 
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(23, 120);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(250, 21);
            this.cbDepartment.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Department";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(279, 120);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(250, 21);
            this.dtEndDate.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "End Date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(279, 80);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(250, 21);
            this.dtStartDate.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Salary";
            // 
            // cbEmployeeStatus
            // 
            this.cbEmployeeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployeeStatus.FormattingEnabled = true;
            this.cbEmployeeStatus.Location = new System.Drawing.Point(23, 80);
            this.cbEmployeeStatus.Name = "cbEmployeeStatus";
            this.cbEmployeeStatus.Size = new System.Drawing.Size(250, 21);
            this.cbEmployeeStatus.TabIndex = 33;
            // 
            // tbSalary
            // 
            this.tbSalary.Location = new System.Drawing.Point(279, 40);
            this.tbSalary.Name = "tbSalary";
            this.tbSalary.Size = new System.Drawing.Size(250, 21);
            this.tbSalary.TabIndex = 45;
            this.tbSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSalary_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(96, 13);
            this.label25.TabIndex = 15;
            this.label25.Text = "Employe Status";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(19, 580);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 42;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(145, 580);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 41;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PhotoGrid
            // 
            this.PhotoGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PhotoGrid.DataPropertyName = "PhotoGrid";
            this.PhotoGrid.HeaderText = "Photo";
            this.PhotoGrid.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.PhotoGrid.MinimumWidth = 8;
            this.PhotoGrid.Name = "PhotoGrid";
            this.PhotoGrid.ReadOnly = true;
            this.PhotoGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PhotoGrid.ToolTipText = "PhotoGrid";
            this.PhotoGrid.Width = 64;
            // 
            // EditGrid
            // 
            this.EditGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EditGrid.FillWeight = 10.16109F;
            this.EditGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditGrid.HeaderText = "Edit";
            this.EditGrid.MinimumWidth = 8;
            this.EditGrid.Name = "EditGrid";
            this.EditGrid.ReadOnly = true;
            this.EditGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EditGrid.Text = "Edit";
            this.EditGrid.ToolTipText = "Edit";
            this.EditGrid.UseColumnTextForButtonValue = true;
            this.EditGrid.Width = 53;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(23, 152);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 54;
            this.checkBox1.Text = "Active";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MasterEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 622);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MasterEmployeeForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasterEmployeeForm";
            this.Load += new System.EventHandler(this.MasterEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbEmployeeStatus;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSalary;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DataGridViewImageColumn PhotoGrid;
        private System.Windows.Forms.DataGridViewButtonColumn EditGrid;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}