using Forum.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Forum.Data
{
    public class ForumDbContext : IdentityDbContext<User>
    {
        public ForumDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Award> Awards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
