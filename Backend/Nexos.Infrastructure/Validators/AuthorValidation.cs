using FluentValidation;
using Nexos.Core.DTOs;
using Nexos.Core.Entities;

namespace Nexos.Infrastructure.Validators
{
    class AuthorValidation : AbstractValidator<AuthorDto>
    {
        public AuthorValidation()
        {
            RuleFor(b => b.FullName).NotNull().MaximumLength(250);
            RuleFor(b => b.BirthTown).NotNull();
            RuleFor(b => b.BirthDate).NotNull();
        }
    }
}
