using Microsoft.EntityFrameworkCore;
using FilRougeCore.Models;

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
                LastName = "User",
                PhoneNumber = "0202020202",
                Address = "10 rue tartempion 55555 Turlututu",
                Email = "defaultuser@email.com",
                PassWord = "UEFzczAwKytsYSBjbMOpIHN1cGVyIHNlY3LDqHRlIGRlIGxhIHBva2Vtb24gYXBp", //PAss00++
                IsAdmin = false
            };
            modelBuilder.Entity<User>().HasMany(e => e.Sessions).WithMany(e => e.Users);
            modelBuilder.Entity<Session>().HasMany(e => e.Users).WithMany(e => e.Sessions);
            modelBuilder.Entity<Session>().HasMany(e => e.Comments).WithOne(e => e.Session).HasForeignKey(e => e.SessionId).HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<Room>().HasMany(e => e.Schedules).WithOne(e => e.Room).HasForeignKey(e => e.RoomId).HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<User>().HasData(adminRoot);
            modelBuilder.Entity<User>().HasData(defaultUser);
        }
    }
}
