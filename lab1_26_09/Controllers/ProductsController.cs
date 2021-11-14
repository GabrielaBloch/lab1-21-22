using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1_26_09.Database;
using lab1_26_09.Entities;
using lab1_26_09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab1_26_09.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ProductsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(ProductModel product)
        {
            var entity = new ProductEntity
            {
                Name = product.Name,
                Description = product.Description,
                IsVisible = product.IsVisible,
            };
            await _dbContext .AddAsync(entity);
            await _dbContext .SaveChangesAsync ();

            var viewModel = new ProductStatsViewModel
            {
                NameLength = product.Name.Length,
                DescriptionLength = product.Description.Length,

            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List(string name)
        {
            IQueryable<ProductEntity> productsQuery = _dbContext.Products;
            if (!string.IsNullOrEmpty(name))
            {
                productsQuery = productsQuery.Where(x => x.Name.Contains(name));
            }
            var products = await _dbContext.Products.ToListAsync();
            return View(products);
        }
    }
}
