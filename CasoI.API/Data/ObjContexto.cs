using CasoI.API.Models;
using CasoI.API.Models.BoardViewModel;
using Microsoft.EntityFrameworkCore;

namespace CasoI.API.Data
{
    public class ObjContexto : DbContext
    {
        public ObjContexto(DbContextOptions<ObjContexto> opts) : base(opts) { }

        public DbSet<BoardViewModel> Task { get; set; } = null!;
        public DbSet<UsersModel> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<BoardViewModel>(entity =>
            {
                entity.HasKey(o => o.Id);

                
                entity.HasOne(b => b.AsignadoA)
                      .WithMany()
                      .HasForeignKey(b => b.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}