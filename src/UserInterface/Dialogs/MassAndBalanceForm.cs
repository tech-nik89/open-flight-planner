using FlightPlanner.Aircrafts;
using FlightPlanner.Briefing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FlightPlanner.UserInterface.Dialogs {
    public partial class MassAndBalanceForm : Form {

        private readonly FlightPlan _FlightPlan;
        private Boolean _Initializing;

        public MassAndBalanceForm(FlightPlan flightPlan) {
            InitializeComponent();
			InitializeIcon();
			ApplyLocalization();

            _FlightPlan = flightPlan;
            _Initializing = true;

            AddStations();
            UpdateMassAndBalance();

            _Initializing = false;
        }

		private void InitializeIcon() {
			Bitmap bitmap = UserInterface.Properties.Resources.Loading;
			Icon = Icon.FromHandle(bitmap.GetHicon());
		}

		private void ApplyLocalization() {
			Text = Strings.MassAndBalance;

			clnName.HeaderText = Strings.Name;
			clnLeverArm.HeaderText = Strings.LeverArm;
			clnMass.HeaderText = Strings.Mass;
			clnFuelTankSize.HeaderText = Strings.Capacity;

			tabMass.Text = Strings.Mass;
			tabFuel.Text = Strings.Fuel;
		}

		private void AddStations() {
            dgvStations.Rows.Clear();

            foreach (LoadingStation station in _FlightPlan.Aircraft.LoadingStations) {
                Double mass = 0;

                if (_FlightPlan.Loading.ContainsKey(station)) {
                    mass = _FlightPlan.Loading[station];
                }

                String max = String.Empty;
                if (station is FuelTank) {
                    FuelTank fuelTank = (FuelTank)station;

					if (_FlightPlan.FuelTanks.ContainsKey(fuelTank)) {
						mass = _FlightPlan.FuelTanks[fuelTank];
					}

                    max = String.Format("{0:0.0}", fuelTank.Capacity);
                }
                
                dgvStations.Rows.Add(station.Name, station.Arm.ToString(), mass, max);
            }
        }

        private void DrawChart() {
            crtCenterOfGravity.Series.Clear();

            Series series = new Series("Center of gravity limits");
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.DarkGray;
            series.MarkerStyle = MarkerStyle.Square;

            List<System.Windows.Point> points = _FlightPlan.Aircraft.CenterOfGravityLimits.GetLimitPoints();
            foreach (System.Windows.Point point in points) {
                series.Points.Add(new DataPoint(point.X, point.Y));
            }

            crtCenterOfGravity.Series.Add(series);
        }

        private void DrawChart(MassAndBalance mab) {
            DrawChart();

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.DarkRed;
            series.MarkerStyle = MarkerStyle.Cross;
            series.MarkerSize = 10;

            series.Points.Add(new DataPoint(mab.TakeOff.Arm, mab.TakeOff.Mass));
            series.Points.Add(new DataPoint(mab.Landing.Arm, mab.Landing.Mass));

            crtCenterOfGravity.Series.Add(series);
        }

		private void UpdateMassDetails(MassAndBalance mab) {
			lvwMass.Items.Clear();

			UpdateMassDetailsItem(mab.Empty);
			UpdateMassDetailsItem(mab.DryOperating);
			UpdateMassDetailsItem(mab.Ramp);
			UpdateMassDetailsItem(mab.TakeOff);
			UpdateMassDetailsItem(mab.Landing);
		}

		private void UpdateFuelDetails(MassAndBalance mab) {
			lvwFuel.Items.Clear();

			UpdateFuelDetailsItem(Strings.RampMass, mab.RampFuel);
			UpdateFuelDetailsItem(Strings.StartupAndTaxiMass, mab.StartupAndTaxiFuel);
			UpdateFuelDetailsItem(Strings.TakeOffMass, mab.TakeOffFuel, true);
			UpdateFuelDetailsItem(Strings.TripFuelMass, mab.TripFuel);
			UpdateFuelDetailsItem(Strings.LandingMass, mab.LandingFuel, true);
			UpdateFuelDetailsItem(Strings.AlternateMass, mab.AlternateFuel);
			UpdateFuelDetailsItem(Strings.FinalReserveMass, mab.FinalReserveFuel);
			UpdateFuelDetailsItem(Strings.ExtraFuelMass, mab.ExtraFuel, true);
		}

		private void UpdateMassDetailsItem(MassAndBalanceItem item) {
			String value = Math.Round(item.Mass, 1).ToString("0.0");
			lvwMass.Items.Add(new ListViewItem(new String[] { item.Name, value }));
		}

		private void UpdateFuelDetailsItem(String name, Double fuel, Boolean colorize = false) {
			String value = Math.Round(fuel, 1).ToString("0.0");
			ListViewItem item = new ListViewItem(new String[] { name, value });

			if (colorize) {
				if (fuel < 0) {
					item.ForeColor = Color.DarkRed;
				}
				else if (fuel > 0){
					item.ForeColor = Color.DarkGreen;
				}
			}

			lvwFuel.Items.Add(item);
		}

		private void dgvStations_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (_Initializing || e.RowIndex == -1 || e.ColumnIndex == -1) {
                return;
            }

            LoadingStation station = _FlightPlan.Aircraft.LoadingStations[e.RowIndex];
            Double mass = 0;

            DataGridViewCell cell = dgvStations.Rows[e.RowIndex].Cells[clnMass.Index];
            try {
                mass = Convert.ToDouble(cell.Value);
            }
            catch {
            }

            if (station is FuelTank) {
                FuelTank fuelTank = (FuelTank)station;
                Double fuel = mass;

                if (fuel > fuelTank.Capacity) {
                    fuel = fuelTank.Capacity;
                    cell.Value = fuel;
                }

                _FlightPlan.FuelTanks[fuelTank] = fuel;
            }
            else {
                _FlightPlan.Loading[station] = mass;
            }
            
            UpdateMassAndBalance();
        }

        private void UpdateMassAndBalance() {
            MassAndBalance mab = MassAndBalance.Create(_FlightPlan);
            DrawChart(mab);
			UpdateMassDetails(mab);
			UpdateFuelDetails(mab);
        }
    }
}
