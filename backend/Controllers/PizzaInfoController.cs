using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;
using backend.Data;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaInfoController : ControllerBase
    {
        // private static readonly PizzaInfo[] TheMenu = new[]
        // {
        //     new PizzaInfo { PizzaName = "The Mighty Meatball", Ingredients = "Meatballs and cheese", Cost = 40, InStock = "yes"},
        //     new PizzaInfo { PizzaName = "Crab Apple", Ingredients = "Dungeness crab and apples", Cost = 35, InStock = "no"},
        //     new PizzaInfo { PizzaName = "Forest Floor", Ingredients = "Mushrooms, rutabagas, and walnuts", Cost = 20, InStock = "yes"},
        //     new PizzaInfo { PizzaName = "Don't At Me", Ingredients = "Pineapple, Canadian bacon, jalapeños", Cost = 25, InStock = "yes"},
        //     new PizzaInfo { PizzaName = "Vanilla", Ingredients = "Sausage and pepperoni", Cost = 15, InStock = "no"},
        //     new PizzaInfo { PizzaName = "Spice Coming At Ya", Ingredients = "Peppers, chili sauce, spicy andouille", Cost = 50, InStock = "yes"}
        // };
        private readonly ILogger<PizzaInfoController> _logger;
        private IPizzaRepo _pizzaRepo;

        public PizzaInfoController(ILogger<PizzaInfoController> logger,
            IPizzaRepo pizzaRepo)
        {
            _logger = logger;
            _pizzaRepo = pizzaRepo;
        }

        [HttpGet]
        public IEnumerable<PizzaDetail> Get()
        {
            return _pizzaRepo.GetAllPizzas();
        }
    }
}
