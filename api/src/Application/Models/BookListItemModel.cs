using AutoMapper;
using CrossCutting.Automapper.Base;
using Domain.Entities;
using System;

namespace Application.Models
{
    public class BookListItemModel : IMapFrom<Book>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double PurchasePrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookListItemModel>();
        }
    }
}
