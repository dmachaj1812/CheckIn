using System;

namespace CheckIn.Entitites
{
    interface IEntity
    {
         int Id { get; set; }
         bool IsActive { get; set; }
         DateTime? CreatedOn { get; set; }
         DateTime? ModifiedOn { get; set; }
         string CreatedBy { get; set; }
         string Modifiedby { get; set; }
    }
}
