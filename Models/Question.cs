using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
  
  public class Question
  {

    
    [Key]
    public int QuestionId { get; set; }
    [Required()]
    [DisplayName("Question")]
    public string Q { get; set; }
    [Required()]
    [DisplayName("A")]
    public string Choice1 { get; set; }
    [Required()]
    [DisplayName("B")]
    public string Choice2 { get; set; }
    [Required()]
    [DisplayName("C")]
    public string Choice3 { get; set; }
    [DisplayName("D")]
    public string Choice4 { get; set; }
    [DisplayName("E")]
    public string Choice5 { get; set; }
    [Required()]
    public string Answer { get; set; }

    public int? Quiz2Id { get; set; }
    public Quiz2 Quiz2 { get; set; }
  

  }
  public class Quiz2
  {
    [Key]
    public int Quiz2Id { get; set; }

    [Required()]
    [DisplayName("Quiz")]
    public string QuizTitle { get; set; }

    public ICollection<Question> Questions { get; set; }
  }

  //[Keyless]
  //public class QuizQuestion
  //{
  //  public string QuizName { get; set; }
  //  public string Question { get; set; }
  //}





}

