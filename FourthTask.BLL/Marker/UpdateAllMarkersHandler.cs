using FourthTask.Contract.Marker;
using FourthTask.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FourthTask.BLL.Marker
{
	internal class UpdateAllMarkersHandler : IRequestHandler<UpdateAllMarkersRequest, Unit>
	{
		private readonly FourthTaskDbContext _dbContext;

		public UpdateAllMarkersHandler(FourthTaskDbContext dbContext) => _dbContext = dbContext;

		public async Task<Unit> Handle(UpdateAllMarkersRequest request, CancellationToken cancellationToken)
		{
			var allMarkers = await _dbContext.MarkersCoordinates.ToListAsync(cancellationToken);

			foreach (var marker in allMarkers)
			{
				var updatedMarker = request.CoordinatesModels.FirstOrDefault(cm => cm.PointName.Equals(marker.PointName));
				marker.Latitude = updatedMarker.Latitude;
				marker.Longitude = updatedMarker.Longitude;
			}

			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
