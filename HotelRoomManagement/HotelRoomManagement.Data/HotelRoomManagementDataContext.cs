using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HotelRoomManagement.Data.Entities;

namespace HotelRoomManagement.Data
{
    public class HotelRoomManagementDataContext : DbContext
    {
        public HotelRoomManagementDataContext(DbContextOptions<HotelRoomManagementDataContext> options)
            : base(options)
        {
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Guests)
                .WithOne(g => g.Room)
                .HasForeignKey(g => g.RoomId);
        }
    }
} 