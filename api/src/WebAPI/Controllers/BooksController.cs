using Application.Queries.Book;
using Application.Queries.Books;
using MediatR;
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
            var result = await Mediator.Send(new BooksQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] BookQuery query)
        {
            var result = await Mediator.Send(query ?? new BookQuery());
            return Result(result);
        }
    }
}
