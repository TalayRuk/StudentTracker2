using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Epicodus;

namespace Tests
{
  public class Student_Tests : IDisposable
  {
    public Student_Tests()
    {
      string dataSource = "Data Source=(localdb)\\mssqllocaldb"; // Data Source identifies the server.
      string databaseName = "epicodus_test"; // Initial Catalog is the database name
      //Integrated Security sets the security of the database access to the Windows user that is currently logged in.
      DBConfiguration.ConnectionString = ""+dataSource+";Initial Catalog="+databaseName+";Integrated Security=SSPI;";
    }

    [Fact]
    public void T1_DbEmpty()
    {
      //Arrange, Act
      int rows = Student.GetAll().Count;

      //Assert
      Assert.Equal(0, rows);
    }

    [Fact]
    public void T2_OverrideBool()
    {
      //Arrange, Act
      DateTime Date1 = new DateTime (2016, 08, 01);
      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
      Student student2 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);

      //Assert
      Assert.Equal(student1, student2);
    }

    [Fact]
    public void T3_SaveToDb()
    {
      //Arrange
      DateTime Date1 = new DateTime (2016, 08, 01);
      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);

      //Act
      student1.Save();
      List<Student> result = Student.GetAll();
      List<Student> testList = new List<Student> {student1};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void T4_SaveToId()
    {
      //Arrange
      DateTime Date1 = new DateTime (2016, 08, 01);
      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
      student1.Save();

      //Act
      Student savedId = Student.GetAll()[0];

      int result = savedId.GetId();
      int testId = student1.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void T5_Find()
    {
      //Arrange
      DateTime Date1 = new DateTime (2016, 08, 01);
      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
      student1.Save();

      //Act
      Student result = Student.Find(student1.GetId());

      //Assert
      Assert.Equal(student1, result);
    }

    [Fact]
    public void T6_UpdateAll()
    {
      //Arrange
      DateTime Date1 = new DateTime (2016, 08, 01);
      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
      student1.Save();

      Student currentStudent = new Student( "Jon", "Jone", "jonJone@gmail.com", "/img/jon.jpg", Date1, student1.GetId());
      //Act
      student1.UpdateAll(currentStudent);
      //  student1.UpdateAll(currentStudent);
      // static void .. error CS0176: Member 'Student.UpdateAll(Student)' cannot be accessed with an instance reference; qualify it with a type name instead
      //Assert
      Assert.Equal(currentStudent, student1);
    }

    [Fact]
    public void T7_DeleteOne()
    {
      //Arrange
      DateTime Date1 = new DateTime (2016, 08, 01);
      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
      student1.Save();

      Student student2 = new Student("Jonny", "Jone", "jonjon@Jone.com", "/img/jonny.jpg", Date1);
      student2.Save();

      //Act
      student2.DeleteOne();
      List<Student> result = Student.GetAll();
      List<Student> test = new List<Student> {student1};

      //Assert
      Assert.Equal(test, result);
    }

    // [Fact]
    // public void T8_AddCourse()
    // {
    //   //Arrange
    //   //Arrange
    //   DateTime Date1 = new DateTime (2016, 08, 01);
    //   Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
    //   student1.Save();
    //
    //   Course course1 = new Course("Intro", Date1, 1);
    //   course1.Save();
    //   Course course2 = new Course("JavaScript", Date1, 1);
    //   course2.Save();
    //
    //   //Act
    //   student1.AddCourse(course1);
    //   student1.AddCourse(course2);
    //
    //   List<Course> result = student1.GetCourses();
    //   List<Course> test = new List<Course> {course1, course2};
    //
    //   //Assert
    //   Assert.Equal(test, result);
    //
    // }
    //
    // [Fact]
    // public void T9_GetCourses()
    // {
    //   //Arrange
    //   DateTime Date1 = new DateTime (2016, 08, 01);
    //   Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
    //   student1.Save();
    //
    //   Course course1 = new Course("Intro", Date1, 1);
    //   course1.Save();
    //   Course course2 = new Course("JavaScript", Date1, 1);
    //   course2.Save();
    //
    //
    //   //Act
    //   student1.AddCourse(course1);
    //
    //   List<Course> result = student1.GetCourses();
    //   List<Course> test = new List<Course> {course1};
    //
    //   //Assert
    //   Assert.Equal(test, result);
    // }

    // [Fact]
    // public void T8_DeleteCourse()
    // {
    //   //Assert
    //   DateTime Date1 = new DateTime (2016, 08, 01);
    //   Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", Date1);
    //   student1.Save();
    //
    //   Course testCourse = new Course("Intro", Date1, 1);
    //   testCourse.Save();
    //
    //   //Act
    //   student1.AddCourse(testCourse);
    //   student1.DeleeteCourse(student1.GetId(), testCourse.GetId());
    //   List<Student> result = testCourse.GetCourses();
    //
    //   //Assert
    //   Assert.Equal(0, result);
    // }


    public void Dispose()
    {
      Student.DeleteAll();
      Course.DeleteAll();
      // Project.DeleteAll();
    }
  }
}
// Update
// string name = "A place";
//       Venue testVenue = new Venue(name);
//       testVenue.Save();
//       string newName = "B place";
//
//       //Act
//       testVenue.Update(newName);
//
//       string result = testVenue.GetName();
