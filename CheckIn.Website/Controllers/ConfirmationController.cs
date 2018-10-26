using CheckIn.Entitites;
using CheckIn.Website.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CheckIn.Website.Controllers
{
    public class ConfirmationController : Controller
    {
        // GET: Confirmation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _FindInvitation(int id, string lastName = "")
        {
            var contex = new CheckInDbContext();

            var invitation = contex.Invitations.Include(x=>x.Guests)
                .FirstOrDefault(s => s.InvitationRecordNumber == id.ToString());
            if (invitation == null)
            {
                return Content("Wrong Number");
            }
            
           IList<GuestViewModel> guests = new List<GuestViewModel>();

            var lastNameMatches = 0;
            
            foreach(var guest in invitation.Guests)
            {
                if (guest.IsActive == true)
                {
                    if (guest.LastName.ToLower() == lastName.ToLower())
                    {
                        lastNameMatches++;
                    }
                    GuestViewModel tempGuest = new GuestViewModel
                    {
                        Id = guest.Id,
                        IsConfirmedMainGuest = guest.IsConfirmedMainGuest,
                        IsConfirmedExtraGuest = guest.IsConfirmedExtraGuest,
                        IsExtraGuest = guest.IsExtraGuest,
                        FirstName = guest.FirstName,
                        LastName = guest.LastName,
                        GuestFirstName = guest.ExtraGuestFirstName,
                        GuestLastName = guest.ExtraGuestLastName,
                        InvitationRecordNumber = id.ToString()
                    };
                    guests.Add(tempGuest);
                }
            }

            if (lastNameMatches == 0)
            {
                return Content("Last Name and Invitation Number does not match");
            }
            return PartialView(guests);
        }
        [HttpPost]
        public ActionResult Confirm(IList<GuestViewModel> viewModel)
        {
            //do poprawy
            using (var context = new CheckInDbContext())
            {
                var viewModelIRN = viewModel[0].InvitationRecordNumber;
                var invitations = context.Invitations.Include(s => s.Guests)
                    .FirstOrDefault(x => x.InvitationRecordNumber == viewModelIRN);
                
                foreach (var guestDb in invitations.Guests)
                {
                    foreach (var guestViewModel in viewModel)
                    {
                        if (guestDb.Id == guestViewModel.Id)
                        {
                            guestDb.IsConfirmedMainGuest = guestViewModel.IsConfirmedMainGuest;
                            guestDb.IsConfirmedExtraGuest = guestViewModel.IsConfirmedExtraGuest;
                        }
                    }
                }

                context.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }
    }
}