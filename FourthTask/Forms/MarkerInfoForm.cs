using GMap.NET.WindowsForms;

namespace FourthTask.Forms
{
	public partial class MarkerInfoForm : Form
	{
		private GMapMarker _marker;

		public MarkerInfoForm()
		{
			InitializeComponent();
		}

		public void InitComponent(GMapMarker marker)
		{
			pointNameLabelForFill.Text = marker.ToolTipText;
			latitudeLabelForFill.Text = marker.Position.Lat.ToString();
			longitudeLabelForFill.Text = marker.Position.Lng.ToString();
			_marker = marker;
		}

		private void DeleteMarkerFromMapButton_Click(object sender, EventArgs e)
		{
			var response = MessageBox.Show("Удалить точку?", "Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (response == DialogResult.Yes)
			{
				DeleteMarkerClicked?.Invoke(_marker);
			}

			Close();
		}

		private void ExitPointInfoFormButton_Click(object sender, EventArgs e)
			=> Close();

		public event Action<GMapMarker> DeleteMarkerClicked;
	}
}
