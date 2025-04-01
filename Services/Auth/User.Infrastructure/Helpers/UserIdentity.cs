using User.Domain.DTO;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Helpers
{
    public class UserIdentity(UserContext db, HashPassword hashPassword)
    {
        private readonly UserContext _db = db;
        private readonly HashPassword _hashPassword = hashPassword;

        public UserDTO GetJwtUser(string email)
        {
            var user = _db.Users.SingleOrDefault(user => user.email.ToLower() == email.ToLower());
            var userDto = new UserDTO
            {
                NickName = user.nickName,
                BirthDate = user.birthDate,
                Posts = user.posts,
                SavedPosts = user.savedPosts,
                StoriesList = user.storiesList,
                Subcriptions = user.subcriptions,
                Subscribers = user.subscribers,
                PrivateProfile = user.privateProfile
            };
            return userDto;

        }

        public bool IsEqual(string email, string password)
        {
            var hashPassword = _hashPassword.HashingPassword(password);
            var user = _db.Users.SingleOrDefault(user => user.email.ToLower() == email.ToLower());
            return user.email.ToLower() == email.ToLower() && user.password == hashPassword;

        }
    }
}
