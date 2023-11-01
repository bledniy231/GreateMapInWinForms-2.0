namespace FourthTask.Forms
{
	partial class MarkerInfoForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.pointNameLabel = new System.Windows.Forms.Label();
			this.longitudeLabel = new System.Windows.Forms.Label();
			this.latitudeLabel = new System.Windows.Forms.Label();
			this.pointNameLabelForFill = new System.Windows.Forms.Label();
			this.latitudeLabelForFill = new System.Windows.Forms.Label();
			this.deletePointFromMapButton = new System.Windows.Forms.Button();
			this.exitPointInfoFormButton = new System.Windows.Forms.Button();
			this.longitudeLabelForFill = new System.Windows.Forms.Label();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.Controls.Add(this.pointNameLabel, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.longitudeLabel, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.latitudeLabel, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.pointNameLabelForFill, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.latitudeLabelForFill, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.deletePointFromMapButton, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.exitPointInfoFormButton, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.longitudeLabelForFill, 1, 2);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 4;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(387, 303);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// pointNameLabel
			// 
			this.pointNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pointNameLabel.AutoSize = true;
			this.pointNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pointNameLabel.Location = new System.Drawing.Point(38, 28);
			this.pointNameLabel.Name = "pointNameLabel";
			this.pointNameLabel.Size = new System.Drawing.Size(116, 18);
			this.pointNameLabel.TabIndex = 0;
			this.pointNameLabel.Text = "Название точки";
			// 
			// longitudeLabel
			// 
			this.longitudeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.longitudeLabel.AutoSize = true;
			this.longitudeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.longitudeLabel.Location = new System.Drawing.Point(65, 178);
			this.longitudeLabel.Name = "longitudeLabel";
			this.longitudeLabel.Size = new System.Drawing.Size(63, 18);
			this.longitudeLabel.TabIndex = 2;
			this.longitudeLabel.Text = "Долгота";
			// 
			// latitudeLabel
			// 
			this.latitudeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.latitudeLabel.AutoSize = true;
			this.latitudeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.latitudeLabel.Location = new System.Drawing.Point(67, 103);
			this.latitudeLabel.Name = "latitudeLabel";
			this.latitudeLabel.Size = new System.Drawing.Size(59, 18);
			this.latitudeLabel.TabIndex = 1;
			this.latitudeLabel.Text = "Широта";
			// 
			// pointNameLabelForFill
			// 
			this.pointNameLabelForFill.AllowDrop = true;
			this.pointNameLabelForFill.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pointNameLabelForFill.AutoSize = true;
			this.pointNameLabelForFill.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.pointNameLabelForFill.Location = new System.Drawing.Point(290, 29);
			this.pointNameLabelForFill.Name = "pointNameLabelForFill";
			this.pointNameLabelForFill.Size = new System.Drawing.Size(0, 16);
			this.pointNameLabelForFill.TabIndex = 3;
			// 
			// latitudeLabelForFill
			// 
			this.latitudeLabelForFill.AllowDrop = true;
			this.latitudeLabelForFill.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.latitudeLabelForFill.AutoSize = true;
			this.latitudeLabelForFill.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.latitudeLabelForFill.Location = new System.Drawing.Point(290, 104);
			this.latitudeLabelForFill.Name = "latitudeLabelForFill";
			this.latitudeLabelForFill.Size = new System.Drawing.Size(0, 16);
			this.latitudeLabelForFill.TabIndex = 4;
			// 
			// deletePointFromMapButton
			// 
			this.deletePointFromMapButton.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.deletePointFromMapButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.deletePointFromMapButton.Location = new System.Drawing.Point(15, 240);
			this.deletePointFromMapButton.Margin = new System.Windows.Forms.Padding(15);
			this.deletePointFromMapButton.Name = "deletePointFromMapButton";
			this.deletePointFromMapButton.Size = new System.Drawing.Size(163, 48);
			this.deletePointFromMapButton.TabIndex = 6;
			this.deletePointFromMapButton.Text = "Удалить точку с карты";
			this.deletePointFromMapButton.UseVisualStyleBackColor = false;
			this.deletePointFromMapButton.Click += new System.EventHandler(this.DeleteMarkerFromMapButton_Click);
			// 
			// exitPointInfoFormButton
			// 
			this.exitPointInfoFormButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exitPointInfoFormButton.Location = new System.Drawing.Point(218, 240);
			this.exitPointInfoFormButton.Margin = new System.Windows.Forms.Padding(25, 15, 25, 15);
			this.exitPointInfoFormButton.Name = "exitPointInfoFormButton";
			this.exitPointInfoFormButton.Size = new System.Drawing.Size(144, 48);
			this.exitPointInfoFormButton.TabIndex = 7;
			this.exitPointInfoFormButton.Text = "Выйти";
			this.exitPointInfoFormButton.UseVisualStyleBackColor = true;
			this.exitPointInfoFormButton.Click += new System.EventHandler(this.ExitPointInfoFormButton_Click);
			// 
			// longitudeLabelForFill
			// 
			this.longitudeLabelForFill.AllowDrop = true;
			this.longitudeLabelForFill.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.longitudeLabelForFill.AutoSize = true;
			this.longitudeLabelForFill.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.longitudeLabelForFill.Location = new System.Drawing.Point(290, 179);
			this.longitudeLabelForFill.Name = "longitudeLabelForFill";
			this.longitudeLabelForFill.Size = new System.Drawing.Size(0, 16);
			this.longitudeLabelForFill.TabIndex = 5;
			// 
			// MarkerInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(387, 303);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MarkerInfoForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Информация о точке";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label pointNameLabel;
		private System.Windows.Forms.Label longitudeLabel;
		private System.Windows.Forms.Label latitudeLabel;
		private System.Windows.Forms.Label pointNameLabelForFill;
		private System.Windows.Forms.Label longitudeLabelForFill;
		private System.Windows.Forms.Label latitudeLabelForFill;
		private System.Windows.Forms.Button deletePointFromMapButton;
		private System.Windows.Forms.Button exitPointInfoFormButton;
	}
}