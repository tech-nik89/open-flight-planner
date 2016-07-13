using FlightPlanner.Common;
using FlightPlanner.Configuration;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace FlightPlanner.UserInterface.Controls {
    public partial class CountriesControl : UserControl {

        private readonly Country[] _Countries;

		public Boolean Changed { get; private set; }

        public CountriesControl() {
            InitializeComponent();

            _Countries = ((IEnumerable<Country>)Enum
                .GetValues(typeof(Country))).Where(c => c != Country.Undefined)
                .OrderBy(c => c.ToString())
                .ToArray();

            FillCountryList();
        }

		private void ApplyLocalization() {
			clnName.Text = Strings.CountryName;
		}
		
		private void FillCountryList() {
            if (Config.Current == null) {
                return;
            }

            lvwCountries.Items.Clear();

            foreach(Country country in _Countries) {
                ListViewItem item = new ListViewItem(country.ToString());
                item.Checked = Config.Current.Countries.Contains(country);

                lvwCountries.Items.Add(item);
            }
        }

        private void lvwCountries_ItemCheck(object sender, ItemCheckEventArgs e) {
            Country country = _Countries[e.Index];

            if (e.NewValue == CheckState.Checked && !Config.Current.Countries.Contains(country)) {
                Config.Current.Countries.Add(country);
            }
            else if (e.NewValue == CheckState.Unchecked && Config.Current.Countries.Contains(country)) {
                Config.Current.Countries.Remove(country);
            }

            Config.Save();
			Changed = true;
		}
    }
}
