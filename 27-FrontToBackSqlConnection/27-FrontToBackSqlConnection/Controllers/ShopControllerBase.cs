using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Views.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class ShopControllerBase
    {

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            List<Product> relatedProducts = await _context.Products
                .Where(p => !p.IsDeleted)
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null && pi.IsDeleted == false))
                .ToListAsync();

            DetailVM detailVM = new DetailVM
            {
                Product = product,
                RelatedProducts = relatedProducts,
            };


        }
    }
}