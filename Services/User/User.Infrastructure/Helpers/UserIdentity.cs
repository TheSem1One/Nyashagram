using User.Domain.DTO;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Helpers
{
    public class UserIdentity(UserContext db, HashPassword hashPassword)
    {
        private readonly UserContext _db = db;
        private readonly HashPassword _hashPassword = hashPassword;

        public UserDto GetJwtUser(string email)
        {
            var user = _db.Users.SingleOrDefault(user => user.Email.ToLower() == email.ToLower());
            var userDto = new UserDto
            {
                NickName = user.NickName,
                BirthDate = user.BirthDate,
                Posts = user.Posts,
                SavedPosts = user.SavedPosts,
                StoriesList = user.StoriesList,
                Subscriptions = user.Subscriptions,
                Subscribers = user.Subscribers,
                 
            };
            return userDto;

        }

        public bool IsEqual(string email, string password)
        {
            var hashPassword = _hashPassword.HashingPassword(password);
            var user = _db.Users.SingleOrDefault(user => user.Email.ToLower() == email.ToLower());
            return user.Email.ToLower() == email.ToLower() && user.Password == hashPassword;

        }
    }
}
