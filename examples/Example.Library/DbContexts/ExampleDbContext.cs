using System;
using System.Linq.Expressions;
using Example.Library.Models;
using Microsoft.EntityFrameworkCore;
using XPike.DataStores.EntityFrameworkCore;
using XPike.DataStores.MultiTenant;

namespace Example.Library.DbContexts
{
    public class ExampleDbContext
        : EfCoreDbContextBase
    {
        protected override string ConnectionString => "ExampleDB";

        public DbSet<User> Examples { get; set; }

        public ExampleDbContext(IMultiTenantConnectionStringManager connectionManager, DbContextOptions<ExampleDbContext> options)
            : base(connectionManager, options)
        {
        }

        public ExampleDbContext(IMultiTenantConnectionStringManager connectionManager)
            : base(connectionManager)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(GetManagedConnectionString());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
                                      {
                                          e.ToTable("userInfo", "users")
                                           .HasOne(u => u.ContactInfo)
                                           .WithOne(c => c.User)
                                           .HasPrincipalKey((Expression<Func<ContactInfo, object>>) (c => c.UserId));

                                          e.Property(u => u.UserType)
                                              .HasColumnName("UserTypeId");
                                      });

            modelBuilder.Entity<ContactInfo>(e =>
                                             {
                                                 e.ToTable("contactInfo", "contacts")
                                                  .HasOne(c => c.User)
                                                  .WithOne(u => u.ContactInfo)
                                                  .HasForeignKey((Expression<Func<ContactInfo, object>>) (c => c.UserId));
                                             });

            base.OnModelCreating(modelBuilder);
        }
    }
}