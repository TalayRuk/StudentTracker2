using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Epicodus
{
  public class Password
  {
    private int _id;
    private string _userName;
    private string _password

    public Password(string userName, string password, int id = 0 )
    {
      _id = id;
      _userName = userName;
      _password = password;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetUserName()
    {
      return _userName;
    }
    public string GetPassword()
    {
      return _password;
    }
    public void SetUserName(string newUserName)
    {
      _userName = newUserName;
    }
    public void SetPassword()
    {
      _password = password;
    }

    public override bool Equals(Sytem.Object otherPassword)
    {
      if (! ohterPassword is Password))
    {
      return false;
    }
    else
    {
      Password newPassword = (Password) ohterPassword;
      bool idEquality = (this.GetId() == newPassword.GetId());
      bool nameEquality = (this.GetUserName() == newPassword.GetUserName());
      bool PasswordEquality = (this.GetPassword() == newPassword.GetPassword());
      return (idEquality && nameEquality && PasswordEquality);
    }
  }

  public static List<Password> GetAll()
  {
    List<password> allPasswords = new List<Password>{};

     SqlConnection conn = DB.Connection();
     conn.Open();

     SqlCommand cmd = new SqlCommand("SELECT * FROM passwords;", conn);
     SqlDataReader rdr = cmd.ExecuteReader();

    while (rdr.Read())
    {
      int id  = rdr.GetInt32(0);
      string userName = rdr.GetString(1);
      string password = rdr.GetString(2);
      Password newPassword = new Password(userName, password, id);
      allPasswords.Add(newPassword);
    }
    if(rdr != null)
    {
      rdr.Close();
    }
    if (conn !=null)
    {
      conn.Close();
    }
    return allPasswords;
  }

  public static Password Find(int id)
  {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM passwords WHERE id = @id;");

    cmd.Parameters.Add(new SqlParameter("@id, id"))
    SqlDataReader rdr = cmd.ExecuteReader();

    int PasswordId = 0;
    string userName = null;
    string password = null;

    while(rdr.Read())
    {
      passwordId = rdr.GetInt(0);
      userName = rdr.GetString(1);
      password = rdr.GetString(2);
    }
    Password foundPassword = new Password(userName, password, passwordId);

    if (rdr !=null)
    {
      rdr.Close();
    }
    if (conn !=null)
    {
      conn.Close();
    }
    return foundPassword;
  }

  public void Save()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("INSERT INTO passwords (user_Name, user_Pasword) OUTPUT INSERTED.id VALUES (@username, @pasword);",conn);

    cmd.Parameters.Add(new SqlParameter("@username", this.GetUserName()));
    cmd.Parameters.Add(new SqlParameter("@password", this.GetPassword()));

    SqlDataReader rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      _id = rdr.GetInt32(0);

    }
    if (rdr !=null)
    {
      rdr.Close();
    }
    if (conn != null)
    {
      conn.Close();
    }
  }

  public void DeleteOne()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("DELETE FROM passwords WHERE id = @Id;",conn);
    cmd.Parameters.Add(new SqlParameter("@Id", this.GetId()));

    cmd.ExecuteNonQuery();
    if (conn !=null)
    {
      conn.Close();
    }
  }

  public static void DeleteAll()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("DELETE FROM passwords;",conn);
    cmd1.ExecuteNonQuery();
    if(conn !=null)
    {
      conn.Close();
    }
   }
  }
}
