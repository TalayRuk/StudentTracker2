using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Epicodus;

namespace Tests
{
  public class Password_Tests : IDisposable
  {
    public Password_Tests()
    {
      string dataSource = "Data Source=(localdb)\\mssqllocaldb"; // Data Source identifies the server.
      string databaseName = "epicodus_test"; // Initial Catalog is the database name
      //Integrated Security sets the security of the database access to the Windows user that is currently logged in.
      DBConfiguration.ConnectionString = ""+dataSource+";Initial Catalog="+databaseName+";Integrated Security=SSPI;";
    }

      [Fact]
        public void T1_DbEmpty()
        {
          int rows = Password.GetAll().Count;

          Assert.Equal(0, rows);
        }

        [Fact]
        public void T2_FindPassword()
        {
          Password newPassword = new Password("username" );
          newPassword.Save();
          Password foundPassword = Password.Find(newPassword.GetId());
          Assert.Equal(newPassword, foundPassword);
        }

        [Fact]
        public void T3_SavePassword()
        {
          Password newPassword = new Password("password");
          newPassword.Save();
          List<Password> allPasswords = Password.GetAll();
          List<Password> testPassword = new List<Password> {newPassword};
          Assert.Equal(testPassword, allPasswords);
        }

        [Fact]
        public void T4_DeleteOnePassword()
        {
          Password newPassword = new Password("password");
          newPassword.Save();

          Password newPassword2 = new Password("password2");
          newPassword2.Save();

          newPassword.DeleteOne();

          List<Password> allPasswords = Password.GetAll();
          List<Password> testPassword = new List<Password> {newPassword2};
          Assert.Equal(testPassword, allPasswords);
        }

        public void Dispose()
        {
          Password.DeleteAll();
        }
      }
    }
