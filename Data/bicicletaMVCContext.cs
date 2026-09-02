using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bicicletaMVC.Models;


namespace bicicletaMVC.Data
{
    public class bicicletaMVCContext : DbContext
    {
        public bicicletaMVCContext (DbContextOptions<bicicletaMVCContext> options)
            : base(options)
        {
        }

        public DbSet<bicicletaMVC.Models.Bicicleta> Bicicleta { get; set; }

        public DbSet<bicicletaMVC.Models.Categoria> Categoria { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Bicicleta>().ToTable("MVC_Bicicleta");
        //    modelBuilder.Entity<Categoria>().ToTable("MVC_Categoria");
        //}

    }
}
