using Domain.Common.CommandResults;
using MediatR;
using System;

namespace Domain.Commands.Subscribe
{
    public class SubscribeCommand : IRequest<CommandResult>
    {
        public Guid BookId { get; set; }
    }
}
