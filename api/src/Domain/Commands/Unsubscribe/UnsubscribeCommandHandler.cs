using AutoMapper;
using Domain.Common.CommandResults;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Unsubscribe
{
    public class UnsubscribeCommandHandler : IRequestHandler<UnsubscribeCommand, CommandResult>
    {
        private readonly IEmContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UnsubscribeCommandHandler(IEmContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<CommandResult> Handle(UnsubscribeCommand request, CancellationToken cancellationToken)
        {
            var subs = await _context
                .Subscriptions
                .FirstOrDefaultAsync(x => x.BookId == request.BookId 
                                     && x.UserId == _userService.UserId.Value.ToString()
                                     , cancellationToken);
            _context.Subscriptions.Remove(subs);
            await _context.SaveChangesAsync(cancellationToken);

            return CommandResult.Ok();
        }
    }
}
