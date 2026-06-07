using Book.Application.UseCases.Book.Delete;
using Book.Application.UseCases.Book.GetBookAll;
using Book.Application.UseCases.Book.GetBookById;
using Book.Application.UseCases.Book.RegisterBook;
using Book.Application.UseCases.Book.UpdateBook;
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

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult UpdateBook([FromRoute] Guid id, [FromBody] RequestUpdateBookJson request)
    {
        try
        {
            var useCase = new UpdateBookUseCase();
            useCase.Execute(id, request);

            return NoContent();
        } 
        catch(ArgumentException ex)
        {
            return NotFound(new ResponseErrorsJson { Errors = {ex.Message} } );
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult DeleteBook([FromRoute] Guid id)
    {
        try
        {
            var useCase = new DeleteBookUseCase();
            useCase.Execute(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(new ResponseErrorsJson { Errors = new List<string> { ex.Message } });
        }    
    }

}
