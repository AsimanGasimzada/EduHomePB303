using EduHome.Business.Abstractions.Exceptions;

namespace EduHome.Business.Exceptions;

public class NotFoundException : Exception, IBaseException
{
    public NotFoundException(string message = "Not found") : base(message)
    {

    }
}
