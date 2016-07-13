using FlightPlanner.Common;
using System;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Controls {
    public partial class WindControl : UserControl {

        public event EventHandler WindChanged;

        private Wind _Wind;

        private Boolean _DisableEvents = false;

        public Wind Wind {
            get {
                SetWindFromFields();
                return _Wind;
            }
            set {
                _Wind = value;
                SetFieldsFromWind();
            }
        }

        public WindControl()
            : this(new Wind()) {
        }

        public WindControl(Wind wind) {
            InitializeComponent();
            Wind = wind;
        }

        private void SetFieldsFromWind() {
            if (_Wind == null) {
                return;
            }

            _DisableEvents = true;
            
            numDirection.Value = _Wind.Direction;
            numSpeed.Value = _Wind.Speed;

            _DisableEvents = false;
        }

        private void SetWindFromFields() {
            if (_Wind == null) {
                return;
            }

            _Wind.Direction = (Int32)numDirection.Value;
            _Wind.Speed = (Int32)numSpeed.Value;
        }

        private void numDirection_ValueChanged(object sender, EventArgs e) {
            FireWindChangedEvent();
        }

        private void numSpeed_ValueChanged(object sender, EventArgs e) {
            FireWindChangedEvent();
        }

        private void FireWindChangedEvent() {
            if (_DisableEvents || WindChanged == null) {
                return;
            }

            WindChanged(this, new EventArgs());
        }
    }
}
