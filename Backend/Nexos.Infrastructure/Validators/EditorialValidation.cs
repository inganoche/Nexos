using FluentValidation;
using Nexos.Core.DTOs;
using Nexos.Core.Entities;

namespace Nexos.Infrastructure.Validators
{
    class EditorialValidation : AbstractValidator<EditorialDto>
    {
        public EditorialValidation()
        {
            RuleFor(b => b.Name).NotNull();
            RuleFor(b => b.MaxBook).NotNull();
            RuleFor(b => b.Address).NotNull();
        }
    }
}
