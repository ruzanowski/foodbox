using System.Collections.Generic;
using Food.Ordering;
using Microsoft.EntityFrameworkCore.Internal;

namespace Food.EntityFrameworkCore.Seed.Products
{
    public class DefaultProductsBuilder
    {
        private readonly FoodDbContext _context;

        public DefaultProductsBuilder(FoodDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultProducts();
        }

        private void CreateDefaultProducts()
        {
            var any = _context.Products.Any();

            if (any)
            {
                return;
            }

            foreach (var additional in GetProducts())
            {
                _context.Products.Add(additional);
            }

            _context.SaveChanges();
        }

        private IEnumerable<Product> GetProducts()
        {
            return new[]
            {
                new Product
                {
                    Name = "Zestaw Standard",
                    Description = "Zbilansowana dieta, zawierająca w menu składniki pochodzenia zwierzęcego.",
                    PriceNet = 43,
                    TaxId = 2
                },
                new Product
                {
                    Name = "Zestaw Vege",
                    Description = "Zbilansowana dieta bezmięsna.",
                    PriceNet = 45,
                    TaxId = 2
                },
                new Product
                {
                    Name = "Zestaw Sport",
                    Description = "Dla osób trenujących, dieta o wysokiej zawartości białka.",
                    PriceNet = 50,
                    TaxId = 2
                },
                new Product
                {
                    Name = "Zestaw Vegan",
                    Description = "Zbilansowana dieta wegańska.",
                    PriceNet = 52,
                    TaxId = 2
                },
            };
        }
    }
}
