using Ecommerce.Domain.Model;
using Ecommerce.Domain.Queries.Request;
using Ecommerce.Domain.Respository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class UserController : ControllerBase
    {

        private readonly ITokenRepository _tokenRepository;

        public UserController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        [AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.HttpPost(nameof(Login))]
        public async Task<ActionResult<dynamic>> Login([Microsoft.AspNetCore.Mvc.FromBody] ObterUserRequest model)
        {
            try
            {
                var user = UserRepository.Get(model.Username, model.Password);

                if (user == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                var token = _tokenRepository.GenerateToken(user);
                user.Password = "";
                return new
                {
                    user,
                    token
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
