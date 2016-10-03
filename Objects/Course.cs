// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Data.SqlClient;
//
// namespace Epicodus
// {
//   public class Course
//   {
//     private int _id;
//     private string _name;
//     private DateTime _startDate;
//     private int _active;
//
//     public Course(string name, DateTime startDate, int active, int Id = 0)
//     {
//       _id = id;
//       _name = name;
//       _startDatedate = startDatedate;
//       _active = active;
//     }
//     public int GetId()
//     {
//       return _id;
//     }
//     public string GetName()
//     {
//       return _name;
//     }
//     public DateTime GetStartDate()
//     {
//       return _startDate;
//     }
//     public int GetActive()
//     {
//       return _active;
//     }
//     public void SetName()
//     {
//       _name = newName;
//     }
//     public void SetDate(DateTime newStartDate)
//     {
//       _startDate = newStartDate;
//     }
//     public void SetActive(int active)
//     {
//       _active = active;
//     }
//
//     public override bool Eqauls(System.Object otherCourse)
//     {
//       if (!(ohterCourse is Course)
//       {
//         return false;
//       }
//       else
//       {
//         Course newCourse = (Course) ohterCourse;
//         bool idEquality = (this.GetId() == newCourse.GetId());
//         bool nameEquality = (this.GetName() == newCourse.GetName());
//         bool startDateEquality = (this.GetStartDate() == newCourse.GetStartDate());
//         bool activeEquality = (this.Active() == newCourse.GetActive());
//         return (idEquality && nameEquality && startDateEquality && activeEquality);
//       }
//     }
//
//     public override int GetHashCode()
//     {
//       return this.GetName().GetHashCode();
//     }
//
//
//     public static List<Course> GetAll()
//     {
//       List<Course< allCourses = new List<Course> {};
//
//       SqlConnection conn = DB.Connectin();
//       conn.Open();
//       SqlCommand cmd = new SqlCommand("SELECT * FROM courses;", conn);
//       SqlDataReader rdr = cmd.ExecuteReader();
//
//       while(rdr.Read())
//       int id =0;
//       string ... = null
//       DateTime date =
//       // {
//       //   int id = rdr.GetInt32();
//       //   int active = rdr.GetInt32();
//       //   string = rdr.GetString();
//       //   DateTime startDate = rdr.GetString();
//       //   Course newCourse = new Course(name , startDate, active, id);
//       //   allCourses.Add(newCourse)
//       // }
//       if(rdr ! = null)
//       {
//         rdr.Close();
//       }
//       if (conn != null)
//       {
//         conn.Close();
//       }
//       return allCourses
//     }
//
//
//     // public void Save()
//     // {
//     //   SqlConnection conn = DB.Connection();
//     //   conn.Open();
//     //
//     //   SqlCommand cmd = new SqlCommand("INSERT INTO courses (name) OUTPUT INSERTED.id VALUES (@CoursesName);", conn);
//     //
//     //   SqlParameter nameParameter = new SqlParameter();
//     //   nameParameter.ParameterName = "@CoursesName";
//     //   nameParameter.Value = this.GetName();
//     //   cmd.Parameters.Add(nameParameter);
//     //   SqlDataReader rdr = cmd.ExecuteReader();
//     //
//     //   while(rdr.Read())
//     //   {
//     //     this._id = rdr.GetInt32(0);
//     //   }
//     //   if (rdr != null)
//     //   {
//     //     rdr.Close();
//     //   }
//     //   if(conn != null)
//     //   {
//     //     conn.Close();
//     //   }
//     // }
//
//
//
//
//   }
// }
