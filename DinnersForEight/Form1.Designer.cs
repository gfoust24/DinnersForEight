namespace DinnersForEight
{
	partial class Form1
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
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dgvMatchCount = new System.Windows.Forms.DataGridView();
			this.dgvUser = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtDinnerInfo = new System.Windows.Forms.TextBox();
			this.lsbDinnerSelect = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnNextDinner = new System.Windows.Forms.Button();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMatchCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(888, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(888, 594);
			this.tabControl1.TabIndex = 1;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.Controls.Add(this.dgvMatchCount);
			this.tabPage1.Controls.Add(this.dgvUser);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(880, 568);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Users";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dgvMatchCount
			// 
			this.dgvMatchCount.AllowUserToAddRows = false;
			this.dgvMatchCount.AllowUserToDeleteRows = false;
			this.dgvMatchCount.AllowUserToResizeColumns = false;
			this.dgvMatchCount.AllowUserToResizeRows = false;
			this.dgvMatchCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dgvMatchCount.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgvMatchCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMatchCount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMatchCount.Location = new System.Drawing.Point(289, 3);
			this.dgvMatchCount.Name = "dgvMatchCount";
			this.dgvMatchCount.RowHeadersVisible = false;
			this.dgvMatchCount.Size = new System.Drawing.Size(588, 562);
			this.dgvMatchCount.TabIndex = 1;
			this.dgvMatchCount.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatchCount_CellValueChanged);
			this.dgvMatchCount.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvMatchCount_ColumnAdded);
			// 
			// dgvUser
			// 
			this.dgvUser.AllowUserToDeleteRows = false;
			this.dgvUser.AllowUserToResizeRows = false;
			this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUser.Dock = System.Windows.Forms.DockStyle.Left;
			this.dgvUser.Location = new System.Drawing.Point(3, 3);
			this.dgvUser.Name = "dgvUser";
			this.dgvUser.Size = new System.Drawing.Size(286, 562);
			this.dgvUser.TabIndex = 0;
			this.dgvUser.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_RowValidated);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtDinnerInfo);
			this.tabPage2.Controls.Add(this.lsbDinnerSelect);
			this.tabPage2.Controls.Add(this.panel1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(880, 568);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Dinners";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtDinnerInfo
			// 
			this.txtDinnerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDinnerInfo.Location = new System.Drawing.Point(123, 45);
			this.txtDinnerInfo.Multiline = true;
			this.txtDinnerInfo.Name = "txtDinnerInfo";
			this.txtDinnerInfo.ReadOnly = true;
			this.txtDinnerInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDinnerInfo.Size = new System.Drawing.Size(754, 520);
			this.txtDinnerInfo.TabIndex = 2;
			this.txtDinnerInfo.WordWrap = false;
			// 
			// lsbDinnerSelect
			// 
			this.lsbDinnerSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.lsbDinnerSelect.Font = new System.Drawing.Font("Consolas", 12F);
			this.lsbDinnerSelect.FormattingEnabled = true;
			this.lsbDinnerSelect.ItemHeight = 19;
			this.lsbDinnerSelect.Items.AddRange(new object[] {
            "<empty>"});
			this.lsbDinnerSelect.Location = new System.Drawing.Point(3, 45);
			this.lsbDinnerSelect.Name = "lsbDinnerSelect";
			this.lsbDinnerSelect.Size = new System.Drawing.Size(120, 520);
			this.lsbDinnerSelect.TabIndex = 1;
			this.lsbDinnerSelect.SelectedIndexChanged += new System.EventHandler(this.lsbDinnerSelect_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnNextDinner);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(874, 42);
			this.panel1.TabIndex = 5;
			// 
			// btnNextDinner
			// 
			this.btnNextDinner.Location = new System.Drawing.Point(13, 16);
			this.btnNextDinner.Name = "btnNextDinner";
			this.btnNextDinner.Size = new System.Drawing.Size(75, 23);
			this.btnNextDinner.TabIndex = 0;
			this.btnNextDinner.Text = "Next Dinner";
			this.btnNextDinner.UseVisualStyleBackColor = true;
			this.btnNextDinner.Click += new System.EventHandler(this.btnNextDinner_Click);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "MMMM yyyy";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(104, 19);
			this.dateTimePicker1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.ShowUpDown = true;
			this.dateTimePicker1.Size = new System.Drawing.Size(125, 20);
			this.dateTimePicker1.TabIndex = 4;
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(31, 20);
			this.toolStripMenuItem1.Text = "    ";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(888, 618);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Dinners For Eight";
			this.Activated += new System.EventHandler(this.Form1_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvMatchCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DataGridView dgvMatchCount;
		private System.Windows.Forms.DataGridView dgvUser;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtDinnerInfo;
		private System.Windows.Forms.ListBox lsbDinnerSelect;
		private System.Windows.Forms.Button btnNextDinner;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
	}
}

