namespace FlightPlanner.UserInterface.Controls {
    partial class WindControl {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
			this.numDirection = new System.Windows.Forms.NumericUpDown();
			this.lblDirection = new System.Windows.Forms.Label();
			this.lblSpeed = new System.Windows.Forms.Label();
			this.numSpeed = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numDirection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
			this.SuspendLayout();
			// 
			// numDirection
			// 
			this.numDirection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numDirection.Location = new System.Drawing.Point(0, 3);
			this.numDirection.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.numDirection.Name = "numDirection";
			this.numDirection.Size = new System.Drawing.Size(90, 20);
			this.numDirection.TabIndex = 0;
			this.numDirection.ValueChanged += new System.EventHandler(this.numDirection_ValueChanged);
			// 
			// lblDirection
			// 
			this.lblDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDirection.AutoSize = true;
			this.lblDirection.Location = new System.Drawing.Point(96, 5);
			this.lblDirection.Name = "lblDirection";
			this.lblDirection.Size = new System.Drawing.Size(11, 13);
			this.lblDirection.TabIndex = 1;
			this.lblDirection.Text = "°";
			// 
			// lblSpeed
			// 
			this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSpeed.AutoSize = true;
			this.lblSpeed.Location = new System.Drawing.Point(211, 5);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(16, 13);
			this.lblSpeed.TabIndex = 2;
			this.lblSpeed.Text = "kt";
			// 
			// numSpeed
			// 
			this.numSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numSpeed.Location = new System.Drawing.Point(118, 3);
			this.numSpeed.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.numSpeed.Name = "numSpeed";
			this.numSpeed.Size = new System.Drawing.Size(87, 20);
			this.numSpeed.TabIndex = 3;
			this.numSpeed.ValueChanged += new System.EventHandler(this.numSpeed_ValueChanged);
			// 
			// WindControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.numSpeed);
			this.Controls.Add(this.lblSpeed);
			this.Controls.Add(this.lblDirection);
			this.Controls.Add(this.numDirection);
			this.Name = "WindControl";
			this.Size = new System.Drawing.Size(232, 27);
			((System.ComponentModel.ISupportInitialize)(this.numDirection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.NumericUpDown numSpeed;
    }
}
