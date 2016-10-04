using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Epicodus;

namespace Tests
{
  public class Course_Tests : IDisposable
  {
    public Course_Tests()
    {
      string dataSource = "Data Source=(localdb)\\mssqllocaldb"; // Data Source identifies the server.
      string databaseName = "epicodus_test"; // Initial Catalog is the database name
      //Integrated Security sets the security of the database access to the Windows user that is currently logged in.
      DBConfiguration.ConnectionString = ""+dataSource+";Initial Catalog="+databaseName+";Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CheckForEmptyDataBase()
    {
    int tableRows = Course.GetAll().Count;
    Assert.Equal( 0, tableRows);
    }

    [Fact]
    public void Test_checkGetNameFunction()
    {
      DateTime date = new DateTime (2016,10,3);
      Course newCourse = new Course("CourseName" , date, 2);
      Assert.Equal("CourseName", newCourse.GetName() );
    }

    [Fact]
    public void Test_Save_CanWeSaveABandToTheDatabase()
    {
      //Course newCourse = new Course(CourseName , DateTime, active);
      DateTime date = new DateTime (2016,10,3);
      Course newCourse = new Course("CourseName" , date, 2);
      newCourse.Save();
      List<Course> allCourses = Course.GetAll();
      List<Course> testCourses = new List<Course> {newCourse};
      Assert.Equal( testCourses, allCourses );
    }

    [Fact]
    public void Test_DeleteOneCourse()
    {
      DateTime date = new DateTime (2016,10,3);
      Course newCourse = new Course("CourseName" , date, 2);
      newCourse.Save();

      DateTime date2 = new DateTime (2017,10,3);
      Course newCourse2 = new Course("CourseName2" , date, 2);
      newCourse2.Save();

      newCourse.DeleteOne();

      List<Course> allCourses = Course.GetAll();
      List<Course> testCourse = new List<Course> {newCourse2};
      Assert.Equal(testCourse, allCourses);
    }

    [Fact]
    public void Test_FindCourse()
    {
      DateTime date = new DateTime (2016,10,3);
      Course newCourse = new Course("CourseName" , date, 2);
      newCourse.Save();
      Course foundCourse = Course.Find( newCourse.GetId() );
      Assert.Equal(newCourse, foundCourse);
    }

    [Fact]
    public void Test_UpdateOneCourse()
    {
      DateTime date = new DateTime (2016,10,3);
      Course testCourse = new Course("CourseName" , date, 2, 0);
      testCourse.Save();

      DateTime date2 = new DateTime (2017,10,3);
      Course newCourse2 = new Course("CourseName2" , date2, 2, testCourse.GetId() );
      testCourse.Update(newCourse2);
      Assert.Equal(testCourse, newCourse2);
    }

    public void Dispose()
    {
      Course.DeleteAll();
    }
  }
}
