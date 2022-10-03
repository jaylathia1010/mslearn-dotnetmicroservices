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
