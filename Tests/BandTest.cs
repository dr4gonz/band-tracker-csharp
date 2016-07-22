using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      // DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
      DBConfiguration.ConnectionString = "Data Source=DESKTOP-7OLC9FT\\SQLEXPRESS;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Band_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Band.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Band_ChecksIfBandsAreEqual_returnsTrue()
    {
      //Arrange, Act
      Band firstBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      Band secondBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      //Assert
      Assert.Equal(firstBand, secondBand);
    }

    [Fact]
    public void Bands_SavesToDatabase()
    {
      //Arrange
      Band newBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      newBand.Save();
      //Act
      List<Band> result = Band.GetAll();
      List<Band> testList = new List<Band>{newBand};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Band_SavesSavesWithID()
    {
      //Arrange
      Band newBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      newBand.Save();
      //Act
      Band savedBand = Band.GetAll()[0];
      int result = newBand.GetId();
      int testId = savedBand.GetId();
      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Band_FindsBandInDatabase()
    {
      //Arrange
      Band newBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      newBand.Save();
      //Act
      Band foundBand = Band.Find(newBand.GetId());
      //Assert
      Assert.Equal(newBand, foundBand);
    }

    [Fact]
    public void Band_Update_UpdatesBandInDatabase()
    {
      //Arrange
      Band newBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      newBand.Save();
      string newName = "J-Dilla";
      string newWebsite = "http://www.j-dilla.com/";
      string newEmail = "none@none.com";
      //Act
      newBand.Update(newName, newWebsite, newEmail);

      string updateName = newBand.GetName();
      string updateWebsite = newBand.GetWebsite();
      string updateEmail = newBand.GetEmail();
      //Assert
      Assert.Equal(newName, updateName);
      Assert.Equal(newWebsite, updateWebsite);
      Assert.Equal(newEmail, updateEmail);
    }

    [Fact]
    public void Bands_Delete_DeletesBandFromDatabase()
    {
      //Arrange
      string name1 = "Red Fang";
      string phone1 = "http://www.redfang.net/";
      string email1 = "email@email.com";
      Band testBand1 = new Band(name1, phone1, email1);
      testBand1.Save();

      string name2 = "Revolution Hall";
      string phone2 = "http://www.j-dilla.com/";
      string email2 = "none@none.com";
      Band testBand2 = new Band(name2, phone2, email2);
      testBand2.Save();
      //Act
      testBand2.Delete();
      List<Band> resultBand = Band.GetAll();
      List<Band> testBand = new List<Band> {testBand1};
      //Assert
      Assert.Equal(testBand, resultBand);
    }

    [Fact]
    public void Band_AddVenue_AddsVenueToBand()
    {
      //Arrange
      Band testBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      testBand.Save();
      Venue testVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      testVenue.Save();

      //Act
      testBand.AddVenue(testVenue.GetId());
      List<Venue> result = testBand.GetVenues();
      List<Venue> expectedResult = new List<Venue> {testVenue};
      //Assert
      Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Band_GetVenues_GetsAllOfBandsVenues()
    {
      //Arrange
      Band testBand = new Band("Red Fang", "http://www.redfang.net/", "email@email.com");
      testBand.Save();
      Venue testVenue = new Venue("Mississippi Studios", "503.555.5555", "email@email.com");
      testVenue.Save();
      List<Venue> expectedResult = new List<Venue> {testVenue};
      //Act
      testBand.AddVenue(testVenue.GetId());
      List<Venue> result = testBand.GetVenues();
      //Assert
      Assert.Equal(expectedResult, result);
    }

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
