using System;
using System.Collections.Generic;
using Food.Ordering;
using Microsoft.EntityFrameworkCore.Internal;

namespace Food.EntityFrameworkCore.Seed.Order
{
    public class DefaultOrderBuilder
    {
        private readonly FoodDbContext _context;

        public DefaultOrderBuilder(FoodDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultAdditionals();
        }

        private void CreateDefaultAdditionals()
        {
            var any = _context.Orders.Any();

            if (any)
            {
                return;
            }

            foreach (var order in GetOrders())
            {
                _context.Orders.Add(order);
            }

            _context.SaveChanges();
        }

        private IEnumerable<Ordering.Order> GetOrders()
        {
            return new[]
            {
                new Ordering.Order
                {
                    Form = new OrderForm
                    {
                        FirstName = "Tester",
                        LastName = "Skuteczny",
                        City = "Wrocław",
                        Email = "test@fitruna.pl",
                        Remarks = "To jest testowe zamówienie.",
                        Street = "Testowa",
                        BuildingNumber = "100",
                        FlatNumber = "50",
                        PhoneNumber = "123-533-433",
                        PostCode = "50-300",
                        GateAccessCode = "50#4033"
                    },
                    Basket = new Basket
                    {
                        Items = new []
                        {
                            new OrderBasketItem
                            {
                                Count = 1,
                                Remarks = "Proszę bez pieczarek",
                                CaloriesId = 1,
                                ProductId = 1,
                                CutleryFeeId = null,
                                DeliveryTimes = new []
                                {
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(1),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(2),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(3),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(4),
                                    }
                                },
                                WeekendsIncluded = null
                            },
                            new OrderBasketItem
                            {
                                Count = 4,
                                Remarks = null,
                                CaloriesId = 2,
                                ProductId = 2,
                                CutleryFeeId = 1,
                                DeliveryTimes = new []
                                {
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(4),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(5),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(6),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(7),
                                    }
                                },
                                WeekendsIncluded = true
                            }
                        }
                    },
                    Payment = new Payment
                    {
                        TransactionId = "Test-1",
                        PaymentProvider = "PayU",
                        ValuePaid = 1234,
                        TaxPaid = 123,
                        ValueGrossPaid = 1434
                    }
                },
                new Ordering.Order
                {
                    Form = new OrderForm
                    {
                        FirstName = "Tester2",
                        LastName = "Skuteczny2",
                        City = "Wrocław2",
                        Email = "test2@fitruna.pl",
                        Remarks = "To jest testowe zamówienie2.",
                        Street = "Testowa2",
                        BuildingNumber = "1002",
                        FlatNumber = "502",
                        PhoneNumber = "123-533-4332",
                        PostCode = "50-300",
                        GateAccessCode = "50#4033"
                    },
                    Basket = new Basket
                    {
                        Items = new []
                        {
                            new OrderBasketItem
                            {
                                Count = 1,
                                Remarks = "Proszę bez czegoś tam",
                                CaloriesId = 1,
                                ProductId = 3,
                                CutleryFeeId = null,
                                DeliveryTimes = new []
                                {
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(1),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(2),
                                    }
                                },
                                WeekendsIncluded = null
                            },
                            new OrderBasketItem
                            {
                                Count = 4,
                                Remarks = null,
                                CaloriesId = 2,
                                ProductId = 4,
                                CutleryFeeId = 1,
                                DeliveryTimes = new []
                                {
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(4),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(5),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(6),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(7),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(8),
                                    },
                                    new DeliveryTime
                                    {
                                        DateTime = DateTime.Now.AddDays(9),
                                    }
                                },
                                WeekendsIncluded = false
                            }
                        }
                    },
                    Payment = new Payment
                    {
                        TransactionId = "Test-2",
                        PaymentProvider = "TPay",
                        ValuePaid = 3134,
                        TaxPaid = 133,
                        ValueGrossPaid = 3267
                    }
                }
            };
        }
    }
}
