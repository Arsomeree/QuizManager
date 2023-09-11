using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
  public class Quiz
  {
    public int Id { get; set; }
    public string Title { get; set; }


    public string Question { get; set; }
    public string Choice1 { get; set; }
    public string Choice2 { get; set; }
    public string Choice3 { get; set; }
    public string Choice4 { get; set; }

    public string Choice5 { get; set; }
    public string Answer { get; set; }

   // public ICollection<Quiz> Quizzes { get; set; }
  }

    
}
