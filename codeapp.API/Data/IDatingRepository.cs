using System.Collections.Generic;
using System.Threading.Tasks;
using codeapp.API.Helpers;
using codeapp.API.Models;

namespace codeapp.API.Data
{
    public interface IDatingRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         // Task<IEnumerable<User>> GetUsers(); commented out when we did pagedList
         Task<PagedList<User>> GetUsers(UserParams userParams);
         Task<User> GetUser(int id, bool isCurrentUser);
         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForUser(int userId);
         Task<Like> GetLike(int userId, int recipientId);
         Task<Message> GetMessage(int id);
         Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
         Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
         Task<IEnumerable<Customer>> GetCustomers();
         Task<Customer> GetCustomer(int id);
         //Task<PagedList<Scrum>> GetScrums(ScrumParams scrumParams);
         Task<IEnumerable<Scrum>> GetScrums();
         Task<Scrum> GetScrum(int id);
         Task<IEnumerable<Ncr>> GetNcrs();
         Task<Ncr> GetNcr(int id);
         Task<IEnumerable<Responsible>> GetResponsibles();
         Task<IEnumerable<Audit>> GetAudits();
         Task<Audit> GetAudit(int id);
         Task<IEnumerable<Finding>> GetFindings();
         Task<Finding> GetFinding(int id);
         Task<PhotoAudit> GetPhotoAudit(int id);
         Task<IEnumerable<AuditType>> GetAuditTypes();
        Task<IEnumerable<ScrumStatus>> GetScrumStatus();

         Task<bool> SaveChangesAsync();
         
         //Task<bool> UpdateScrumAsync(Scrum scrum);
         
    }
}