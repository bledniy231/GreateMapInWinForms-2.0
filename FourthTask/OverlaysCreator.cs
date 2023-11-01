using FourthTask.Contract.Models;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace FirstTask
{
	public class OverlaysCreator
	{
		public GMapOverlay GetOverlayWithMarkers(List<MarkerCoordinateModel> coordinates, string overlayId, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
		{
			var gMapMarkers = new GMapOverlay(overlayId);
			coordinates.ForEach(coord => gMapMarkers.Markers.Add(GetOneGoogleMarker(coord, gMarkerGoogleType)));
			return gMapMarkers;
		}

		public GMarkerGoogle GetOneGoogleMarker(MarkerCoordinateModel coord, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
		{
			var mapMarker = new GMarkerGoogle(new GMap.NET.PointLatLng(coord.Latitude, coord.Longitude), gMarkerGoogleType);
			mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker); // всплывающее окно с инфой к маркеру
			mapMarker.ToolTipText = coord.PointName; // текст внутри всплывающего окна
			mapMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver; // отображение всплывающего окна (при наведении)
			return mapMarker;
		}

		public GMapOverlay GetOverlayWithArea(AreaModel area, string overlayId, string polygonName, Color colorFill, Color colorStroke)
		{
			var areaCoordinates = area.AreaCoordinates.Select(c => new GMap.NET.PointLatLng(c.Latitude, c.Longitude)).ToList();
			var areaOverlay = new GMapOverlay(overlayId);
			var areaPolygon = new GMapPolygon(areaCoordinates, polygonName)
			{
				Fill = new SolidBrush(Color.FromArgb(50, colorFill)),
				Stroke = new Pen(colorStroke, 2)
			};

			areaOverlay.Polygons.Add(areaPolygon);

			return areaOverlay;
		}
	}
}
