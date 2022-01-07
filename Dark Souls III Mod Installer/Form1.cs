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
		private string FOLDER_PATH;
		private string PARENT_DIRECTORY;
		private string CAUGHTPATH;
		public readonly string SETTINGS_PATH = Path.GetDirectoryName(Application.ExecutablePath) + @"\userSettings.ini";	

		FolderOperations folderOperations = new FolderOperations();

        OpenFileDialog fbd = new OpenFileDialog();


		public void setFolderPath(string newFolderPath) 
		{
		
			FOLDER_PATH = newFolderPath;
		}

		public Form1()
		{
			InitializeComponent();
			MessageBox.Show("Thanks for installing, This is my first C# Project so please leave some constructive criticism!");

			if (!File.Exists(SETTINGS_PATH))
			{
				FileStream myFile = File.Create(SETTINGS_PATH);
			}

			else 
			{
				folderOperations.readDirectory(SETTINGS_PATH);

			}

			checkBox1.Enabled = false; 

			if (urlBox.Text.Contains("Game"))
			{
				enOnlinebtn.Enabled = true;
				btnInstall.Enabled = true;
				checkBox1.Enabled = true;
				folderOperations.readUserSettings(enOnlinebtn);
				readUserSettingsaltBtn(altSaveBtn);
				readUserSettingsDisableBtn(checkBox1);
			}
		}

		private void selPath_Click(object sender, EventArgs e)
		{
			try
			{
				
				if (fbd.ShowDialog() == DialogResult.OK)
				{

                    FOLDER_PATH = fbd.FileName;

					PARENT_DIRECTORY = Directory.GetParent(FOLDER_PATH).FullName;
					if (FOLDER_PATH.Contains("DarkSoulsIII.exe") && !SETTINGS_PATH.Contains(null))
					{
						MessageBox.Show("DARK SOULS 3 DIRECTORY SELECTED!");
						btnInstall.Enabled = true;
					folderOperations.fileBox = PARENT_DIRECTORY;
						checkBox1.Enabled = true;
						folderOperations.readUserSettings(enOnlinebtn);
						readUserSettingsaltBtn(altSaveBtn);
						readUserSettingsDisableBtn(checkBox1);
						folderOperations.savedDirectory(FOLDER_PATH);
					}
					else
					{
						FOLDER_PATH = null;
						btnInstall.Enabled = false;
						MessageBox.Show("DARK SOULS 3 DIRECTORY NOT SELECTED, PLEASE TRY AGAIN!");
					}
				}
				string modEngine = Path.Combine(FOLDER_PATH + @"\modengine.ini");
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


				string[] paths = { FOLDER_PATH, "mod" };

				using (OpenFileDialog fbd2 = new OpenFileDialog())
				{

					fbd2.InitialDirectory = "C:\\";
					fbd2.Filter = "Archive Files (*.zip)|*.zip|All files (*.*)|*.*";

					if (fbd2.ShowDialog() == DialogResult.OK)
					{

						CAUGHTPATH = fbd2.FileName;
						string modDirectory = Path.Combine(paths);
						if (!Directory.Exists(modDirectory))
						{
							DirectoryInfo createMod = Directory.CreateDirectory(modDirectory);
						}
						else
						{
							ZipFile.ExtractToDirectory(CAUGHTPATH, modDirectory);
							MessageBox.Show("Mod installed!");
						}

					}


				}
			}
			catch(IOException) 
			{
				MessageBox.Show("File Already exists in that Location");
			}
		}
		public void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			string modEngine = Path.Combine(FOLDER_PATH + @"\modengine.ini");
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(modEngine);
			if (FOLDER_PATH.Contains("Game"))
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
			
			string modEngine = Path.Combine(FOLDER_PATH + @"\modengine.ini");
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(modEngine);
			
			if (FOLDER_PATH.Contains("Game"))
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

			string modEngine = Path.Combine(FOLDER_PATH + @"\modengine.ini");
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(modEngine);
			if (FOLDER_PATH.Contains("Game"))
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
			IniData data = parser.ReadFile(SETTINGS_PATH);
			if (checker.Checked)
			{
				var directValue = data["CheckSaveState"]["checked"] = "1";
				parser.WriteFile(SETTINGS_PATH, data);
			}
			else 
			{
				var directValue = data["CheckSaveState"]["checked"] = "0";
				parser.WriteFile(SETTINGS_PATH, data);
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
			IniData data = parser.ReadFile(SETTINGS_PATH);
			var directValue = data["files"]["DS3Dir"] = parentDir;
			parser.WriteFile(SETTINGS_PATH, data);

		}
		
	
		public void SaveUserSettingsDisablebtn(CheckBox checker)
		{

			if (!File.Exists(SETTINGS_PATH))
			{
				File.Create(SETTINGS_PATH);
			}
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(SETTINGS_PATH);
			if (checker.Checked)
			{
				var directValue = data["CheckSaveState"]["disablemods"] = "1";
				parser.WriteFile(SETTINGS_PATH, data);
			}
			else
			{
				var directValue = data["CheckSaveState"]["disablemods"] = "0";
				parser.WriteFile(SETTINGS_PATH, data);
			}
		}

		public void readUserSettingsDisableBtn(CheckBox check)
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(SETTINGS_PATH);
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

			if (!File.Exists(SETTINGS_PATH))
			{
				File.Create(SETTINGS_PATH);
			}
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(SETTINGS_PATH);
			if (checker.Checked)
			{
				var directValue = data["CheckSaveState"]["altbtn"] = "1";
				parser.WriteFile(SETTINGS_PATH, data);
			}
			else
			{
				var directValue = data["CheckSaveState"]["altbtn"] = "0";
				parser.WriteFile(SETTINGS_PATH, data);
			}
		}

		public void readUserSettingsaltBtn(CheckBox check)
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(SETTINGS_PATH);
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
