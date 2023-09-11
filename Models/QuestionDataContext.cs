using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;


using System.Data.Entity;


namespace WebApp1.Models

{

  public class QuestionDataContext : DbContext

  {
    //public QuestionDataContext()
    //  : base(options) { }


    public DbSet<Quiz2> Quiz2s { get; set; }
    public DbSet<Question> Questions { get; set; }
    //public DbSet<QuizQuestion> QuizQuestions { get; set; }
    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{
    //  // configures one-to-many relationship
    //  modelBuilder.Entity<Question>()
    //    .HasRequired<Quiz2>(s => s.Quiz2)
    //        .WithMany(g => g.Questions)
    //        .HasForeignKey(s => s.Quiz2Id);

    //}

    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{
    //  modelBuilder.Entity<QuizQuestion>(
    //      eb =>
    //      {
    //        eb.HasNoKey();
    //        eb.ToView("View_QuizQuestions");
    //        eb.Property(v => v.QuizName).HasColumnName("QuizTitle");
    //      });

    }
  }





