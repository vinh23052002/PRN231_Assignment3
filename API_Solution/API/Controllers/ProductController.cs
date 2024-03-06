using API.DTO;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyStoreContext context;
        private MapperConfiguration config;
        private IMapper mapper;
        public ProductController(MyStoreContext _context)
        {
            context = _context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        //Get all Products
        [HttpGet]
        public IActionResult Get()
        {
            List<Product> products;
            products = context.Products.Include(p => p.Category).ToList();
            if (products == null)
            {
                return NotFound(); // Response with status code: 404
            }
            List<ProductDTO> productDTOs = products.Select(p => mapper.Map<Product, ProductDTO>(p)).ToList();
            return Ok(productDTOs);
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    List<ProductDTO> products;
        //    products = context.Products.Include(p => p.Category).ProjectTo<ProductDTO>(config).ToList();
        //    if (products == null)
        //    {
        //        return NotFound(); // Response with status code: 404
        //    }
        //    return Ok(products);
        //}

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    Product product;
        //    product = context.Products.Include(p => p.Category).FirstOrDefault(p1 => p1.ProductId == id);
        //    if (product==null)
        //    {
        //        return NotFound();
        //    }
        //    ProductDTO productDTO = mapper.Map<Product, ProductDTO>(product);
        //    return Ok(productDTO);
        //}

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ProductDTO product;
            product = context.Products.Include(p => p.Category).ProjectTo<ProductDTO>(config).FirstOrDefault(p1 => p1.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("search")]
        public IActionResult Get(string name)
        {
            List<ProductDTO> products;
            products = context.Products.Include(p => p.Category).Where(p => p.ProductName.Contains(name)).ProjectTo<ProductDTO>(config).ToList();
            if (products == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //[HttpPost]
        //public IActionResult Add(ProductRequest productRequest)
        //{
        //    try
        //    {
        //        Product product = mapper.Map<ProductRequest, Product>(productRequest);
        //        context.Products.Add(product);
        //        context.SaveChanges();
        //        return Ok(product);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPut]
        public IActionResult Put(int id, Product product)
        {
            try
            {
                Product pro = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (pro == null)
                {
                    return NotFound();
                }
                context.Entry<Product>(pro).State = EntityState.Detached;
                context.Products.Update(product);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                Product pro = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (pro == null)
                {
                    return NotFound();
                }
                context.Products.Remove(pro);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
