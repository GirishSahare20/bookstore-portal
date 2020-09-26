using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using BookGatewayService;
using KCN.ViewModels;
using BookStore.Infastructure;

namespace BookStore.Controllers
{
    public class BookStoreController : ApiController
    {
        private IBookRepository _bookRepository;
        public BookStoreController()
        {

        }
        public BookStoreController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        [BasicAuthentication]
        [HttpPost]
        public IEnumerable<Book> Post(SearchBookViewModel oSearch)
        {
            // var books = _bookRepository.GetAllBooks().AsEnumerable();
            var books = from r in _bookRepository.GetAllBooks()
                        where
                        (r.Name == oSearch.Name || oSearch.Name.Length == 0)
                        && (r.ISBN == oSearch.ISBN || oSearch.ISBN.Length == 0)
                        && (r.Description == oSearch.Description || oSearch.Description.Length == 0)
                        && (r.Author == oSearch.Author || oSearch.Author.Length == 0)
                        select r;

            return books;
        }

        // POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}