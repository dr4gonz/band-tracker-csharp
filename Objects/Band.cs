using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Band
  {
    private int _id;
    private string _name;
    private string _website;
    private string _email;

    public Band(string name, string website, string email, int id = 0)
    {
      _id = id;
      _name = name;
      _website = website;
      _email = email;
    }

    public int GetId()
      {
        return _id;
      }
    public string GetName()
    {
      return _name;
    }

    public string GetWebsite()
    {
      return _website;
    }

    public string GetEmail()
    {
      return _email;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM bands;", conn);
      cmd.ExecuteNonQuery();
    }

    public static List<Band> GetAll()
    {
      List<Band> allBands = new List<Band>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int newBandId = rdr.GetInt32(0);
        string newBandName = rdr.GetString(1);
        string newBandWebsite = rdr.GetString(2);
        string newBandEmail = rdr.GetString(3);

        Band newBand = new Band(newBandName, newBandWebsite, newBandEmail, newBandId);
        allBands.Add(newBand);
      }

      if(rdr != null) rdr.Close();
      if(conn != null) conn.Close();

      return allBands;
    }

    public override bool Equals(System.Object otherBand)
    {
      if (!(otherBand is Band))
      {
          return false;
      }
      else
      {
        Band newBand = (Band) otherBand;
        bool idEquality = (this._id == newBand.GetId());
        bool nameEquality = (this._name == newBand.GetName());
        bool websiteEquality = (this._website == newBand.GetWebsite());
        bool emailEquality = (this._email == newBand.GetEmail());
        return (idEquality && nameEquality && websiteEquality && emailEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO bands (name, website, email) OUTPUT INSERTED.id VALUES(@BandName, @BandWebsite, @BandEmail);", conn);

      SqlParameter bandNameParameter = new SqlParameter();
      bandNameParameter.ParameterName = "@BandName";
      bandNameParameter.Value = this.GetName();
      cmd.Parameters.Add(bandNameParameter);

      SqlParameter bandWebsiteParameter = new SqlParameter();
      bandWebsiteParameter.ParameterName = "@BandWebsite";
      bandWebsiteParameter.Value = this.GetWebsite();
      cmd.Parameters.Add(bandWebsiteParameter);

      SqlParameter bandEmailParameter = new SqlParameter();
      bandEmailParameter.ParameterName = "@BandEmail";
      bandEmailParameter.Value = this.GetEmail();
      cmd.Parameters.Add(bandEmailParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }

      if(rdr != null) rdr.Close();
      if(conn != null) conn.Close();
    }

    public static Band Find(int id)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands WHERE id = @BandId;", conn);
      SqlParameter bandIdParameter = new SqlParameter();
      bandIdParameter.ParameterName = "@BandId";
      bandIdParameter.Value = id.ToString();
      cmd.Parameters.Add(bandIdParameter);

      rdr = cmd.ExecuteReader();

      int foundBandId = 0;
      string foundBandName = null;
      string foundBandWebsite = null;
      string foundBandEmail = null;

      while(rdr.Read())
      {
          foundBandId = rdr.GetInt32(0);
          foundBandName = rdr.GetString(1);
          foundBandWebsite = rdr.GetString(2);
          foundBandEmail = rdr.GetString(3);
      }
      Band newBand = new Band(foundBandName, foundBandWebsite, foundBandEmail, foundBandId);

      if(rdr != null) rdr.Close();
      if(conn != null) conn.Close();

      return newBand;
    }

    public void Update(string newName, string newWebsite, string newEmail)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE bands SET name = @NewName, website = @NewWebsite, email = @NewEmail OUTPUT INSERTED.name, INSERTED.website, INSERTED.email WHERE id = @BandId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);

      SqlParameter newWebsiteParameter = new SqlParameter();
      newWebsiteParameter.ParameterName = "@NewWebsite";
      newWebsiteParameter.Value = newWebsite;
      cmd.Parameters.Add(newWebsiteParameter);

      SqlParameter newEmailParameter = new SqlParameter();
      newEmailParameter.ParameterName = "@NewEmail";
      newEmailParameter.Value = newEmail;
      cmd.Parameters.Add(newEmailParameter);

      SqlParameter bandtIdParameter = new SqlParameter();
      bandtIdParameter.ParameterName = "@BandId";
      bandtIdParameter.Value = this.GetId();
      cmd.Parameters.Add(bandtIdParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
        this._website = rdr.GetString(1);
        this._email = rdr.GetString(2);
      }

      if(rdr != null) rdr.Close();
      if(conn != null) conn.Close();
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM bands WHERE id = @BandId;", conn);

      SqlParameter bandIdParameter = new SqlParameter();
      bandIdParameter.ParameterName = "@BandId";
      bandIdParameter.Value = this.GetId();
      cmd.Parameters.Add(bandIdParameter);

      cmd.ExecuteNonQuery();

      if(conn != null) conn.Close();
    }
  }
}
