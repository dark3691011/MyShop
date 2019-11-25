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
            Chilkat.Rss rss = new Chilkat.Rss();

            // Download from the feed URL:
            bool success = rss.DownloadRss(page);
            if (success != true)
            {
                return View();
            }

            // Get the 1st channel.
            Chilkat.Rss rssChannel = rss.GetChannel(0);
            if (rss.LastMethodSuccess == false)
            {
                return View();
            }
            

            // For each item in the channel, display the title, link,
            // publish date, and categories assigned to the post.
            int numItems = rssChannel.NumItems;
            List<Chilkat.Rss> ListRss = new List<Chilkat.Rss>();
            for (int i = 0; i <= numItems - 1; i++)
            {
                Chilkat.Rss rssItem = rssChannel.GetItem(i);
                ListRss.Add(rssChannel.GetItem(i));
            }
            return View(ListRss);
        }
    }
}
