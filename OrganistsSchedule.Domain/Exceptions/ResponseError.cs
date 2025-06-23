namespace OrganistsSchedule.Domain.Exceptions;

public class ResponseError
{
    public int? ErrorCode { get; }
    public string Message { get; }
    public string? Details { get; }
    public string? StackTrace { get; }

    public ResponseError(string exMessage, int? exErrorCode, string? exDetails, string? exStackTraceInfo)
    {
        Message = exMessage;
        ErrorCode = exErrorCode;
        Details = exDetails;
        StackTrace = exStackTraceInfo;
    }
}