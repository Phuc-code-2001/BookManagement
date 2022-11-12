using AutoMapper;
using DataLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi.DTOs;
using WebApi.Models.Books;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase, IAPIController<CreateBook, UpdateBook>
    {

        IMapper _mapper;
        AppDbContext _context;

        public BooksController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateBook createModel)
        {
            try
            {
                Book book = _mapper.Map<Book>(createModel);

                _context.Books.Add(book);
                _context.SaveChanges();

                book = _context.Books.Include(b => b.Publisher).FirstOrDefault(b => b.Id == book.Id);
                BookDTO bookDTO = _mapper.Map<BookDTO>(book);

                return Ok(bookDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Id)
        {
            try
            {
                Book book = _context.Books.Find(Id);
                if (book == null) return NotFound("Book not found!");

                _context.Books.Remove(book);
                _context.SaveChanges();


                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                Book book = _context.Books.Include(b => b.Publisher).FirstOrDefault(b => b.Id == Id);
                if (book == null) return NotFound("Book not found!");

                BookDTO bookDTO = _mapper.Map<BookDTO>(book);

                return Ok(bookDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Search")]
        public IActionResult Search(string search)
        {
            try
            {
                IQueryable<Book> queries = _context.Books.Include(b => b.Publisher);
                if(search != null)
                {
                    bool isDecimal = decimal.TryParse(search, out var price);
                    queries = queries.Where(b => b.Title.Contains(search) || (isDecimal && b.Price == price));
                }

                Book[] dataset = queries.ToArray();
                BookDTO[] bookDTOs = _mapper.Map<BookDTO[]>(dataset);

                return Ok(bookDTOs);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetAll()
        {
            try
            {
                IQueryable<Book> queries = _context.Books.Include(b => b.Publisher);
                Book[] dataset = queries.ToArray();
                BookDTO[] bookDTOs = _mapper.Map<BookDTO[]>(dataset);

                return Ok(bookDTOs);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(UpdateBook updateModel)
        {
            try
            {
                var book = _context.Books
                    .FirstOrDefault(u => u.Id == updateModel.Id);

                if (book == null) return NotFound("User not found!");

                _mapper.Map<UpdateBook, Book>(updateModel, book);

                _context.Books.Update(book);
                _context.SaveChanges();

                book = _context.Books
                    .Include(b => b.Publisher)
                    .FirstOrDefault(b => b.Id == updateModel.Id);

                BookDTO bookDTO = _mapper.Map<BookDTO>(book);
                return Ok(bookDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
