using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Epicodus
{
  public class Course
  {
    private int _id;
    private string _name;
    private DateTime _startDate;
    private int _active;

    public Course(string name, DateTime startDate, int active, int id = 0)
    {
      _id = id;
      _name = name;
      _startDate = startDate;
      _active = active;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public DateTime GetStartDate()
    {
      return _startDate;
    }
    public int GetActive()
    {
      return _active;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public void SetDate(DateTime newStartDate)
    {
      _startDate = newStartDate;
    }
    public void SetActive(int active)
    {
      _active = active;
    }

    public override bool Equals(System.Object otherCourse)
    {
      if (!(otherCourse is Course))
      {
        return false;
      }
      else
      {
        Course newCourse = (Course) otherCourse;
        bool idEquality = (this.GetId() == newCourse.GetId());
        bool nameEquality = (this.GetName() == newCourse.GetName());
        bool startDateEquality = (this.GetStartDate() == newCourse.GetStartDate());
        bool activeEquality = (this.GetActive() == newCourse.GetActive());
        return (idEquality && nameEquality && startDateEquality && activeEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }


    public static List<Course> GetAll()
    {
      List<Course> allCourses = new List<Course>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        DateTime date = rdr.GetDateTime(2);
        int active = rdr.GetInt32(3);
        Course newCourse = new Course(name, date, active, id);
        allCourses.Add(newCourse);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allCourses;
    }


    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO courses (name, sdate, active) OUTPUT INSERTED.id VALUES (@Name, @Sdate, @Active);", conn);

      cmd.Parameters.Add(new SqlParameter("@Name", this.GetName()));
      cmd.Parameters.Add(new SqlParameter("@Sdate", this.GetStartDate()));
      cmd.Parameters.Add(new SqlParameter("@Active", this.GetActive()));
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        _id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd1 = new SqlCommand("DELETE FROM students_courses;", conn);
      cmd1.ExecuteNonQuery();

      SqlCommand cmd = new SqlCommand("DELETE FROM courses;", conn);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

    public void DeleteOne()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM courses WHERE id = @courseId;", conn);
      cmd.Parameters.Add(new SqlParameter("@courseId", this.GetId()));

      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }


    public static Course Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses WHERE id = @id;", conn);

      cmd.Parameters.Add(new SqlParameter("@id", id));
      SqlDataReader rdr = cmd.ExecuteReader();

      int courseId = 0;
      string name = null;
      DateTime defaultDate = new DateTime (2016, 08, 01);
      int active = 0;
      while (rdr.Read())
      {
        courseId = rdr.GetInt32(0);
        name = rdr.GetString(1);
        defaultDate = rdr.GetDateTime(2);
        active = rdr.GetInt32(3);
      }
      Course foundCourse = new Course(name, defaultDate, active, courseId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundCourse;
    }


    public void Update(Course newCourse)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("UPDATE courses SET name = @NewName, sdate = @Date, active = @Active OUTPUT INSERTED.name, INSERTED.sdate, INSERTED.active WHERE id = @Id;", conn);

      cmd.Parameters.Add(new SqlParameter("@NewName", newCourse.GetName() ));
      cmd.Parameters.Add(new SqlParameter("@Date", newCourse.GetStartDate() ));
      cmd.Parameters.Add(new SqlParameter("@Active", newCourse.GetActive() ));
      cmd.Parameters.Add(new SqlParameter("@Id", newCourse.GetId() ));

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read() )
      {
        this._name = rdr.GetString(0);
        this._startDate = rdr.GetDateTime(1);
        this._active = rdr.GetInt32(2);
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


  }
}
