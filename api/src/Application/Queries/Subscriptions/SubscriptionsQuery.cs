using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Subscriptions
{
    public class SubscriptionsQuery : IRequest<List<SubscriptionModel>>
    {
        // empty query
    }
}
