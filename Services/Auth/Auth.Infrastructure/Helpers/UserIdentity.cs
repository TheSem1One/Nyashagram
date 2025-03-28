using Auth.Domain.DTO;
using Auth.Infrastructure.Persistence;

namespace Auth.Infrastructure.Helpers
{
    public class UserIdentity
    {
        private readonly UserContext _db;
        private readonly HashPassword _hashPassword;

        public UserIdentity(UserContext db, HashPassword hashPassword)
        {
            _db = db;
            _hashPassword = hashPassword;

        }

        public UserDTO GetJwtUser(string email)
        {
            var user = _db.Users.SingleOrDefault(user => user.email.ToLower() == email.ToLower());
            var userDTO = new UserDTO
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
            return userDTO;

        }

        public bool IsEqual(string email, string password)
        {
            var hashPassword = _hashPassword.HashingPassword(password);
            var user = _db.Users.SingleOrDefault(user => user.email.ToLower() == email.ToLower());
            return user.email.ToLower() == email.ToLower() && user.password == hashPassword;

        }
    }
}
