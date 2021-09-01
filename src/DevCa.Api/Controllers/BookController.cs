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
    public class BookController : MainController
    {
        private readonly IBookService _service;
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookController(INotificator notificator, IBookService service, IBookRepository repository, IMapper mapper) : base(notificator)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<BookViewModel>>(await _repository.GetAll());
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<BookViewModel>> GetById(long id)
        {
            var book = await GetEntityById(id);

            if (book == null) return NotFound();

            return book;
        }
        
        [HttpPost]
        public async Task<ActionResult<BookViewModel>> Add(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Add(_mapper.Map<Book>(bookViewModel));

            return CustomResponse(bookViewModel);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, BookViewModel bookViewModel)
        {
            if (id != bookViewModel.Id)
            {
                NotifyError("Sorry! The ids aren't equals!");
                return CustomResponse();
            }
            
            var book = await GetEntityById(id);

            book.Name = bookViewModel.Name;
            book.Synopsis = bookViewModel.Synopsis;

            await _service.Update(_mapper.Map<Book>(book));

            return CustomResponse(book);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<BookViewModel>> Remove(long id)
        {
            var book = await GetEntityById(id);

            if (book == null) return NotFound();

            await _service.Remove(id);

            return CustomResponse(book);
        }

        public override async Task<BookViewModel> GetEntityById(long id)
        {
            return _mapper.Map<BookViewModel>(await _repository.GetById(id));
        }
    }
}