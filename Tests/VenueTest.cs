using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      // DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
      DBConfiguration.ConnectionString = "Data Source=DESKTOP-7OLC9FT\\SQLEXPRESS;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Venue_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Venue.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Venue_ChecksIfVenuesAreEqual_returnsTrue()
    {
      //Arrange, Act
      Venue firstVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      Venue secondVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      //Assert
      Assert.Equal(firstVenue, secondVenue);
    }

    [Fact]
    public void Venues_SavesToDatabase()
    {
      //Arrange
      Venue newVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      newVenue.Save();
      //Act
      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{newVenue};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Venue_SavesSavesWithID()
    {
      //Arrange
      Venue newVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      newVenue.Save();
      //Act
      Venue savedVenue = Venue.GetAll()[0];
      int result = newVenue.GetId();
      int testId = savedVenue.GetId();
      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Venue_FindsVenueInDatabase()
    {
      //Arrange
      Venue newVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      newVenue.Save();
      //Act
      Venue foundVenue = Venue.Find(newVenue.GetId());
      //Assert
      Assert.Equal(newVenue, foundVenue);
    }

    [Fact]
    public void Venue_Update_UpdatesVenueInDatabase()
    {
      //Arrange
      Venue newVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      newVenue.Save();
      string newName = "Revolution Hall";
      string newPhone = "503.666.6666";
      string newEmail = "none@none.com";
      //Act
      newVenue.Update(newName, newPhone, newEmail);

      string updateName = newVenue.GetName();
      string updatePhone = newVenue.GetPhone();
      string updateEmail = newVenue.GetEmail();
      //Assert
      Assert.Equal(newName, updateName);
      Assert.Equal(newPhone, updatePhone);
      Assert.Equal(newEmail, updateEmail);
    }

    [Fact]
    public void Venues_Delete_DeletesVenueFromDatabase()
    {
      //Arrange
      string name1 = "Mississippi Studios";
      string phone1 = "503.555.5555";
      string email1 = "email@email.com";
      Venue testVenue1 = new Venue(name1, phone1, email1);
      testVenue1.Save();

      string name2 = "Revolution Hall";
      string phone2 = "503.666.6666";
      string email2 = "none@none.com";
      Venue testVenue2 = new Venue(name2, phone2, email2);
      testVenue2.Save();
      //Act
      testVenue2.Delete();
      List<Venue> resultVenue = Venue.GetAll();
      List<Venue> testVenue = new List<Venue> {testVenue1};
      //Assert
      Assert.Equal(testVenue, resultVenue);
    }

    [Fact]
    public void Venue_AddBand_AddsBandToAVenue()
    {
      //Arrange
      Venue testVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      testVenue.Save();
      Band testBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      testBand.Save();

      //Act
      testVenue.AddBand(testBand.GetId());
      List<Band> result = testVenue.GetBands();
      List<Band> expectedResult = new List<Band> {testBand};
      //Assert
      Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Venue_GetBands_GetsAllOfVenuesBands()
    {
      //Arrange
      Venue testVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      testVenue.Save();
      Band testBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      testBand.Save();
      List<Band> expectedResult = new List<Band> {testBand};
      //Act
      testVenue.AddBand(testBand.GetId());
      List<Band> result = testVenue.GetBands();
      //Assert
      Assert.Equal(expectedResult, result);
    }

    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }
  }
}
