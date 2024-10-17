namespace CleanArchMvc.Domain.Validators;

public class DomainExceptionValidation: Exception
{
    public DomainExceptionValidation(string errorMessage) : base(errorMessage)
    {}

    public static void When(bool hasError, string errorMessage)
    {
        if(hasError)
            throw new DomainExceptionValidation(errorMessage);
    }
}