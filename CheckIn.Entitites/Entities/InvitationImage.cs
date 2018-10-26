using System;

namespace CheckIn.Entitites.Entities
{
    public class InvitationImage : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }
        


        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Modifiedby { get; set; }
    }
}
