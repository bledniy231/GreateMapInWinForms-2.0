namespace FourthTask
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			longitudeTextBox = new TextBox();
			longitudeLabel = new Label();
			pointNameTextBox = new TextBox();
			TableLayoutPanel = new TableLayoutPanel();
			pointNameLable = new Label();
			latitudeTextBox = new TextBox();
			latitudeLabel = new Label();
			addCoordButton = new Button();
			gMapControl = new GMap.NET.WindowsForms.GMapControl();
			TableLayoutPanel.SuspendLayout();
			SuspendLayout();
			// 
			// longitudeTextBox
			// 
			longitudeTextBox.AllowDrop = true;
			longitudeTextBox.Dock = DockStyle.Fill;
			longitudeTextBox.Location = new Point(305, 25);
			longitudeTextBox.Margin = new Padding(0, 25, 0, 0);
			longitudeTextBox.Name = "longitudeTextBox";
			longitudeTextBox.Size = new Size(161, 27);
			longitudeTextBox.TabIndex = 1;
			longitudeTextBox.KeyPress += LongitudeTextBox_KeyPress;
			// 
			// longitudeLabel
			// 
			longitudeLabel.Anchor = AnchorStyles.None;
			longitudeLabel.AutoSize = true;
			longitudeLabel.Location = new Point(236, 27);
			longitudeLabel.Name = "longitudeLabel";
			longitudeLabel.Size = new Size(65, 20);
			longitudeLabel.TabIndex = 2;
			longitudeLabel.Text = "Долгота";
			// 
			// pointNameTextBox
			// 
			pointNameTextBox.AllowDrop = true;
			pointNameTextBox.Dock = DockStyle.Fill;
			pointNameTextBox.Location = new Point(592, 25);
			pointNameTextBox.Margin = new Padding(0, 25, 0, 0);
			pointNameTextBox.Name = "pointNameTextBox";
			pointNameTextBox.Size = new Size(161, 27);
			pointNameTextBox.TabIndex = 7;
			// 
			// TableLayoutPanel
			// 
			TableLayoutPanel.ColumnCount = 7;
			TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.853762F));
			TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.61261F));
			TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.853762F));
			TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.61261F));
			TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.8385F));
			TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.61261F));
			TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.61613F));
			TableLayoutPanel.Controls.Add(pointNameLable, 4, 0);
			TableLayoutPanel.Controls.Add(latitudeTextBox, 1, 0);
			TableLayoutPanel.Controls.Add(latitudeLabel, 0, 0);
			TableLayoutPanel.Controls.Add(longitudeLabel, 2, 0);
			TableLayoutPanel.Controls.Add(pointNameTextBox, 5, 0);
			TableLayoutPanel.Controls.Add(longitudeTextBox, 3, 0);
			TableLayoutPanel.Controls.Add(addCoordButton, 6, 0);
			TableLayoutPanel.Dock = DockStyle.Bottom;
			TableLayoutPanel.Location = new Point(0, 585);
			TableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
			TableLayoutPanel.Name = "TableLayoutPanel";
			TableLayoutPanel.RowCount = 1;
			TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			TableLayoutPanel.Size = new Size(917, 75);
			TableLayoutPanel.TabIndex = 8;
			// 
			// pointNameLable
			// 
			pointNameLable.Anchor = AnchorStyles.None;
			pointNameLable.AutoSize = true;
			pointNameLable.Location = new Point(469, 27);
			pointNameLable.Name = "pointNameLable";
			pointNameLable.Size = new Size(120, 20);
			pointNameLable.TabIndex = 10;
			pointNameLable.Text = "Название точки";
			// 
			// latitudeTextBox
			// 
			latitudeTextBox.AllowDrop = true;
			latitudeTextBox.Dock = DockStyle.Fill;
			latitudeTextBox.Location = new Point(72, 25);
			latitudeTextBox.Margin = new Padding(0, 25, 0, 0);
			latitudeTextBox.Name = "latitudeTextBox";
			latitudeTextBox.Size = new Size(161, 27);
			latitudeTextBox.TabIndex = 9;
			latitudeTextBox.KeyPress += LatitudeTextBox_KeyPress;
			// 
			// latitudeLabel
			// 
			latitudeLabel.Anchor = AnchorStyles.None;
			latitudeLabel.AutoSize = true;
			latitudeLabel.Location = new Point(4, 27);
			latitudeLabel.Name = "latitudeLabel";
			latitudeLabel.Size = new Size(64, 20);
			latitudeLabel.TabIndex = 8;
			latitudeLabel.Text = "Широта";
			// 
			// addCoordButton
			// 
			addCoordButton.Dock = DockStyle.Fill;
			addCoordButton.Location = new Point(756, 4);
			addCoordButton.Margin = new Padding(3, 4, 3, 4);
			addCoordButton.Name = "addCoordButton";
			addCoordButton.Size = new Size(158, 67);
			addCoordButton.TabIndex = 11;
			addCoordButton.Text = "Добавить точку";
			addCoordButton.UseVisualStyleBackColor = true;
			addCoordButton.Click += AddCoordButton_ClickAsync;
			// 
			// gMapControl
			// 
			gMapControl.Bearing = 0F;
			gMapControl.CanDragMap = true;
			gMapControl.Dock = DockStyle.Fill;
			gMapControl.EmptyTileColor = Color.Navy;
			gMapControl.GrayScaleMode = false;
			gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			gMapControl.LevelsKeepInMemory = 5;
			gMapControl.Location = new Point(0, 0);
			gMapControl.Margin = new Padding(3, 4, 3, 4);
			gMapControl.MarkersEnabled = true;
			gMapControl.MaxZoom = 2;
			gMapControl.MinZoom = 2;
			gMapControl.MouseWheelZoomEnabled = true;
			gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			gMapControl.Name = "gMapControl";
			gMapControl.NegativeMode = false;
			gMapControl.PolygonsEnabled = true;
			gMapControl.RetryLoadTile = 0;
			gMapControl.RoutesEnabled = true;
			gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			gMapControl.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
			gMapControl.ShowTileGridLines = false;
			gMapControl.Size = new Size(917, 585);
			gMapControl.TabIndex = 9;
			gMapControl.Zoom = 0D;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveBorder;
			ClientSize = new Size(917, 660);
			Controls.Add(gMapControl);
			Controls.Add(TableLayoutPanel);
			Margin = new Padding(3, 4, 3, 4);
			MinimumSize = new Size(935, 707);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Карта техники";
			Load += GMapControl_LoadAsync;
			TableLayoutPanel.ResumeLayout(false);
			TableLayoutPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.TextBox longitudeTextBox;
		private System.Windows.Forms.Label longitudeLabel;
		private System.Windows.Forms.TextBox pointNameTextBox;
		private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
		private System.Windows.Forms.Label latitudeLabel;
		private System.Windows.Forms.TextBox latitudeTextBox;
		private System.Windows.Forms.Label pointNameLable;
		private System.Windows.Forms.Button addCoordButton;
		private GMap.NET.WindowsForms.GMapControl gMapControl;
	}
}