using MediatR;
using FourthTask.DAL;
using FourthTask.Contract.Marker;
using Microsoft.EntityFrameworkCore;

namespace FourthTask.BLL.Marker
{
	internal class UpdateMarkerHandler : IRequestHandler<UpdateMarkerRequest, bool>
	{
		private readonly FourthTaskDbContext _dbContext;

		public UpdateMarkerHandler(FourthTaskDbContext dbContext) 
			=> _dbContext = dbContext;

		public async Task<bool> Handle(UpdateMarkerRequest request, CancellationToken cancellationToken)
		{
			var coord = await _dbContext.MarkersCoordinates.FirstOrDefaultAsync(c => c.PointName.Equals(request.PointName));

			if (coord == null)
			{
				return false;
			}

			coord.Latitude = request.Latitude;
			coord.Longitude = request.Longitude;

			await _dbContext.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
