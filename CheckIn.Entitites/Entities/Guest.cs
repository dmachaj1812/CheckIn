using System;
using System.ComponentModel.DataAnnotations;

namespace CheckIn.Entitites.Entities
{
    public class Guest : IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Modifiedby { get; set; }

        [MaxLength(30)]
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        public bool IsConfirmedMainGuest{ get; set; }

        public bool IsExtraGuest { get; set; }

        [MaxLength(30)]
        public string ExtraGuestFirstName { get; set; }

        [MaxLength(30)]
        public string ExtraGuestLastName { get; set; }

        public bool IsConfirmedExtraGuest { get; set; }

        public int InvitationId { get; set; }
        public Invitation Invitation { get; set; }

        public Guest()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            
            IsConfirmedMainGuest = false;
            IsConfirmedExtraGuest = false;
        }

    }
}
