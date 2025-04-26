namespace User.Application.Common.Exceptions
{
    public class UserExistException : Exception
    {
        public UserExistException() : base("Wrong Email or Password")
        {
        }

        public UserExistException(string email) : base($"email : \"{email}\" is exist.")
        {

        }
}
}
