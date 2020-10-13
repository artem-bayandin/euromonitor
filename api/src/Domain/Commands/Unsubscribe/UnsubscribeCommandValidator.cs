using CrossCutting.FluentValidation;
using Domain.Common.Errors;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Unsubscribe
{
    public class UnsubscribeCommandValidator : AbstractValidator<UnsubscribeCommand>
    {
        private readonly IEmContext _context;
        private readonly IUserService _userService;

        public UnsubscribeCommandValidator(IEmContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;

            RuleFor(x => x.BookId)
                .MustAsync(BookExists)
                .WithMessage(ValidatorMessageExtensions.FormatMessage(CommonCustomFormatterErrors.EntityShouldExist, "Book"));

            RuleFor(x => x.BookId)
                .MustAsync(Subscribed)
                .WithMessage(UnsubscribeCommandErrors.NotSubscribed);
        }

        private async Task<bool> BookExists(Guid bookId, CancellationToken cancellationToken)
        {
            return await _context.Books.AnyAsync(x => x.Id == bookId, cancellationToken);
        }

        private async Task<bool> Subscribed(Guid bookId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
