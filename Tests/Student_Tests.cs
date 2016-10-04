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

      Student currentStudent = new Student("Jon", "Jone", "jonJone@gmail.com", "/img/jon.jpg", Date1);
      //Act
      Student updateStudent = Student.Update(currentStudent)
      //  student1.UpdateAll(currentStudent);
      // static void .. error CS0176: Member 'Student.UpdateAll(Student)' cannot be accessed with an instance reference; qualify it with a type name instead
      //Assert
      Assert.Equal(currentStudent, updateStudent);
    }

    public void Dispose()
    {
      Student.DeleteAll();
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
