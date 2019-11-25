using CodeHollow.FeedReader;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewComponents
{
    public class Rss : ViewComponent
    {
        public Rss()
        {

        }
        public IViewComponentResult Invoke(string page)
        {
            Feed feed = FeedReader.Read(page);
            
            return View(feed);
        }
    }
}
