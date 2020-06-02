using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Linq;

namespace HotelManagement.DataServices
{
    public abstract class HotelManagementMigration : Migration
    {
        protected void ExecuteScripts(MigrationBuilder migrationBuilder, string path)
        {
            var fullPath = Path.GetFullPath(Directory.GetParent(Directory.GetCurrentDirectory()).GetDirectories()
                .FirstOrDefault(x => x.Name.Equals("HotelManagement.DataServices", StringComparison.OrdinalIgnoreCase)) + path);

            foreach (var file in Directory.GetFiles(fullPath, "*.sql"))
            {
                migrationBuilder.Sql(File.ReadAllText(file));
            }
        }
    }
}
