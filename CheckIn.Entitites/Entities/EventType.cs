using System;
using System.ComponentModel.DataAnnotations;

namespace CheckIn.Entitites.Entities
{

    public class EventType : IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Modifiedby { get; set; }
        [MaxLength(40)]
        public string EventTypeName { get; set; }

      
       
    }
}
