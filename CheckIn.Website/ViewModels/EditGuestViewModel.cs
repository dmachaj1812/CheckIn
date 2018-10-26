using CheckIn.Entitites.Entities;
using CheckIn.Entitites.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckIn.Website.ViewModels
{
    public class EditGuestViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Group Name is Required",AllowEmptyStrings = false)]
        public string GroupName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public int StateId { get; set; }

        //[RequiredList(ErrorMessage = "The FirstName is required")]
        [Required(AllowEmptyStrings = false)]
        public IList<Guest> Guest { get; set; }
    }
}