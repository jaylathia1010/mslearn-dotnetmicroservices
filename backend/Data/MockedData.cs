using System;
using System.Linq;
using backend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Data
{
    public static class MockedData
    {
        public static void PopulateData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.PizzaDetails.Any())
            {
                Console.WriteLine("---> Seeding the Data...!");

                context.PizzaDetails.AddRange(
                    new PizzaDetail() { PizzaName = "French Bread", Ingredients = "Tomato sauce, cheese, pepperoni", Cost = 40, InStock = "yes" },
                    new PizzaDetail() { PizzaName = "Baked Ziti", Ingredients = "Ziti, tomato sauce, ricotta, mozzarella", Cost = 35, InStock = "no" },
                    new PizzaDetail() { PizzaName = "Forest Floor", Ingredients = "Mushrooms, rutabagas, and walnuts", Cost = 20, InStock = "yes" },
                    new PizzaDetail() { PizzaName = "Don't At Me", Ingredients = "Pineapple, Canadian bacon, jalapeños", Cost = 25, InStock = "yes" },
                    new PizzaDetail() { PizzaName = "Vanilla", Ingredients = "Sausage and pepperoni", Cost = 15, InStock = "no" },
                    new PizzaDetail() { PizzaName = "Spice Coming At Ya", Ingredients = "Peppers, chili sauce, spicy andouille", Cost = 50, InStock = "yes" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> Data already exist...!");
            }
        }
    }
}