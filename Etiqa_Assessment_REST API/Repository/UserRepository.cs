using Etiqa_Assessment_REST_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Etiqa_Assessment_REST_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext ??
                throw new ArgumentNullException(nameof(userDbContext));
        }

        public async Task<PaginatedList<User>> GetUserLists(int pageIndex, int pageSize)
        {
            var userLists = await _userDbContext.users
                .OrderBy(b => b.username)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await _userDbContext.users.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<User>(userLists, pageIndex, totalPages);
        }

        public async Task<User> RegisterNewUser(User objUserDetails)
        {
            _userDbContext.users.Add(objUserDetails);
            await _userDbContext.SaveChangesAsync();
            return objUserDetails;
        }

        public async Task<User> UpdateUserDetails(User objUserDetails)
        {
            _userDbContext.Entry(objUserDetails).State = EntityState.Modified;
            await _userDbContext.SaveChangesAsync();
            return objUserDetails;
        }

        public bool DeleteUser(string userid)
        {
            bool result = false;
            var department = _userDbContext.users.Find(userid);
            if (department != null)
            {
                _userDbContext.Entry(department).State = EntityState.Deleted;
                _userDbContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
