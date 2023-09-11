using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Controllers
{// Using permissioning for manager aka view user to see questions and answers. Most of these views will not be utlised and only the Question controller will be used as this user can only see questions and answers. 
  [Authorize(Roles = "Manager")]
  public class ViewUserController : Controller
    {
    QuestionDataContext Quiz2DataContext = new QuestionDataContext();

    //This is the initial view the user sees and controls what the user will be able to see and redirects to the question controller in the html page. 
    public IActionResult Index()
    {
      List<Quiz2> Quiz2 = Quiz2DataContext.Quiz2s.ToList();
      return View(Quiz2);
   
    }

    public ActionResult create()
    {

      return View();
    }


    // GET: Quiz2b/Create
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
        Questions = quiz.Questions.ToList()
      };

      return View(view);
    }

    public ActionResult Edit(string id)
    {
      int quiz2Id = Convert.ToInt32(id);
      var quiz2 = Quiz2DataContext.Quiz2s.Find(quiz2Id);
      return View(quiz2);
    }

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

    public ActionResult Delete(string id)
    {
      int quiz2Id = Convert.ToInt32(id);
      var quiz2 = Quiz2DataContext.Quiz2s.Find(quiz2Id);
      return View(quiz2);
    }
  }
}







