namespace FitnessWebApp.Common.Exceptions
{
    public class FoodDoesNotExistException : Exception
    {
        private const string DeafultMessage = "Food does not exist!";
        public FoodDoesNotExistException():base(DeafultMessage) { }
        public FoodDoesNotExistException(string messsage) : base(messsage)
        {
            
        }
    }
}
