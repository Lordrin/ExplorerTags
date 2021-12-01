using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoTagPlayer.Domain.model;

namespace VideoTagPlayer.DataLayer
{
    public class VideoTagContext : DbContext
    {
        public VideoTagContext() : base()
        {
        }
        public VideoTagContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoPath> VideoPaths { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=VideoTagDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var splitStringConverter = new ValueConverter<List<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }).ToList());
            modelBuilder.Entity<Video>()
                   .Property(nameof(Video.TagsWithDescriptionList))
                   .HasConversion(splitStringConverter);
            modelBuilder.Entity<Video>().Ignore(t => t.Path);
            modelBuilder.Entity<Video>().Ignore(e => e.Tags);
            modelBuilder.Entity<Video>().ToTable("Videos");
            modelBuilder.Entity<VideoPath>().ToTable("VideoPaths");
            base.OnModelCreating(modelBuilder);

        }
    }
}
