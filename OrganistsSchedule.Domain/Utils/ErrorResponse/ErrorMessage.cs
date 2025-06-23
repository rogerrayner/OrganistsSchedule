namespace OrganistsSchedule.Domain.Utils;

public class ErrorMessage(int code, string description, string? details = "")
{
    public int Code { get; } = code;
    public string Description { get; } = description;
    public string? Details { get; } = details;
}