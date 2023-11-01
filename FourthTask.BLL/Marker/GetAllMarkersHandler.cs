using FourthTask.Contract.Marker;
using FourthTask.Contract.Models;
using FourthTask.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FourthTask.BLL.Marker
{
	internal class GetAllMarkersHandler : IRequestHandler<GetAllMarkersRequest, GetAllMarkersResponse>
	{
		private readonly FourthTaskDbContext _dbContext;

		public GetAllMarkersHandler(FourthTaskDbContext dbContext) 
			=> _dbContext = dbContext;

		public async Task<GetAllMarkersResponse> Handle(GetAllMarkersRequest request, CancellationToken cancellationToken)
			=> new GetAllMarkersResponse
			{
				Coordinates = await _dbContext.MarkersCoordinates.Select(c => new MarkerCoordinateModel
				{
					PointName = c.PointName,
					Latitude = c.Latitude,
					Longitude = c.Longitude
				}).ToListAsync(cancellationToken)
			};
	}
}
