using Application.Models;
using Domain.Common.Commandresults;
using MediatR;
using System;

namespace Application.Queries.Book
{
    public class BookQuery : IRequest<CommandResult<BookModel>>
    {
        public Guid Id { get; set; }
    }
}
