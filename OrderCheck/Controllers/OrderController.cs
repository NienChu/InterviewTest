using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderCheck.Data;
using OrderCheck.Model;
using OrderCheck.Model.DataModel;
using OrderCheck.Model.Enum;
using OrderCheck.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderCheck.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : Controller {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// 取得訂單列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<OrderViewModel>>> GetUserOrders() {
            try {
                var user = await _userManager.GetUserAsync(User);

                // get order list and related order items info
                var result = await _context.Orders
                    .Include(o => o.OrderItems)
                        .ThenInclude(i => i.Product)
                    .Where(o => o.OwnerId.Equals(user.Id))
                    .Select(o => new OrderViewModel {
                        Id = o.Id,
                        Status = o.Status,
                        Cost = o.OrderItems.Sum(i => i.Cost),
                        OrderId = o.OrderId,
                        Price = o.OrderItems.Sum(i => i.Product.Price),
                        Items = o.OrderItems.Select(i => new OrderItemViewModel {
                            Id = i.Id,
                            ProductId = i.ProductId,
                            Name = i.Product.Name
                        }).ToList()
                    })
                    .ToListAsync();
                return result;
            } catch (Exception) {
                return BadRequest(new ErrorResponse("取得訂單發生錯誤"));
            }
        }

        /// <summary>
        /// 變更訂單狀態
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateOrderStatus(OrderUpdateViewModel model) {
            try {
                var orders = _context.Orders
                        .Where(o => model.OrderIds.Contains(o.Id));

                // todo: verify other status changes
                if (model.Status == OrderStatus.ToBeShipped
                    && orders.Any(o => o.Status != OrderStatus.PaymentCompleted)) {
                    return BadRequest(new ErrorResponse("變更訂單狀拒絕"));
                }

                using (var transaction = _context.Database.BeginTransaction()) {
                    // modify order status
                    foreach (Order order in orders) {
                        order.Status = model.Status;
                    }

                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }

                return Ok();
            } catch (Exception) {
                return BadRequest(new ErrorResponse("變更訂單狀態發生錯誤"));
            }
        }
    }
}
