using HouseRent.Core.Domain.Users;

namespace HouseRent.Core.ApplicationServices.Contracts;

public interface IEmailService
{
    Task SendAsync(Email email, string subject, string body);
}