using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venue
  {
    private int _id;
    private string _name;
    private string _phone;
    private string _email;

    public Venue(string name, string phone, string email, int id = 0)
    {
      _id = id;
      _name = name;
      _phone = phone;
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

    public string GetPhone()
    {
      return _phone;
    }

    public string GetEmail()
    {
      return _email;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);
      cmd.ExecuteNonQuery();
    }

    public static List<Venue> GetAll()
    {
      List<Venue> allVenues = new List<Venue>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int newVenueId = rdr.GetInt32(0);
        string newVenueName = rdr.GetString(1);
        string newVenuePhone = rdr.GetString(2);
        string newVenueEmail = rdr.GetString(3);

        Venue newVenue = new Venue(newVenueName, newVenuePhone, newVenueEmail, newVenueId);
        allVenues.Add(newVenue);
      }

      if(rdr != null) rdr.Close();
      if(conn != null) conn.Close();

      return allVenues;
    }

    public override bool Equals(System.Object otherVenue)
    {
      if (!(otherVenue is Venue))
      {
          return false;
      }
      else
      {
        Venue newVenue = (Venue) otherVenue;
        bool idEquality = (_id == newVenue.GetId());
        bool nameEquality = (_name == newVenue.GetName());
        bool phoneEquality = (_phone == newVenue.GetPhone());
        bool emailEquality = (_email == newVenue.GetEmail());
        return (idEquality && nameEquality && phoneEquality && emailEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO venues (name, phone, email) OUTPUT INSERTED.id VALUES(@VenueName, @VenuePhone, @VenueEmail);", conn);

      SqlParameter venueNameParameter = new SqlParameter();
      venueNameParameter.ParameterName = "@VenueName";
      venueNameParameter.Value = this.GetName();
      cmd.Parameters.Add(venueNameParameter);

      SqlParameter venuePhoneParameter = new SqlParameter();
      venuePhoneParameter.ParameterName = "@VenuePhone";
      venuePhoneParameter.Value = this.GetPhone();
      cmd.Parameters.Add(venuePhoneParameter);

      SqlParameter venueEmailParameter = new SqlParameter();
      venueEmailParameter.ParameterName = "@VenueEmail";
      venueEmailParameter.Value = this.GetEmail();
      cmd.Parameters.Add(venueEmailParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }

      if(rdr != null) rdr.Close();
      if(conn != null) conn.Close();
    }

    public static Venue Find(int id)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues WHERE id = @VenueId;", conn);
      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = id.ToString();
      cmd.Parameters.Add(venueIdParameter);

      rdr = cmd.ExecuteReader();

      int foundVenueId = 0;
      string foundVenueName = null;
      string foundVenuePhone = null;
      string foundVenueEmail = null;

      while(rdr.Read())
      {
          foundVenueId = rdr.GetInt32(0);
          foundVenueName = rdr.GetString(1);
          foundVenuePhone = rdr.GetString(2);
          foundVenueEmail = rdr.GetString(3);
      }
      Venue newVenue = new Venue(foundVenueName, foundVenuePhone, foundVenueEmail, foundVenueId);

      if(rdr != null) rdr.Close();
      if(conn != null) conn.Close();

      return newVenue;
    }

    public void Update(string newName, string newPhone, string newEmail)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE venues SET name = @NewName, phone = @NewPhone, email = @NewEmail OUTPUT INSERTED.name, INSERTED.phone, INSERTED.email WHERE id = @VenueId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);

      SqlParameter newPhoneParameter = new SqlParameter();
      newPhoneParameter.ParameterName = "@NewPhone";
      newPhoneParameter.Value = newPhone;
      cmd.Parameters.Add(newPhoneParameter);

      SqlParameter newEmailParameter = new SqlParameter();
      newEmailParameter.ParameterName = "@NewEmail";
      newEmailParameter.Value = newEmail;
      cmd.Parameters.Add(newEmailParameter);

      SqlParameter venuetIdParameter = new SqlParameter();
      venuetIdParameter.ParameterName = "@VenueId";
      venuetIdParameter.Value = this.GetId();
      cmd.Parameters.Add(venuetIdParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
        this._phone = rdr.GetString(1);
        this._email = rdr.GetString(2);
      }

      if(rdr != null) rdr.Close();
      if(conn != null) conn.Close();
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM venues WHERE id = @VenueId;", conn);

      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = this.GetId();
      cmd.Parameters.Add(venueIdParameter);

      cmd.ExecuteNonQuery();

      if(conn != null) conn.Close();
    }
  }
}
