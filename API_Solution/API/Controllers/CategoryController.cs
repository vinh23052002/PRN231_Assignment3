using API.DTO;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyStoreContext context;
        private MapperConfiguration config;
        private IMapper mapper;
        public CategoryController(MyStoreContext _context)
        {
            context = _context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Category> categories;
            categories = context.Categories.ToList();
            if (categories == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category category;
            category = context.Categories.FirstOrDefault(c=>c.CategoryId==id);
            if (category == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(category);
        }
    }
}
