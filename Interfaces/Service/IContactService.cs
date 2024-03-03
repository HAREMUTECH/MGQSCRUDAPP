using MGQS.Dto;

namespace MGQS.Interfaces.Service
{
    public interface IContactService
    {
        void CreateContat(CreateContact request);
        void UpdateContact(int Id, UpdateContact request);
        UpdateContact GetContactById(int Id);
        List<ContactDto> GetContacts();

        bool DeleteContact(int Id);
    }
}
