using CheckIn.Entitites.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckIn.Website.ViewModels
{
    public class AddGuestViewModel
    {
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required(ErrorMessage = "The State field is required")]
        public int StateId { get; set; }
        [Required]
        public IList<Guest> Guest { get; set; }
        public int EventId { get; set; }
        public int IsActive { get; set; }
    }
}