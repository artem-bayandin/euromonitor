using AutoMapper;
using Domain.Common.CommandResults;
using Domain.Interfaces;
using MediatR;
using System;
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
            throw new NotImplementedException();

            return CommandResult.Ok();
        }
    }
}
