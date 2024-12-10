using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new(
        "User.Found",
        "کاربر با شناسه ارسالی یافت نشد");

    public static Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "مقدار ارسالی نامعتبر است");
}