using Application.Queries.Book;
using Application.Queries.Books;
using Application.Queries.Subscriptions;
using Domain.Commands.Subscribe;
using Domain.Commands.Unsubscribe;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        public BooksController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new BooksQuery()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] BookQuery request)
        {
            return Result(await Mediator.Send(request ?? new BookQuery()));
        }

        [Authorize]
        [HttpPost("{bookId}/subscribe")]
        public async Task<IActionResult> Subscribe([FromRoute] SubscribeCommand request)
        {
            return Result(await Mediator.Send(request ?? new SubscribeCommand()));
        }

        [Authorize]
        [HttpPost("{bookId}/unsubscribe")]
        public async Task<IActionResult> Unsubscribe([FromRoute] UnsubscribeCommand request)
        {
            return Result(await Mediator.Send(request ?? new UnsubscribeCommand()));
        }

        [Authorize]
        [HttpGet("subscriptions")]
        public async Task<IActionResult> Subscriptions()
        {
            return Ok(await Mediator.Send(new SubscriptionsQuery()));
        }
    }
}
