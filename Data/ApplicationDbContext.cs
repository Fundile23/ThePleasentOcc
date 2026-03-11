using Microsoft.EntityFrameworkCore;
using ThePleasantOcc.Models;

namespace ThePleasantOcc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasData(
                // The Single - Floor 1 (1 bed each) - ALL EMPTY
                new Room { Id = 1, RoomNumber = "101", Residence = "single", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 1, Price = 3500, Size = "20m²" },
                new Room { Id = 2, RoomNumber = "102", Residence = "single", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 1, Price = 3500, Size = "20m²" },
                new Room { Id = 3, RoomNumber = "103", Residence = "single", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 1, Price = 3500, Size = "20m²" },
                new Room { Id = 4, RoomNumber = "104", Residence = "single", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 1, Price = 3500, Size = "20m²" },

                // The Single - Floor 2 (1 bed each) - ALL EMPTY
                new Room { Id = 5, RoomNumber = "201", Residence = "single", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 2, Price = 3500, Size = "20m²" },
                new Room { Id = 6, RoomNumber = "202", Residence = "single", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 2, Price = 3500, Size = "20m²" },
                new Room { Id = 7, RoomNumber = "203", Residence = "single", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 2, Price = 3500, Size = "20m²" },
                new Room { Id = 8, RoomNumber = "204", Residence = "single", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 2, Price = 3500, Size = "20m²" },

                // The Double - Floor 1 (2 beds each) - ALL EMPTY
                new Room { Id = 9, RoomNumber = "101", Residence = "double", RoomType = "Double", TotalBeds = 2, OccupiedBeds = 0, Floor = 1, Price = 2800, Size = "28m²" },
                new Room { Id = 10, RoomNumber = "102", Residence = "double", RoomType = "Double", TotalBeds = 2, OccupiedBeds = 0, Floor = 1, Price = 2800, Size = "28m²" },
                new Room { Id = 11, RoomNumber = "103", Residence = "double", RoomType = "Double", TotalBeds = 2, OccupiedBeds = 0, Floor = 1, Price = 2800, Size = "28m²" },
                new Room { Id = 12, RoomNumber = "104", Residence = "double", RoomType = "Double", TotalBeds = 2, OccupiedBeds = 0, Floor = 1, Price = 2800, Size = "28m²" },

                // The Triple - Floor 1 (3 beds each) - ALL EMPTY
                new Room { Id = 13, RoomNumber = "101", Residence = "triple", RoomType = "Triple", TotalBeds = 3, OccupiedBeds = 0, Floor = 1, Price = 2200, Size = "35m²" },
                new Room { Id = 14, RoomNumber = "102", Residence = "triple", RoomType = "Triple", TotalBeds = 3, OccupiedBeds = 0, Floor = 1, Price = 2200, Size = "35m²" },
                new Room { Id = 15, RoomNumber = "103", Residence = "triple", RoomType = "Triple", TotalBeds = 3, OccupiedBeds = 0, Floor = 1, Price = 2200, Size = "35m²" },
                new Room { Id = 16, RoomNumber = "104", Residence = "triple", RoomType = "Triple", TotalBeds = 3, OccupiedBeds = 0, Floor = 1, Price = 2200, Size = "35m²" },

                // The Mix - Floor 1 (Mixed types) - ALL EMPTY
                new Room { Id = 17, RoomNumber = "101", Residence = "mix", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 1, Price = 3500, Size = "20m²" },
                new Room { Id = 18, RoomNumber = "102", Residence = "mix", RoomType = "Double", TotalBeds = 2, OccupiedBeds = 0, Floor = 1, Price = 2800, Size = "28m²" },
                new Room { Id = 19, RoomNumber = "103", Residence = "mix", RoomType = "Triple", TotalBeds = 3, OccupiedBeds = 0, Floor = 1, Price = 2200, Size = "35m²" },
                new Room { Id = 20, RoomNumber = "104", Residence = "mix", RoomType = "Single", TotalBeds = 1, OccupiedBeds = 0, Floor = 1, Price = 3500, Size = "20m²" }
            );
        }
    }
}