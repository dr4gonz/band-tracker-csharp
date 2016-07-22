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
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Band newBand = Band.Find(parameters.id);
        List<Venue> bandsVenues = newBand.GetVenues();
        List<Venue> allVenues = Venue.GetAll();
        model.Add("band", newBand);
        model.Add("bands-venues", bandsVenues);
        model.Add("venues", allVenues);
        return View["band.cshtml", model];
      };
      Post["/bands/{id}/add-venue"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Band newBand = Band.Find(parameters.id);
        newBand.AddVenue(Request.Form["venue-id"]);
        List<Venue> bandsVenues = newBand.GetVenues();
        List<Venue> allVenues = Venue.GetAll();
        model.Add("band", newBand);
        model.Add("bands-venues", bandsVenues);
        model.Add("venues", allVenues);
        return View["band.cshtml", model];
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
      Delete["/venues/delete-all"] = _ => {
        Venue.DeleteAll();
        List<Venue> allVenues = Venue.GetAll();
        return View["venues.cshtml", allVenues];
      };
      Get["/venues/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Venue newVenue = Venue.Find(parameters.id);
        List<Band> venuesBands = newVenue.GetBands();
        List<Band> allBands = Band.GetAll();
        model.Add("venue", newVenue);
        model.Add("venues-bands", venuesBands);
        model.Add("bands", allBands);
        return View["venue.cshtml", model];
      };
      Patch["/venues/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Venue newVenue = Venue.Find(parameters.id);
        newVenue.Update(Request.Form["venue-name"], Request.Form["venue-phone"], Request.Form["venue-email"]);
        List<Band> venuesBands = newVenue.GetBands();
        List<Band> allBands = Band.GetAll();
        model.Add("venue", newVenue);
        model.Add("venues-bands", venuesBands);
        model.Add("bands", allBands);
        return View["venue.cshtml", model];
      };
      Delete["/venues/{id}/delete"] = parameters => {
        Venue selectedVenue = Venue.Find(parameters.id);
        selectedVenue.Delete();
        List<Venue> allVenues = Venue.GetAll();
        return View["venues.cshtml", allVenues];
      };
      Get["/venues/{id}/update"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Venue newVenue = Venue.Find(parameters.id);
        List<Band> venuesBands = newVenue.GetBands();
        List<Band> allBands = Band.GetAll();
        model.Add("venue", newVenue);
        model.Add("venues-bands", venuesBands);
        model.Add("bands", allBands);
        return View["venue_edit.cshtml", model];
      };
      Post["/venues/{id}/add-band"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Venue newVenue = Venue.Find(parameters.id);
        newVenue.AddBand(Request.Form["band-id"]);
        List<Band> venuesBands = newVenue.GetBands();
        List<Band> allBands = Band.GetAll();
        model.Add("venue", newVenue);
        model.Add("venues-bands", venuesBands);
        model.Add("bands", allBands);
        return View["venue.cshtml", model];
      };
    }
  }
}
