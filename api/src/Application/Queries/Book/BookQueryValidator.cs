using CrossCutting.FluentValidation;
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
                .WithMessage((query, id) => ValidatorMessageExtensions.FormatMessage(BookQueryErrors.BookDoesNotExist, id));
        }

        private async Task<bool> BookExists(Guid orderId, CancellationToken cancellationToken)
        {
            return await _context.Books.AnyAsync(x => x.Id == orderId, cancellationToken);
        }
    }
}
