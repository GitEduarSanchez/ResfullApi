namespace API.Validations
{
    using APIRestful.Domain.Models.Request;
    using FluentValidation;
    public class ValidationRequest : AbstractValidator<RequestJourney>
    {
        public ValidationRequest()
        {
            RuleFor(x => x.DepartureStation)
                .NotEmpty().WithMessage("Not Empty")
                .Length(3).WithMessage("Leng 3")
                .Must(x => x.All(c => Char.IsUpper(c))).WithMessage("only uppercase");
            RuleFor(x => x.ArrivalStation)
                .NotEmpty().WithMessage("Not Empty")
                .Length(3).WithMessage("Leng 3")
                .Must(x => x.All(c => Char.IsUpper(c))).WithMessage("only uppercase");

        }
    }
}
