using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;


// Função do nosso controller é receber a (Request) requisição, e passar para a regra de negócio (useCase)o caso de uso e devolver a resposta
namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] ResquestClientJson resquest) 
        {
            var useCase = new RegisterClientUseCase();

            var response = useCase.Execute(resquest);

            return Created(string.Empty, response);

        }

        [HttpPut]
        public IActionResult Update() 
        { 
            return Ok();

        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll() 
        { 
            var useCase = new GetAllClientsUseCase();
            var response = useCase.Execute();
            if(response.Clients.Count == 0) //retorna 204 No Content (Não tem conteudo nenhum)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id) 
        { 
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        { 
            return Ok();
        }


    }
}
