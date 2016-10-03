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
    // public void Save()
    // {
    //
    // }
  }
}
