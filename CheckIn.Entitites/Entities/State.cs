using System.ComponentModel.DataAnnotations;

namespace CheckIn.Entitites.Entities
{

    public class State 
    {
        
        public int Id { get; set; }
        [MaxLength(2)]
        public string StateCode { get; set; }
        [Required]
        [MaxLength(20)]
        public string NameOfTheState { get; set; }
        
        
        
        
    }
}
