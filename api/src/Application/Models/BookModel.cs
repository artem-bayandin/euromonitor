using AutoMapper;
using CrossCutting.Automapper.Base;
using Domain.Entities;
using System;

namespace Application.Models
{
    public class BookModel : IMapFrom<Book>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }
        public double PurchasePrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookModel>();
        }
    }
}
