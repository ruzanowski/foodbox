using System.Collections.Generic;
using Food.Ordering.Dictionaries;
using Microsoft.EntityFrameworkCore.Internal;

namespace Food.EntityFrameworkCore.Seed.Additionals
{
    public class DefaultAdditionalsBuilder
    {
        private readonly FoodDbContext _context;

        public DefaultAdditionalsBuilder(FoodDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultAdditionals();
        }

        private void CreateDefaultAdditionals()
        {
            var any = _context.Additionals.Any();

            if (any)
            {
                return;
            }

            foreach (var additional in GetAdditionals())
            {
                _context.Additionals.Add(additional);
            }

            _context.SaveChanges();
        }

        private IEnumerable<Ordering.Dictionaries.Additionals> GetAdditionals()
        {
            return new[]
            {
                new Ordering.Dictionaries.Additionals
                {
                    Name = "Sztućce plasitkowe",
                    Description = "Sztućce plasitkowe dołączone do zestawu",
                    Type = AdditionalsType.Cutlery,
                    Value = 1,
                    TaxId = 1
                },
                new Ordering.Dictionaries.Additionals
                {
                    Name = "Dowóz do 50km",
                    Description = "Dowóz zestawów do 50km - za darmo",
                    Type = AdditionalsType.Delivery,
                    Value = 0,
                    TaxId = 3
                },
            };
        }
    }
}
