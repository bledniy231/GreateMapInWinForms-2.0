using FourthTask.Contract.Marker;
using FourthTask.DAL;
using MediatR;

namespace FourthTask.BLL.Marker
{
	internal class CreateMarkerHandler : IRequestHandler<CreateMarkerRequest, bool>
	{
		private readonly FourthTaskDbContext _dbContext;

		public CreateMarkerHandler(FourthTaskDbContext dbContext) 
			=> _dbContext = dbContext;

		public async Task<bool> Handle(CreateMarkerRequest request, CancellationToken cancellationToken)
		{
			try
			{
				_dbContext.MarkersCoordinates.Add(new DAL.Domain.MarkerCoordinate
				{
					PointName = request.PointName,
					Latitude = request.Latitude,
					Longitude = request.Longitude
				});

				await _dbContext.SaveChangesAsync(cancellationToken);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
