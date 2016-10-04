using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Epicodus;

namespace Tests
{
  public class Project_Tests : IDisposable
  {
    public Project_Tests()
    {
      string dataSource = "Data Source=(localdb)\\mssqllocaldb"; // Data Source identifies the server.
      string databaseName = "epicodus_test"; // Initial Catalog is the database name
      //Integrated Security sets the security of the database access to the Windows user that is currently logged in.
      DBConfiguration.ConnectionString = ""+dataSource+";Initial Catalog="+databaseName+";Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CheckForEmptyDataBase()
    {
    int tableRows = Project.GetAll().Count;
    Assert.Equal( 0, tableRows);
    }

    [Fact]
    public void Test_checkGetNameFunction()
    {
      DateTime Date = new DateTime(2016,10,3);
      Project newProject = new Project("ProjectName", Date);
      Assert.Equal("ProjectName", newProject.GetName() );
    }

    [Fact]
    public void Test_FindProject()
    {
      DateTime Date = new DateTime(2016,10,3);
      Project newProject = new Project("ProjectName", Date);
      newProject.Save();
      Project foundProject = Project.Find( newProject.GetId() );
      Assert.Equal(newProject, foundProject);
    }
    [Fact]
    public void Test_DeleteOneProject()
    {
      DateTime Date = new DateTime(2016,10,3);
      Project newProject = new Project("ProjectName", Date);
      newProject.Save();

      DateTime Date2 = new DateTime(2016,10,3);
      Project newProject2 = new Project("ProjectName", Date2);
      newProject2.Save();

      newProject.Delete();

      List<Project> allProjects = Project.GetAll();
      List<Project> testProject = new List<Project> {newProject2};
      Assert.Equal(testProject, allProjects);
    }

    public void Dispose()
    {
      Project.DeleteAll();
    }
  }
}
