using CrossCutting.FluentValidation;
using Domain.Common.Errors;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Subscribe
{
    public class SubscribeCommandValidator : AbstractValidator<SubscribeCommand>
    {
        private readonly IEmContext _context;
        private readonly IUserService _userService;

        public SubscribeCommandValidator(IEmContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;

            RuleFor(x => x.BookId)
                .MustAsync(BookExists)
                .WithMessage(ValidatorMessageExtensions.FormatMessage(CommonCustomFormatterErrors.EntityShouldExist, "Book"));

            RuleFor(x => x.BookId)
                .MustAsync(NotSubscribed)
                .WithMessage(SubscribeCommandErrors.AlreadySubscribed);
        }

        private async Task<bool> BookExists(Guid bookId, CancellationToken cancellationToken)
        {
            return await _context.Books.AnyAsync(x => x.Id == bookId, cancellationToken);
        }

        private async Task<bool> NotSubscribed(Guid bookId, CancellationToken cancellationToken)
        {
            var subs = await _context
                .Subscriptions
                .FirstOrDefaultAsync(x => x.BookId == bookId 
                                     && x.UserId == _userService.UserId.Value.ToString()
                                     , cancellationToken);
            return subs == null;
        }
    }
}
