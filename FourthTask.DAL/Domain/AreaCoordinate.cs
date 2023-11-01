namespace FourthTask.DAL.Domain
{
	public class AreaCoordinate
	{
		public long AreaId { get; set; }
		public long AreaCoordinateId { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public Area Area { get; set; }
	}
}
