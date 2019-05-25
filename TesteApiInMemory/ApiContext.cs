using System;
using Microsoft.EntityFrameworkCore;
using TesteApiInMemory.Model;

namespace TesteApiInMemory
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        { }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasOne<Address>(u => u.Address)
                .WithOne(a => a.UserModel)
                .HasForeignKey<Address>(a => a.IdUser);
        }*/



        public DbSet<UserModel> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
