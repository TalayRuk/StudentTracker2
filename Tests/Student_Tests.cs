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
      DateTime sDate = new DateTime (2016, 08, 01);
      Student student1 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", sDate);
      Student student2 = new Student("Jon", "Jone", "jon@Jone.com", "/img/jon.jpg", sDate);

      //Assert
      Assert.Equal(student1, student2);
    }

    public void Dispose()
    {
      // Item.DeleteAll();
    }
  }
}
