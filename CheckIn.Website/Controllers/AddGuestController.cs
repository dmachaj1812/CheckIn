using CheckIn.Entitites;
using CheckIn.Entitites.Entities;
using CheckIn.Website.Models;
using CheckIn.Website.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CheckIn.Website.Controllers
{
    [Authorize]
    public class AddGuestController : Controller
    {
        
        // GET: AddGuest
        public ActionResult Index(int? eventId)
        {
           var context = new CheckInDbContext();
           //var allInvitations = context.Invitations.Include("Address").ToList();
            
            var invitation = context.Invitations.Where(x=>x.IsActive && x.EventId == eventId).ToList();
             invitation.ForEach(x=>
             {
                 x.Guests= x.Guests.Where(g => g.IsActive).ToList();
             });
            ViewBag.EventId = eventId;
            ViewBag.States = context.States.ToList();
            
            return View(invitation);
        }
        
        
        public ActionResult AddInvitation(int eventId)
        {
            var context = new CheckInDbContext();
            ViewBag.States = context.States.ToList();
            var newInviation = new AddGuestViewModel();
            newInviation.EventId = eventId;
            return View(newInviation);
        }
        [HttpPost]
        public ActionResult AddInvatition(AddGuestViewModel viewModel)
        {
            var modelContext = new CheckInDbContext();
            if (!ModelState.IsValid)
            {
                ViewBag.States = modelContext.States.ToList();
                return View("AddInvitation");
            }

            using (var context = new CheckInDbContext())
            {
                string invitationNumber;

                do
                {
                    invitationNumber = InivationNumberGenerator.InvitationNumber();
                } while (context.InvitationNumbersLists.Any(x => x.InvitationNumber == invitationNumber));


                var newInvitation = new Invitation()
                {
                    CreatedBy = User.Identity.GetUserId(),
                    Modifiedby = User.Identity.GetUserId(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    GroupName = viewModel.GroupName,
                    Address = new Address()
                    {
                        AddressName = viewModel.Address,
                        CityName = viewModel.City,
                        StateId = viewModel.StateId,
                        ZipCode = viewModel.ZipCode
                    },
                    Guests = viewModel.Guest.ToList(),
                    EventId = viewModel.EventId,
                    IsActive = true,
                    InvitationRecordNumber = invitationNumber,
                    
                    
                };
                context.Invitations.Add(newInvitation);
                InvitationNumbersList newNumber = new InvitationNumbersList{InvitationNumber = invitationNumber };
                context.InvitationNumbersLists.Add(newNumber);
                context.SaveChanges();
            }

            return RedirectToAction("Index", new {eventId = viewModel.EventId});

           
        }

       
        public ActionResult Edit(int id)
        {
          
            var context = new CheckInDbContext();
            var invitation = context.Invitations.Include("Address").Where(s => s.Id == id).FirstOrDefault<Invitation>();
            var viewModel = new EditGuestViewModel()
            {
                Id = invitation.Id,
                GroupName = invitation.GroupName,
                Address = invitation.Address.AddressName,
                City = invitation.Address.CityName,
                StateId = invitation.Address.StateId,
                ZipCode = invitation.Address.ZipCode,
                Guest = invitation.Guests
            };

            ViewBag.States = context.States.ToList();

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(EditGuestViewModel viewModel)
        {
            var contex = new CheckInDbContext();
            if (!ModelState.IsValid)
            {
                ViewBag.States = contex.States.ToList();
                return View(viewModel);
            }
            // To Do I have to 
            using (var context = new CheckInDbContext())
            {
                var invitation = context.Invitations.Where(s => s.Id == viewModel.Id)
                    .FirstOrDefault();
                var temp = invitation.Guests.Count - 1 < viewModel.Guest.Count;
               
                if (invitation.Guests.Count - 1 < viewModel.Guest.Count)
                {
                   invitation.Guests.AddRange(viewModel.Guest.Skip(Convert.ToInt32(invitation.Guests.Count)));

                }

                invitation.GroupName = viewModel.GroupName;
                invitation.Address.AddressName = viewModel.Address;
                invitation.Address.CityName = viewModel.City;
                invitation.Address.StateId = viewModel.StateId;

                for (int i = 0; i < viewModel.Guest.Count; i++)
                {
                    invitation.Guests[i].FirstName = viewModel.Guest[i].FirstName;
                    invitation.Guests[i].LastName = viewModel.Guest[i].LastName;
                    invitation.Guests[i].IsActive = viewModel.Guest[i].IsActive;
                    invitation.Guests[i].IsExtraGuest = viewModel.Guest[i].IsExtraGuest;
                }

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public void DeleteInvitation(int id)
        {
            using (var context = new CheckInDbContext()){ 
            var customer = context.Invitations.FirstOrDefault(s => s.Id == id);
                customer.IsActive = false;
                customer.Modifiedby = User.Identity.GetUserId();
                customer.ModifiedOn = DateTime.Now;
            context.SaveChanges();
            }
        }


        public ActionResult ListOfGuests(int id)
        {
            var contex = new CheckInDbContext();
            
                var listOfInvitations = contex.Invitations
                    .Where(s => s.EventId == id && s.IsActive == true)
                    .ToList();
                IList<Guest> Guests = new List<Guest>();

                foreach (var invitaion in listOfInvitations)
                {
                    foreach (var guest in invitaion.Guests)
                    {
                        if (guest.IsActive == true)
                        {
                            Guests.Add(guest);
                        }
                    }
                }

            
                return View(Guests);
        }

        [HttpGet]
        public ActionResult _InvitationPartial(int id)
        {
            var context = new CheckInDbContext();
            var invitation = context
                .Invitations
                .Include(x => x.Address)
                .Include(x=>x.Guests)
                .FirstOrDefault(x=>x.Id == id);

            invitation.Guests.Select(x => x.IsActive == true);

            return PartialView(invitation);
        }
    }
}