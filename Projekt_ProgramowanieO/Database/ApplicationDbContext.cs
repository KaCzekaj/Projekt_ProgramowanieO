using Microsoft.EntityFrameworkCore;
using Projekt_ProgramowanieO.Database.Tables;

namespace Projekt_ProgramowanieO.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<ListaSamochodow> ListaSamochodow { get; set; }
        public DbSet<LoginHaslo> LoginHaslo { get; set; }
        public DbSet<Pracownicy> Pracownicy { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<ZamowieniaSamochodow> ZamowieniaSamochodow { get; set; }
    }
}
