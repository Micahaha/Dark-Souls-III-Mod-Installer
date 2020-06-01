namespace Dark_Souls_III_Mod_Installer
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
			this.urlBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.selPath = new System.Windows.Forms.Button();
			this.btnInstall = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// urlBox
			// 
			this.urlBox.Location = new System.Drawing.Point(12, 22);
			this.urlBox.Name = "urlBox";
			this.urlBox.ReadOnly = true;
			this.urlBox.Size = new System.Drawing.Size(501, 20);
			this.urlBox.TabIndex = 0;
			this.urlBox.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Dark Souls Directory";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// selPath
			// 
			this.selPath.Location = new System.Drawing.Point(12, 48);
			this.selPath.Name = "selPath";
			this.selPath.Size = new System.Drawing.Size(110, 23);
			this.selPath.TabIndex = 2;
			this.selPath.Text = "Select File Path";
			this.selPath.UseVisualStyleBackColor = true;
			this.selPath.Click += new System.EventHandler(this.selPath_Click);
			// 
			// btnInstall
			// 
			this.btnInstall.Enabled = false;
			this.btnInstall.Location = new System.Drawing.Point(12, 77);
			this.btnInstall.Name = "btnInstall";
			this.btnInstall.Size = new System.Drawing.Size(110, 23);
			this.btnInstall.TabIndex = 3;
			this.btnInstall.Text = "Install";
			this.btnInstall.UseVisualStyleBackColor = true;
			this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(12, 196);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(87, 17);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Text = "disable mods";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(525, 225);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.btnInstall);
			this.Controls.Add(this.selPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.urlBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox urlBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button selPath;
		private System.Windows.Forms.Button btnInstall;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}

