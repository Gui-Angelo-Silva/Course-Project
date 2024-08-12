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
    public class ReservationController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITableService _tableService;
        private readonly IReservationService _reservationService;
        private readonly Response _response;

        public ReservationController(IUserService userService, ITableService tableService, IReservationService reservationService)
        {
            _userService = userService;
            _tableService = tableService;
            _reservationService = reservationService;

            _response = new Response();
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetAll()
        {
            try
            {
                var reservationsDTO = await _reservationService.GetAll();
                _response.SetSuccess();
                _response.Message = reservationsDTO.Any() ?
                    "Lista da(s) Reserva(s) obtida com sucesso." :
                    "Nenhuma Reserva encontrada.";
                _response.Data = reservationsDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível adquirir a lista da(s) Reserva(s)!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id:int}", Name = "GetReservation")]
        public async Task<ActionResult<ReservationDTO>> GetById(int id)
        {
            try
            {
                var reservationDTO = await _reservationService.GetById(id);
                if (reservationDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Reserva não encontrada!";
                    _response.Data = reservationDTO;
                    return NotFound(_response);
                };

                _response.SetSuccess();
                _response.Message = "Reserva para " + reservationDTO.DateReservation + " obtida com sucesso.";
                _response.Data = reservationDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível adquirir a Reserva informada!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] ReservationDTO reservationDTO)
        {
            if (reservationDTO is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado(s) inválido(s)!";
                _response.Data = reservationDTO;
                return BadRequest(_response);
            }
            reservationDTO.Id = 0;

            try
            {
                var userDTO = await _userService.GetById(reservationDTO.IdUser);
                if (userDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = new { errorIdUser = "O Usuário informado não existe!" };
                    return NotFound(_response);
                }

                dynamic errors = new ExpandoObject();
                var hasErrors = false;

                var tableDTO = await _tableService.GetById(reservationDTO.IdTable);
                CheckDatas(tableDTO, reservationDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                await _reservationService.Create(reservationDTO);

                _response.SetSuccess();
                _response.Message = "Reserva para " + reservationDTO.DateReservation + " cadastrada com sucesso.";
                _response.Data = reservationDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível cadastrar a Reserva!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] ReservationDTO reservationDTO)
        {
            if (reservationDTO is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado(s) inválido(s)!";
                _response.Data = reservationDTO;
                return BadRequest(_response);
            }

            try
            {
                var existingReservationDTO = await _reservationService.GetById(reservationDTO.Id);
                if (existingReservationDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = new { errorId = "A Reserva informada não existe!" };
                    return NotFound(_response);
                }

                var userDTO = await _userService.GetById(reservationDTO.IdUser);
                if (userDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = new { errorIdUser = "O Usuário informado não existe!" };
                    return NotFound(_response);
                }

                dynamic errors = new ExpandoObject();
                var hasErrors = false;

                var tableDTO = await _tableService.GetById(reservationDTO.IdTable);
                CheckDatas(tableDTO, reservationDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                await _reservationService.Update(reservationDTO);

                _response.SetSuccess();
                _response.Message = "Reserva para " + reservationDTO.DateReservation + " alterada com sucesso.";
                _response.Data = reservationDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível alterar a Reserva!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ReservationDTO>> Delete(int id)
        {
            try
            {
                var reservationDTO = await _reservationService.GetById(id);
                if (reservationDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado com conflito!";
                    _response.Data = new { errorId = "Reserva não encontrada!" };
                    return NotFound(_response);
                }

                await _reservationService.Delete(id);

                _response.SetSuccess();
                _response.Message = "Reserva para " + reservationDTO.DateReservation + " excluída com sucesso.";
                _response.Data = reservationDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível excluir a Reserva!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        private static void CheckDatas(TableDTO table, ReservationDTO reservationDTO, ref dynamic errors, ref bool hasErrors)
        {
            if (table.ReservedTable)
            {
                errors.errorIdTable = "A Mesa " + table.CodeTable + " já está reservada!";
                hasErrors = true;
            }
        }
    }
}