using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;

namespace Food.EntityFrameworkCore.Seed.Calories
{
    public class DefaultCaloriesBuilder
    {
        private readonly FoodDbContext _context;

        public DefaultCaloriesBuilder(FoodDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultCalories();
        }

        private void CreateDefaultCalories()
        {
            var any = _context.Calories.Any();

            if (any)
            {
                return;
            }

            foreach (var calories in GetCalories())
            {
                _context.Calories.Add(calories);
            }

            _context.SaveChanges();
        }

        private IEnumerable<Ordering.Dictionaries.Calories> GetCalories()
        {
            return new[]
            {
                new Ordering.Dictionaries.Calories
                {
                    Name = "1500 kcal",
                    Value = 1500,
                },
                new Ordering.Dictionaries.Calories
                {
                    Name = "2000 kcal",
                    Value = 2000,
                },
                new Ordering.Dictionaries.Calories
                {
                    Name = "2500 kcal",
                    Value = 2500,
                },
                new Ordering.Dictionaries.Calories
                {
                    Name = "3000 kcal",
                    Value = 3000,
                },
            };
        }
    }
}
