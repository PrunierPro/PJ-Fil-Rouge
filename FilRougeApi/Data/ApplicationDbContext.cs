using Microsoft.EntityFrameworkCore;
using FilRougeCore.Models;
using FilRougeCore.Data;

namespace FilRougeApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminRoot = new User()
            {
                Id = 1,
                FirstName = "Root",
                LastName = "ROOT",
                PhoneNumber = "0101010101",
                Address = "2 rue tartempion 55555 Bidule",
                Email = "root@sportscorp.com",
                PassWord = "UEFzczAwKytsYSBjbMOpIHN1cGVyIHNlY3LDqHRlIGRlIGxhIHBva2Vtb24gYXBp", // PAss00++
                IsAdmin = true
            };
            var defaultUser = new User()
            {
                Id = 2,
                FirstName = "Default",
                LastName = "USER",
                PhoneNumber = "0202020202",
                Address = "10 rue tartempion 55555 Turlututu",
                Email = "defaultuser@email.com",
                PassWord = "UEFzczAwKytsYSBjbMOpIHN1cGVyIHNlY3LDqHRlIGRlIGxhIHBva2Vtb24gYXBp", //PAss00++
                IsAdmin = false
            };
            modelBuilder.Entity<User>().HasMany(e => e.Sessions).WithMany(e => e.Users).UsingEntity<Dictionary<string, object>>(
            "SessionsUser",
                r => r.HasOne<Session>().WithMany().HasForeignKey("SessionId"),
                l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                je =>
                {
                    je.HasKey("SessionId", "UserId");
                    je.HasData(
                             new { SessionId = 1, UserId = 2 },
                             new { SessionId = 2, UserId = 2 });
                });
            //modelBuilder.Entity<Session>().HasMany(e => e.Users).WithMany(e => e.Sessions);
            modelBuilder.Entity<Session>().HasMany(e => e.Comments).WithOne(e => e.Session).HasForeignKey(e => e.SessionId).HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<Room>().HasMany(e => e.Schedules).WithOne(e => e.Room).HasForeignKey(e => e.RoomId).HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<Room>().HasMany(e => e.Activities).WithMany(e => e.Rooms).UsingEntity<Dictionary<string, object>>(
                "ActivityRoom",
                r => r.HasOne<Activity>().WithMany().HasForeignKey("ActivityId"),
                l => l.HasOne<Room>().WithMany().HasForeignKey("RoomId"),
                je =>
                {
                    je.HasKey("ActivityId", "RoomId");
                    je.HasData(
                        new { ActivityId = 1, RoomId = 2 },
                        new { ActivityId = 2, RoomId = 1 },
                        new { ActivityId = 3, RoomId = 1 },
                        new { ActivityId = 4, RoomId = 1 },
                        new { ActivityId = 5, RoomId = 2 },
                        new { ActivityId = 6, RoomId = 2 });
                });

            modelBuilder.Entity<User>().HasData(adminRoot);
            modelBuilder.Entity<User>().HasData(defaultUser);

            modelBuilder.Entity<Room>().HasData(InitialRoom.rooms);
            modelBuilder.Entity<Activity>().HasData(InitialRoom.activities);
            modelBuilder.Entity<Schedule>().HasData(InitialRoom.schedules);
            modelBuilder.Entity<Session>().HasData(InitialRoom.sessions);
            modelBuilder.Entity<Comment>().HasData(InitialRoom.comments);
        }
    }
}
