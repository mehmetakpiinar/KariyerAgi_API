using KariyerAgi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerAgi.DataAccess
{
    public class KariyerAgiContext:DbContext
    {
        public KariyerAgiContext(DbContextOptions<KariyerAgiContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Comment tablosunun User ile olan ilişkisine müdahale ediyoruz.
            // Bir Kullanıcının birden fazla Yorumu olabilir.
            // Ve bir Yorumun tek bir Kullanıcısı vardır.
            // ÖNEMLİ KISIM: Cascade (Otomatik silme) işlemini kapatıyoruz.
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // veya DeleteBehavior.NoAction

            // Aynı kriz JobApplication tablosunda da çıkabilir, onu da sağlama alalım.
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Applicant)
                .WithMany()
                .HasForeignKey(ja => ja.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

            // Like tablon için de eklemek iyi olur (eğer varsa)
            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
