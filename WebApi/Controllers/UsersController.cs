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
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase, IAPIController<CreateAppUser, UpdateAppUser>
    {
        IMapper _mapper;
        AppDbContext _context;

        public UsersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateAppUser createModel)
        {
            try
            {
                if(_context.Users.Any(u => u.Email == createModel.Email))
				{
                    return BadRequest("Email already have account!");
				}

                AppUser appUser = _mapper.Map<AppUser>(createModel);
                _context.Users.Add(appUser);
                _context.SaveChanges();

                var user = _context.Users
                    .Include(u => u.Publisher)
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Id == appUser.Id);

                AppUserDTO uDTO = _mapper.Map<AppUserDTO>(user);

                return Ok(uDTO);
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
                var user = _context.Users
                    .Include(u => u.Publisher)
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Id == Id);

                if (user == null) return NotFound("User not found!");

                _context.Users.Remove(user);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{Id}")]
        [Authorize]
        public IActionResult Get(int Id)
        {
            try
            {
                var user = _context.Users
                    .Include(u => u.Publisher)
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Id == Id);

                if (user == null) return NotFound("User not found!");

                AppUserDTO uDTO = _mapper.Map<AppUserDTO>(user);

                return Ok(uDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [EnableQuery]
        public IActionResult GetAll()
        {
            try
            {
                var users = _context.Users
                    .Include(u => u.Publisher)
                    .Include(u => u.Role)
                    .ToArray();

                var items = _mapper.Map<AppUserDTO[]>(users);
                
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(UpdateAppUser updateModel)
        {
            try
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Id == updateModel.Id);

                if (user == null) return NotFound("User not found!");

                _mapper.Map<UpdateAppUser, AppUser>(updateModel, user);

                _context.Users.Update(user);
                _context.SaveChanges();

                user = _context.Users
                    .Include(u => u.Publisher)
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Id == updateModel.Id);

                AppUserDTO uDTO = _mapper.Map<AppUserDTO>(user);
                return Ok(uDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
