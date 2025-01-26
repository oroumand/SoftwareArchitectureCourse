namespace CourseStore.Framework.Services.DateTimeServices;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetUtcNow() => DateTime.UtcNow;
}