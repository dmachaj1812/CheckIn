namespace CheckIn.Website.ViewModels
{
    public class GuestViewModel
    {
        public int Id { get; set; }
        public bool IsConfirmedExtraGuest { get; set; }
        public bool IsConfirmedMainGuest { get; set; }
        public bool IsExtraGuest { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public string InvitationRecordNumber { get; set; }

    }
}