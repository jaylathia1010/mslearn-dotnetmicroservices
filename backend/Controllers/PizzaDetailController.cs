using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Data;
using AutoMapper;
using backend.Dtos;
using System;
using backend.Models;

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

        [HttpGet("{id}", Name = "GetPizzaById")]
        public ActionResult<PizzaReadDto> GetPizzaById(int id)
        {
            var pizza = _pizzaRepo.GetPizzaById(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PizzaReadDto>(pizza));
        }

        [HttpPost]
        public ActionResult<PizzaReadDto> CreatePizza(PizzaCreateDto pizzaCreate)
        {
            var pizzaModel = _mapper.Map<PizzaDetail>(pizzaCreate);
            _pizzaRepo.CreatePizza(pizzaModel);
            _pizzaRepo.SaveChanges();

            var pizzaReadDto = _mapper.Map<PizzaReadDto>(pizzaModel);

            return CreatedAtRoute(nameof(GetPizzaById), new { Id = pizzaReadDto.Id }, pizzaReadDto);
        }
    }
}
