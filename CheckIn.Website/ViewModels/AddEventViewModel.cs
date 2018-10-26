using System.ComponentModel.DataAnnotations;

namespace CheckIn.Website.ViewModels
{
    public class AddEventViewModel
    {   [Required]
        public string NameOfEvent { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        [Display(Name="Place of Event")]
        public string PlaceOfEvent { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Display(Name="Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        public int StateId { get; set; }
        //public IEnumerable<State> States { get; set; }

        [Required]
        [Display(Name="Event Type")]
        public int EventTypeId { get; set; }
        //public IEnumerable<EventType> EventTypes { get; set; }
    }

}