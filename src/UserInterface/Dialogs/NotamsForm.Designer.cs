namespace FlightPlanner.UserInterface.Dialogs {
	partial class NotamsForm {
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
			this.lvwNotams = new System.Windows.Forms.ListView();
			this.clnNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.txtNotam = new System.Windows.Forms.TextBox();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwNotams
			// 
			this.lvwNotams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lvwNotams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnNumber,
            this.clnArea,
            this.clnYear,
            this.clnText});
			this.lvwNotams.FullRowSelect = true;
			this.lvwNotams.GridLines = true;
			this.lvwNotams.Location = new System.Drawing.Point(12, 12);
			this.lvwNotams.MultiSelect = false;
			this.lvwNotams.Name = "lvwNotams";
			this.lvwNotams.ShowItemToolTips = true;
			this.lvwNotams.Size = new System.Drawing.Size(414, 349);
			this.lvwNotams.TabIndex = 0;
			this.lvwNotams.UseCompatibleStateImageBehavior = false;
			this.lvwNotams.View = System.Windows.Forms.View.Details;
			this.lvwNotams.SelectedIndexChanged += new System.EventHandler(this.lvwNotams_SelectedIndexChanged);
			// 
			// clnNumber
			// 
			this.clnNumber.Text = "Number";
			// 
			// clnArea
			// 
			this.clnArea.Text = "Area";
			// 
			// clnYear
			// 
			this.clnYear.Text = "Year";
			// 
			// clnText
			// 
			this.clnText.Text = "Text";
			this.clnText.Width = 200;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 375);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(864, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tslStatus
			// 
			this.tslStatus.Name = "tslStatus";
			this.tslStatus.Size = new System.Drawing.Size(39, 17);
			this.tslStatus.Text = "Ready";
			// 
			// txtNotam
			// 
			this.txtNotam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNotam.BackColor = System.Drawing.Color.White;
			this.txtNotam.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNotam.Location = new System.Drawing.Point(432, 12);
			this.txtNotam.Multiline = true;
			this.txtNotam.Name = "txtNotam";
			this.txtNotam.ReadOnly = true;
			this.txtNotam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNotam.Size = new System.Drawing.Size(420, 349);
			this.txtNotam.TabIndex = 2;
			// 
			// NotamsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(864, 397);
			this.Controls.Add(this.txtNotam);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.lvwNotams);
			this.MinimizeBox = false;
			this.Name = "NotamsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Notams";
			this.Shown += new System.EventHandler(this.NotamsForm_Shown);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lvwNotams;
		private System.Windows.Forms.ColumnHeader clnArea;
		private System.Windows.Forms.ColumnHeader clnNumber;
		private System.Windows.Forms.ColumnHeader clnYear;
		private System.Windows.Forms.ColumnHeader clnText;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tslStatus;
		private System.Windows.Forms.TextBox txtNotam;
	}
}