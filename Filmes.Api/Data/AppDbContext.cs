using Microsoft.EntityFrameworkCore;
using Filmes.Api.Models;

namespace Filmes.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }
        public DbSet<Filme> Filmes => Set<Filme>();
    }

}
