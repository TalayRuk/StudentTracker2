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
      // Delete One course
      Post["/delete"] = _ => {
        string idString = Request.Form["id"];
        int id = Int32.Parse(idString);
        Student student = Student.Find(id);
        student.DeleteOne();

        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };

      //DELETE all student
      Post["/delete_all"] = _ => {
        Student.DeleteAll();
        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };
      //Add Course
      Post["/add_course"] = _ => {
        string name = Request.Form["name"];
        DateTime startDate = Request.Form["start-Date"];
        string activeString = Request.Form["active"];
        int active = Int32.Parse(activeString);
        Course course = new Course(name, startDate, active);
        course.Save();

        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };
      // Delete One course
      Post["/delete_course"] = _ => {
        string idString = Request.Form["id"];
        int id = Int32.Parse(idString);
        Course course = Course.Find(id);
        course.DeleteOne();

        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };
      //DELETE all course
      Post["/delete_all_course"] = _ => {
        Course.DeleteAll();
        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };
      ////
      //Add Course
      Post["/add_project"] = _ => {
        string name = Request.Form["name"];
        DateTime startDate = Request.Form["date"];
        Project project = new Project(name, startDate);
        project.Save();

        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };
      // Delete One course
      Post["/delete_project"] = _ => {
        string idString = Request.Form["id"];
        int id = Int32.Parse(idString);
        Project project = Project.Find(id);
        project.Delete();

        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };
      //DELETE all course *not working
      Post["/delete_all_project"] = _ => {
        Project.DeleteAll();
        Dictionary<string, object> model = ViewRoutes.IndexView();
        return View["index.cshtml", model];
      };


      //////////////////////////////////////////////////////
      /// Goes student.cshtml
      /////////////////////////////////////////////////////

      Get["/student/{id}"] = parameters => {
          Student student = Student.Find(parameters.id);
          List<Course> courseList = student.GetCourses();
          List<Project> projectList = student.GetProjects();
          Dictionary<string, object> model = new Dictionary<string, object>{};
          model.Add("courseList", courseList);
          model.Add("projectList", projectList);
          model.Add("student", student);
          return View["student.cshtml", model];
      };


      Post["/update/{id}"] = parameters => {
        Student student = Student.Find(parameters.id);
        string fname = Request.Form["fname"];
        string lname = Request.Form["lname"];
        string email = Request.Form["email"];
        string picture = Request.Form["picture"];
        DateTime startDate = Request.Form["startDate"];
        Student newStudent = new Student (fname, lname, email, picture, startDate);
        newStudent.Save();
        student.UpdateAll(newStudent);
        List<Course> courseList = student.GetCourses();
        List<Project> projectList = student.GetProjects();
        Dictionary<string, object> model = new Dictionary<string, object>{};
        model.Add("courseList", courseList);
        model.Add("projectList", projectList);
        model.Add("student", student);
        return View["student.cshtml", model];
      };

      // Basic Link GetAll

      // link :homepage, courseslist, delete, project list?
      //UpdateAll student
      // add course to student
      //delete course from student
      //add project to student ????
      //////////////////////////////////////////////////////
      /// Goes Course.cshtml
      /////////////////////////////////////////////////////

      Get["/course/{id}"] = parameters => {
          Course course = Course.Find(parameters.id);
          List<Student> studentList = course.GetStudents();
          Dictionary<string, object> model = new Dictionary<string, object>{};
          model.Add("studentList", studentList);
          model.Add("course", course);
          return View["course.cshtml", model];
      };

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
