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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.urlBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selPath = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.enOnlinebtn = new System.Windows.Forms.CheckBox();
            this.altSaveBtn = new System.Windows.Forms.CheckBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Enabled = false;
            this.urlBox.Location = new System.Drawing.Point(12, 22);
            this.urlBox.Name = "urlBox";
            this.urlBox.ReadOnly = true;
            this.urlBox.Size = new System.Drawing.Size(501, 20);
            this.urlBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dark Souls Directory";
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
            // enOnlinebtn
            // 
            this.enOnlinebtn.AutoSize = true;
            this.enOnlinebtn.Location = new System.Drawing.Point(105, 196);
            this.enOnlinebtn.Name = "enOnlinebtn";
            this.enOnlinebtn.Size = new System.Drawing.Size(91, 17);
            this.enOnlinebtn.TabIndex = 5;
            this.enOnlinebtn.Text = "enable Online";
            this.enOnlinebtn.UseVisualStyleBackColor = true;
            this.enOnlinebtn.CheckedChanged += new System.EventHandler(this.EnOnlineBtn_CheckedChanged);
            // 
            // altSaveBtn
            // 
            this.altSaveBtn.AutoSize = true;
            this.altSaveBtn.Location = new System.Drawing.Point(198, 196);
            this.altSaveBtn.Name = "altSaveBtn";
            this.altSaveBtn.Size = new System.Drawing.Size(108, 17);
            this.altSaveBtn.TabIndex = 6;
            this.altSaveBtn.Text = "use Alt. Save-File";
            this.altSaveBtn.UseVisualStyleBackColor = true;
            this.altSaveBtn.CheckedChanged += new System.EventHandler(this.altSaveBtn_CheckedChanged);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(330, 192);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(183, 23);
            this.savebtn.TabIndex = 7;
            this.savebtn.Text = "save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 225);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.altSaveBtn);
            this.Controls.Add(this.enOnlinebtn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.selPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Dark Souls III Mod Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox urlBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button selPath;
		private System.Windows.Forms.Button btnInstall;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox enOnlinebtn;
		private System.Windows.Forms.CheckBox altSaveBtn;
		private System.Windows.Forms.Button savebtn;
	}
}

