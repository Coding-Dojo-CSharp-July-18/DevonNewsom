using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SessionTimes.Controllers
{
    public class PartyController : Controller
    {
        private int? _countInSession
        {
            get { return HttpContext.Session.GetInt32("count"); }
        }
        private PartyData _partyInSession
        {
            get { return HttpContext.Session.GetFunnyObjectFromSession<PartyData>("party"); }
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            if(_countInSession == null)
                // initialize to 0
                HttpContext.Session.SetInt32("count", 0);
            
            if(_partyInSession == null)
                // initialize to 0
                HttpContext.Session.SetFunnyObjectInSession("party", new PartyData());

            ViewBag.PartyTime = DateTime.Now.AwesomeFormatter();
            ViewBag.Count = _countInSession;

            return View();
        }
        [HttpGet("party/{things}")]
        public IActionResult Count(string things)
        {
            PartyData currentPartyData = _partyInSession;
            if(things == "bux")
            {
                currentPartyData.Bux++;
            }
            else if(things == "hats")
            {
                currentPartyData.Hats++;
            }
            else
                currentPartyData.Boards++;

            HttpContext.Session.SetFunnyObjectInSession("party", currentPartyData);
            
            // Increment Count
            // int? currentCount = _countInSession;

            // if(currentCount == null)
            //     return RedirectToAction("Index");

            // currentCount++;

            return RedirectToAction("Index");
        }
    
    }
}