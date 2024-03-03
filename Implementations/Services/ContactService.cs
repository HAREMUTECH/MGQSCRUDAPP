using MGQS.Context;
using MGQS.Dto;
using MGQS.Entities;
using MGQS.Interfaces.Service;

namespace MGQS.Implementations.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationContext _dbContext;
        private readonly ILogger<ContactService> _logger;

        public ContactService(ApplicationContext dbContext, ILogger<ContactService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public void CreateContat(CreateContact request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var newContact = new Contact()
            {
                ContactType = request.ContactType,
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber
            };

            _dbContext.Contacts.Add(newContact);
            _dbContext.SaveChanges();
        }

        public bool DeleteContact(int Id)
        {
            var contanct = _dbContext.Contacts.FirstOrDefault(x => x.Id == Id);
            if (contanct == null)
            {
                throw new ArgumentNullException(nameof(DeleteContact));
            }

            _dbContext.Contacts.Remove(contanct);
            return _dbContext.SaveChanges() > 0 ? true : false;
        }

        public UpdateContact GetContactById(int Id)
        {
            var result = new ContactDto();
            var contanct = _dbContext.Contacts.FirstOrDefault(x => x.Id == Id);

            if (contanct == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            return new UpdateContact()
            {
                ContactType = contanct.ContactType,
                Email = contanct.Email,
                Name = contanct.Name,
                PhoneNumber = contanct.PhoneNumber
            };
        }

        public List<ContactDto> GetContacts()
        {
            var result = _dbContext.Contacts.Select(x => new ContactDto()
            {
                ContactType = x.ContactType,
                Id = x.Id,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Name = x.Name
            }).ToList();

            return result;
        }

        public void UpdateContact(int Id, UpdateContact request)
        {

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var contanct = _dbContext.Contacts.FirstOrDefault(x => x.Id == Id);

            if (contanct == null)
            {
                throw new ArgumentNullException(nameof(UpdateContact));
            }

            contanct.ContactType = request.ContactType.Value;
            contanct.Email = request.Email;
            contanct.Name = request.Name;
            contanct.PhoneNumber = request.PhoneNumber;

            _dbContext.Contacts.Update(contanct);
            _dbContext.SaveChanges();

        }
    }
}
