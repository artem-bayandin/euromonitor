using Application.Models;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Books
{
    public class BooksQueryHandler : IRequestHandler<BooksQuery, List<BookListItemModel>>
    {
        private readonly IEmContext _context;
        private readonly IMapper _mapper;

        public BooksQueryHandler(IEmContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookListItemModel>> Handle(BooksQuery request, CancellationToken cancellationToken)
        {
            var data = await _context
                .Books
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<BookListItemModel>>(data);
        }
    }
}
