using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public interface IPizzaRepo
    {
        bool SaveChanges();

        IEnumerable<PizzaDetail> GetAllPizzas();
        PizzaDetail GetPizzaById(int id);
        void CreatePizza(PizzaDetail pizza);
    }
}