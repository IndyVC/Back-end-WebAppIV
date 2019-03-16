using ElectricApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ElectricApi.Controllers {
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CarsController : ControllerBase {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;

        public CarsController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ICustomerRepository customerRepository, ICarRepository carRepository) {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._carRepository = carRepository;
            this._customerRepository = customerRepository;
        }

        ///GET: api/Cars
        /// <summary>
        /// Get all cars ordered by model name.
        /// </summary>
        /// <returns>array of cars</returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Car> GetCars() {
            return _carRepository.GetAllCars().OrderBy(r => r.Model);
        }



    }
}