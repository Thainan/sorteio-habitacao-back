using Microsoft.EntityFrameworkCore;
using SorteioHabitacaoThainan.Dominio;

namespace SorteioHabitacaoThainan.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
