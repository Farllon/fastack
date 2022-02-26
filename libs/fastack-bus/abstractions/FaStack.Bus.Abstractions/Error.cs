namespace FaStack.Bus.Abstractions
{
    public sealed class Error : Notification
    {
        public Error(string message) 
            : base(message)
        {

        }
    }
}