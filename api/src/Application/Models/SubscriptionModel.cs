using AutoMapper;
using CrossCutting.Automapper.Base;
using Domain.Entities;
using System;

namespace Application.Models
{
    public class SubscriptionModel : IMapFrom<Subscription>
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public BookModel Book { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subscription, SubscriptionModel>();
        }
    }
}
