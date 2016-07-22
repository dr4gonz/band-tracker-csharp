using Nancy;
using System;
using System.Collections.Generic;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/bands"] = _ => {
        List<Band> allBands = Band.GetAll();
        return View["bands.cshtml", allBands];
      };
      Get["/bands/add"] = _ => {
        List<Band> allBands = Band.GetAll();
        return View["add_band.cshtml", allBands];
      };
      Post["/bands/add"] = _ => {
        Band newBand = new Band(Request.Form["band-name"], Request.Form["band-website"], Request.Form["band-email"]);
        newBand.Save();
        List<Band> allBands = Band.GetAll();
        return View["add_band.cshtml", allBands];
      };
      Get["/bands/{id}"] = parameters => {
        Band newBand = Band.Find(parameters.id);
        return View["band.cshtml", newBand];
      };
      Get["/venues"] = _ => {
        List<Venue> allVenues = Venue.GetAll();
        return View["venues.cshtml", allVenues];
      };
      Get["/venues/add"] = _ => {
        List<Venue> allVenues = Venue.GetAll();
        return View["add_venue.cshtml", allVenues];
      };
      Post["/venues/add"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"], Request.Form["venue-phone"], Request.Form["venue-email"]);
        newVenue.Save();
        List<Venue> allVenues = Venue.GetAll();
        return View["add_venue.cshtml", allVenues];
      };
      Get["/venues/{id}"] = parameters => {
        Venue newVenue = Venue.Find(parameters.id);
        return View["venue.cshtml", newVenue];
      };
    }
  }
}
