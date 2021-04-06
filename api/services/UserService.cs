using System.Linq;
using api.Entities;
using api.Exception;

namespace api
{
    public interface IUserService
    {
        User GetUserWithSelectedId(int Id);
    }

    public class UserService : IUserService
    {
        private readonly LostDbContext _dbContext;

        public UserService( LostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserWithSelectedId(int Id)
        {
            var user = _dbContext.Users
                .FirstOrDefault(u => u.Id == Id);

            if (user is null)
            {
                throw new NotFoundException("User with Selected Id doesn't appear in Database");
            }

            return user;
        }
    }
}