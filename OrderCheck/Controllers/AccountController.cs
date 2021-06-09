using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderCheck.Data;
using OrderCheck.Model;
using OrderCheck.Model.DataModel;
using OrderCheck.Model.ViewModel;
using System;
using System.Threading.Tasks;

namespace OrderCheck.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        
        public AccountController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model) {
            try {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (!await _userManager.CheckPasswordAsync(user, model.Password)) {
                    return BadRequest(new ErrorResponse("Login發生錯誤"));
                }
                await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                // todo: jwt

                return Ok();
            } catch (Exception) { 
                return BadRequest(new ErrorResponse("Login發生錯誤"));
            }
        }
    }
}
