using Microsoft.EntityFrameworkCore;
using System;
using SysGym.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGym.Infraestructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }
        public DbSet<Rol> rols { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().ToTable("t_rols");
            modelBuilder.Entity<Rol>().ToTable("t_usuarios");
            base.OnModelCreating(modelBuilder);
        }
    }
}
