using CheckIn.Entitites;
using CheckIn.Entitites.Entities;
using System.Linq;
using System.Web.Mvc;

namespace CheckIn.Website.Controllers
{
    public class MyEventsController : Controller
    {
        // GET: MyEvents
        public ActionResult Index()
        {
            var context = new CheckInDbContext();
            var myEvents = context.Events.Include("Address").ToList<Event>();
            
           

            return View(myEvents);
        }
    }
}