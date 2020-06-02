using HotelManagement.DataModel.Model;
using HotelManagement.DataServices.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HotelManagement.DataServices
{
	public class Entities : DbContext
	{
		public DbSet<Language> Language { get; set; }

		public DbSet<User> User { get; set; }
		public DbSet<Hotel> Hotel { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.AddEnvironmentVariables();
			var configuration = builder.Build();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			optionsBuilder.UseSqlServer(connectionString, x => x.UseNetTopologySuite());
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Seed();
		}

		private ValueConverter<DateTime, DateTime> GetUtcDateTimeValueConverter()
			=> new ValueConverter<DateTime, DateTime>(
				x => x,
				x => new DateTime(x.Year, x.Month, x.Day, x.Hour, x.Minute, x.Second, DateTimeKind.Utc));
	}
}
