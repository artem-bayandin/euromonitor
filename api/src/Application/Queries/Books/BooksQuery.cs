using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Books
{
    public class BooksQuery : IRequest<List<BookListItemModel>>
    {
        // empty query
    }
}
