using Newtonsoft.Json;
using SocialMediaSat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SocialMediaSat.Controllers
{
    public class HomeController : Controller
    {
        //declare a Twitter object to use inside of actionresults - gives auth 
        public Twitter twitter = new Twitter
        {
            OAuthConsumerKey = "ZKQO3mOrtZSvgD0YPDnyZ4iOf",
            OAuthConsumerSecret = "NNvgVh8sFBEroWqk3gPF775hTQ3mNGtBNQhdrXEX3MIDiub39C"
        };
        
        //taking user input
        public ActionResult Index()
        {
            return View();
        }

        //passing the user input called text, then place in viewbag (using foreach loop) 
        //Method to take (text) from the user input and generate a list - display list in our view bag
        [HttpPost]
        public ActionResult Create(string text)
        {
            int count = 10;
            var result = twitter.GetSpecificUserPost(text, count).Result;
            List<TwitObject> TweeitsList = MapResultToTweetList(result);
            var model = new TweetListModel
            {
                TweetsList = TweeitsList
            };

            return View("TweetsList", model);
        }

        private List<TwitObject> MapResultToTweetList(string result)
        {
            return JsonConvert.DeserializeObject<List<TwitObject>>(result);
        }

        public ActionResult TweetsList(List<TwitObject>TweetsList)
        {
            //List<TwitObject> TweetsList = twitter.GetSpecificUserPost(text).Result;
            ViewBag.tweetsList = TweetsList;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Social Media Satillite";

            return View();
        }

        public ActionResult Analytics()
        {
            ViewBag.Message = "Analytics page!! what up!";

            return View();
        }
    }
}