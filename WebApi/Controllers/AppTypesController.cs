using AutoMapper;
using DataLayer.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppTypesController : ControllerBase
    {

        IMapper _mapper;
        AppDbContext _context;

        public AppTypesController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBookTypes()
        {
           
            var types = _mapper.Map<TypeResponse[]>(Enum.GetValues<BookType>());

            return Ok(types);
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var types = _mapper.Map<TypeResponse[]>(Enum.GetValues<City>());

            return Ok(types);
        }

        [HttpGet]
        public IActionResult GetStates()
        {
            var types = _mapper.Map<TypeResponse[]>(Enum.GetValues<State>());

            return Ok(types);
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var types = _mapper.Map<TypeResponse[]>(Enum.GetValues<Country>());

            return Ok(types);
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            var types = _mapper.Map<TypeResponse[]>(_context.Publishers.ToArray());

            return Ok(types);
        }
    }
}
