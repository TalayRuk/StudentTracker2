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

          Dictionary<string, object> model = ViewRoutes.StudentsView(student);
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
        student.UpdateAll(newStudent);

        Dictionary<string, object> model = ViewRoutes.StudentsView(student);
        return View["student.cshtml", model];
      };

      Post["/update_courses/{id}"] = parameters => {
        Student student = Student.Find(parameters.id);


        string courseidString = Request.Form["courseid"];
        int courseidStringid = Int32.Parse(courseidString);

        string idString = Request.Form["projectid"];
        int projectId = Int32.Parse(idString);
        Project project = Project.Find(projectId);

        string grade = Request.Form["grade"];

        project.AddCourseStudent(student.GetId(),courseidStringid,grade);


        Dictionary<string, object> model = ViewRoutes.StudentsView(student);
        return View["student.cshtml", model];
      };

      Patch["/student/{id}"] = parameters => {
        Student student = Student.Find(parameters.id);

        string idString = Request.Form["id"];
        int id = Int32.Parse(idString);
        Course course = Course.Find(id);
        student.AddCourse(course);

        Dictionary<string, object> model = ViewRoutes.StudentsView(student);
        return View["student.cshtml", model];
      };

    Delete["/student/{id}"] = parameters => {
        Student student = Student.Find(parameters.id);
        string idString = Request.Form["id"];
        int id = Int32.Parse(idString);
        student.DeleteCourse(id);

        Dictionary<string, object> model = ViewRoutes.StudentsView(student);
        return View["student.cshtml", model];
      };

      //////////////////////////////////////////////////////
      /// Goes Course.cshtml
      /////////////////////////////////////////////////////

      Get["/course/{id}"] = parameters => {
      Course course = Course.Find(parameters.id);

      Dictionary<string, object> model = ViewRoutes.CourseView(course);
      return View["course.cshtml", model];
      };

      Patch["/update/{id}"] = parameters => {
        Course course = Course.Find(parameters.id);
        string name = Request.Form["name"];
        int active = Request.Form["active"];
        DateTime sdate = Request.Form["sdate"];
        Course newCourse = new Course (name, sdate, active);
        course.Update(newCourse);

        Dictionary<string, object> model = ViewRoutes.CourseView(course);
        return View["course.cshtml", model];
      };

      Patch["/course/{id}"] = parameters => {
        Course course = Course.Find(parameters.id);
        string idString = Request.Form["id"];
        int id = Int32.Parse(idString);
        Student student = Student.Find(id);
        course.AddStudent(student);

        Dictionary<string, object> model = ViewRoutes.CourseView(course);
        return View["course.cshtml", model];
      };

      Delete["/course/{id}"] = parameters => {
          Course course = Course.Find(parameters.id);

          string idString = Request.Form["id"];
          int id = Int32.Parse(idString);
          course.DeleteStudent(id);

          Dictionary<string, object> model = ViewRoutes.CourseView(course);
          return View["course.cshtml", model];
        };

        Patch["/add_project/{id}"] = parameters => {
          Course course = Course.Find(parameters.id);

          Dictionary<string, object> model = ViewRoutes.CourseView(course);
          return View["course.cshtml", model];
        };

    }
  }
}
