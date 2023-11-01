using FourthTask.Contract.Area;
using FourthTask.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FourthTask.BLL.Area
{
	internal class GetOneAreaHandler : IRequestHandler<GetOneAreaRequest, GetOneAreaResponse?>
	{
		private readonly FourthTaskDbContext _dbContext;

		public GetOneAreaHandler(FourthTaskDbContext dbContext) => _dbContext = dbContext;

		public async Task<GetOneAreaResponse?> Handle(GetOneAreaRequest request, CancellationToken cancellationToken)
			=> await _dbContext.Areas
				.Where(a => a.AreaName.Equals(request.AreaName))
				.Select(a => new GetOneAreaResponse
				{
					Area = new Contract.Models.AreaModel
					{
						AreaName = a.AreaName,
						AreaCoordinates = a.AreaCoordiantes.Select(c => new Contract.Models.AreaCoordinateModel
						{
							Latitude = c.Latitude,
							Longitude = c.Longitude
						}).ToList()
					}
				})
				.FirstOrDefaultAsync(cancellationToken);
	}
}
