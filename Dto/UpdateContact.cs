﻿using MGQS.Enums;

namespace MGQS.Dto
{
    public class UpdateContact
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ContactType? ContactType { get; set; }
    }
}
