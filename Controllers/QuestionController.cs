using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;


namespace WebApp1.Controllers
{ //This view shows questions relating to the associated quiz based on it's share QuizId.
  public class QuestionController : Controller
  {
    QuestionDataContext objQuestionDataContext = new QuestionDataContext();

   
    public ActionResult QuestionQ(int Id)
   
    {
      var Questions = (from eachQ in objQuestionDataContext.Questions select eachQ).Where(s => s.Quiz2Id == Id).ToList();


      return View(objQuestionDataContext.Questions.Where(s => s.Quiz2Id == Id).ToList());
    }

    //Question view for Restricted user with no answers
    public ActionResult QuestionQRestrict(int Id)
    
    {
      var Questions = (from eachQ in objQuestionDataContext.Questions select eachQ).Where(s => s.Quiz2Id == Id).ToList();


      return View(objQuestionDataContext.Questions.Where(s => s.Quiz2Id == Id).ToList());
    }
    //Question view For view user with no edit permissions.
    public ActionResult QuestionQView(int Id)
   
    {
      var Questions = (from eachQ in objQuestionDataContext.Questions select eachQ).Where(s => s.Quiz2Id == Id).ToList();


      return View(objQuestionDataContext.Questions.Where(s => s.Quiz2Id == Id).ToList());
    }

    // question details view of all questions
    public IActionResult QuestionDetails()

    {


      var QuizList = (from eachQ in objQuestionDataContext.Questions select eachQ).ToList();


      return View(objQuestionDataContext.Questions.ToList());
    }

    // create new question view
    public ActionResult create()
    {

      return View();
    }

    //post of question
    [HttpPost]
    public ActionResult create(Question objQ)
    {

      objQuestionDataContext.Questions.Add(objQ);
      objQuestionDataContext.SaveChanges();
      return Redirect("QuestionDetails");
    }
  
    
    //Details view of selected question
    public ActionResult Details(string id)
    {
      int QId = Convert.ToInt32(id);
      var objQ = objQuestionDataContext.Questions.Find(QId);
      return View(objQ);
    }

    //Details question view for view user
    public ActionResult ViewUserDetails(string id)
    {
      int QId = Convert.ToInt32(id);
      var objQ = objQuestionDataContext.Questions.Find(QId);
      return View(objQ);
    }
    // Admin detail view
    public ActionResult ViewAdminDetails(string id)
    {
      int QId = Convert.ToInt32(id);
      var objQ = objQuestionDataContext.Questions.Find(QId);
      return View(objQ);
    }

    //question edit view
    public ActionResult Edit(int id)
    {
      int QId = Convert.ToInt32(id);
      var objQ = objQuestionDataContext.Questions.Find(QId);
      return View(objQ);
    }

    //post questions
    [HttpPost]
    public ActionResult Edit(Question objQ)
    {
      var data = objQuestionDataContext.Questions.Find(objQ.QuestionId);
      if (data != null)
      {
        data.QuestionId = objQ.QuestionId;
        data.Q = objQ.Q;
        data.Choice1 = objQ.Choice1;
        data.Choice2 = objQ.Choice2;
        data.Choice3 = objQ.Choice3;
        data.Choice4 = objQ.Choice4;
        data.Choice5 = objQ.Choice5;
        data.Answer = objQ.Answer;
        data.Quiz2Id = objQ.Quiz2Id;
      }
      objQuestionDataContext.SaveChanges();
      return Redirect("QuestionDetails"); 
    }

    //delete question view
    public ActionResult Delete(int id)
    {
      int QId = Convert.ToInt32(id);
      var Q = objQuestionDataContext.Questions.Find(QId);
      return View(Q);
    }

    //post of delete questions
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var quiz = await objQuestionDataContext.Questions.FindAsync(id);
      objQuestionDataContext.Questions.Remove(quiz);
      await objQuestionDataContext.SaveChangesAsync();
      return View(); 
    }

    private bool QuizExists(int id)
    {
      return objQuestionDataContext.Quiz2s.Any(e => e.Quiz2Id == id);
    }

  
  }
}

