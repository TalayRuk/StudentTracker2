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
    public void Test1_CheckForEmptyDataBase()
    {
    int tableRows = Course.GetAll().Count;
    Assert.Equal( 0, tableRows);
    }

    [Fact]
    public void Test2_checkGetNameFunction()
    {
      DateTime date = new DateTime (2016,10,3);
      Course newCourse = new Course("CourseName" , date, 2);
      Assert.Equal("CourseName", newCourse.GetName() );
    }

    [Fact]
    public void Test3_Save_CanWeSaveABandToTheDatabase()
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
    public void Test4_DeleteOneCourse()
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
    public void Test5_FindCourse()
    {
      DateTime date = new DateTime (2016,10,3);
      Course newCourse = new Course("CourseName" , date, 2);
      newCourse.Save();
      Course foundCourse = Course.Find( newCourse.GetId() );
      Assert.Equal(newCourse, foundCourse);
    }

    [Fact]
    public void Test6_UpdateOneCourse()
    {
      DateTime date = new DateTime (2016,10,3);
      Course testCourse = new Course("CourseName" , date, 2, 0);
      testCourse.Save();

      DateTime date2 = new DateTime (2017,10,3);
      Course newCourse2 = new Course("CourseName2" , date2, 2, testCourse.GetId() );
      testCourse.Update(newCourse2);
      Assert.Equal(testCourse, newCourse2);
    }

    [Fact]
    public void T8_AddStudent()
    {
      //Arrange
      DateTime Date1 = new DateTime (2016, 08, 01);
      Course course1 = new Course("Intro", Date1, 1);
      course1.Save();

      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
      student1.Save();

      Student student2 = new Student("Dan", "Lee", "dan@Lee.com", "/img/dan.jpg", Date1);
      student2.Save();

      //Act
      course1.AddStudent(student1);
      course1.AddStudent(student2);


      List<Student> result = course1.GetStudents();
      List<Student> test = new List<Student> {student1, student2};
      // Console.WriteLine(result[0].GetId());
      // Console.WriteLine(test[0].GetId());
      // Console.WriteLine(result[0].GetName());
      // Console.WriteLine(test[0].GetName());
      // Console.WriteLine(result[0]. GetStartDate() );
      // Console.WriteLine(test[0]. GetStartDate() );

      //Assert
      Assert.Equal(test, result);

    }

    [Fact]
    public void T9_GetStudents()
    {
      //Arrange
      DateTime Date1 = new DateTime (2016, 08, 01);
      Course course1 = new Course("Intro", Date1, 1);
      course1.Save();

      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
      student1.Save();

      Student student2 = new Student("Dan", "Lee", "dan@Lee.com", "/img/dan.jpg", Date1);
      student2.Save();


      //Act
      course1.AddStudent(student1);

      List<Student> result = course1.GetStudents();
      List<Student> test = new List<Student> {student1};

      //Assert
      Assert.Equal(test, result);
    }

    [Fact]
    public void T10_DeleteCourse()
    {
      //Assert
      DateTime Date1 = new DateTime (2016, 08, 01);
      Course testCourse = new Course("Intro", Date1, 1);
      testCourse.Save();

      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
      student1.Save();


      //Act
      testCourse.AddStudent(student1);
      testCourse.DeleteStudent( student1.GetId() );
      int result = testCourse.GetStudents().Count;

      //Assert
      Assert.Equal(0, result);
    }



    public void Dispose()
    {
      Course.DeleteAll();
    }
  }
}
