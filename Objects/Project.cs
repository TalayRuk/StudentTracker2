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

    public Project(string name, DateTime date, int id = 0)
    {
      _id = id;
      _name = name;
      _date = date;
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




  }
}
