using System;
using System.Collections.Generic;
using Nancy;

namespace Epicodus
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {

      Get["/"] = _ => {
        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };
      Post["/add"] = _ => {
        string fname = Request.Form["fname"];
        string lname = Request.Form["lname"];
        string email = Request.Form["email"];
        string picture = Request.Form["picture"];
        DateTime startDate = Request.Form["startDate"];
        Student student = new Student (fname, lname, email, picture, startDate);
        student.Save();

        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };
      Post["/delete"] = _ => {
        string idstring = Request.Form["id"];
        int id = Int32.Parse(idstring);
        Console.WriteLine(id);
        Student student = Student.Find(id);
        student.DeleteOne();

        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };

    }
  }
}



//For updateAll ***note from John***
// FORM ROUTE->
//
// FORM populated with Student Data:
// <input type="text" value="@Model.GetFName()"></input>
//
// POST ROUTE to SUCCESS PAGE->
// Student EditedStudent = new Student(Request.Form["fname"], )
