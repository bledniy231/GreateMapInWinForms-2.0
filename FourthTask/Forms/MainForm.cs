using FirstTask;
using FourthTask.BackgroundServices;
using FourthTask.Contract.Area;
using FourthTask.Contract.Marker;
using FourthTask.Contract.Models;
using FourthTask.Forms;
using GMap.NET.WindowsForms;
using MediatR;
using WindowsFormsLifetime;

namespace FourthTask
{
	public partial class MainForm : Form
	{
		private GMapMarker? _selectedMarkerForDragAndDrop;
		private bool _isDragging = false;
		private (double Latitude, double Longitude) _draggedMarkerStartCoordinates;
		private readonly string _overlayWithMarkersForMouseMovingName = "Markers";
		private readonly string _overlayWithMarkersForGpggaGenName = "GPGGA";

		private readonly IMediator _mediator;
		private readonly IFormProvider _formProvider;
		private readonly OverlaysCreator _overlaysCreator;
		private readonly CancellationTokenSourcesFactory _ctsFactory;

		public MainForm(
			IMediator mediator,
			IFormProvider formProvider,
			OverlaysCreator overlaysCreator,
			CancellationTokenSourcesFactory ctsFactory)
		{
			_mediator = mediator;
			_formProvider = formProvider;
			_overlaysCreator = overlaysCreator;
			_ctsFactory = ctsFactory;
			InitializeComponent();
		}

		private async void GMapControl_LoadAsync(object sender, EventArgs e)
		{
			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
			gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
			gMapControl.MinZoom = 2;
			gMapControl.MaxZoom = 19;
			gMapControl.Zoom = 10;
			gMapControl.Position = new GMap.NET.PointLatLng(55.163491061033234, 61.416926896980414);
			gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			gMapControl.CanDragMap = true;
			gMapControl.DragButton = MouseButtons.Left;
			gMapControl.ShowCenter = false;
			gMapControl.ShowTileGridLines = false;
			gMapControl.OnMarkerClick += GMapControl_OnMarkerClick;
			gMapControl.MouseDown += GMapControl_MouseDown;
			gMapControl.MouseUp += GMapControl_MouseUp;
			gMapControl.MouseMove += GMapControl_MouseMove;

			var markersResponse = await _mediator.Send(new GetAllMarkersRequest(), CancellationToken.None);

			var overlayMarkersMouseMoving = _overlaysCreator.GetOverlayWithMarkers(
				markersResponse.Coordinates.Where(c => !c.PointName.Equals("Turbo plane")).ToList(),
				_overlayWithMarkersForMouseMovingName);

			var overlayMarkersGpggaGen = _overlaysCreator.GetOverlayWithMarkers(
				markersResponse.Coordinates.Where(c => c.PointName.Equals("Turbo plane")).ToList(),
				_overlayWithMarkersForGpggaGenName,
				GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple);

			var areaResponse = await _mediator.Send(new GetOneAreaRequest("Area 1"), CancellationToken.None);
			if (areaResponse == null)
			{
				ShowWindowFailedLoadArea();
			}
			else
			{
				var areaOverlay = _overlaysCreator.GetOverlayWithArea(areaResponse.Area, "Area 1", "Polygon 1", Color.Blue, Color.DarkBlue);
				gMapControl.Overlays.Add(areaOverlay);
			}

			gMapControl.Overlays.Add(overlayMarkersMouseMoving);
			gMapControl.Overlays.Add(overlayMarkersGpggaGen);
		}

		private void GMapControl_MouseDown(object sender, MouseEventArgs e)
		{
			//_selectedMarkerForDragAndDrop = gMapControl.Overlays
			//	.SelectMany(o => o.Markers)
			//	.Where(m => m.Overlay.Id.Equals(_overlayWithMarkersForMouseMovingName))
			//	.FirstOrDefault(m => m.IsMouseOver);

			_selectedMarkerForDragAndDrop = gMapControl.Overlays
				.SelectMany(o => o.Markers)
				.FirstOrDefault(m => m.IsMouseOver);

			_isDragging = e.Button == MouseButtons.Left && _selectedMarkerForDragAndDrop != null;

			if (_isDragging)
			{
				_draggedMarkerStartCoordinates.Latitude = _selectedMarkerForDragAndDrop.Position.Lat;
				_draggedMarkerStartCoordinates.Longitude = _selectedMarkerForDragAndDrop.Position.Lng;
			}
		}


		private void GMapControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (_isDragging && _selectedMarkerForDragAndDrop != null)
			{
				_selectedMarkerForDragAndDrop.Position = gMapControl.FromLocalToLatLng(e.X, e.Y);
			}
		}

		private async void GMapControl_MouseUp(object sender, MouseEventArgs e)
		{
			if (_selectedMarkerForDragAndDrop == null || !_isDragging)
			{
				return;
			}

			var latlng = gMapControl.FromLocalToLatLng(e.X, e.Y);

			if (_selectedMarkerForDragAndDrop.Overlay.Id.Equals(_overlayWithMarkersForGpggaGenName))
			{
				SetNewMarkerCoordsForGpggaOverlay(latlng.Lat, latlng.Lng);
				_selectedMarkerForDragAndDrop = null;
				_isDragging = false;
				return;
			}

			_selectedMarkerForDragAndDrop.Position = latlng;

			if (!await _mediator.Send(new UpdateMarkerRequest(_selectedMarkerForDragAndDrop.ToolTipText, latlng.Lat, latlng.Lng)))
			{
				MessageBox.Show("Ошибка сохранения новых координат точки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
				_selectedMarkerForDragAndDrop.Position = new GMap.NET.PointLatLng(_draggedMarkerStartCoordinates.Latitude, _draggedMarkerStartCoordinates.Longitude);
			}

			_selectedMarkerForDragAndDrop = null;
			_isDragging = false;
		}



		private void GMapControl_OnMarkerClick(GMapMarker marker, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}

			ShowMarkerInfoForm(marker);
		}

