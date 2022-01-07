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

	 class FolderOperations : Form1
	{

		public string fileBox
		{

			get { return urlBox.Text; }
			set { urlBox.Text = value; }

		}
		public void readDirectory(string path)
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(path);
			var directValue = data["files"]["DS3Dir"];
			if (!fileBox.Contains("Game"))
			{
				fileBox += directValue;
			}
		}

		public void readUserSettings(CheckBox check) 
		{
			var parser = new FileIniDataParser();
			IniData data = parser.ReadFile(filePath: SETTINGS_PATH);
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

	}
}