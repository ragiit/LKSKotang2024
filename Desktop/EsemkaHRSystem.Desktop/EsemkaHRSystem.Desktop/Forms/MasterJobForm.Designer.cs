namespace EsemkaHRSystem.Desktop
{
    partial class MasterJobForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.EditGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(147, 592);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 62;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(18, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1023, 190);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Job Position";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1017, 170);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(21, 592);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 63;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 32);
            this.label1.TabIndex = 58;
            this.label1.Text = "Master Job";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(18, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1023, 190);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Job Title";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditGrid,
            this.DeleteGrid});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.GridColor = System.Drawing.Color.Silver;
            this.dataGridView2.Location = new System.Drawing.Point(3, 17);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.Size = new System.Drawing.Size(1017, 170);
            this.dataGridView2.TabIndex = 8;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.tbName);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Location = new System.Drawing.Point(21, 456);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 130);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Job Title";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(23, 80);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(250, 21);
            this.numericUpDown1.TabIndex = 67;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(23, 40);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(250, 21);
            this.tbName.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Level";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(20, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 13);
            this.label28.TabIndex = 13;
            this.label28.Text = "Name";
            // 
            // EditGrid
            // 
            this.EditGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EditGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditGrid.HeaderText = "Edit";
            this.EditGrid.Name = "EditGrid";
            this.EditGrid.ReadOnly = true;
            this.EditGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EditGrid.Text = "Edit";
            this.EditGrid.ToolTipText = "Edit";
            this.EditGrid.UseColumnTextForButtonValue = true;
            this.EditGrid.Width = 53;
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
            // MasterJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 640);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MasterJobForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasterJobForm";
            this.Load += new System.EventHandler(this.MasterJobForm_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewButtonColumn EditGrid;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteGrid;
    }
}