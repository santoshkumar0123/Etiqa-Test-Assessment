using Etiqa_Assessment_REST_API.Models;
using System.Numerics;
namespace Etiqa_Assessment_REST_API.Repository
{
    public interface IUserRepository
    {
        Task<PaginatedList<User>> GetUserLists(int pageIndex, int pageSize);
        Task<User> RegisterNewUser(User objUserDetails);
        Task<User> UpdateUserDetails(User objUserDetails);
        bool DeleteUser(string userid);
    }
}
