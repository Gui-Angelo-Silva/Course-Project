using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.Objects.DTOs.Entities;
using backend.Objects.Server;
using backend.Objects.Utilities;
using System.Dynamic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly Response _response;

        public UserController(IUserService userService)
        {
            _userService = userService;

            _response = new Response();
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            try
            {
                var usersDTO = await _userService.GetAll();
                _response.SetSuccess();
                _response.Message = usersDTO.Any() ?
                    "Lista do(s) Usuário(s) obtida com sucesso." :
                    "Nenhum Usuário encontrado.";
                _response.Data = usersDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível adquirir a lista do(s) Usuário(s)!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            try
            {
                var userDTO = await _userService.GetById(id);
                if (userDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Usuário não encontrado!";
                    _response.Data = userDTO;
                    return NotFound(_response);
                };

                _response.SetSuccess();
                _response.Message = "Usuário " + userDTO.NameUser + " obtido com sucesso.";
                _response.Data = userDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível adquirir o Usuário informado!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] UserDTO userDTO)
        {
            if (userDTO is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado(s) inválido(s)!";
                _response.Data = userDTO;
                return BadRequest(_response);
            }
            userDTO.Id = 0;

            try
            {
                dynamic errors = new ExpandoObject();
                var hasErrors = false;

                CheckDatas(userDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                var usersDTO = await _userService.GetAll();
                CheckDuplicates(usersDTO, userDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                await _userService.Create(userDTO);

                _response.SetSuccess();
                _response.Message = "Usuário " + userDTO.NameUser + " cadastrado com sucesso.";
                _response.Data = userDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível cadastrar o Usuário!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost()]
        public async Task<ActionResult> Login([FromBody] Login login)
        {
            if (login is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado(s) inválido(s)!";
                _response.Data = login;
                return BadRequest(_response);
            }

            try
            {
                var userDTO = await _userService.Login(login);
                if (userDTO is null)
                {
                    _response.SetUnauthorized();
                    _response.Message = "Login inválido!";
                    _response.Data = new { errorLogin = "Login inválido!" };
                    return BadRequest(_response);
                }

                var token = new Token(); 
                token.GenerateToken(userDTO.EmailUser);

                _response.SetSuccess();
                _response.Message = "Login realizado com sucesso.";
                _response.Data = token;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível realizar o Login!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost()]
        public async Task<ActionResult> Validate([FromBody] Token token)
        {
            if (token is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado inválido!";
                _response.Data = token;
                return BadRequest(_response);
            }

            try
            {
                if (!token.ValidateToken())
                {
                    _response.SetUnauthorized();
                    _response.Message = "Token inválido!";
                    _response.Data = new { errorToken = "Token inválido!" };
                    return BadRequest(_response);
                }

                _response.SetSuccess();
                _response.Message = "Token validado com sucesso.";
                _response.Data = token;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível validar o Token!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }


        [HttpPut()]
        public async Task<ActionResult> Update([FromBody] UserDTO userDTO)
        {
            if (userDTO is null)
            {
                _response.SetInvalid();
                _response.Message = "Dado(s) inválido(s)!";
                _response.Data = userDTO;
                return BadRequest(_response);
            }

            try
            {
                var existingUserDTO = await _userService.GetById(userDTO.Id);
                if (existingUserDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = new { errorId = "O Usuário informado não existe!" };
                    return NotFound(_response);
                }

                dynamic errors = new ExpandoObject();
                var hasErrors = false;

                CheckDatas(userDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                var usersDTO = await _userService.GetAll();
                CheckDuplicates(usersDTO, userDTO, ref errors, ref hasErrors);

                if (hasErrors)
                {
                    _response.SetConflict();
                    _response.Message = "Dado(s) com conflito!";
                    _response.Data = errors;
                    return BadRequest(_response);
                }

                await _userService.Update(userDTO);

                _response.SetSuccess();
                _response.Message = "Usuário " + userDTO.NameUser + " alterado com sucesso.";
                _response.Data = userDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível alterar o Usuário!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            try
            {
                var userDTO = await _userService.GetById(id);
                if (userDTO is null)
                {
                    _response.SetNotFound();
                    _response.Message = "Dado com conflito!";
                    _response.Data = new { errorId = "Usuário não encontrado!" };
                    return NotFound(_response);
                }

                await _userService.Delete(id);

                _response.SetSuccess();
                _response.Message = "Usuário " + userDTO.NameUser + " excluído com sucesso.";
                _response.Data = userDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetError();
                _response.Message = "Não foi possível excluir o Usuário!";
                _response.Data = new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace ?? "No stack trace available!" };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        private static void CheckDatas(UserDTO userDTO, ref dynamic errors, ref bool hasErrors)
        {
            if (!userDTO.CheckValidPhone())
            {
                errors.errorPhoneUser = "Número inválido!";
                hasErrors = true;
            }

            int status = userDTO.CheckValidEmail();
            if (status == -1)
            {
                errors.errorEmailUser = "E-mail inválido!";
                hasErrors = true;
            }
            else if (status == -2)
            {
                errors.errorEmailUser = "Domínio inválido!";
                hasErrors = true;
            }
        }

        private static void CheckDuplicates(IEnumerable<UserDTO> usersDTO, UserDTO userDTO, ref dynamic errors, ref bool hasErrors)
        {
            foreach (var user in usersDTO)
            {
                if (userDTO.Id == user.Id)
                {
                    continue;
                }

                if (Operator.CompareString(userDTO.EmailUser, user.EmailUser))
                {
                    errors.errorEmailUser = "O e-mail " + userDTO.EmailUser + " já está sendo utilizado!";
                    hasErrors = true;

                    break;
                }
            }
        }
    }
}