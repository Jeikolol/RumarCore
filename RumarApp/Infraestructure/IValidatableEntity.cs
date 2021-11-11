using FluentValidation.Results;

namespace RumarApp.Infraestructure
{
    public interface IValidatableEntity
    {
        ValidationResult Validate();
    }
}
