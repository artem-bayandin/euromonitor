using Domain.Common.CommandResults;
using MediatR;
using System;

namespace Domain.Commands.Unsubscribe
{
    public class UnsubscribeCommand : IRequest<CommandResult>
    {
        public Guid BookId { get; set; }
    }
}
