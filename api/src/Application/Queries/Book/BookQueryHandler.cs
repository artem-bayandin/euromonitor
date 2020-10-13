using Application.Models;
using AutoMapper;
using Domain.Common.CommandResults;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Book
{
    public class BookQueryHandler : IRequestHandler<BookQuery, CommandResult<BookModel>>
    {
        private readonly IEmContext _context;
        private readonly IMapper _mapper;

        public BookQueryHandler(IEmContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommandResult<BookModel>> Handle(BookQuery request, CancellationToken cancellationToken)
        {
            var data = await _context
                .Books
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return CommandResult<BookModel>.Ok(_mapper.Map<BookModel>(data));
        }
    }
}
