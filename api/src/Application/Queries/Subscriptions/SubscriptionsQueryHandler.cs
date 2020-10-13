using Application.Models;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Subscriptions
{
    public class SubscriptionsQueryHandler : IRequestHandler<SubscriptionsQuery, List<SubscriptionModel>>
    {
        private readonly IEmContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public SubscriptionsQueryHandler(IEmContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<List<SubscriptionModel>> Handle(SubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context
                .Subscriptions
                .Include(x => x.Book)
                .Where(x => x.UserId == _userService.UserId.Value.ToString())
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<SubscriptionModel>>(data);
        }
    }
}
