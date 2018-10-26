using System;
using System.ComponentModel.DataAnnotations;

namespace CheckIn.Entitites.Entities
{
    public class InvitationCard : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }

        public int InvitationImageId { get; set; }
        public virtual InvitationImage InvitationImage { get; set; }

        public int? InvitationMakerId { get; set; }
        public virtual InvitationMaker InviaInvitationMaker { get; set; }

        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Modifiedby { get; set; }


    }
}
