using Microsoft.EntityFrameworkCore;

namespace ColegioRojasAPI.Models
{
    public class ColegioContext: DbContext
    {

        public ColegioContext(DbContextOptions<ColegioContext> options) : base(options)
        {
        }

        public DbSet<Colegio> Colegios { get; set; }
    }
}
