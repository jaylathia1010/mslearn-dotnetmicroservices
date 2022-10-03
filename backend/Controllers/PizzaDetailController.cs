using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Data;
using AutoMapper;
using backend.Dtos;
using System;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaDetailController : ControllerBase
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
        private readonly ILogger<PizzaDetailController> _logger;
        private readonly IPizzaRepo _pizzaRepo;
        private readonly IMapper _mapper;

        public PizzaDetailController(ILogger<PizzaDetailController> logger,
            IPizzaRepo pizzaRepo,
            IMapper mapper)
        {
            _logger = logger;
            _pizzaRepo = pizzaRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PizzaReadDto>> GetAllPizzas()
        {
            Console.WriteLine("---> Getting Pizzas --->");

            var pizzas = _pizzaRepo.GetAllPizzas();

            return Ok(_mapper.Map<IEnumerable<PizzaReadDto>>(pizzas));
        }
    }
}
