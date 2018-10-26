using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckIn.Entitites.Entities
{

    public class Event : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        
        [MaxLength(50)]
        [Display(Name="Place of Event")]
        public string PlaceOfEvent { get; set; }

        [Display(Name = "Event Type")]
        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
        public Address Address { get; set; }
        
        public virtual List<Invitation> Invitations { get; set; }

        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Modifiedby { get; set; }

    }
}
