using MediatR;

namespace FourthTask.Contract.Area
{
	public class GetOneAreaRequest : IRequest<GetOneAreaResponse?>
	{
		public GetOneAreaRequest(string areaName) => AreaName = areaName;

		public string AreaName { get; set; }
	}
}
