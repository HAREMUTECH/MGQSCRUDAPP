using MGQS.Enums;

namespace MGQS.Dto
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ContactType? ContactType { get; set; }
    }
}
