using MGQS.Enums;

namespace MGQS.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? Email { get; set; }
        public ContactType ContactType { get; set; }
    }
}