using FourthTask.Contract.Marker;
using FourthTask.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FourthTask.BLL.Marker
{
	internal class DeleteMarkerHandler : IRequestHandler<DeleteMarkerRequest, Unit>
	{
		private readonly FourthTaskDbContext _dbContext;

		public DeleteMarkerHandler(FourthTaskDbContext dbContext) 
			=> _dbContext = dbContext;

		public async Task<Unit> Handle(DeleteMarkerRequest request, CancellationToken cancellationToken)
		{
			var coord = await _dbContext.MarkersCoordinates.FirstOrDefaultAsync(c => c.PointName.Equals(request.PointName));

			if (coord == null)
			{
				return Unit.Value;
			}

			_dbContext.MarkersCoordinates.Remove(coord);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
