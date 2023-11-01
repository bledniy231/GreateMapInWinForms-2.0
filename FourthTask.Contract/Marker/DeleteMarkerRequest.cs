using MediatR;

namespace FourthTask.Contract.Marker
{
	public class DeleteMarkerRequest : IRequest<Unit>
	{
		public DeleteMarkerRequest(string pointName)
			=> PointName = pointName;

		public string PointName { get; set; }
	}
}
