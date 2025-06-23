namespace OrganistsSchedule.Domain.Exceptions;
public class NotFoundException : Exception
{
    public int? ErrorCode { get; }
    public string? Details { get; }
    public string? StackTraceInfo { get; }

    public NotFoundException(
        string message,
        int? errorCode = null,
        string? details = null,
        string? stackTraceInfo = null
    ) : base(message)
    {
        ErrorCode = errorCode;
        Details = details;
        StackTraceInfo = stackTraceInfo;
    }
}
