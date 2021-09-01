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
    public class BookGenderController : MainController
    {
        private readonly IBookGenderService _service;
        private readonly IBookGenderRepository _repository;
        private readonly IMapper _mapper;
        
        public BookGenderController(INotificator notificator, IBookGenderService service, IBookGenderRepository repository, IMapper mapper) : base(notificator)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookGenderViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<BookGenderViewModel>>(await _repository.GetAll());
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<BookGenderViewModel>> GetById(long id)
        {
            var bookGender = await GetEntityById(id);

            if (bookGender == null) return NotFound();

            return bookGender;
        }

        [HttpPost]
        public async Task<ActionResult<BookViewModel>> Add(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Add(_mapper.Map<BookGender>(bookViewModel));

            return CustomResponse();
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, BookGenderViewModel bookGenderViewModel)
        {
            if (id != bookGenderViewModel.Id)
            {
                NotifyError("Sorry! The ids aren't equals!");
                return CustomResponse();
            }

            var bookGender = await GetEntityById(id);

            bookGender.Name = bookGenderViewModel.Name;

            await _service.Update(_mapper.Map<BookGender>(bookGender));

            return CustomResponse(bookGender);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<BookGenderViewModel>> Remove(long id)
        {
            var bookGender = await GetEntityById(id);

            if (bookGender == null) return NotFound();

            await _service.Remove(id);

            return CustomResponse(bookGender);
        }

        public override async Task<BookGenderViewModel> GetEntityById(long id)
        {
            return _mapper.Map<BookGenderViewModel>(await _repository.GetById(id));
        }
    }
}