using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using codeapp.API.Helpers;
using codeapp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace codeapp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            _context =context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Like> GetLike(int userId, int recipientId)
        {
            return await _context.Likes.FirstOrDefaultAsync(u =>
            u.LikerId == userId && u.LikeeId == recipientId);
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId)
                .FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public async Task<User> GetUser(int id, bool isCurrentUser)
        {
            var query = _context.Users.Include(p => p.Photos).AsQueryable();

            if (isCurrentUser)
                query = query.IgnoreQueryFilters();

            var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        /*public Task GetUser()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }*/

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.Include(p => p.Photos).OrderByDescending(u => u.LastActive).AsQueryable();

            users = users.Where(u => u.Id != userParams.UserId);

            users = users.Where(u => u.Gender == userParams.Gender);

            if (userParams.Likers)
            {
                var userLikers = await GetUserLikes(userParams.UserId, userParams.Likers);
                users = users.Where(u => userLikers.Contains(u.Id));
            }

            if (userParams.Likees)
            {
                var userLikees = await GetUserLikes(userParams.UserId, userParams.Likers);
                users = users.Where(u => userLikees.Contains(u.Id));
            }

            if (userParams.MinAge != 18 || userParams.MaxAge != 99)
            {
                var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
                var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

                users = users.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
            }

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u => u.Created);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        private async Task<IEnumerable<int>> GetUserLikes(int id, bool likers)
        {
            var user = await _context.Users
                .Include(x => x.Likers)
                .Include(x => x.Likees)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (likers)
            {
                return user.Likers.Where(u => u.LikeeId == id).Select(i => i.LikerId);
            }
            else
            {
                return user.Likees.Where(u => u.LikerId == id).Select(i => i.LikeeId);
            }
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages
                .Include(u => u.Sender).ThenInclude(p => p.Photos)
                .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .AsQueryable();

            switch (messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.RecipientDeleted == false);
                    break;
                case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId && u.SenderDeleted == false);
                    break;
                default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.RecipientDeleted == false && u.IsRead == false);
                    break;
            }

            messages = messages.OrderByDescending(d => d.MessageSent);
            return await PagedList<Message>.CreateAsync(messages,
                messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await _context.Messages
                .Include(u => u.Sender).ThenInclude(p => p.Photos)
                .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .Where(m => m.RecipientId == userId && m.RecipientDeleted == false 
                    && m.SenderId == recipientId 
                    || m.RecipientId == recipientId && m.SenderDeleted == false 
                    && m.SenderId == userId)
                .OrderByDescending(m => m.MessageSent)
                .ToListAsync();

            return messages;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }
 
        public async Task<Customer> GetCustomer(int id)
        {
            var specificcustomer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
            return specificcustomer;
        }
        
        public async Task<IEnumerable<Scrum>> GetScrums()
        {
            var scrums = await _context.Scrums.ToListAsync();
            return scrums;
        }
        
        /*
        public async Task<PagedList<Scrum>> GetScrums(ScrumParams scrumParams)
        {
            var scrums = _context.Scrums.OrderByDescending(u => u.DateCreated).AsQueryable();

            scrums = scrums.Where(u => u.Id != scrumParams.ScrumId);

            scrums = scrums.Where(u => u.ScrumStatus == scrumParams.ScrumStatus);

            return await PagedList<Scrum>.CreateAsync(scrums, scrumParams.PageNumber, scrumParams.PageSize);
        }
        */
        public async Task<Scrum> GetScrum(int id)
        {
            var specificscrum = await _context.Scrums.FirstOrDefaultAsync(m => m.Id == id);
            return specificscrum;
        }

        public async Task<IEnumerable<Ncr>> GetNcrs()
        {
            var ncrs = await _context.Ncrs.ToListAsync();
            return ncrs;
        } 

        public async Task<Ncr> GetNcr(int id)
        {
            var specificncr = await _context.Ncrs.FirstOrDefaultAsync(m => m.NcrId == id);
            return specificncr;
        }

        public async Task<IEnumerable<Audit>> GetAudits()
        {
            var audits = await _context.Audits
                .OrderByDescending(m => m.PlannedAuditStartDate)
                .ToListAsync();
            return audits;
        }
 
        public async Task<Audit> GetAudit(int id)
        {
            var query = _context.Audits.Include(p => p.PhotoAudits).AsQueryable();

            var audit = await query.FirstOrDefaultAsync(u => u.AuditId == id);
            return audit;
        }

        public async Task<IEnumerable<Finding>> GetFindings()
        {
            var findings = await _context.Findings.ToListAsync();
            return findings;
        }
 
        public async Task<Finding> GetFinding(int id)
        {
            var specificfinding = await _context.Findings.FirstOrDefaultAsync(m => m.FindingId == id);
            return specificfinding;
        }

/*       public async Task<bool> UpdateScrumAsync(Scrum scrum){
             _context.Update(scrum);
             return true;
        }*/
        
        public async Task<IEnumerable<Responsible>> GetResponsibles()
        {
            var responsibles = await _context.Responsibles.ToListAsync();
            return responsibles;
        }

        public async Task<IEnumerable<ScrumStatus>> GetScrumStatus()
        {
            var scrumstatus = await _context.ScrumStatuses.ToListAsync();
            return scrumstatus;
        }

        public async Task<IEnumerable<AuditType>> GetAuditTypes()
        {
            var audittypes = await _context.AuditTypes.ToListAsync();
            return audittypes;
        }

        public async Task<PhotoAudit> GetPhotoAudit(int id)
        {
            var photo = await _context.PhotoAudits.IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

    }
}
