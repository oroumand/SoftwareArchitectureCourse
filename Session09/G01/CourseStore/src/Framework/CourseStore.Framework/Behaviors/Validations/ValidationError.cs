namespace CourseStore.Framework.Behaviors.Validations;

public sealed record ValidationError(string PropertyName, string ErrorMessage);