using FourthTask.DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace FourthTask.DAL
{
	public class FourthTaskDbContext : DbContext
	{
		public FourthTaskDbContext(DbContextOptions<FourthTaskDbContext> options) : base(options) { }

		public DbSet<MarkerCoordinate> MarkersCoordinates { get; set; }
		public DbSet<AreaCoordinate> AreasCoordinates { get; set; }
		public DbSet<Area> Areas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("FourthTask");

			modelBuilder.Entity<MarkerCoordinate>(e =>
			{
				e.ToTable("MarkersCoordinates");

				e.HasKey(p => p.Id);

				e.HasIndex(p => p.PointName).IsUnique();

				e.Property(p => p.PointName).IsRequired().HasMaxLength(255);
			});

			modelBuilder.Entity<MarkerCoordinate>().HasData(new MarkerCoordinate[]
			{
				new MarkerCoordinate { Id = 1, PointName = "SUSU", Latitude = 55.16050371482184, Longitude = 61.370177583057185},
				new MarkerCoordinate { Id = 2, PointName = "Chelyabinsk State Academic Opera and Ballet Theater", Latitude = 55.166862645697776, Longitude = 61.40195476957598},
				new MarkerCoordinate { Id = 3, PointName = "Chelyabinsk State Museum of Local Lore", Latitude = 55.16834771226128, Longitude =  61.398008203174214},
				new MarkerCoordinate { Id = 4, PointName = "Chelyabinsk State Academic Drama Theater", Latitude = 55.15624283510331, Longitude = 61.40282635287497},
				new MarkerCoordinate { Id = 5, PointName = "Turbo plane", Latitude = 55.1625346688695, Longitude = 61.391016876126}
			});

			modelBuilder.Entity<AreaCoordinate>(e =>
			{
				e.ToTable("AreasCoordinates");

				e.HasKey(p => new { p.AreaId, p.AreaCoordinateId }).IsClustered();
			});

			modelBuilder.Entity<Area>(e =>
			{
				e.ToTable("Areas");

				e.HasKey(p => p.AreaId);

				e.HasIndex(p => p.AreaName).IsUnique();

				e.HasMany(p => p.AreaCoordiantes).WithOne(p => p.Area).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<Area>().HasData(new Area[]
			{
				new Area { AreaId = 1, AreaName = "Area 1" }
			});

			modelBuilder.Entity<AreaCoordinate>().HasData(new AreaCoordinate[] 
			{
				new AreaCoordinate { AreaId = 1, AreaCoordinateId = 1, Latitude = 55.16059402945803, Longitude = 61.38836444193657 },
				new AreaCoordinate { AreaId = 1, AreaCoordinateId = 2, Latitude = 55.16158750374075, Longitude = 61.39312229229125 },
				new AreaCoordinate { AreaId = 1, AreaCoordinateId = 3, Latitude = 55.15879084992464, Longitude = 61.391890341658154 }
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}