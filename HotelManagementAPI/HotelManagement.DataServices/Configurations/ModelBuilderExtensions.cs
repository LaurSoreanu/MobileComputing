using HotelManagement.DataModel.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DataServices.Configurations
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language()
                {
                    Id = 1,
                    Name = "English",
                    Code = "en"
                },
                new Language()
                {
                    Id = 2,
                    Name = "Dutch",
                    Code = "nl"
                },
                new Language()
                {
                    Id = 3,
                    Name = "German",
                    Code = "de"
                },
                new Language()
                {
                    Id = 4,
                    Name = "French",
                    Code = "fr"
                }
            );
        }
    }
}
