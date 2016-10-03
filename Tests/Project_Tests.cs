using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Epicodus;

namespace Tests
{
  public class Testing : IDisposable
  {
    public ToDoTest()
    {
      string dataSource = "Data Source=(localdb)\\mssqllocaldb"; // Data Source identifies the server.
      string databaseName = "epicodus_test"; // Initial Catalog is the database name
      //Integrated Security sets the security of the database access to the Windows user that is currently logged in.
      DBConfiguration.ConnectionString = ""+dataSource+";Initial Catalog="+databaseName+";Integrated Security=SSPI;";
    }


    public void Dispose()
    {
      // Item.DeleteAll();
    }
  }
}
