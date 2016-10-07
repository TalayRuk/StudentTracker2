using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Epicodus
{
  public class Project
  {
    private int _id;
    private string _name;
    private DateTime _date;
    private string _grade;

    public Project(string name, DateTime date, int id = 0, string grade = "Null")
    {
      _id = id;
      _name = name;
      _date = date;
      _grade = grade;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public DateTime GetDate()
    {
      return _date;
    }
    public string GetGrade()
    {
      return _grade;
    }
    public override bool Equals(System.Object otherProject)
    {
      if (!(otherProject is Project))
      {
        return false;
      }
      else
      {
        Project newProject = (Project) otherProject;
        bool idEquality = (this.GetId() == newProject.GetId());
        bool nameEquality = (this.GetName() == newProject.GetName());
        bool dateEquality = (this.GetDate() == newProject.GetDate());
        return (idEquality && nameEquality && dateEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }

    public static List<Project> GetAll()
    {
      List<Project> allProjects = new List<Project>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM projects;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        DateTime date = rdr.GetDateTime(2);
        Project newProject = new Project(name, date, id);
        allProjects.Add(newProject);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allProjects;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO projects (name, date) OUTPUT INSERTED.id VALUES (@name, @date);", conn);
      cmd.Parameters.Add(new SqlParameter("@name", this.GetName()));
      cmd.Parameters.Add(new SqlParameter("@date", this.GetDate()));
      SqlDataReader rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        _id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Project Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM projects WHERE id = @id;" , conn);

      cmd.Parameters.Add(new SqlParameter("@id", id.ToString() ) );
      SqlDataReader rdr = cmd.ExecuteReader();

      int projectId = 0;
      string name = null;
      DateTime defaultDate = new DateTime (2016, 08, 01);

      while (rdr.Read())
      {
        projectId = rdr.GetInt32(0);
        name = rdr.GetString(1);
        defaultDate = rdr.GetDateTime(2);
      }
      Project foundProject = new Project(name, defaultDate, projectId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundProject;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd2 = new SqlCommand("DELETE FROM scg;", conn);
      cmd2.ExecuteNonQuery();

      SqlCommand cmd1 = new SqlCommand("DELETE FROM students_courses;", conn);
      cmd1.ExecuteNonQuery();

      SqlCommand cmd = new SqlCommand("DELETE FROM projects;", conn);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM projects WHERE id = @id;" , conn);
      cmd.Parameters.Add(new SqlParameter("@id", this.GetId() ) );
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public void Update(Project newProject)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("UPDATE projects SET name = @NewName, date = @Date OUTPUT INSERTED.name, INSERTED.date WHERE id = @Id;", conn);

      cmd.Parameters.Add(new SqlParameter("@NewName", newProject.GetName() ));
      cmd.Parameters.Add(new SqlParameter("@Date", newProject.GetDate() ));
      cmd.Parameters.Add(new SqlParameter("@Id", newProject.GetId() ));

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read() )
      {
        this._name = rdr.GetString(0);
        this._date = rdr.GetDateTime(1);
      }

      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }
    }
    public void AddCourseStudent(int student_id, int class_id, string grade )
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string query =  "SELECT id FROM students_courses WHERE student_id = @student_id AND class_id = @class_id;";
      SqlCommand cmd = new SqlCommand(query, conn);
      cmd.Parameters.Add(new SqlParameter("@student_id", student_id ));
      cmd.Parameters.Add(new SqlParameter("@class_id", class_id ));
      SqlDataReader rdr = cmd.ExecuteReader();

      int id = 0;
      while( rdr.Read() )
      {
        id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }
      conn.Open();

      string query1 = "INSERT INTO scg (students_courses_id, projects_id, grade) VALUES (@id, @project_id, @grade);";
      SqlCommand cmd2 = new SqlCommand(query1, conn);
      cmd2.Parameters.Add(new SqlParameter("@id", id ));
      cmd2.Parameters.Add(new SqlParameter("@project_id", this.GetId() ));
      cmd2.Parameters.Add(new SqlParameter("@grade", grade ));
      cmd2.ExecuteNonQuery();

      conn.Close();
    }

//     public static Dictionary<string, string> GetSCG()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       string query =  "
// SELECT
// students.id,students.fname,students.lname,students.email,students.picture,students.sdate,students_courses.id,students_courses.student_id,students_courses.class_id,courses.id,courses.name,courses.sdate,courses.active,scg.id,scg.students_courses_id,scg.projects_id,scg.grade, projects.id, projects.name, projects.date FROM STUDENTS JOIN STUDENTS_COURSES ON STUDENTS.id = STUDENTS_COURSES.student_id JOIN COURSES ON COURSES.id = STUDENTS_COURSES.class_id JOIN SCG ON SCG.students_courses_id = STUDENTS_COURSES.id JOIN PROJECTS on PROJECTS.id = SCG.projects_id;";
//       SqlCommand cmd = new SqlCommand(query, conn);
//       SqlDataReader rdr = cmd.ExecuteReader();
//
//       Dictionary<string, string> dictionary = new Dictionary<string, string> {};
//
//       while( rdr.Read() )
//       {
//         string students_id = rdr.GetInt32(0).ToString();
//         dictionary.Add("students_id",students_id);
//
//         string students_fname = rdr.GetString(1);
//         dictionary.Add("students_fname", students_fname);
//
//         string students_lname = rdr.GetString(2);
//         dictionary.Add("students_lname",students_lname);
//
//         string students.email = rdr.GetString(3);
//         dictionary.Add("students.email,",students.email);
//
//         string students.picture = rdr.GetString(4);
//         dictionary.Add("students.picture",students.picture);
//
//         string students.sdate = rdr.GetDateTime(5).ToString();
//         dictionary.Add("students_id",students.sdate);
//
//       }
    //
    //   if (rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //
    //   if (conn != null)
    //   {
    //     conn.Close();
    //   }
    //   return dictionary;
    // }

    public static void DeleteSCG()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd1 = new SqlCommand("DELETE FROM scg;", conn);
      cmd1.ExecuteNonQuery();
    }
  }
}
