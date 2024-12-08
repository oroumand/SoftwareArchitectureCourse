namespace HouseRent.Core.ApplicationService.Extentions.Behaviors.Validations;

public sealed record ValidationError(string PropertyName, string ErrorMessage);