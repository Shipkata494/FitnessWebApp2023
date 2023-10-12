namespace FitnessWebApp.Common.Exceptions
{
    public class UserNotFoundExeption : Exception
    {
        private const string UserNotFoundExeptionMessage = "User is not found please try again later or text support!";
        public UserNotFoundExeption() : base(UserNotFoundExeptionMessage) 
        {

        }     

        public UserNotFoundExeption(string message)
            : base(message)
        {
            
        }
    }
}
