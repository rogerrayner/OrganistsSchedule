namespace OrganistsSchedule.Domain.Identity;

public interface IAuthentication
{
    Task<bool> Login(string email, string password);
    Task<bool> RegisterUser(string email, string password);
    Task Logout();
}