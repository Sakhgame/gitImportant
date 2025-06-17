using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AlphaHotel.Data
{
    public partial class AlphaHotelContext : DbContext
    {
        public AlphaHotelContext()
            : base("name=AlphaHotelContext")
        {
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Card)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Client>()
                .Property(e => e.ClientName)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.Passport)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.Adres)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Client)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Role)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Room)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();
        }
    }
}
