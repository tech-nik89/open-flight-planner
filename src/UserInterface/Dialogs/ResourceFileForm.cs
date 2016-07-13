using FlightPlanner.Configuration;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace FlightPlanner.UserInterface.Dialogs {
    public partial class ResourceFileForm : Form {

        public DataFile DataFile { get; private set; }

        private static readonly Regex _UrlRegex = new Regex(@"https?:\/\/.*");

        public ResourceFileForm() 
            : this(null) {
        }

        public ResourceFileForm(DataFile file) {
            InitializeComponent();
			ApplyLocalization();

            DataFile = file;
			rbLocationOnline.Checked = DataFile == null;

			FillTypeDropDown();
            ApplyFileToFields();
			ApplyDependentControlProperties();
        }

		private void ApplyLocalization() {
			Text = Strings.ResourceFiles;
			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			lblType.Text = String.Format("{0}:", Strings.Type);
			lblName.Text = String.Format("{0}:", Strings.Name);
			lblVisible.Text = String.Format("{0}:", Strings.Visible);
			lblLocation.Text = String.Format("{0}:", Strings.Location);

			rbLocationOnline.Text = Strings.Online;
			rbLocationLocal.Text = Strings.Local;
		}

		private void ApplyDependentControlProperties() {
			if (rbLocationOnline.Checked) {
				lblPath.Text = String.Format("{0}:", Strings.URL);
				btnBrowse.Enabled = false;
			}
			else if (rbLocationLocal.Checked) {
				lblPath.Text = String.Format("{0}:", Strings.Path);
				btnBrowse.Enabled = true;
			}
		}

		private void FillTypeDropDown() {
            cbxType.Items.Clear();
            foreach (Type type in DataFile.DataFileTypes) {
                cbxType.Items.Add(type.Name);
            }
        }

        private void ApplyFileToFields() {
            if (DataFile == null) {
                return;
            }

            txtName.Text = DataFile.Name;
            txtPath.Text = DataFile.Path;
            chkVisible.Checked = DataFile.Visible;

            for (Int32 i = 0; i < DataFile.DataFileTypes.Count(); i++) {
                if (DataFile.DataFileTypes.ElementAt(i).FullName == DataFile.GetType().FullName) {
                    cbxType.SelectedIndex = i;
                    break;
                }
            }

			rbLocationOnline.Checked = DataFile.IsOnlineFile;
			rbLocationLocal.Checked = !DataFile.IsOnlineFile;
        }

        private void ApplyFieldsToFile() {
			if (DataFile == null) {
				DataFile = DataFile.CreateDataFile(cbxType.SelectedIndex);
			}

            if (DataFile == null) {
                return;
            }

            DataFile.Path = txtPath.Text;
            DataFile.Name = txtName.Text;
            DataFile.Visible = chkVisible.Checked;
        }

        private Boolean ValidateFields() {
            if (cbxType.SelectedIndex == -1) {
                ShowValidationMessage("Please select a resource type.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtName.Text)) {
                ShowValidationMessage("Please specify a name.");
                return false;
            }

            if (rbLocationOnline.Checked && !_UrlRegex.IsMatch(txtPath.Text)) {
                ShowValidationMessage("Please enter a valid URL.");
                return false;
            }

			if (rbLocationLocal.Checked) {
				FileInfo info = new FileInfo(txtPath.Text);
				if (!info.Exists) {
					ShowValidationMessage("The specified file does not exist.");
					return false;
				}
			}

			return true;
        }

        private static void ShowValidationMessage(String message) {
            MessageBox.Show(message, "Invalid field", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            if (!ValidateFields()) {
                return;
            }

            ApplyFieldsToFile();
			if (!DataFile.IsOnlineFile) {
				DataFile.CopyLocal();
			}

            DialogResult = DialogResult.OK;
            Close();
        }

		private void rbLocation_CheckedChanged(object sender, EventArgs e) {
			ApplyDependentControlProperties();
		}

		private void btnBrowse_Click(object sender, EventArgs e) {
			if (cbxType.SelectedIndex < 0) {
				return;
			}

			DataFile file = DataFile.CreateDataFile(cbxType.SelectedIndex);
			Type type = file.GetType();

			ofdOpen.Filter = String.Format("{0}-Files (*.{1})|*.{1}", type.Name, file.FileExtension);
			DialogResult result = ofdOpen.ShowDialog();

			if (result != DialogResult.OK) {
				return;
			}

			txtPath.Text = ofdOpen.FileName;
		}
	}
}
