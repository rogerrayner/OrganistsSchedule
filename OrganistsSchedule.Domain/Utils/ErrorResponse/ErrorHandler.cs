using OrganistsSchedule.Domain.Exceptions;

namespace OrganistsSchedule.Domain.Utils;

public static class ErrorHandler
{
    public static string Format(ErrorMessage error, params object[] args)
        => string.Format(error.Description, args);
    
    public static void ThrowBusinessException(ErrorMessage error, params object[] args)
    {
        throw new BusinessException(
            string.Format(error.Description, args),
            error.Code
        );
    }
    
    public static void ThrowNotFoundException(ErrorMessage error, params object[] args)
    {
        throw new NotFoundException(
            string.Format(error.Description, args),
            error.Code
        );
    }
}