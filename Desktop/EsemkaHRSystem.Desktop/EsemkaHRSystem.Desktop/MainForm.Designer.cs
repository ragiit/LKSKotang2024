namespace EsemkaHRSystem.Desktop
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterJobPositionAndJobTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterCountryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterCityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSecondItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.menuSecondItem,
            this.toolStripMenuItem1,
            this.logoutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterEmployeeToolStripMenuItem,
            this.masterJobPositionAndJobTitleToolStripMenuItem,
            this.masterCountryToolStripMenuItem,
            this.masterCityToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // masterEmployeeToolStripMenuItem
            // 
            this.masterEmployeeToolStripMenuItem.Name = "masterEmployeeToolStripMenuItem";
            this.masterEmployeeToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.masterEmployeeToolStripMenuItem.Text = "Master Employee";
            this.masterEmployeeToolStripMenuItem.Click += new System.EventHandler(this.masterEmployeeToolStripMenuItem_Click);
            // 
            // masterJobPositionAndJobTitleToolStripMenuItem
            // 
            this.masterJobPositionAndJobTitleToolStripMenuItem.Name = "masterJobPositionAndJobTitleToolStripMenuItem";
            this.masterJobPositionAndJobTitleToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.masterJobPositionAndJobTitleToolStripMenuItem.Text = "Master Job Position and Job Title";
            this.masterJobPositionAndJobTitleToolStripMenuItem.Click += new System.EventHandler(this.masterJobPositionAndJobTitleToolStripMenuItem_Click);
            // 
            // masterCountryToolStripMenuItem
            // 
            this.masterCountryToolStripMenuItem.Name = "masterCountryToolStripMenuItem";
            this.masterCountryToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.masterCountryToolStripMenuItem.Text = "Master Country";
            this.masterCountryToolStripMenuItem.Click += new System.EventHandler(this.masterCountryToolStripMenuItem_Click);
            // 
            // masterCityToolStripMenuItem
            // 
            this.masterCityToolStripMenuItem.Name = "masterCityToolStripMenuItem";
            this.masterCityToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.masterCityToolStripMenuItem.Text = "Master City";
            this.masterCityToolStripMenuItem.Click += new System.EventHandler(this.masterCityToolStripMenuItem_Click);
            // 
            // menuSecondItem
            // 
            this.menuSecondItem.Name = "menuSecondItem";
            this.menuSecondItem.Size = new System.Drawing.Size(175, 20);
            this.menuSecondItem.Text = "Generate Employee Schedule ";
            this.menuSecondItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem1.Text = "Logout";
            this.logoutToolStripMenuItem1.Click += new System.EventHandler(this.logoutToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(73, 20);
            this.toolStripMenuItem1.Text = "My Profile";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSecondItem;
        private System.Windows.Forms.ToolStripMenuItem masterEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterJobPositionAndJobTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterCountryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterCityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}