		private async void MarkerInfoForm_DeletePointClicked(GMapMarker marker)
		{
			await _mediator.Send(new DeleteMarkerRequest(marker.ToolTipText));
			gMapControl.Overlays.FirstOrDefault(ov => ov.Id.Equals(marker.Overlay.Id))?.Markers.Remove(marker);
			gMapControl.Update();
		}

		private void LongitudeTextBox_KeyPress(object sender, KeyPressEventArgs e)
			=> e.Handled = KeyPressValidation(longitudeTextBox, e.KeyChar);


		private void LatitudeTextBox_KeyPress(object sender, KeyPressEventArgs e)
			=> e.Handled = KeyPressValidation(latitudeTextBox, e.KeyChar);

		private static bool KeyPressValidation(TextBox textBox, char letter)
			=> letter switch
			{
				'-' => textBox.Text.Length != 0 || textBox.Text.Contains('-') || textBox.Text.Contains(','),
				',' => textBox.Text.Length == 0 || textBox.Text.Contains(','),
				(char)8 => false,
				_ => !char.IsDigit(letter),
			};

		private async void AddCoordButton_ClickAsync(object sender, EventArgs e)
		{
			if (!TryParseLatitude(latitudeTextBox.Text, out var latitudeDouble)
				|| !TryParseLongitude(longitudeTextBox.Text, out var longitudeDouble))
			{
				MessageBox.Show("Введены не корректные координаты!", "Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			var coord = new MarkerCoordinateModel { PointName = pointNameTextBox.Text, Latitude = latitudeDouble, Longitude = longitudeDouble };
			var inputMarker = _overlaysCreator.GetOneGoogleMarker(coord);

			if (gMapControl.Overlays.Count == 0)
			{
				var newOverlay = new GMapOverlay(_overlayWithMarkersForMouseMovingName);
				newOverlay.Markers.Add(inputMarker);
				gMapControl.Overlays.Add(newOverlay);

				await _mediator.Send(new CreateMarkerRequest(coord.PointName, coord.Latitude, coord.Longitude));
			}
			else
			{
				gMapControl.Overlays.FirstOrDefault(ov => ov.Id.Equals(_overlayWithMarkersForMouseMovingName))?.Markers.Add(inputMarker);
				await _mediator.Send(new CreateMarkerRequest(coord.PointName, coord.Latitude, coord.Longitude));
			}

			gMapControl.Update();
			latitudeTextBox.Clear();
			longitudeTextBox.Clear();
			pointNameTextBox.Clear();
		}

		private static bool TryParseLatitude(string latitudeString, out double latitudeDouble)
			=> double.TryParse(latitudeString, out latitudeDouble) && (latitudeDouble >= -90 && latitudeDouble <= 90);


		private static bool TryParseLongitude(string longitudeString, out double longitudeDouble)
			=> double.TryParse(longitudeString, out longitudeDouble) && (longitudeDouble >= -180 && longitudeDouble <= 180);

		public (double? Latitude, double? Longitude) GetMarkerCoordsFromGpggaOverlay()
		{
			var marker = gMapControl.Overlays
				.FirstOrDefault(o => o.Id.Equals(_overlayWithMarkersForGpggaGenName))
				?.Markers
				.FirstOrDefault();

			if (marker == null)
			{
				_ctsFactory.CancelCtsForService(nameof(GpggaGenerator));
				return (null, null);
			}

			var latitude = marker.Position.Lat;
			var longitude = marker.Position.Lng;

			return (latitude, longitude);
		}

		public async void SetNewMarkerCoordsForGpggaOverlay(double latitude, double longitude)
		{
			var marker = gMapControl.Overlays
				.First(o => o.Id.Equals(_overlayWithMarkersForGpggaGenName))
				.Markers
				.First();

			marker.Position = new GMap.NET.PointLatLng(latitude, longitude);
			var areaOverlay = gMapControl.Overlays.FirstOrDefault(o => o.Id.Equals("Area 1"));

			if (areaOverlay != null && areaOverlay.Polygons.Any(p => p.IsInside(marker.Position)))
			{
				_ctsFactory.CancelCtsForService(nameof(GpggaGenerator));
				ShowMarkerInfoForm(marker);
			}
			else
			{
				await _mediator.Send(new UpdateMarkerRequest(marker.ToolTipText, marker.Position.Lat, marker.Position.Lng));
			}
		}

		private static void ShowWindowFailedLoadArea()
			=> MessageBox.Show("Ошибка загрузки слоя с территорией", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

		//private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		//{
		//	var allMarkers = new List<MarkerCoordinateModel>();
		//	foreach (var overlay in gMapControl.Overlays)
		//	{
		//		allMarkers.AddRange(overlay.Markers.Select(m => new MarkerCoordinateModel
		//		{
		//			PointName = m.ToolTipText,
		//			Latitude = m.Position.Lat,
		//			Longitude = m.Position.Lng
		//		}).ToList());
		//	}

		//	await _mediator.Send(new UpdateAllMarkersRequest(allMarkers), CancellationToken.None);
		//}

		private async void ShowMarkerInfoForm(GMapMarker marker)
		{
			using var markerInfoForm = await _formProvider.GetFormAsync<MarkerInfoForm>();
			markerInfoForm.InitComponent(marker);
			markerInfoForm.DeleteMarkerClicked += MarkerInfoForm_DeletePointClicked;
			markerInfoForm.ShowDialog();
		}
	}
}