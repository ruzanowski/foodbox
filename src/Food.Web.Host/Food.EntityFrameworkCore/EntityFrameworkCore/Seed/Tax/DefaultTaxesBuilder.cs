using System.Collections.Generic;
using System.Linq.Dynamic.Core;

namespace Food.EntityFrameworkCore.Seed.Tax
{
    public class DefaultTaxBuilder
    {
        private readonly FoodDbContext _context;

        public DefaultTaxBuilder(FoodDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultTaxes();
        }

        private void CreateDefaultTaxes()
        {
            var any = _context.Taxes.Any();

            if (any)
            {
                return;
            }

            foreach (var taxes in GetTaxes())
            {
                _context.Taxes.Add(taxes);
            }

            _context.SaveChanges();
        }

        private IEnumerable<Ordering.Dictionaries.Tax> GetTaxes()
        {
            return new[]
            {
                new Ordering.Dictionaries.Tax
                {
                    Name = "Podatek VAT 23%",
                    Value = (decimal) 0.23
                },
                new Ordering.Dictionaries.Tax
                {
                    Name = "Podatek VAT 8%",
                    Value = (decimal) 0.08
                },
                new Ordering.Dictionaries.Tax
                {
                    Name = "Podatek VAT 5%",
                    Value = (decimal) 0.05
                },
                new Ordering.Dictionaries.Tax
                {
                    Name = "Podatek VAT 0%",
                    Value = (decimal) 0.00
                },
            };
        }
    }
}
