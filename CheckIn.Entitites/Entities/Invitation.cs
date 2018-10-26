using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckIn.Entitites.Entities
{

    public class Invitation:IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Modifiedby { get; set; }
        [MaxLength(40)]
        public string GroupName { get; set; }

        public virtual List<Guest> Guests { get; set; }

        public virtual Address Address { get; set; }
        
        public string InvitationRecordNumber { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
         
    }
}
