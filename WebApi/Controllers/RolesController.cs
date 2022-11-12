using DataLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase, IAPIController<AppRole, AppRole>
    {
        AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [EnableQuery]
        public IActionResult GetAll()
        {
            try
            {
                var roles = _context.Roles.ToList();
                return Ok(roles);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Get(int Id)
        {
            try
            {
                var role = _context.Roles.Find(Id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(AppRole role)
        {
            try
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(AppRole role)
        {
            try
            {
                var entity = _context.Roles.Find(role.Id);

                if(entity != null)
                {
                    _context.Roles.Update(role);
                    _context.SaveChanges();
                    return Ok(role);
                }

                return NotFound("Role not found!");
            }
            catch (Exception ex)
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
                var entity = _context.Roles.Find(Id);

                if (entity != null)
                {
                    _context.Roles.Remove(entity);
                    _context.SaveChanges();
                    return Ok();
                }

                return NotFound("Role not found!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
