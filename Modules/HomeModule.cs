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
        }
    }
}
