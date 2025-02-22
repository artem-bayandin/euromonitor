﻿using CrossCutting.FluentValidation;
using Domain.Common.Errors;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Book
{
    public class BookQueryValidator : AbstractValidator<BookQuery>
    {
        private readonly IEmContext _context;

        public BookQueryValidator(IEmContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .MustAsync(BookExists)
                .WithMessage(ValidatorMessageExtensions.FormatMessage(CommonCustomFormatterErrors.EntityShouldExist, "Book"));
        }

        private async Task<bool> BookExists(Guid bookId, CancellationToken cancellationToken)
        {
            return await _context.Books.AnyAsync(x => x.Id == bookId, cancellationToken);
        }
    }
}
