namespace FlightPlanner.UserInterface.Dialogs {
	partial class AirfieldDetailsForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.lblICAO = new System.Windows.Forms.Label();
			this.txtICAO = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.txtCoordinates = new System.Windows.Forms.TextBox();
			this.lblCoordinates = new System.Windows.Forms.Label();
			this.txtElevation = new System.Windows.Forms.TextBox();
			this.lblElevation = new System.Windows.Forms.Label();
			this.lvwRunways = new System.Windows.Forms.ListView();
			this.clnRunwayDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnRunwayLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnRunwaySurface = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblRunways = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtFrequency = new System.Windows.Forms.TextBox();
			this.lblFrequency = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblICAO
			// 
			this.lblICAO.AutoSize = true;
			this.lblICAO.Location = new System.Drawing.Point(21, 20);
			this.lblICAO.Name = "lblICAO";
			this.lblICAO.Size = new System.Drawing.Size(35, 13);
			this.lblICAO.TabIndex = 0;
			this.lblICAO.Text = "ICAO:";
			// 
			// txtICAO
			// 
			this.txtICAO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtICAO.Location = new System.Drawing.Point(110, 17);
			this.txtICAO.Name = "txtICAO";
			this.txtICAO.ReadOnly = true;
			this.txtICAO.Size = new System.Drawing.Size(303, 20);
			this.txtICAO.TabIndex = 1;
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(110, 43);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(303, 20);
			this.txtName.TabIndex = 3;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(21, 46);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "Name:";
			// 
			// txtCoordinates
			// 
			this.txtCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCoordinates.Location = new System.Drawing.Point(110, 69);
			this.txtCoordinates.Name = "txtCoordinates";
			this.txtCoordinates.ReadOnly = true;
			this.txtCoordinates.Size = new System.Drawing.Size(303, 20);
			this.txtCoordinates.TabIndex = 5;
			// 
			// lblCoordinates
			// 
			this.lblCoordinates.AutoSize = true;
			this.lblCoordinates.Location = new System.Drawing.Point(21, 72);
			this.lblCoordinates.Name = "lblCoordinates";
			this.lblCoordinates.Size = new System.Drawing.Size(66, 13);
			this.lblCoordinates.TabIndex = 4;
			this.lblCoordinates.Text = "Coordinates:";
			// 
			// txtElevation
			// 
			this.txtElevation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtElevation.Location = new System.Drawing.Point(110, 95);
			this.txtElevation.Name = "txtElevation";
			this.txtElevation.ReadOnly = true;
			this.txtElevation.Size = new System.Drawing.Size(303, 20);
			this.txtElevation.TabIndex = 7;
			// 
			// lblElevation
			// 
			this.lblElevation.AutoSize = true;
			this.lblElevation.Location = new System.Drawing.Point(21, 98);
			this.lblElevation.Name = "lblElevation";
			this.lblElevation.Size = new System.Drawing.Size(54, 13);
			this.lblElevation.TabIndex = 6;
			this.lblElevation.Text = "Elevation:";
			// 
			// lvwRunways
			// 
			this.lvwRunways.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwRunways.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnRunwayDirection,
            this.clnRunwayLength,
            this.clnRunwaySurface});
			this.lvwRunways.FullRowSelect = true;
			this.lvwRunways.Location = new System.Drawing.Point(110, 147);
			this.lvwRunways.Name = "lvwRunways";
			this.lvwRunways.Size = new System.Drawing.Size(303, 118);
			this.lvwRunways.TabIndex = 8;
			this.lvwRunways.UseCompatibleStateImageBehavior = false;
			this.lvwRunways.View = System.Windows.Forms.View.Details;
			// 
			// clnRunwayDirection
			// 
			this.clnRunwayDirection.Text = "Direction";
			this.clnRunwayDirection.Width = 90;
			// 
			// clnRunwayLength
			// 
			this.clnRunwayLength.Text = "Length";
			this.clnRunwayLength.Width = 90;
			// 
			// clnRunwaySurface
			// 
			this.clnRunwaySurface.Text = "Surface";
			this.clnRunwaySurface.Width = 90;
			// 
			// lblRunways
			// 
			this.lblRunways.AutoSize = true;
			this.lblRunways.Location = new System.Drawing.Point(21, 152);
			this.lblRunways.Name = "lblRunways";
			this.lblRunways.Size = new System.Drawing.Size(54, 13);
			this.lblRunways.TabIndex = 9;
			this.lblRunways.Text = "Runways:";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(313, 271);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Close";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtFrequency
			// 
			this.txtFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFrequency.Location = new System.Drawing.Point(110, 121);
			this.txtFrequency.Name = "txtFrequency";
			this.txtFrequency.ReadOnly = true;
			this.txtFrequency.Size = new System.Drawing.Size(303, 20);
			this.txtFrequency.TabIndex = 12;
			// 
			// lblFrequency
			// 
			this.lblFrequency.AutoSize = true;
			this.lblFrequency.Location = new System.Drawing.Point(21, 124);
			this.lblFrequency.Name = "lblFrequency";
			this.lblFrequency.Size = new System.Drawing.Size(60, 13);
			this.lblFrequency.TabIndex = 11;
			this.lblFrequency.Text = "Frequency:";
			// 
			// AirfieldDetailsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(438, 308);
			this.Controls.Add(this.txtFrequency);
			this.Controls.Add(this.lblFrequency);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblRunways);
			this.Controls.Add(this.lvwRunways);
			this.Controls.Add(this.txtElevation);
			this.Controls.Add(this.lblElevation);
			this.Controls.Add(this.txtCoordinates);
			this.Controls.Add(this.lblCoordinates);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.txtICAO);
			this.Controls.Add(this.lblICAO);
			this.MinimizeBox = false;
			this.Name = "AirfieldDetailsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Airfield";
			this.Load += new System.EventHandler(this.AirfieldDetailsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblICAO;
		private System.Windows.Forms.TextBox txtICAO;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtCoordinates;
		private System.Windows.Forms.Label lblCoordinates;
		private System.Windows.Forms.TextBox txtElevation;
		private System.Windows.Forms.Label lblElevation;
		private System.Windows.Forms.ListView lvwRunways;
		private System.Windows.Forms.ColumnHeader clnRunwayDirection;
		private System.Windows.Forms.ColumnHeader clnRunwayLength;
		private System.Windows.Forms.ColumnHeader clnRunwaySurface;
		private System.Windows.Forms.Label lblRunways;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtFrequency;
		private System.Windows.Forms.Label lblFrequency;
	}
}