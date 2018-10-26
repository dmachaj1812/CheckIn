using CheckIn.Entitites;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CheckIn.Website.Controllers
{
    public class InvitationsController : Controller
    {
       
        // GET: Invitations
        public ActionResult Index()
        {
           var context = new CheckInDbContext();

            var allInvitations = context.InvitationCards.Include(s => s.InvitationImage).ToList();

            return View(allInvitations);

        }

        public ActionResult Paging(int id = 1, string filterBy = "")
        {
            var pageNumber = id;
            var skipIndex = (pageNumber * 9) - 9;
            var context = new CheckInDbContext();
            var invitationCards = context.InvitationCards.Include(s => s.InvitationImage).ToList();

            //Filtering Invitaions
            switch (filterBy)
            {
                case "All":
                    break;
                case "Weeding":
                    invitationCards = invitationCards.Where(s => s.EventType.EventTypeName == "Weeding").ToList();
                    break;
                case "BabyShower":
                    invitationCards = invitationCards.Where(s => s.EventType.EventTypeName == "Baby Shower").ToList();
                    break;
                case "BridalShower":
                    invitationCards = invitationCards.Where(s => s.EventType.EventTypeName == "Bridal Shower").ToList();
                    break;
            }
            //Number of Pages
            var numberOfPages = ((int)(invitationCards.Count / 9));
            if (numberOfPages % 9 != 0) numberOfPages++;
            ViewBag.NumberOfPages = numberOfPages;

            // Calculating TakIndex
            var takeIndex = 0;
            if (invitationCards.Count < pageNumber * 9)
                takeIndex = invitationCards.Count - (pageNumber * 9);
            takeIndex = 9;

            invitationCards = invitationCards.Skip(skipIndex).Take(takeIndex).ToList();

            //Filter By To Keep Value
            ViewBag.FilterBy = filterBy;
            ViewBag.CurrentPage = id;
            return PartialView(invitationCards);
        }
    }
}

