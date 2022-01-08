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
		public string modEngine;
		FileIniDataParser parser = new FileIniDataParser();
		IniData data = new IniData();
		FolderOperations folderOperations = new FolderOperations();
        OpenFileDialog fbd = new OpenFileDialog();


		public string fileBox
		{

			get { return urlBox.Text; }
			set { urlBox.Text = value; }

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
				folderOperations.readDirectory(SETTINGS_PATH, fileBox);
			}

		/*	if (!File.Exists(PARENT_DIRECTORY))
			{
				modEngine = Path.Combine(PARENT_DIRECTORY + @"\modengine.ini");
				FileStream myFile = File.Create(modEngine);
			}
		*/
			checkBox1.Enabled = false;
			
			if (urlBox.Text.Contains("Game"))
			{
				enOnlinebtn.Enabled = true;
				btnInstall.Enabled = true;
				checkBox1.Enabled = true;
				folderOperations.readUserSettings(enOnlinebtn,SETTINGS_PATH);
				folderOperations.readUserSettingsaltBtn(altSaveBtn, SETTINGS_PATH);
				folderOperations.readUserSettingsDisableBtn(checkBox1, SETTINGS_PATH);
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

					if (FOLDER_PATH.Contains("DarkSoulsIII.exe"))
					{
						MessageBox.Show("DARK SOULS 3 DIRECTORY SELECTED!");
						btnInstall.Enabled = true;
						fileBox = PARENT_DIRECTORY;
						checkBox1.Enabled = true;
						folderOperations.readUserSettings(enOnlinebtn, SETTINGS_PATH);
						folderOperations.readUserSettingsaltBtn(altSaveBtn, SETTINGS_PATH);
						folderOperations.readUserSettingsDisableBtn(checkBox1, SETTINGS_PATH);
						folderOperations.savedDirectory(FOLDER_PATH, SETTINGS_PATH);

						modEngine = Path.Combine(PARENT_DIRECTORY + @"\\modengine.ini");


						// Begin parsing modEngine file
						data = parser.ReadFile(modEngine);

						foreach (SectionData section in data.Sections) 
						{

							Console.WriteLine("[" + section.SectionName + "]");
						}
					}
					else 
					{
						MessageBox.Show("Wrong file, Please select your DarkSoulsIII.exe");
					}
				}


			/*	string directValue = data["files"]["modOverrideDirectory"];
				if (!directValue.Contains(@"""\mod"""))
				{
					directValue = data["files"]["modOverrideDirectory"] = @"""\mod""";
					parser.WriteFile(modEngine, data);
				}
			*/

			}
			

			catch (Exception catchThis)
			{
				MessageBox.Show("Nothing was selected. Please choose your DarkSouls3.exe");
				Console.WriteLine(catchThis.Message);
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
			if (FOLDER_PATH.Contains("Game"))
			{
				string directValue = data["files"]["useModOverrideDirectory"];
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

			
			if (FOLDER_PATH.Contains("Game"))
			{
				var directValue = data["online"]["blockNetworkAccess"];
				if (enOnlinebtn.Checked)
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

			if (FOLDER_PATH.Contains("Game"))
			{
                string directValue = data["savefile"]["useAlternateSaveFile"];
				if (altSaveBtn.Checked)
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
			folderOperations.SaveUserSettingsaltbtn(altSaveBtn, SETTINGS_PATH);
			folderOperations.SaveUserSettingsDisablebtn(checkBox1,SETTINGS_PATH);

			try
			{
				SaveUserSettings(enOnlinebtn);
				MessageBox.Show("Options saved");
			}
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
				MessageBox.Show("Error  saving options, Please try again");
			}
			
		}
    }
}
