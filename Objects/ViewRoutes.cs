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

    public static Dictionary<string, object> StudentsView(Student student)
    {
      List<Project> allProjects = Project.GetAll();
      List<Course> allCourses = Course.GetAll();
      List<Course> courseList = student.GetCourses();
      List<Project> projectList = student.GetProjects();
      Dictionary<string, object> model = new Dictionary<string, object>{};
      model.Add("allProjects", allProjects);
      model.Add("allCourses", allCourses);
      model.Add("courseList", courseList);
      model.Add("projectList", projectList);
      model.Add("student", student);
      return model;
    }

    public static Dictionary<string, object> CourseView(Course course)
    {
      List<Project> projectList = Project.GetAll();
      List<Student> allStudents = Student.GetAll();
      List<Student> studentList = course.GetStudents();
      List<Project> projectList = student.GetProjects();
      Dictionary<string, object> model = new Dictionary<string, object>{};
      model.Add("allStudents", allStudents);
      model.Add("studentList", studentList);
      model.Add("course", course);
      model.Add("projectList", projectList);
      model.Add("projectList", projectList);
      return model;
    }
  }
}
