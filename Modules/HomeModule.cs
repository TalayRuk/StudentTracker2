using System;
using System.Collections.Generic;
using Nancy;

namespace Epicodus
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {

      Get["/"] = _ =>
        {
          List<Student> studentList = studentList.GetAll();
          List<Course> courseList = Course.GetAll();
          List<Project> projectList = Project.GetAll();
          Dictionary<string, object> model = new Dictionary<string, object>();
          model.Add("studentList", studentList);
          model.Add("courseList", courseList);
          model.Add("projectList", projectList);
          return View["index.cshtml", model];
        };

      Get["/"] = _ => {

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
