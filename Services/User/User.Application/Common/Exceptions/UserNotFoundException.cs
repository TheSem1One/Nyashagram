namespace User.Application.Common.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User Not Found.")
        {

        }
    }
}
