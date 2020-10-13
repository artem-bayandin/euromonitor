using Application.Models;
using Domain.Common.CommandResults;
using MediatR;
using System;

namespace Application.Queries.Book
{
    public class BookQuery : IRequest<CommandResult<BookModel>>
    {
        public Guid Id { get; set; }
    }
}
