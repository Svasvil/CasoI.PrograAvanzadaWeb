using CasoI.API.Models;
using CasoI.API.Models.BoardViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace CasoI.API.Data
{
    public class ObjContexto : DbContext
    {
        public ObjContexto(DbContextOptions<ObjContexto> opts) : base(opts) { }
        public DbSet<BoardViewModel> Task { get; set; } = null!;
        public DbSet<UsersModel> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<BoardViewModel>().HasKey(o => o.Id);
        }
    }
}
