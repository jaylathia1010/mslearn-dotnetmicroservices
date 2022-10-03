using System;
using System.Collections.Generic;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public class PizzaRepo : IPizzaRepo
    {
        private AppDbContext _context;

        public PizzaRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePizza(PizzaDetail pizza)
        {
            if (pizza == null)
            {
                throw new ArgumentNullException(nameof(pizza));
            }

            _context.PizzaDetails.Add(pizza);
        }

        public IEnumerable<PizzaDetail> GetAllPizzas()
        {
            return _context.PizzaDetails.ToList();
        }

        public PizzaDetail GetPizzaById(int id)
        {
            return _context.PizzaDetails.FirstOrDefault(pizza => pizza.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}