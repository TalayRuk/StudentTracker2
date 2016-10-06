using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Nancy;

namespace Epicodus
{
  public class ViewRoutes : NancyModule
  {
    public static Dictionary<string, object> IndexView()
    {
      List<Student> studentList = Student.GetAll();
      List<Course> courseList = Course.GetAll();
      List<Project> projectList = Project.GetAll();
      Dictionary<string, object> model = new Dictionary<string, object>{};
      model.Add("studentList", studentList);
      model.Add("courseList", courseList);
      model.Add("projectList", projectList);
      return model;
    }
    public static Dictionary<string, object> StudentView()
    {
      List<Course> courseList = Student.GetCourses();
      List<Project> projectList = Student.GetProjects();
      Dictionary<string, object> model = new Dictionary<string, object>{};
      model.Add("courseList", courseList);
      model.Add("projectList", projectList);
      return model;
    }
  }
}
