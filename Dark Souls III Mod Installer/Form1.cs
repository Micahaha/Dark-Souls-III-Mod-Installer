using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenZipNET;
using System.IO.Compression;
using System.CodeDom;
using IniParser;
using IniParser.Model;
using System.Runtime.InteropServices;

namespace Dark_Souls_III_Mod_Installer
{
	public partial class Form1 : Form
	{

		public string fileBox
		{

			get { return urlBox.Text; }
			set { urlBox.Text = value; }

		}
		public string coughtPath;




		public void openFolderDialog()
		{
			using (var fbd = new FolderBrowserDialog())
			{


				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					fileBox = fbd.SelectedPath;
				}
			}
		}

		public Form1()
		{
			InitializeComponent();
			MessageBox.Show("Thanks for installing, This is my first C# Project so please leave some constructive criticism!");
			

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void urlBox_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void selPath_Click(object sender, EventArgs e)
		{
			
			string folderPath = "";
			OpenFileDialog fbd = new OpenFileDialog();
			string parentDirectory = "";
			string errorMessage = "Wrong Directory";
			try
			{
				if (fbd.ShowDialog() == DialogResult.OK)
				{

					folderPath = fbd.FileName;
					parentDirectory = Directory.GetParent(folderPath).FullName;

					if (folderPath.Contains("DarkSoulsIII.exe"))
					{
						MessageBox.Show("DARK SOULS 3 DIRECTORY SELECTED!");
						btnInstall.Enabled = true;
						fileBox = parentDirectory;
						
					}
					else
					{
						fileBox = null;
						MessageBox.Show("Dark Souls 3 Directory was not selected!");
						btnInstall.Enabled = false;
					}
				}
				else
				{
					MessageBox.Show("Nothing was selected");
				}

			}

			catch (Exception fuckedUp)
			{
				errorMessage = fuckedUp.Message;
			}
			if (fileBox.Contains("Game")) 
			{
				string modEngine = Path.Combine(parentDirectory + @"\modengine.ini");
				var parser = new FileIniDataParser();
				IniData data = parser.ReadFile(modEngine);
				var directValue = data["files"]["modOverrideDirectory"] = @"""\mod""";
				parser.WriteFile(modEngine, data);
			}

		}

		private void btnInstall_Click(object sender, EventArgs e)
		{
	

			string[] paths = { fileBox, "mod" };
		
			using (OpenFileDialog fbd2 = new OpenFileDialog())
			{

				fbd2.InitialDirectory = "C:\\";
				fbd2.Filter = "Archive Files (*.zip)|*.zip|All files (*.*)|*.*";

				if (fbd2.ShowDialog() == DialogResult.OK)
				{
					
					coughtPath = fbd2.FileName;
					string modDirectory = Path.Combine(paths);
					if (!Directory.Exists(modDirectory))
					{
						DirectoryInfo createMod = Directory.CreateDirectory(modDirectory);
					}
					else
					{
						ZipFile.ExtractToDirectory(coughtPath,modDirectory);
						MessageBox.Show("Mod installed!");
					}

				}


			}
		}
	}
}
