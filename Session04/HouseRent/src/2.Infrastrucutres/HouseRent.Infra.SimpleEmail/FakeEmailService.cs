using HouseRent.Core.ApplicationServices.Contracts;

namespace HouseRent.Infra.SimpleEmail;

internal sealed class FakeEmailService : IEmailService
{
    public Task SendAsync(Core.Domain.Users.Email recipient, string subject, string body)
    {
        Console.WriteLine(recipient);
        Console.WriteLine(subject);
        Console.WriteLine(body);
        return Task.CompletedTask;
    }
}