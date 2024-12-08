using HouseRent.Core.Domain.Users;

namespace HouseRent.Core.ApplicationService.Contracts;

public interface IEmailService
{
    Task SendAsync(Email email, string subject, string body);
}