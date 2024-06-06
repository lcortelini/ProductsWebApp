namespace ProductsAPI.Utilities
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message) { }
    }
}
