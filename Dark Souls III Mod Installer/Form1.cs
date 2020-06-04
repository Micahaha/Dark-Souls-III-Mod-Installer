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
		string folderPath = "";
		OpenFileDialog fbd = new OpenFileDialog();
		string parentDirectory = "";
		public string fileBox
		{

			get { return urlBox.Text; }
			set { urlBox.Text = value; }

		}
		public string coughtPath;
		public string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\userSettings.ini";


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
			if (!File.Exists(path))
			{
				using (var myFile = File.Create(path));
			}
		
	
			readDirectory();
			checkBox1.Enabled = false; 
			if (fileBox.Contains("Game"))
			{
				enOnlinebtn.Enabled = true;
				btnInstall.Enabled = true;
				checkBox1.Enabled = true;
				readUserSettings(enOnlinebtn);
				readUserSettingsaltBtn(altSaveBtn);
				readUserSettingsDisableBtn(checkBox1);
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void urlBox_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void selPath_Click(object sender, EventArgs e)
		{
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
						checkBox1.Enabled = true;
						readUserSettings(enOnlinebtn);
						readUserSettingsaltBtn(altSaveBtn);
						readUserSettingsDisableBtn(checkBox1);
						savedDirectory(folderPath);
					}
					else
					{
						fileBox = null;
						btnInstall.Enabled = false;
					}
				}
				string modEngine = Path.Combine(fileBox + @"\modengine.ini");
				var parser = new FileIniDataParser();
				IniData data = parser.ReadFile(modEngine);
				var directValue = data["files"]["modOverrideDirectory"];

				if (!directValue.Contains(@"""\mod"""))
				{
					directValue = data["files"]["modOverrideDirectory"] = @"""\mod""";
					parser.WriteFile(modEngine, data);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Nothing was selected. Please choose your DarkSouls3.exe");
			}
		}

		private void btnInstall_Click(object sender, EventArgs e)
		{
			try {


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
							ZipFile.ExtractToDirectory(coughtPath, modDirectory);
							MessageBox.Show("Mod installed!");
						}

					}


				}
			}
			catch(IOException eee) 
			{
				MessageBox.Show("File Already exists in that Location");
			}
		}
		public void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			string modEngine = Path.Combine(fileBox + @"\modengine.ini");
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(modEngine);
			if (fileBox.Contains("Game"))
			{
				
				var directValue = data["files"]["useModOverrideDirectory"];
				if (checkBox1.Checked)
				{
					directValue = data["files"]["useModOverrideDirectory"] = "0";
					parser.WriteFile(modEngine, data);
				}
				else
				{
					directValue = data["files"]["useModOverrideDirectory"] = "1";
					parser.WriteFile(modEngine, data);
				}
			}
		}
	
		private void EnOnlineBtn_CheckedChanged(object sender, EventArgs e)
		{
			
			string modEngine = Path.Combine(fileBox + @"\modengine.ini");
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(modEngine);
			
			if (fileBox.Contains("Game"))
			{
				var directValue = data["online"]["blockNetworkAccess"];
				if (checkBox1.Checked)
				{
					directValue = "0";
					parser.WriteFile(modEngine, data);
				}
				else
				{
					directValue = "1";
					parser.WriteFile(modEngine, data);
				}
			}
		}

		private void altSaveBtn_CheckedChanged(object sender, EventArgs e)
		{

			string modEngine = Path.Combine(fileBox + @"\modengine.ini");
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(modEngine);
			if (fileBox.Contains("Game"))
			{
				var directValue = data["savefile"]["useAlternateSaveFile"];
				if (checkBox1.Checked)
				{
					directValue = "1";
					parser.WriteFile(modEngine, data);
				}
				else
				{
					directValue = "0";
					parser.WriteFile(modEngine, data);
				}
			}
		}

		
		public void SaveUserSettings(CheckBox checker)
		{
			
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			if (checker.Checked)
			{
				var directValue = data["CheckSaveState"]["checked"] = "1";
				parser.WriteFile(path, data);
			}
			else 
			{
				var directValue = data["CheckSaveState"]["checked"] = "0";
				parser.WriteFile(path, data);
			}
		}

		public void readUserSettings(CheckBox check) 
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			var directValue = data["CheckSaveState"]["checked"];
			int trueValue = Convert.ToInt32(directValue);
			// contains "1" or "0"
			if (trueValue == 1)
			{
				check.Checked = true;
			}
			else
			{
				check.Checked = false;
			}
		}

		private void savebtn_Click(object sender, EventArgs e)
		{
			SaveUserSettingsaltbtn(altSaveBtn);
			SaveUserSettingsDisablebtn(checkBox1);
			SaveUserSettings(enOnlinebtn);
			MessageBox.Show("Options saved");
		}
		public void savedDirectory(string filePath) 
		{
			DirectoryInfo parent = Directory.GetParent(filePath);
			string parentDir = Convert.ToString(parent);
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			var directValue = data["files"]["DS3Dir"] = parentDir;
			parser.WriteFile(path, data);

		}
		public void readDirectory() 
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			var directValue = data["files"]["DS3Dir"];
			if (!fileBox.Contains("Game"))  
			{
				fileBox += directValue;
			}
		}
	
		public void SaveUserSettingsDisablebtn(CheckBox checker)
		{

			if (!File.Exists(path))
			{
				File.Create(path);
			}
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			if (checker.Checked)
			{
				var directValue = data["CheckSaveState"]["disablemods"] = "1";
				parser.WriteFile(path, data);
			}
			else
			{
				var directValue = data["CheckSaveState"]["disablemods"] = "0";
				parser.WriteFile(path, data);
			}
		}

		public void readUserSettingsDisableBtn(CheckBox check)
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			var directValue = data["CheckSaveState"]["disablemods"];
			int trueValue = Convert.ToInt32(directValue);
			// contains "1" or "0"
			if (trueValue == 1)
			{
				check.Checked = true;
			}
			else
			{
				check.Checked = false;
			}
		}
		public void SaveUserSettingsaltbtn(CheckBox checker)
		{

			if (!File.Exists(path))
			{
				File.Create(path);
			}
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			if (checker.Checked)
			{
				var directValue = data["CheckSaveState"]["altbtn"] = "1";
				parser.WriteFile(path, data);
			}
			else
			{
				var directValue = data["CheckSaveState"]["altbtn"] = "0";
				parser.WriteFile(path, data);
			}
		}

		public void readUserSettingsaltBtn(CheckBox check)
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			var directValue = data["CheckSaveState"]["altbtn"];
			int trueValue = Convert.ToInt32(directValue);
			// contains "1" or "0"
			if (trueValue == 1)
			{
				check.Checked = true;
			}
			else
			{
				check.Checked = false;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
