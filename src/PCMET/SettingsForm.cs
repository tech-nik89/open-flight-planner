using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightPlanner.PCMET {
	public partial class SettingsForm : Form {
		public SettingsForm() {
			InitializeComponent();

			LoadSettings();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			SaveSettings();
			Close();
		}

		private void LoadSettings() {
			if (Constants.Configuration.ContainsKey(Constants.SettingUserName)) {
				txtUserName.Text = (String)Constants.Configuration[Constants.SettingUserName];
			}

			if (Constants.Configuration.ContainsKey(Constants.SettingPassword)) {
				txtPassword.Text = (String)Constants.Configuration[Constants.SettingPassword];
			}
		}

		private void SaveSettings() {
			Constants.Configuration[Constants.SettingUserName] = txtUserName.Text;
			Constants.Configuration[Constants.SettingPassword] = txtPassword.Text;
		}
	}
}
