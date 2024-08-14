using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.Objects.DTOs.Entities;
using System.Dynamic;
using backend.Objects.Server;
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

        [HttpGet("GetAll")]
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

        [HttpGet("GetById/{id:int}")]
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

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] ReservationDTO reservationDTO)
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

                var tableDTO = await _tableService.GetById(reservationDTO.IdTable);
                if (tableDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = new { errorIdTable = "A Mesa informada não existe!" };
                    return NotFound(_response);
                }

                dynamic errors = new ExpandoObject();
                var hasErrors = false;

                var reservationsRelatedTableDTO = await _reservationService.GetReservationsRelatedTable(reservationDTO.IdTable);
                CheckDatas(tableDTO, reservationsRelatedTableDTO, reservationDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                var reservationsRelatedUserDTO = await _reservationService.GetReservationsRelatedUser(reservationDTO.IdUser);
                CheckDuplicates(reservationsRelatedUserDTO, reservationDTO, ref errors, ref hasErrors);

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

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] ReservationDTO reservationDTO)
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

                var tableDTO = await _tableService.GetById(reservationDTO.IdTable);
                if (tableDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = new { errorIdTable = "A Mesa informada não existe!" };
                    return NotFound(_response);
                }

                dynamic errors = new ExpandoObject();
                var hasErrors = false;

                var reservationsRelatedTableDTO = await _reservationService.GetReservationsRelatedTable(reservationDTO.IdTable);
                CheckDatas(tableDTO, reservationsRelatedTableDTO, reservationDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                var reservationsRelatedUserDTO = await _reservationService.GetReservationsRelatedUser(reservationDTO.IdUser);
                CheckDuplicates(reservationsRelatedUserDTO, reservationDTO, ref errors, ref hasErrors);

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

        [HttpDelete("Delete/{id:int}")]
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

                await _reservationService.Delete(reservationDTO);

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

        private static void CheckDatas(TableDTO table, IEnumerable<ReservationDTO> reservationsDTO, ReservationDTO reservationDTO, ref dynamic errors, ref bool hasErrors)
        {
            if (!table.AvailableTable)
            {
                errors.errorIdTable = "A Mesa " + table.CodeTable + " está indisponível para reserva!";
                hasErrors = true;
            }

            reservationDTO = reservationsDTO.FirstOrDefault(reservation => reservation.IdUser != reservationDTO.IdUser && Operator.CompareString(reservationDTO.DateReservation, reservation.DateReservation));
            if (reservationDTO is not null)
            {
                errors.errorIdTable = "A Mesa " + table.CodeTable + " está reservada!";
                hasErrors = true;
            }
        }

        private static void CheckDuplicates(IEnumerable<ReservationDTO> reservationsDTO, ReservationDTO reservationDTO, ref dynamic errors, ref bool hasErrors)
        {
            foreach (var reservation in reservationsDTO)
            {
                if (reservationDTO.Id == reservation.Id)
                {
                    continue;
                }

                if (reservationDTO.IdTable == reservation.IdTable && Operator.CompareString(reservationDTO.DateReservation, reservation.DateReservation))
                {
                    errors.errorDateReservation = "Você já reservou a Mesa para " + reservationDTO.DateReservation + "!";
                    hasErrors = true;

                    break;
                }
            }
        }
    }
}