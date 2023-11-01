using FourthTask.Contract.Models;
using MediatR;

namespace FourthTask.Contract.Marker
{
	public class UpdateAllMarkersRequest : IRequest<Unit>
	{
		public UpdateAllMarkersRequest(List<MarkerCoordinateModel> coordinatesModels)
		{
			CoordinatesModels = coordinatesModels;
		}

		public List<MarkerCoordinateModel> CoordinatesModels { get; set; }
	}
}
