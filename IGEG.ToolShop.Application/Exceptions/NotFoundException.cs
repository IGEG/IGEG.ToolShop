
namespace IGEG.ToolShop.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, object key) : base($"{message} with id ({key}) was not found")
        {
                
        }
    }
}
