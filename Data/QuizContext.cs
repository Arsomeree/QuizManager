//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using WebApp1.Models;

//namespace WebApp1.Data
//{
//  public class QuizContext : DbContext
//  {
//    public DbSet<Quiz> Quiz { get; set; }
//    public DbSet<Quiz2> Quiz2s { get; set; }
//    public DbSet<Question> Questions { get; set; }
//    protected override void OnModelCreating(DbModelBuilder modelBuilder)
//    {
//      // configures one-to-many relationship
//      modelBuilder.Entity<Question>()
//          .HasRequired<Quiz2>(s => s.CurrentQuiz)
//          .WithMany(g => g.Questions)
//          .HasForeignKey<int>(s => s.CurrentQuizId);
//    }
//  }



//}
////    public class QuizContext (DbContextOptions)<QuizContext> options)
////      :base(options)
////      {
////      }

////  public DbSet<Quiz> Quiz { get; set; }

////  protected override void OnModelCreating(ModelBuilder modelBuilder)
////  {
////    modelBuilder.Entity<Quiz>().ToTable("Quiz");

////  }
////}


