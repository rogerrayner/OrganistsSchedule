namespace OrganistsSchedule.Domain.Exceptions;

public class BusinessException(
    string message,
    int errorCode,
    string? details = null,
    string? stackTraceInfo = null)
    : Exception(message)
{
    public int ErrorCode { get; } = errorCode;
    public string? Details { get; } = details;
    public string? StackTraceInfo { get; } = stackTraceInfo;
}