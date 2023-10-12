namespace FitnessWebApp.Common.Exceptions
{
    public class GymUserDoesNotExistException : Exception
    {
        private const string DefaultMessage = "User does not exist!";
        public GymUserDoesNotExistException() 
            : base(DefaultMessage) 
        {
        }
        public GymUserDoesNotExistException(string message)
            : base(message)
        {
        }
    }
}
