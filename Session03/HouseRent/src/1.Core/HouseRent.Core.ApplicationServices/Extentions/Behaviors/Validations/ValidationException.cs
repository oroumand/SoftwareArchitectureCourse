namespace HourseRent.Core.Applicaiton.Extentions.Behaviors.Validations;

public sealed class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationError> errors) => Errors = errors;

    public IEnumerable<ValidationError> Errors { get; }
}

public static class ValidationExceptionGuard
{
    public static void ThrowIfIsInvalid(this List<ValidationError> validationErrors)
    {
        if (validationErrors.Count != 0)
        {
            throw new ValidationException(validationErrors);
        }
    }
}