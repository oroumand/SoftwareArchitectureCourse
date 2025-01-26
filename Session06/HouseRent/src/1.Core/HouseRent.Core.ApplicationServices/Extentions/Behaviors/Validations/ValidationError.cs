namespace HouseRent.Core.Applicaiton.Extentions.Behaviors.Validations;

public sealed record ValidationError(string PropertyName, string ErrorMessage);