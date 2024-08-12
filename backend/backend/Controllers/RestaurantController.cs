using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.Objects.DTOs.Entities;
using backend.Objects.Server;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly Response _response;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;

            _response = new Response();
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetAll()
        {
            try
            {
                var restaurantsDTO = await _restaurantService.GetAll();
                _response.SetSuccess();
                _response.Message = restaurantsDTO.Any() ?
                    "Lista do(s) Restaurante(s) obtida com sucesso." :
                    "Nenhum Restaurante encontrado.";
                _response.Data = restaurantsDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível adquirir a lista do(s) Restaurante(s)!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id:int}", Name = "GetRestaurant")]
        public async Task<ActionResult<RestaurantDTO>> GetById(int id)
        {
            try
            {
                var restaurantDTO = await _restaurantService.GetById(id);
                if (restaurantDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Restaurante não encontrado!";
                    _response.Data = restaurantDTO;
                    return NotFound(_response);
                };

                _response.SetSuccess();
                _response.Message = "Restaurante " + restaurantDTO.NameRestaurant + " obtido com sucesso.";
                _response.Data = restaurantDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível adquirir o Restaurante informado!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] RestaurantDTO restaurantDTO)
        {
            if (restaurantDTO is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado(s) inválido(s)!";
                _response.Data = restaurantDTO;
                return BadRequest(_response);
            }
            restaurantDTO.Id = 0;

            try
            {
                await _restaurantService.Create(restaurantDTO);

                _response.SetSuccess();
                _response.Message = "Restaurante " + restaurantDTO.NameRestaurant + " cadastrado com sucesso.";
                _response.Data = restaurantDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível cadastrar o Restaurante!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut()]
        public async Task<ActionResult> Update([FromBody] RestaurantDTO restaurantDTO)
        {
            if (restaurantDTO is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado(s) inválido(s)!";
                _response.Data = restaurantDTO;
                return BadRequest(_response);
            }

            try
            {
                var existingRestaurantDTO = await _restaurantService.GetById(restaurantDTO.Id);
                if (existingRestaurantDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = new { errorId = "O Restaurante informado não existe!" };
                    return NotFound(_response);
                }

                await _restaurantService.Update(restaurantDTO);

                _response.SetSuccess();
                _response.Message = "Restaurante " + restaurantDTO.NameRestaurant + " alterado com sucesso.";
                _response.Data = restaurantDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível alterar o Restaurante!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<RestaurantDTO>> Delete(int id)
        {
            try
            {
                var restaurantDTO = await _restaurantService.GetById(id);
                if (restaurantDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado com conflito!";
                    _response.Data = new { errorId = "Restaurante não encontrado!" };
                    return NotFound(_response);
                }

                await _restaurantService.Delete(id);

                _response.SetSuccess();
                _response.Message = "Restaurante " + restaurantDTO.NameRestaurant + " excluído com sucesso.";
                _response.Data = restaurantDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível excluir o Restaurante!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}