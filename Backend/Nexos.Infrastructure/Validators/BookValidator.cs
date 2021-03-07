using FluentValidation;
using Nexos.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nexos.Infrastructure.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(b => b.Gender).NotNull();
            RuleFor(b => b.Title).NotNull().MaximumLength(500);
            RuleFor(b => b.IdAuthor).NotNull();
            RuleFor(b => b.IdEditorial).NotNull();
        }
    }
}
