using FlightPlanner.Weather.MetarTaf;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class MetarTafDetailsForm : Form {

		private readonly MetarTafInfo _MetarTafInfo;

		public MetarTafDetailsForm(MetarTafInfo info) {
			InitializeComponent();
			ApplyLocalization();

			_MetarTafInfo = info;
			txtMetar.Text = _MetarTafInfo.Metar.Raw;
			txtTaf.Text = _MetarTafInfo.Taf.Raw;
		}

		private void ApplyLocalization() {
			Text = Strings.MetarTafDetails;
			btnAccept.Text = Strings.Close;
		}

		private void btnAccept_Click(object sender, System.EventArgs e) {
			Close();
		}
	}
}
