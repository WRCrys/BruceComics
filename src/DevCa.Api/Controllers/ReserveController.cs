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
    public class ReserveController : MainController
    {
        private readonly IReserveService _service;
        private readonly IReserveRepository _repository;
        private readonly IMapper _mapper;
        
        public ReserveController(INotificator notificator, IReserveService service, IReserveRepository repository, IMapper mapper) : base(notificator)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ReserveViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ReserveViewModel>>(await _repository.GetAll());
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ReserveViewModel>> GetById(long id)
        {
            var reserve = await GetEntityById(id);

            if (reserve == null) return NotFound();

            return reserve;
        }
        
        [HttpPost]
        public async Task<ActionResult<ReserveViewModel>> Add(ReserveViewModel reserveViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Add(_mapper.Map<Reserve>(reserveViewModel));

            return CustomResponse(reserveViewModel);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, ReserveViewModel reserveViewModel)
        {
            if (id != reserveViewModel.Id)
            {
                NotifyError("Sorry! The ids aren't equals!");
                return CustomResponse();
            }
            
            var reserve = await GetEntityById(id);

            reserve.Returned = reserveViewModel.Returned;

            await _service.Update(_mapper.Map<Reserve>(reserve));

            return CustomResponse(reserve);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ReserveViewModel>> Remove(long id)
        {
            var reserve = await GetEntityById(id);

            if (reserve == null) return NotFound();

            await _service.Remove(id);

            return CustomResponse(reserve);
        }

        public override async Task<ReserveViewModel> GetEntityById(long id)
        {
            return _mapper.Map<ReserveViewModel>(await _repository.GetById(id));
        }
    }
}