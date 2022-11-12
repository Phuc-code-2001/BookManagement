using AutoMapper;
using DataLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Linq;
using WebApi.DTOs;
using WebApi.Models.Authors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase, IAPIController<CreateAuthor, UpdateAuthor>
    {
        IMapper _mapper;
        AppDbContext _context;

        public AuthorsController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateAuthor createModel)
        {
            try
            {
                Author author = _mapper.Map<Author>(createModel);

                _context.Authors.Add(author);
                _context.SaveChanges();

                AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);

                return Ok(authorDTO);

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
                Author author = _context.Authors.Find(Id);

                if (author == null) return NotFound("Author not found!");

                _context.Authors.Remove(author);
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
                Author author = _context.Authors.Find(Id);

                if (author == null) return NotFound("Author not found!");

                AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);

                return Ok(authorDTO);

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
                Author[] dataset = _context.Authors.ToArray();

                AuthorDTO[] datasetDTO = _mapper.Map<AuthorDTO[]>(dataset);

                return Ok(datasetDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(UpdateAuthor updateModel)
        {
            try
            {
                var author = _context.Authors
                    .FirstOrDefault(auth => auth.Id == updateModel.Id);

                if (author == null) return NotFound("Author not found!");

                _mapper.Map<UpdateAuthor, Author>(updateModel, author);

                _context.Authors.Update(author);
                _context.SaveChanges();

                AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);

                return Ok(authorDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
