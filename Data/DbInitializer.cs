using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Data
{
  public static class DbInitializer
  {
    public static void Initialize(ApplicationDbContext context)
    {
      context.Database.EnsureCreated();

      // Look for any students.
      if (context.Quiz.Any())
      {
        return;   // DB has been seeded
      }

      var quizs = new Quiz[]
      {
            new Quiz{  Id=2,
               Title = "Animals",
              Question = "What type of animal is a seahorse ?",
             Choice1 = "Arachnid",
              Choice2 = "Fish",
               Choice3 = "Crustacean",
              Choice4 = "Coral",
               Choice5= "Shell",
                 Answer = "Fish",
            },
              new Quiz
            {  Id=2,
               Title = "Animals",
              Question = "What type of animal is a seahorse ?",
             Choice1 = "Arachnid",
              Choice2 = "Fish",
               Choice3 = "Crustacean",
              Choice4 = "Coral",
               Choice5= "Shell",
                 Answer = "Fish",
            },

            new Quiz
            {
              Id = 3,
              Title = "Politics ",
              Question = ". Who was elected President of the United States in 2017?",
             Choice1 = "Donald Trump",
              Choice2 = "Barack Obama",
              Choice3 = "George Bush",
              Choice4 = "Bill Clinton",
              Choice5 = "Tony Blair",
              Answer = "Barack Obama",
            },

            new Quiz
            {
              Id = 4,
              Title = "Cartoons ",
              Question = "Which vegetable gives Popeye his strength?",
              Choice1 = "Spinach",
              Choice2 = "Asparagus",
              Choice3 = "Lentils",
              Choice4 = "Brussels",
              Choice5 = "Pumpkin",
              Answer = "Spinach",
            },

            new Quiz
            {
              Id = 5,
              Title = "Sci-fi ",
              Question = " What is the name of Superman’s home planet?",
               Choice1 = "Rann",
              Choice2 = "Namek",
              Choice3 = "Krypton",
              Choice4 = "Qward",
              Choice5 = "Shelldon",
              Answer = "Krypton",
            },
      };
      foreach (Quiz q in quizs)
      {
        context.Quiz.Add(q);
      }
      context.SaveChanges();

    }
  }
}
