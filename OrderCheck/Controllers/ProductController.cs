using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderCheck.Data;
using OrderCheck.Model;
using OrderCheck.Model.ViewModel;
using System;
using System.Threading.Tasks;

namespace OrderCheck.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : Controller {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context) {
            _context = context;
        }

        /// <summary>
        /// 取得商品細節
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductViewModel>> GetProductDetail(Guid id) {
            try {
                var product = await _context.Products.FindAsync(id);

                if (product == null) { 
                    return NotFound(new ErrorResponse("商品不存在"));
                }

                // get product detail
                var model = new ProductViewModel { 
                    Description = product.Description,
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Type = product.Type
                };

                return model;
            } catch (Exception) { 
                return BadRequest(new ErrorResponse("取得商品細節發生錯誤"));
            }
        }
    }
}
