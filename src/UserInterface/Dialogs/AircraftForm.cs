using FlightPlanner.Aircrafts;
using FlightPlanner.Units;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class AircraftForm : Form {

        private readonly Properties _Properties;
        private readonly Aircraft _Aircraft;

        public Aircraft Aircraft {
            get {
                return _Aircraft;
            }
        }

        public AircraftForm() 
            : this(new Aircraft()) {
        }

        public AircraftForm(Aircraft aircraft) {
            InitializeComponent();
			ApplyLocalization();

			_Aircraft = aircraft;
            _Properties = new Properties();

            pgProperties.SelectedObject = _Properties;

            ApplyAircraftToFields();
        }

		private void ApplyLocalization() {
			Text = Strings.Aircraft;
			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			lblRegistration.Text = Strings.Registration;
			lblType.Text = Strings.Type;

			tabProperties.Text = Strings.Properties;
			tabStations.Text = Strings.LoadingStations;
			tabFuelTanks.Text = Strings.FuelTanks;
			tabCenterOfGravity.Text = Strings.CenterOfGravity;
			tabPerformance.Text = Strings.CruisePerformance;

			clnStationName.HeaderText = Strings.Name;
			clnStationArm.HeaderText = Strings.LeverArm;

			clnFuelTankName.HeaderText = Strings.Name;
			clnFuelTankArm.HeaderText = Strings.LeverArm;
			clnFuelTankCapacity.HeaderText = Strings.Capacity;

			clnMass.HeaderText = Strings.Mass;
			clnForwardLimit.HeaderText = Strings.ForwardLimit;
			clnAftLimit.HeaderText = Strings.AftLimit;

			clnAltitude.HeaderText = Strings.PressureAltitude;
			clnTrueAirspeed.HeaderText = Strings.TrueAirspeed;
			clnFuelFlow.HeaderText = Strings.FuelFlow;
		}

        private void ApplyAircraftToFields() {
            txtRegistration.Text = _Aircraft.Registration;
            txtType.Text = _Aircraft.Type;

            _Properties.EmptyMass = _Aircraft.EmptyMass;
            _Properties.EmptyMoment = _Aircraft.EmptyMoment;

            _Properties.StartupTaxiFuel = _Aircraft.StartupAndTaxiFuel;
            _Properties.AverageFuelFlow = _Aircraft.AverageFuelFlow;
            _Properties.FuelType = _Aircraft.FuelType;

            dgvStations.Rows.Clear();
            foreach (LoadingStation station in _Aircraft.GetLoadingStations()) {
                dgvStations.Rows.Add(station.Name, station.Arm);
            }

            dgvFuelTanks.Rows.Clear();
            foreach (FuelTank station in _Aircraft.GetFuelTanks()) {
                dgvFuelTanks.Rows.Add(station.Name, station.Arm, station.Capacity);
            }

            dgvCenterOfGravity.Rows.Clear();
            foreach (CenterOfGravityLimit limit in _Aircraft.CenterOfGravityLimits) {
                dgvCenterOfGravity.Rows.Add(limit.Mass, limit.ForwardLimit, limit.AftLimit);
            }

            dgvPerformance.Rows.Clear();
            foreach (Performance performance in _Aircraft.CruisePerformance) {
                dgvPerformance.Rows.Add(
					performance.PressureAltitude != null ? performance.PressureAltitude.Feet : -1,
					performance.Airspeed != null ? performance.Airspeed.Knots : -1,
					performance.FuelFlow);
            }
        }

        private void ApplyFieldsToAircraft() {
            _Aircraft.Registration = txtRegistration.Text;
            _Aircraft.Type = txtType.Text;

            _Aircraft.EmptyMass = _Properties.EmptyMass;
            _Aircraft.EmptyMoment = _Properties.EmptyMoment;

            _Aircraft.StartupAndTaxiFuel = _Properties.StartupTaxiFuel;
            _Aircraft.AverageFuelFlow = _Properties.AverageFuelFlow;
            _Aircraft.FuelType = _Properties.FuelType;

            _Aircraft.LoadingStations.Clear();
            foreach (DataGridViewRow row in dgvStations.Rows) {
                if (row.IsNewRow) {
                    continue;
                }

                LoadingStation station = new LoadingStation() {
                    Name = Convert.ToString(row.Cells[0].Value),
                    Arm = Convert.ToDouble(row.Cells[1].Value)
                };

                _Aircraft.LoadingStations.Add(station);
            }

            foreach (DataGridViewRow row in dgvFuelTanks.Rows) {
                if (row.IsNewRow) {
                    continue;
                }

                FuelTank station = new FuelTank() {
                    Name = Convert.ToString(row.Cells[0].Value),
                    Arm = Convert.ToDouble(row.Cells[1].Value),
                    Capacity = Convert.ToDouble(row.Cells[2].Value)
                };

                _Aircraft.LoadingStations.Add(station);
            }

            _Aircraft.CenterOfGravityLimits.Clear();
            foreach (DataGridViewRow row in dgvCenterOfGravity.Rows) {
                if (row.IsNewRow) {
                    continue;
                }

                CenterOfGravityLimit limit = new CenterOfGravityLimit() {
                    Mass = Convert.ToDouble(row.Cells[0].Value),
                    ForwardLimit = Convert.ToDouble(row.Cells[1].Value),
                    AftLimit = Convert.ToDouble(row.Cells[2].Value)
                };

                _Aircraft.CenterOfGravityLimits.Add(limit);
            }

            _Aircraft.CruisePerformance.Clear();
            foreach (DataGridViewRow row in dgvPerformance.Rows) {
                if (row.IsNewRow) {
                    continue;
                }

                Performance performance = new Performance() {
                    PressureAltitude = new Altitude(Altitude.Unit.Feet, Convert.ToDouble(row.Cells[0].Value)),
                    Airspeed = new Airspeed(Convert.ToInt32(row.Cells[1].Value)),
                    FuelFlow = Convert.ToDouble(row.Cells[2].Value)
                };

                _Aircraft.CruisePerformance.Add(performance);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            ApplyFieldsToAircraft();
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    class Properties {

        [Category("Weighing")]
        [DisplayName("Empty Mass")]
        public Double EmptyMass { get; set; }

        [Category("Weighing")]
        [DisplayName("Empty Moment")]
        public Double EmptyMoment { get; set; }

        [Category("Fuel")]
        [DisplayName("Startup and Taxi")]
        public Double StartupTaxiFuel { get; set; }

        [Category("Fuel")]
        [DisplayName("Average fuel flow")]
        public Double AverageFuelFlow { get; set; }

        [Category("Fuel")]
        [DisplayName("Type")]
        public Aircraft.TypeOfFuel FuelType { get; set; }

    }
}
