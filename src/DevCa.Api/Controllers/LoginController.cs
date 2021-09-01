using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevCa.Api.Extensions;
using DevCa.Api.ViewModels;
using DevCA.Business.Interfaces;
using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Interfaces.Service;
using DevCA.Business.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DevCa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : MainController
    {
        private readonly IUserService _service;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        
        public LoginController(INotificator notificator, IUserService service, IUserRepository repository, AppSettings appSettings, IMapper mapper) : base(notificator)
        {
            _service = service;
            _repository = repository;
            _appSettings = appSettings;
            _mapper = mapper;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> Auth(LoginViewModel loginViewModel)
        {
            await _service.VerifyAuth(loginViewModel.Email, loginViewModel.Password);

            return CustomResponse(GenerateJwt());
        }
        
        [HttpPost("SignUp")]
        public async Task<ActionResult<UserViewModel>> Add(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Add(_mapper.Map<User>(userViewModel));

            return CustomResponse(userViewModel);
        }
        
        private string GenerateJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor 
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidIn,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }
    }
}