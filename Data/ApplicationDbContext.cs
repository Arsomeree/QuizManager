using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp1.Models;

namespace WebApp1.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Quiz> Quiz { get; set; }
    public DbSet<Quiz2> Quiz2s { get; set; }
    public DbSet<Question> Questions { get; set; }
    //  protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //  {
    //    // configures one-to-many relationship
    //    modelBuilder.Entity<Question>()
    //        .HasRequired<Quiz2>(s => s.CurrentQuiz)
    //        .WithMany(g => g.Questions)
    //        .HasForeignKey<int>(s => s.CurrentQuizId);
    //  }
    //}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //  modelBuilder.Entity<Quiz>().ToTable("QuizInfo");
    //}
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //  modelBuilder.Entity<Question>().ToTable("Question");

    //}
  }
}

