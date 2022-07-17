using Microsoft.EntityFrameworkCore;
using Projekt_ProgramowanieO.Database.Tables;

namespace Projekt_ProgramowanieO.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<ListaSamochodow> CarsList { get; set; }
        public DbSet<LoginHaslo> Users { get; set; }
        public DbSet<Pracownicy> Workers { get; set; }
        public DbSet<Status> CarsStatuses { get; set; }
        public DbSet<ZamowieniaSamochodow> CarsReservations { get; set; }
    }
}
