namespace FourthTask.DAL.Domain
{
	public class Area
	{
		public long AreaId { get; set; }
		public string AreaName { get; set; }
		public List<AreaCoordinate> AreaCoordiantes { get; set; }
	}
}
