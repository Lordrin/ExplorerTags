using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoTagPlayer.Domain.model;

namespace VideoTagPlayer.DataLayer
{
    public class VideoTagContext : DbContext
    {
        public VideoTagContext()
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
            modelBuilder.Entity<Video>().Ignore(t => t.Path);
            modelBuilder.Entity<Video>().ToTable("Videos");
            modelBuilder.Entity<VideoPath>().ToTable("VideoPaths");
            base.OnModelCreating(modelBuilder);

        }
    }
}
