using FlightPlanner.Configuration;
using FlightPlanner.Ressources;
using FlightPlanner.UserInterface.Dialogs;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Controls {
    public partial class ResourcesControl : UserControl {

		public Boolean Changed { get; private set; }

        public ResourcesControl() {
            InitializeComponent();
			ApplyLocalization();
            UpdateList();
        }

		private void ApplyLocalization() {
			tsbAdd.Text = Strings.Add;
			tsbEdit.Text = Strings.Edit;
			tsbRemove.Text = Strings.Remove;
			tsbUpdate.Text = Strings.Update;
			tsbUpdate.ToolTipText = Strings.UpdateOnlineRessources;

			clnName.Text = Strings.ResourceName;
			clnVisible.Text = Strings.Visible;
			clnPath.Text = Strings.Path;
		}

		private void UpdateList() {
            if(Config.Current == null) {
                return;
            }

            lvwResources.Items.Clear();
			lvwResources.Groups.Clear();

			ListViewGroup groupWelt2k = new ListViewGroup("WELT 2000");
			lvwResources.Groups.Add(groupWelt2k);

			ListViewGroup groupOpenAir = new ListViewGroup("Open Air");
			lvwResources.Groups.Add(groupOpenAir);

            foreach (DataFile file in Config.Current.RessourceFiles) {
                String[] fields = new String[] {
                    file.Name,
                    file.Visible ? Strings.Yes : Strings.No,
                    file.Path
                };

                ListViewItem item = new ListViewItem(fields);

				if (file is OpenAirFile) {
					item.Group = groupOpenAir;
				}
				else if (file is Welt2kFile) {
					item.Group = groupWelt2k;
				}

                lvwResources.Items.Add(item);
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e) {
            ResourceFileForm form = new ResourceFileForm();
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.OK) {
                return;
            }

            Config.Current.RessourceFiles.Add(form.DataFile);
            Config.Save();

			Changed = true;
            UpdateList();
        }
		
		private void tsbEdit_Click(object sender, EventArgs e) {
            if (lvwResources.SelectedItems.Count == 0) {
                return;
            }

            Int32 index = lvwResources.SelectedItems[0].Index;
            ResourceFileForm form = new ResourceFileForm(Config.Current.RessourceFiles[index]);
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.OK) {
                return;
            }

            Config.Current.RessourceFiles[index] = form.DataFile;
            Config.Save();

			Changed = true;
			UpdateList();
        }

        private void tsbRemove_Click(object sender, EventArgs e) {
            if (lvwResources.SelectedItems.Count == 0) {
                return;
            }

            if (MessageBox.Show(
				Strings.RemoveFileConfirm,
				Strings.RemoveConfirm,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) != DialogResult.Yes) {

                return;
            }

            Config.Current.RessourceFiles.RemoveAt(lvwResources.SelectedItems[0].Index);
            Config.Save();

			Changed = true;
			UpdateList();
        }

		private void tsbUpdate_Click(object sender, EventArgs e) {
			BackgroundWorker worker = new BackgroundWorker();

			worker.DoWork += (s, args) => {
				RessourceManager.UpdateAll();
			};

			worker.RunWorkerCompleted += (s, args) => {
				tsbUpdate.Enabled = true;
			};

			tsbUpdate.Enabled = false;
			worker.RunWorkerAsync();
		}
	}
}
