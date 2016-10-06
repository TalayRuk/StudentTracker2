using System;
using System.Collections.Generic;
using Nancy;

namespace Epicodus
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {

      Get["/password"] = _ => {
        return View["password.cshtml"];
      };
      //////////////////////////////////////////////////////
      /// Goes index.cshtml
      /////////////////////////////////////////////////////
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

      //DELETE all students
      //DELETE all course
      //Add Course
      // Delete One course


      //////////////////////////////////////////////////////
      /// Goes student.cshtml
      /////////////////////////////////////////////////////
      // Basic Link GetAll
      // link :homepage, courseslist, delete, project list?
      //UpdateAll student
      // add course to student
      //delete course from student
      //add project to student ????
      //////////////////////////////////////////////////////
      /// Goes Course.cshtml
      /////////////////////////////////////////////////////
      //link to getall course, homepage, studentlist, delete, project?
      //updateAll course
      //delete student from course
      //add project to course???
      //list project

      ////////////////////////////////////
      //// Project.cshtml
      // //////////////
      //project list
      //add project
      // select project 



      Post["/editAll"] = _ => {

      };
      Post["/deleteall"] = _ => {
        Student student = Student.GetId();
        student.DeleteAll();
        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };

      Post["/add-course"] = _ => {

      };
      Post["/edit-course"] = _ => {

      };
      Post["/delete-course"] = _ => {

      };
      Post["/deleteall-course"] = _ => {

      };
      Post["/add-project"] = _ => {

      };
      Post["/edit-project"] = _ => {

      };
      Post["/delete-project"] = _ => {

      };
      Post["/deleteall-project"] = _ => {

      };
      Post["/add-student-to-course"] = _ => {

      };
      Post["/delete-student-to-course"] = _ => {

      };
      Post["/add-course-to-student"] = _ => {

      };
      Post["/delete-course-to-student"] = _ => {

      };
      Post["/add-project-to-student"] = _ => {

      };
      Post["/delete-project-to-student"] = _ => {

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
