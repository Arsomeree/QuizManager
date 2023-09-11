using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Controllers
{// Controls the quiz view.
  public class Quiz2Controller : Controller
  {
   QuestionDataContext Quiz2DataContext = new QuestionDataContext();

    //Initial page to show all quizzes
    public IActionResult Index()
    {
      List<Quiz2> Quiz2 = Quiz2DataContext.Quiz2s.ToList();
      return View(Quiz2);
     
    }
    //Create new quiz view
    public ActionResult create()
    {

      return View();
    }


    // GET: Quiz2/Create
    [HttpPost]
    public ActionResult create(Quiz2 objQuiz)
    {
      Quiz2DataContext.Quiz2s.Add(objQuiz);
      Quiz2DataContext.SaveChanges();
      return View();
    }
    public ActionResult Details(int? id)
    {


     

      Quiz2 quiz = Quiz2DataContext.Quiz2s
    .Include(a => a.Questions)
    .Where(a => a.Quiz2Id == id)
    .SingleOrDefault();

      if (quiz == null)
      {
        return NotFound();
      }

      var view = new QuizwithQDetaillView
      {
        Quiz2Id = quiz.Quiz2Id,
        QuizTitle = quiz.QuizTitle,
        Questions=quiz.Questions.ToList()
      };

        return View(view);
      }
    //edit quiz view
  public ActionResult Edit(string id)
    {
      int quiz2Id = Convert.ToInt32(id);
      var quiz2 = Quiz2DataContext.Quiz2s.Find(quiz2Id);
      return View(quiz2);
    }
    //posts edit of quiz
    [HttpPost]
    public ActionResult Edit(Quiz2 objQuiz)
    {
      var data = Quiz2DataContext.Quiz2s.Find(objQuiz.Quiz2Id);
      if (data != null)
      {
        data.Quiz2Id = objQuiz.Quiz2Id;
        data.QuizTitle = objQuiz.QuizTitle;
        
      }
      Quiz2DataContext.SaveChanges();
      return View();
    }
    //delete quiz view
    public ActionResult Delete(string id)
    {
      int quiz2Id = Convert.ToInt32(id);
      var quiz2 = Quiz2DataContext.Quiz2s.Find(quiz2Id);
      return View(quiz2);
    }
  }
}

