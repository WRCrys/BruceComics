using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevCa.Api.ViewModels;
using DevCA.Business.Interfaces;
using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Interfaces.Service;
using DevCA.Business.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevCa.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IUserService _service;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        
        public UserController(INotificator notificator, IUserService service, IUserRepository repository, IMapper mapper) : base(notificator)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(await _repository.GetAll());
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<UserViewModel>> GetById(long id)
        {
            var user = await GetEntityById(id);

            if (user == null) return NotFound();

            return user;
        }


        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                NotifyError("Sorry! The ids aren't equals!");
                return CustomResponse();
            }
            
            var user = await GetEntityById(id);

            user.Email = userViewModel.Email;
            user.Password = userViewModel.Password;
            user.Administrator = userViewModel.Administrator;

            await _service.Update(_mapper.Map<User>(user));

            return CustomResponse(user);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<UserViewModel>> Remove(long id)
        {
            var user = await GetEntityById(id);

            if (user == null) return NotFound();

            await _service.Remove(id);

            return CustomResponse(user);
        }

        public override async Task<UserViewModel> GetEntityById(long id)
        {
            return _mapper.Map<UserViewModel>(await _repository.GetById(id));
        }
    }
}