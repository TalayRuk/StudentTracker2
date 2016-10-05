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
      Get["/add"] = _ => {

        string fname = Request.Form["fname"];
        string fname = Request.Form["lname"];
        string fname = Request.Form["email"];
        string fname = Request.Form["picture"];
        string fname = Request.Form["starDate"];
        Student student = new Student (fname, lname, email, picture, startDate);
        student.Save();

        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      }

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
