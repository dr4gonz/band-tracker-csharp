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
      Get["/bands/{id}"] = parameters => {
        Band newBand = Band.Find(parameters.id);
        return View["band.cshtml", newBand];
      };
      Get["/venues"] = _ => {
        List<Venue> allVenues = Venue.GetAll();
        return View["venues.cshtml", allVenues];
      };
      Get["/venues/{id}"] = parameters => {
        Venue newVenue = Venue.Find(parameters.id);
        return View["venue.cshtml", newVenue];
      };
    }
  }
}
