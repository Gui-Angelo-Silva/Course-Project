using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.Objects.DTOs.Entities;
using System.Dynamic;
using backend.Objects.Server;
using backend.Services.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using backend.Objects.Utilities;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ITableService _tableService;
        private readonly Response _response;

        public TableController(IRestaurantService restaurantService, ITableService tableService)
        {
            _restaurantService = restaurantService;
            _tableService = tableService;

            _response = new Response();
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TableDTO>>> GetAll()
        {
            try
            {
                var tablesDTO = await _tableService.GetAll();
                _response.SetSuccess();
                _response.Message = tablesDTO.Any() ?
                    "Lista da(s) Mesa(s) obtida com sucesso." :
                    "Nenhuma Mesa encontrada.";
                _response.Data = tablesDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível adquirir a lista da(s) Mesa(s)!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id:int}", Name = "GetTable")]
        public async Task<ActionResult<TableDTO>> GetById(int id)
        {
            try
            {
                var tableDTO = await _tableService.GetById(id);
                if (tableDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Mesa não encontrada!";
                    _response.Data = tableDTO;
                    return NotFound(_response);
                };

                _response.SetSuccess();
                _response.Message = "Mesa " + tableDTO.CodeTable + " obtida com sucesso.";
                _response.Data = tableDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível adquirir a Mesa informada!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] TableDTO tableDTO)
        {
            if (tableDTO is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado(s) inválido(s)!";
                _response.Data = tableDTO;
                return BadRequest(_response);
            }
            tableDTO.Id = 0;

            try
            {
                var restaurantDTO = await _restaurantService.GetById(tableDTO.IdRestaurant);
                if (restaurantDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "O Restaurante informado não existe!";
                    _response.Data = new { errorIdRestaurant = "O Restaurante informado não existe!" };
                    return NotFound(_response);
                }

                dynamic errors = new ExpandoObject();
                var hasErrors = false;

                var tablesDTO = await _tableService.GetTablesRelatedRestaurant(tableDTO.IdRestaurant);
                CheckDuplicates(tablesDTO, tableDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                await _tableService.Create(tableDTO);

                _response.SetSuccess();
                _response.Message = "Mesa" + tableDTO.CodeTable + " cadastrada com sucesso.";
                _response.Data = tableDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível cadastrar a Mesa!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] TableDTO tableDTO)
        {
            if (tableDTO is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado(s) inválido(s)!";
                _response.Data = tableDTO;
                return BadRequest(_response);
            }

            try
            {
                var existingTableDTO = await _tableService.GetById(tableDTO.Id);
                if (existingTableDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = new { errorId = "A Mesa informada não existe!" };
                    return NotFound(_response);
                }

                var restaurantDTO = await _restaurantService.GetById(tableDTO.IdRestaurant);
                if (restaurantDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "O Restaurante informado não existe!";
                    _response.Data = new { errorIdRestaurant = "O Restaurante informado não existe!" };
                    return NotFound(_response);
                }

                dynamic errors = new ExpandoObject();
                var hasErrors = false;

                CheckDatas(tableDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                var tablesDTO = await _tableService.GetTablesRelatedRestaurant(tableDTO.IdRestaurant);
                CheckDuplicates(tablesDTO, tableDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                await _tableService.Update(tableDTO);

                _response.SetSuccess();
                _response.Message = "Mesa " + tableDTO.CodeTable + " alterada com sucesso.";
                _response.Data = tableDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível alterar a Mesa!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TableDTO>> Delete(int id)
        {
            try
            {
                var tableDTO = await _tableService.GetById(id);
                if (tableDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado com conflito!";
                    _response.Data = new { errorId = "TMesa não encontrada!" };
                    return NotFound(_response);
                }

                await _tableService.Delete(id);

                _response.SetSuccess();
                _response.Message = "Mesa " + tableDTO.CodeTable + " excluída com sucesso.";
                _response.Data = tableDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível excluir a Mesa!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        private static void CheckDatas(TableDTO tableDTO, ref dynamic errors, ref bool hasErrors)
        {
            if (tableDTO.CapacityPersons >= 100)
            {
                errors.errorCapacityPersons = "Não é possível uma Mesa possuir capacidade para mais de 100 pessoas!";
                hasErrors = true;
            }

            if ((double)tableDTO.ValueTable >= 100000.0)
            {
                errors.errorValueTable = "A taxa por hora reservada não pode ser superior a R$ 100.000,00!";
                hasErrors = true;
            }
        }

        private static void CheckDuplicates(IEnumerable<TableDTO> tablesDTO, TableDTO tableDTO, ref dynamic errors, ref bool hasErrors)
        {
            foreach (var table in tablesDTO)
            {
                if (tableDTO.Id == table.Id)
                {
                    continue;
                }

                if (Operator.CompareString(tableDTO.CodeTable, table.CodeTable))
                {
                    errors.errorNomeEstado = "Já existe a Mesa " + tableDTO.CodeTable + "!";
                    hasErrors = true;

                    break;
                }
            }
        }
    }
}