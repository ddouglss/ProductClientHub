using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] ResquestClientJson resquest) 
        { 
            try{
                var useCase = new RegisterClientUseCase();

                var response = useCase.Execute(resquest);

                return Created(string.Empty, response);
            }
            catch (ProductClientHubException ex)
            {
                var errors = ex.GetErrors();
                return BadRequest(new ResponseErrorMessagesJson(errors));
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("ERRO DESCONHECIDO"));
            }
        }

        [HttpPut]
        public IActionResult Update() 
        { 
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll() 
        { 
            return Ok();
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
