using AutoMapper;
using Domain.Common.CommandResults;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Subscribe
{
    public class SubscribeCommandHandler : IRequestHandler<SubscribeCommand, CommandResult>
    {
        private readonly IEmContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public SubscribeCommandHandler(IEmContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<CommandResult> Handle(SubscribeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            return CommandResult.Ok();
        }
    }
}
