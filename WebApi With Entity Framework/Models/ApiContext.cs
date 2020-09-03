using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi_With_Entity_Framework.Models
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<Customers> Customers { get; set; }
        
        public virtual DbSet<Orders> Orders { get; set; }
       
        public virtual DbSet<Products> Products { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);
                //.IsRequired()
                //.HasMaxLength(50);

                //entity.Property(e => e.LastName)
                //.IsRequired()
                //.HasMaxLength(50);
            });

           
            

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);
            });


            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
