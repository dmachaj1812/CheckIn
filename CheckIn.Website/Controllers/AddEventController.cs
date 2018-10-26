using CheckIn.Entitites;
using CheckIn.Entitites.Entities;
using CheckIn.Website.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CheckIn.Website.Controllers
{
    [Authorize]
    public class AddEventController : Controller
    {
        
      
        // GET: AddEvent
        public ActionResult Index()
        {
            var context = new CheckInDbContext();
            var currentUser = User.Identity.GetUserId();
            var events = context.Events.Include(s=>s.Address).Where(s=>s.CreatedBy == currentUser&& s.IsActive == true)
                .ToList();
            events.ForEach(s=>s.Invitations = s.Invitations.Where(x=>x.IsActive == true).ToList());
            return View(events);

        }
     

        public ActionResult AddEvent()
        {

            AddEventViewModel addEvent = new AddEventViewModel();
            CheckInDbContext context = new CheckInDbContext();
            ViewBag.States = context.States.ToList();
            ViewBag.EventTypes = context.EventTypes.OrderBy(s => s.EventTypeName).ToList();

            return View(addEvent);
        }
        [HttpPost]
        public ActionResult AddEvent( AddEventViewModel viewModel)
        {
            AddEventViewModel addEvent = new AddEventViewModel();
            CheckInDbContext contextModel = new CheckInDbContext();

            if (!ModelState.IsValid)
            {
                ViewBag.States = (from o in contextModel.States select o).ToList();
                ViewBag.EventTypes = (from o in contextModel.EventTypes select o).ToList();

                return View("AddEvent", addEvent);
            }
            using (var context = new CheckInDbContext())
            {

                var newEvent = new Event
                {
                    CreatedBy = User.Identity.GetUserId(),
                    Modifiedby = User.Identity.GetUserId(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    Name = viewModel.NameOfEvent,
                    Date = Convert.ToDateTime(string.Format("{0},{1}",viewModel.Date,viewModel.Time)),
                    PlaceOfEvent = viewModel.PlaceOfEvent,
                    EventTypeId = viewModel.EventTypeId,
                    IsActive = true,
                    Address = new Address()
                    {
                        AddressName = viewModel.Address,
                        ZipCode = viewModel.ZipCode,
                        CityName = viewModel.City,
                        StateId = viewModel.StateId

                    }

                };
                context.Events.Add(newEvent);
                context.SaveChanges();


            }


            return RedirectToAction("Index");
        }

        public void DeleteEvent(int id)
        {
            using (var contex = new CheckInDbContext())
            {
                var currentEvent = contex.Events.FirstOrDefault(s => s.Id == id);
                currentEvent.IsActive = false;
                currentEvent.ModifiedOn = DateTime.Now;
                currentEvent.Modifiedby = User.Identity.GetUserId();
                contex.SaveChanges();
            }
        }

        public ActionResult Edit(int id)
        {
            var context = new CheckInDbContext();
                var eventDB = context.Events.Include(s=>s.Address).SingleOrDefault(s => s.Id == id);
                var viewModel = new EditEventViewModel
                {
                    Id = eventDB.Id,
                    Address = eventDB.Address.AddressName,
                    City = eventDB.Address.CityName,
                    Date = eventDB.Date.ToLongDateString(),
                    Time = eventDB.Date.ToLongTimeString(),
                    EventTypeId = eventDB.EventTypeId,
                    NameOfEvent = eventDB.Name,
                    PlaceOfEvent = eventDB.PlaceOfEvent,
                    StateId = eventDB.Address.StateId,
                    ZipCode = eventDB.Address.ZipCode
                };

            ViewBag.States = context.States.ToList();
            ViewBag.Events = context.Events.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditEventViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var context = new CheckInDbContext();
                ViewBag.States = context.States.ToList();
                return View(viewModel);
            }

            using (var context = new CheckInDbContext())
            {
                var eventDb = context.Events.Include(s=>s.Address).FirstOrDefault(x => x.Id == viewModel.Id);
                eventDb.Address.AddressName = viewModel.Address;
                eventDb.Address.StateId = viewModel.StateId;
                eventDb.Address.CityName = viewModel.City;
                eventDb.Address.ZipCode = viewModel.ZipCode;
                eventDb.Date = Convert.ToDateTime(string.Format("{0},{1}",viewModel.Date,viewModel.Time));
                eventDb.PlaceOfEvent = viewModel.PlaceOfEvent;
                eventDb.Name = viewModel.NameOfEvent;
                eventDb.ModifiedOn = DateTime.Now;
                eventDb.Modifiedby = User.Identity.GetUserId();

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}