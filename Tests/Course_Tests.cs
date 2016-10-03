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
      Course newCourse = new Course("CourseName" , 2016-10-3, 2);
      Assert.Equal("CourseName", newCourse.GetName() );
    }

    // [Fact]
    // public void Test_Save_CanWeSaveABandToTheDatabase()
    // {
    //   //Course newCourse = new Course(CourseName , DateTime, active);
    //   Course newCourse = new Course("CourseName" , 2016-10-3, 2);
    //   Course.Save();
    //   List<Course> allCourses = Course.GetAll();
    //   List<Course> testCourses = new List<Course> {newCourse};
    //   Assert.Equal( testCourses, allCourses );
    // }

    public void Dispose()
    {
      // Item.DeleteAll();
    }
  }
}
