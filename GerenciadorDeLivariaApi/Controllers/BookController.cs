using Book.Application.UseCases.Book.GetBookAll;
using Book.Application.UseCases.Book.GetBookById;
using Book.Application.UseCases.Book.RegisterBook;
using Book.Communication.Requests;
using Book.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivariaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ReponseRegisterBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult CreateBook([FromBody]RequestRegisterBookJson request)
    {
        try
        {
            var response = new CreateBookUseCase().Execute(request);
            return Created(string.Empty, response);
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseErrorsJson { Errors = new List<string> { ex.Message } });
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReponseRegisterBookJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAllBooks()
    {
        var useCase = new GetAllBooksUseCase();
        var response = useCase.Execute();
        if (response == null || response.Count == 0) { return NoContent(); }
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(List<ReponseRegisterBookJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetBookById([FromRoute]Guid id)
    {
        try
        {
            var book = new GetBookByIdUseCase();
            var response = book.Execute(id);

            if (response == null)
            {
                return NotFound(new ResponseErrorsJson { Errors = new List<string> { "Tarefa não encontrada." } });
            }

            return Ok(response);
        }
        catch(ArgumentException ex)
        {
            return NotFound(new ResponseErrorsJson { Errors = new List<string> { ex.Message } });
        }
    }

}
