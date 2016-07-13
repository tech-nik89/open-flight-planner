using FlightPlanner.Tools;
using System;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class AboutForm : Form {
		public AboutForm() {
			InitializeComponent();
			ApplyLocalization();

			lblVersion.Text = Utilities.GetVersion();
		}

		private void ApplyLocalization() {
			Text = Strings.Info;

			lblVersionTitle.Text = String.Format("{0}:", Strings.Version);
			lblThirdpartyComponents.Text = String.Format("{0}:", Strings.ThirdpartyComponents);
			lblDisclaimer.Text = String.Format("{0}:", Strings.Disclaimer);
		}
	}
}
