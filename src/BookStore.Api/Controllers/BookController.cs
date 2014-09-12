using BookStore.Domain;
using BookStore.Domain.Contracts;
using System.Collections.Generic;
using System.Web.Http;

namespace BookStore.Api.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public List<Book> Get()
        {
            return _repository.Get();
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
    }
}
