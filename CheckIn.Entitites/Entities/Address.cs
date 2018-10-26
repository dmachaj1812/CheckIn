using System;
using System.ComponentModel.DataAnnotations;

namespace CheckIn.Entitites.Entities
{

    public class Address
    {

        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Modifiedby { get; set; }
        [MaxLength(50)]
        public string AddressName { get; set; }
        
        public int ZipCode { get; set; }
        [MaxLength(30)]
        public string CityName { get; set; }
        [Required]
        
        public int StateId { get; set; }
        public virtual State State { get; set; }
        
        
    }
}
