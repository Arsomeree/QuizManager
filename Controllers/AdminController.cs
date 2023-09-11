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
{// Using identity to show this view to only admin (view/edit user)
  [Authorize(Roles = "Admin")]
  public class AdminController : Controller
  {
        
   QuestionDataContext Quiz2DataContext = new QuestionDataContext();

    //index(home) view
    public IActionResult Index()
    {
      List<Quiz2> Quiz2 = Quiz2DataContext.Quiz2s.ToList();
      return View(Quiz2);
      
    }
    //Create view
    public ActionResult create()
    {

      return View();
    }


    // GET: Quiz/Create view
    [HttpPost]
    public ActionResult create(Quiz2 objQuiz)
    {
      Quiz2DataContext.Quiz2s.Add(objQuiz);
      Quiz2DataContext.SaveChanges();
      return RedirectToAction(nameof(Index));
      
    }

    //Details view
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
      return View(quiz);
    }

      
    //Edit view
    public ActionResult Edit(string id)
    {
      int quiz2Id = Convert.ToInt32(id);
      var quiz2 = Quiz2DataContext.Quiz2s.Find(quiz2Id);
      return View(quiz2);
    }
    //Post edit view
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
      return RedirectToAction(nameof(Index));
    }
    //Delete view
    public ActionResult Delete(string id)
    {
      int quiz2Id = Convert.ToInt32(id);
      var quiz2 = Quiz2DataContext.Quiz2s.Find(quiz2Id);
      return View(quiz2);
    }

    
   
    // POST: Quizs/Delete view
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var quiz = await Quiz2DataContext.Quiz2s.FindAsync(id);
      Quiz2DataContext.Quiz2s.Remove(quiz);
      await Quiz2DataContext.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool QuizExists(int id)
    {
      return Quiz2DataContext.Quiz2s.Any(e => e.Quiz2Id == id);
    }


  }
}

