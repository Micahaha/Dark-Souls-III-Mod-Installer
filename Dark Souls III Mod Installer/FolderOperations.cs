using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dark_Souls_III_Mod_Installer
{

	 class FolderOperations
	{
		public void savedDirectory(string filePath, string settings)
		{
			DirectoryInfo parent = Directory.GetParent(filePath);
			string parentDir = Convert.ToString(parent);
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(settings);
			var directValue = data["files"]["DS3Dir"] = parentDir;
			parser.WriteFile(settings, data);

		}

		public void readDirectory(string path, string fileBox)
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			var directValue = data["files"]["DS3Dir"];
			if (!fileBox.Contains("Game"))
			{
				fileBox += directValue;
			}
		}

		public void readUserSettings(CheckBox check, string settings) 
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(filePath: settings);
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

		public void openFolderDialog(String fileBox)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			DialogResult result = fbd.ShowDialog();
			if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
			{
				fileBox = fbd.SelectedPath;
			}

		}


		public void SaveUserSettingsDisablebtn(CheckBox checker, string settings)
		{

			if (!File.Exists(settings))
			{
				File.Create(settings);
			}
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(settings);
			if (checker.Checked)
			{
				var directValue = data["CheckSaveState"]["disablemods"] = "1";
				parser.WriteFile(settings, data);
			}
			else
			{
				var directValue = data["CheckSaveState"]["disablemods"] = "0";
				parser.WriteFile(settings, data);
			}
		}

		public void readUserSettingsDisableBtn(CheckBox check, string settings)
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(settings);
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
		public void SaveUserSettingsaltbtn(CheckBox checker, string settings)
		{

			if (!File.Exists(settings))
			{
				File.Create(settings);
			}
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(settings);
			if (checker.Checked)
			{
				var directValue = data["CheckSaveState"]["altbtn"] = "1";
				parser.WriteFile(settings, data);
			}
			else
			{
				var directValue = data["CheckSaveState"]["altbtn"] = "0";
				parser.WriteFile(settings, data);
			}
		}

		public void readUserSettingsaltBtn(CheckBox check,string settings)
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(settings);
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

		public void setFolderPath(string FOLDER_PATH, string newFolderPath)
		{

			FOLDER_PATH = newFolderPath;
		}


	}
}