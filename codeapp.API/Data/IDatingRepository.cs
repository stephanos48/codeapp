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
         Task<User> GetUser(int id);
         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForUser(int userId);
    }
}