using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Epicodus
{
  public class Student
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _picture;
    private DateTime _startDate;

    public Student(string firstName, string lastName, string email, string picture, DateTime startDate, int id = 0)
    {
      _firstName = firstName;
      _lastName = lastName;
      _email = email;
      _picture = picture;
      _startDate = startDate;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetFName()
    {
      return _firstName;
    }
    public string GetLName()
    {
      return _lastName;
    }
    public string GetEmail()
    {
      return _email;
    }
    public string GetPicture()
    {
      return _picture;
    }
    public DateTime GetStartDate()
    {
      return _startDate;
    }

    public override bool Equals(System.Object otherStudent)
    {
      if (!(otherStudent is Student))
      {
        return false;
      }
      else
      {
        Student newStudent = (Student) otherStudent;
        bool idEquality = (this.GetId() == newStudent.GetId());
        bool firstNameEquality = (this.GetFName() == newStudent.GetFName());
        bool lastNameEquality = (this.GetLName() == newStudent.GetLName());
        bool emailEquality = (this.GetEmail() == newStudent.GetEmail());
        bool startDateEquality = (this.GetStartDate() == newStudent.GetStartDate());
        return (idEquality && firstNameEquality && lastNameEquality && emailEquality && startDateEquality);
      }
    }
    //GetHash
    public override int GetHashCode()
    {
      return this.GetFName().GetHashCode();
    }

    public static List<Student> GetAll()
    {
      List<Student> allStudents = new List<Student>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string firstName = rdr.GetString(1);
        string lastName = rdr.GetString(2);
        string email = rdr.GetString(3);
        string picture = rdr.GetString(4);
        DateTime startDate = rdr.GetDateTime(5);
        Student newStudent = new Student(firstName, lastName, email, picture, startDate, id);
        allStudents.Add(newStudent);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allStudents;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO students (fname, lname, email, picture, sdate) OUTPUT INSERTED.id VALUES (@fname, @lname, @email, @picture, @sDate);", conn);

      cmd.Parameters.Add(new SqlParameter("@fname", this.GetFName()));
      cmd.Parameters.Add(new SqlParameter("@lname", this.GetLName()));
      cmd.Parameters.Add(new SqlParameter("@email", this.GetEmail()));
      cmd.Parameters.Add(new SqlParameter("@picture", this.GetPicture()));
      cmd.Parameters.Add(new SqlParameter("@sDate", this.GetStartDate()));

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

    public static Student Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE id = @id;", conn);

      cmd.Parameters.Add(new SqlParameter("@id", id));
      SqlDataReader rdr = cmd.ExecuteReader();

      int studentId = 0;
      string firstName = null;
      string lastName = null;
      string email = null;
      string picture = null;
      DateTime defaultDate = new DateTime (2016, 08, 01);

      while (rdr.Read())
      {
        studentId = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        email = rdr.GetString(3);
        picture = rdr.GetString(4);
        defaultDate = rdr.GetDateTime(5);

      }
      Student foundStudent = new Student(firstName, lastName, email, picture, defaultDate, studentId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundStudent;
    }

    // public void Update(string firstName, string lastName, string email, string picture, DateTime startDate, int id = 0)
    public static Student UpdateAll(Student currentStudent)
    {
      // this;
      // currentStudent;
      //in routing .. need to have already set form @Model ...
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE students SET fname = @fname OUTPUT INSERTED.fname WHERE id = @StudentId;", conn);

      SqlCommand cmd = new SqlCommand("UPDATE students SET (lname = @lname) OUTPUT INSERTED.lname;", conn);

      SqlCommand cmd = new SqlCommand("UPDATE students SET (email = @email) OUTPUT INSERTED.email;", conn);

      SqlCommand cmd = new SqlCommand("UPDATE students SET (picture = @picture) OUTPUT INSERTED.picture;", conn);

      SqlCommand cmd = new SqlCommand("UPDATE students SET (sdate = @sDate) OUTPUT INSERTED.sdate;", conn);
// CMD is already diffined in this scope - try googling long string update / multiple collums
      SqlParameter firstNameParameter = new SqlParameter();
      firstNameParameter.ParameterName = "@fname";
      firstNameParameter.Value = currentStudent.GetFName();
      cmd.Parameters.Add(firstNameParameter);
      cmd.Parameters.Add(new SqlParameter("@lname", currentStudent.GetLName()));
      cmd.Parameters.Add(new SqlParameter("@lname", currentStudent.GetLName()));
      cmd.Parameters.Add(new SqlParameter("@email", currentStudent.GetEmail()));
      cmd.Parameters.Add(new SqlParameter("@picture", currentStudent.GetPicture()));
      cmd.Parameters.Add(new SqlParameter("@sDate", currentStudent.GetStartDate()));
      cmd.Parameters.Add(new SqlParameter("@StudentId", currentStudent.GetId()));
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        string fname = rdr.GetString(0);
        string lname = rdr.GetString(0);
        string email = rdr.GetString(0);
        string picture = rdr.GetString(0);
        DateTime sdate = rdr.GetDateTime(0);
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


    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM students;", conn);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }
  }
}
