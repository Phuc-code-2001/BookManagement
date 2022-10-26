using AutoMapper;
using DataLayer.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase, IAPIController<Publisher, Publisher>
    {
        IMapper _mapper;
        AppDbContext _context;

        public PublishersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(Publisher createModel)
        {
            try
            {
                _context.Publishers.Add(createModel);
                _context.SaveChanges();

                PublisherDTO pDTO = _mapper.Map<PublisherDTO>(createModel);

                return Ok(pDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                Publisher entity = _context.Publishers.Find(Id);

                _context.Publishers.Remove(entity);
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
                Publisher entity = _context.Publishers.Find(Id);
                if (entity == null) return NotFound("Publisher not found!");

                PublisherDTO pDTO = _mapper.Map<PublisherDTO>(entity);
                return Ok(pDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var items = _mapper.Map<PublisherDTO[]>(_context.Publishers.ToArray());

                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Publisher updateModel)
        {
            try
            {
                Publisher entity = _context.Publishers.Find(updateModel.Id);
                if (entity == null) return NotFound("Publisher not found!");

                _context.Publishers.Update(entity);
                _context.SaveChanges();

                PublisherDTO pDTO = _mapper.Map<PublisherDTO>(entity);

                return Ok(pDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
