using FluentValidation.Results;

namespace Shared.Extensions;

public static class ValidationExtensions
{
    public static Failure ToErrors(this ValidationResult validationResult) =>
        validationResult.Errors.Select(e => Error.Validation(e.ErrorCode, e.ErrorMessage, e.PropertyName)).ToArray();

    public static Failure ToErrors(this IEnumerable<ValidationResult> validationResults) =>
        validationResults.SelectMany(e => e.Errors).Select(e => Error.Validation(e.ErrorCode, e.ErrorMessage, e.PropertyName)).ToArray();
}