using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCentral.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public sealed class UserController : ControllerBase
    {
        // private readonly ILoggedUserService _loggedUserService;
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /*
        public UserController(ILoggedUserService loggedUserService, IUserService userService)
        {
            _loggedUserService = loggedUserService;
            _userService = userService;
        }
        */
         
        /// <summary>
        /// Lista todos os usuários cadastrados no sistema
        /// </summary>
        /// <returns>Usuários cadastrados</returns>
        /// <response code="200">Listagem exibida com sucesso</response>
        /// <response code="401">Não autorizado. Realizar login</response>
        /// <response code="500">Não foi possível listar usuários</response> 
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult GetAll()
        {
            var users = _userService.Get();

            return Ok(users);
        }

        /// <summary>
        /// Adiciona novo usuário que terá acesso ao sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///        "name": "Mariana Tancredi"
        ///        "email": "matancredi@hotmail.com",
        ///        "senha": "senha"
        ///     }
        ///
        /// Email precisa estar em um formato válido.
        /// </remarks>
        /// <param user="user"></param>
        /// <response code="200">Usuário cadastrado com sucesso</response>
        /// <response code="400">Confira os dados de cadastro</response>
        /// <response code="500">Não foi possível cadastrar usuário</response> 
        [HttpPost]
        public IActionResult Save(User user)
        {
            bool saved = _userService.Save(user);

            if (saved)
            {
                return Ok("Usuário salvo com sucesso");
            }
            return StatusCode(500);

        }

        /// <summary>
        /// Troca a senha de um usuário dado seu e-mail e a senha nova. 
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT
        ///     {
        ///        "email": "matancredi@hotmail.com",
        ///        "senha": "nova_senha"
        ///     }
        ///
        /// </remarks>
        /// <param email="string"></param>
        /// <param senha="string"></param>
        /// <response code="200">Senha alterada com sucesso</response>
        /// <response code="500">Não foi possível alterar a senha</response> 
        [HttpPut]
        public IActionResult ChangePassword([FromBody] LoginUser user)
        {
            var users = _userService.Update(user);

            return Ok(users); 
        }
    }
}
