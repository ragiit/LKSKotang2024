namespace EsemkaHRSystem.Desktop
{
    partial class GenerateEmployeeSchedule
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbBreakTime = new System.Windows.Forms.TextBox();
            this.cbEndTime = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBreakTime = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbStartTime = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbWorkLocation = new System.Windows.Forms.ComboBox();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbWorkDay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DeleteGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbWorkDay);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbBreakTime);
            this.groupBox2.Controls.Add(this.cbWorkLocation);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtEndDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtStartDate);
            this.groupBox2.Controls.Add(this.cbStartTime);
            this.groupBox2.Controls.Add(this.cbUser);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbBreakTime);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.cbEndTime);
            this.groupBox2.Location = new System.Drawing.Point(15, 439);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 239);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "Break Time Duration (Minutes)";
            // 
            // tbBreakTime
            // 
            this.tbBreakTime.Location = new System.Drawing.Point(279, 201);
            this.tbBreakTime.Name = "tbBreakTime";
            this.tbBreakTime.Size = new System.Drawing.Size(250, 21);
            this.tbBreakTime.TabIndex = 64;
            this.tbBreakTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBreakTime_KeyPress);
            // 
            // cbEndTime
            // 
            this.cbEndTime.DisplayMember = "TimeValue";
            this.cbEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndTime.FormattingEnabled = true;
            this.cbEndTime.Location = new System.Drawing.Point(279, 120);
            this.cbEndTime.Name = "cbEndTime";
            this.cbEndTime.Size = new System.Drawing.Size(250, 21);
            this.cbEndTime.TabIndex = 62;
            this.cbEndTime.ValueMember = "Id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "End Time";
            // 
            // cbBreakTime
            // 
            this.cbBreakTime.DisplayMember = "TimeValue";
            this.cbBreakTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBreakTime.FormattingEnabled = true;
            this.cbBreakTime.Location = new System.Drawing.Point(279, 160);
            this.cbBreakTime.Name = "cbBreakTime";
            this.cbBreakTime.Size = new System.Drawing.Size(250, 21);
            this.cbBreakTime.TabIndex = 60;
            this.cbBreakTime.ValueMember = "Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Break Time";
            // 
            // cbStartTime
            // 
            this.cbStartTime.DisplayMember = "TimeValue";
            this.cbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartTime.FormattingEnabled = true;
            this.cbStartTime.Location = new System.Drawing.Point(279, 80);
            this.cbStartTime.Name = "cbStartTime";
            this.cbStartTime.Size = new System.Drawing.Size(250, 21);
            this.cbStartTime.TabIndex = 58;
            this.cbStartTime.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Start Time";
            // 
            // cbWorkLocation
            // 
            this.cbWorkLocation.DisplayMember = "name";
            this.cbWorkLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkLocation.FormattingEnabled = true;
            this.cbWorkLocation.Location = new System.Drawing.Point(23, 80);
            this.cbWorkLocation.Name = "cbWorkLocation";
            this.cbWorkLocation.Size = new System.Drawing.Size(250, 21);
            this.cbWorkLocation.TabIndex = 56;
            this.cbWorkLocation.ValueMember = "Id";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(23, 201);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(250, 21);
            this.dtEndDate.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Work Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "End Date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(23, 161);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(250, 21);
            this.dtStartDate.TabIndex = 53;
            // 
            // cbUser
            // 
            this.cbUser.DisplayMember = "FullName";
            this.cbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(23, 40);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(506, 21);
            this.cbUser.TabIndex = 32;
            this.cbUser.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Start Date";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(20, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 13);
            this.label28.TabIndex = 13;
            this.label28.Text = "Employee";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(15, 684);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 57;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteGrid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1187, 189);
            this.dataGridView1.TabIndex = 60;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.GridColor = System.Drawing.Color.Silver;
            this.dataGridView2.Location = new System.Drawing.Point(3, 17);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.Size = new System.Drawing.Size(1184, 186);
            this.dataGridView2.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1193, 209);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedule";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Location = new System.Drawing.Point(15, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1190, 206);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Schedule Detail";
            // 
            // cbWorkDay
            // 
            this.cbWorkDay.DisplayMember = "name";
            this.cbWorkDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkDay.FormattingEnabled = true;
            this.cbWorkDay.Location = new System.Drawing.Point(23, 120);
            this.cbWorkDay.Name = "cbWorkDay";
            this.cbWorkDay.Size = new System.Drawing.Size(250, 21);
            this.cbWorkDay.TabIndex = 66;
            this.cbWorkDay.ValueMember = "Id";
            this.cbWorkDay.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Work Day";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // DeleteGrid
            // 
            this.DeleteGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DeleteGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteGrid.HeaderText = "Delete";
            this.DeleteGrid.Name = "DeleteGrid";
            this.DeleteGrid.ReadOnly = true;
            this.DeleteGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteGrid.Text = "Delete";
            this.DeleteGrid.ToolTipText = "Delete";
            this.DeleteGrid.UseColumnTextForButtonValue = true;
            this.DeleteGrid.Width = 69;
            // 
            // GenerateEmployeeSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 724);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GenerateEmployeeSchedule";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenerateEmployeeSchedule";
            this.Load += new System.EventHandler(this.GenerateEmployeeSchedule_Load);
            this.TextChanged += new System.EventHandler(this.S);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbWorkLocation;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cbEndTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbBreakTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbBreakTime;
        private System.Windows.Forms.ComboBox cbWorkDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteGrid;
    }
}