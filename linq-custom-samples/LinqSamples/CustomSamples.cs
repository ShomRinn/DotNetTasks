#pragma warning disable S3358
#pragma warning disable CA1305
#pragma warning disable CA1310
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LinqSamples.Attributes;
using LinqSamples.NorthwindEntities;

namespace LinqSamples
{
    [Title("LINQ Query Custom Samples")]
    [Prefix("linq")]
    public class CustomSamples : SampleHarness
    {
        private readonly string dataPath;

        private List<Product> productList;
        private List<Customer> customerList;
        private List<Supplier> supplierList;

        public CustomSamples(string path)
        {
            this.dataPath = path ?? throw new ArgumentNullException(nameof(path));
            this.CreateLists();
        }

        [Category("Orders")]
        [Title("LinqQuery01")]
        [Description("Get a list of all customers whose sum of all orders exceeds some given value.")]
        public void LinqQuery1()
        {
            decimal givenValue = 12000;
            var result = this.customerList.Where(c => c.Orders.Sum(o => o.Total) > givenValue).ToList();
            foreach (var customer in result)
            {
                Console.WriteLine($"Customer Name: {customer.CustomerId}, Sum of Orders: {customer.Orders.Sum(o => o.Total)}");
            }
        }

        [Category("Clients and Suppliers")]
        [Title("LinqQuery2a")]
        [Description("For each client, get a list of suppliers located in the same country and the same city without grouping.")]
        public void LinqQuery2a()
        {
            var result = this.customerList.SelectMany(c => this.supplierList.Where(s => s.Country == c.Country && s.City == c.City).Select(s => new { Customer = c, Supplier = s }));
            foreach (var pair in result)
            {
                Console.WriteLine($"CustomerId: {pair.Customer.CustomerId}, Supplier: {pair.Supplier.SupplierName}, Country: {pair.Supplier.Country}, City: {pair.Supplier.City}");
            }
        }

        [Category("Clients and Suppliers")]
        [Title("LinqQuery2b")]
        [Description("For each client, get a list of suppliers located in the same country and the same city with grouping.")]
        public void LinqQuery2b()
        {
            // With grouping
            var resultWithGrouping = this.customerList.GroupBy(c => new { c.Country, c.City }).Select(g => new { g.Key, Suppliers = this.supplierList.Where(s => s.Country == g.Key.Country && s.City == g.Key.City) });
            foreach (var group in resultWithGrouping)
            {
                Console.WriteLine($"Country: {group.Key.Country}, City: {group.Key.City}, Suppliers: {string.Join(", ", group.Suppliers.Select(s => s.SupplierName))}");
            }
        }

        [Category("Orders")]
        [Title("LinqQuery3")]
        [Description("Get a list of those customers whose orders exceed the specified amount.")]
        public void LinqQuery3()
        {
            decimal specifiedAmount = 12000;
            var result = this.customerList.Where(c => c.Orders.Any(o => o.Total > specifiedAmount)).ToList();
            foreach (var customer in result)
            {
                Console.WriteLine($"CustomerId: {customer.CustomerId}, Orders Over Specified Amount: {string.Join(", ", customer.Orders.Where(o => o.Total > specifiedAmount).Select(o => o.Total.ToString()))}");
            }
        }

        [Category("Customers")]
        [Title("LinqQuery04")]
        [Description("Get a list of all customers sorted by year, month of the customer's first order, customer turnover and customer name.")]
        public void LinqQuery04()
        {
            var result = this.customerList.OrderBy(c => c.Orders.Min(o => o.OrderDate.Year))
                           .ThenBy(c => c.Orders.Min(o => o.OrderDate.Month))
                           .ThenByDescending(c => c.Orders.Sum(o => o.Total))
                           .ThenBy(c => c.CustomerId)
                           .ToList();
            foreach (var customer in result)
            {
                Console.WriteLine($"CustomerId: {customer.CustomerId}, First Order: {customer.Orders.Min(o => o.OrderDate)}, Total Orders: {customer.Orders.Sum(o => o.Total)}");
            }
        }

        [Category("Customers")]
        [Title("LinqQuery5")]
        [Description("Get a list of those customers who have a non-numeric postal code or region is not filled in or the operator code is not specified in the phone.")]
        public void LinqQuery5()
        {
            var result = this.customerList.Where(c => !int.TryParse(c.PostalCode, out _) || string.IsNullOrWhiteSpace(c.Region) || !c.Phone.StartsWith("(")).ToList();
            foreach (var customer in result)
            {
                Console.WriteLine($"CustomerId: {customer.CustomerId}, Postal Code: {customer.PostalCode}, Region: {customer.Region}, Phone: {customer.Phone}");
            }
        }

        [Category("Products")]
        [Title("LinqQuery6")]
        [Description("Group all products by category, inside - by availability in stock, inside the last group - by cost.")]
        public void LinqQuery6()
        {
            var result = this.productList.GroupBy(p => p.Category)
                .Select(categoryGroup => new
                {
                    Category = categoryGroup.Key,
                    ProductsByStock = categoryGroup.GroupBy(p => p.UnitsInStock > 0).Select(stockGroup => new
                    {
                        InStock = stockGroup.Key,
                        ProductsByCost = stockGroup.OrderBy(p => p.UnitPrice),
                    }),
                })
               .ToList();

            foreach (var categoryGroup in result)
            {
                Console.WriteLine($"Category: {categoryGroup.Category}");
                foreach (var stockGroup in categoryGroup.ProductsByStock)
                {
                    Console.WriteLine($"  InStock: {stockGroup.InStock}");
                    foreach (var product in stockGroup.ProductsByCost)
                    {
                        Console.WriteLine($"    Product: {product.ProductName}, Price: {product.UnitPrice}");
                    }
                }
            }
        }

        [Category("Products")]
        [Title("LinqQuery7")]
        [Description("Group all goods into groups \"cheap\", \"average price\", \"expensive\", defining the boundaries of each group in an arbitrary way.")]
        public void LinqQuery7()
        {
            decimal cheapLimit = 10000;
            decimal averageLimit = 12000;
            var result = this.productList.GroupBy(p => p.UnitPrice <= cheapLimit ? "Cheap" : (p.UnitPrice <= averageLimit ? "Average price" : "Expensive")).ToList();

            foreach (var group in result)
            {
                Console.WriteLine($"Price Group: {group.Key}, Products: {string.Join(", ", group.Select(p => $"Name: {p.ProductName}, Price: {p.UnitPrice}"))}");
            }
        }

        [Category("Orders")]
        [Title("LinqQuery8")]
        [Description("Calculate the average order amount for all customers from a given city and the average number of orders per customer from each city.")]
        public void LinqQuery8()
        {
            string givenCity = "New York";
            var resultPerCity = this.customerList.GroupBy(c => c.City).Select(g => new { City = g.Key, AverageOrders = g.Average(c => c.Orders.Length) });

            Console.WriteLine($"Average order amount and average number of orders per customer from city: {givenCity}");
            foreach (var result in resultPerCity)
            {
                Console.WriteLine($"Average orders per customer in {result.City}: {result.AverageOrders}");
            }
        }

        [Category("Custom")]
        [Title("LinqQuery9a")]
        [Description("Compose your queries (at least 5) to the data sets described by the Product, Customer, Supplier, Order classes.")]
        public void LinqQuery9a()
        {
            var topCustomers = this.customerList.OrderByDescending(c => c.Orders.Sum(o => o.Total)).Take(5).ToList();
            Console.WriteLine("Top CustomerIds: " + string.Join(", ", topCustomers.Select(c => c.CustomerId)));
        }

        [Category("Custom")]
        [Title("LinqQuery9b")]
        [Description("Compose your queries (at least 5) to the data sets described by the Product, Customer, Supplier, Order classes.")]
        public void LinqQuery9b()
        {
            var outOfStockProducts = this.productList.Where(p => p.UnitsInStock == 0).ToList();
            Console.WriteLine("Out of Stock Products: " + string.Join(", ", outOfStockProducts.Select(p => p.ProductName)));
        }

        [Category("Custom")]
        [Title("LinqQuery9c")]
        [Description("Compose your queries (at least 5) to the data sets described by the Product, Customer, Supplier, Order classes.")]
        public void LinqQuery9c()
        {
            var suppliersWithMostCustomers = this.supplierList.GroupBy(s => new { s.Country, s.City }).OrderByDescending(g => g.Count()).First();
            Console.WriteLine($"Suppliers With Most Customers: {suppliersWithMostCustomers.Key.City}, {suppliersWithMostCustomers.Key.Country}");
        }

        [Category("Custom")]
        [Title("LinqQuery9d")]
        [Description("Identify the customer with the highest order total.")]
        public void LinqQuery9d()
        {
            var customerWithHighestOrder = this.customerList
                .Where(c => c.Orders.Any())
                .Select(c => new
                {
                    Customer = c,
                    HighestOrder = c.Orders.Max(o => o.Total),
                })
                .OrderByDescending(c => c.HighestOrder)
                .FirstOrDefault();

            Console.WriteLine(customerWithHighestOrder != null
            ? $"Customer With Highest Order: {customerWithHighestOrder.Customer.CustomerId}, Highest Order: {customerWithHighestOrder.HighestOrder}"
            : "No customers found with an order.");
        }

        [Category("Custom")]
        [Title("LinqQuery9e")]
        [Description("Compose your queries (at least 5) to the data sets described by the Product, Customer, Supplier, Order classes.")]
        public void LinqQuery9e()
        {
            var productsInPriceRange = this.productList.Where(p => p.UnitPrice >= 100 && p.UnitPrice <= 200).ToList();
            Console.WriteLine("Products In Price Range: " + string.Join(", ", productsInPriceRange.Select(p => p.ProductName)));
        }

        private void CreateLists()
        {
            this.productList = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Chai",
                    Category = "Beverages",
                    UnitPrice = 18.0000M,
                    UnitsInStock = 39,
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Chang",
                    Category = "Beverages",
                    UnitPrice = 19.0000M,
                    UnitsInStock = 17,
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Aniseed Syrup",
                    Category = "Condiments",
                    UnitPrice = 10.0000M,
                    UnitsInStock = 13,
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Chef Anton's Cajun Seasoning",
                    Category = "Condiments",
                    UnitPrice = 22.0000M,
                    UnitsInStock = 53,
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Chef Anton's Gumbo Mix",
                    Category = "Condiments",
                    UnitPrice = 21.3500M,
                    UnitsInStock = 0,
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Grandma's Boysenberry Spread",
                    Category = "Condiments",
                    UnitPrice = 25.0000M,
                    UnitsInStock = 120,
                },
                new Product
                {
                    ProductId = 7,
                    ProductName = "Uncle Bob's Organic Dried Pears",
                    Category = "Produce",
                    UnitPrice = 30.0000M,
                    UnitsInStock = 15,
                },
                new Product
                {
                    ProductId = 8,
                    ProductName = "Northwoods Cranberry Sauce",
                    Category = "Condiments",
                    UnitPrice = 40.0000M,
                    UnitsInStock = 6,
                },
                new Product
                {
                    ProductId = 9,
                    ProductName = "Mishi Kobe Niku",
                    Category = "Meat/Poultry",
                    UnitPrice = 97.0000M,
                    UnitsInStock = 29,
                },
                new Product
                {
                    ProductId = 10,
                    ProductName = "Ikura",
                    Category = "Seafood",
                    UnitPrice = 31.0000M,
                    UnitsInStock = 31,
                },
                new Product
                {
                    ProductId = 11,
                    ProductName = "Queso Cabrales",
                    Category = "Dairy Products",
                    UnitPrice = 21.0000M,
                    UnitsInStock = 22,
                },
                new Product
                {
                    ProductId = 12,
                    ProductName = "Queso Manchego La Pastora",
                    Category = "Dairy Products",
                    UnitPrice = 38.0000M,
                    UnitsInStock = 86,
                },
                new Product
                {
                    ProductId = 13,
                    ProductName = "Konbu",
                    Category = "Seafood",
                    UnitPrice = 6.0000M,
                    UnitsInStock = 24,
                },
                new Product
                {
                    ProductId = 14,
                    ProductName = "Tofu",
                    Category = "Produce",
                    UnitPrice = 23.2500M,
                    UnitsInStock = 35,
                },
                new Product
                {
                    ProductId = 15,
                    ProductName = "Genen Shouyu",
                    Category = "Condiments",
                    UnitPrice = 15.5000M,
                    UnitsInStock = 39,
                },
                new Product
                {
                    ProductId = 16,
                    ProductName = "Pavlova",
                    Category = "Confections",
                    UnitPrice = 17.4500M,
                    UnitsInStock = 29,
                },
                new Product
                {
                    ProductId = 17,
                    ProductName = "Alice Mutton",
                    Category = "Meat/Poultry",
                    UnitPrice = 39.0000M,
                    UnitsInStock = 0,
                },
                new Product
                {
                    ProductId = 18,
                    ProductName = "Carnarvon Tigers",
                    Category = "Seafood",
                    UnitPrice = 62.5000M,
                    UnitsInStock = 42,
                },
                new Product
                {
                    ProductId = 19,
                    ProductName = "Teatime Chocolate Biscuits",
                    Category = "Confections",
                    UnitPrice = 9.2000M,
                    UnitsInStock = 25,
                },
                new Product
                {
                    ProductId = 20,
                    ProductName = "Sir Rodney's Marmalade",
                    Category = "Confections",
                    UnitPrice = 81.0000M,
                    UnitsInStock = 40,
                },
                new Product
                {
                    ProductId = 21,
                    ProductName = "Sir Rodney's Scones",
                    Category = "Confections",
                    UnitPrice = 10.0000M,
                    UnitsInStock = 3,
                },
                new Product
                {
                    ProductId = 22,
                    ProductName = "Gustaf's Knäckebröd",
                    Category = "Grains/Cereals",
                    UnitPrice = 21.0000M,
                    UnitsInStock = 104,
                },
                new Product
                {
                    ProductId = 23,
                    ProductName = "Tunnbröd",
                    Category = "Grains/Cereals",
                    UnitPrice = 9.0000M,
                    UnitsInStock = 61,
                },
                new Product
                {
                    ProductId = 24,
                    ProductName = "Guaraná Fantástica",
                    Category = "Beverages",
                    UnitPrice = 4.5000M,
                    UnitsInStock = 20,
                },
                new Product
                {
                    ProductId = 25,
                    ProductName = "NuNuCa Nuß-Nougat-Creme",
                    Category = "Confections",
                    UnitPrice = 14.0000M,
                    UnitsInStock = 76,
                },
                new Product
                {
                    ProductId = 26,
                    ProductName = "Gumbär Gummibärchen",
                    Category = "Confections",
                    UnitPrice = 31.2300M,
                    UnitsInStock = 15,
                },
                new Product
                {
                    ProductId = 27,
                    ProductName = "Schoggi Schokolade",
                    Category = "Confections",
                    UnitPrice = 43.9000M,
                    UnitsInStock = 49,
                },
                new Product
                {
                    ProductId = 28,
                    ProductName = "Rössle Sauerkraut",
                    Category = "Produce",
                    UnitPrice = 45.6000M,
                    UnitsInStock = 26,
                },
                new Product
                {
                    ProductId = 29,
                    ProductName = "Thüringer Rostbratwurst",
                    Category = "Meat/Poultry",
                    UnitPrice = 123.7900M,
                    UnitsInStock = 0,
                },
                new Product
                {
                    ProductId = 30,
                    ProductName = "Nord-Ost Matjeshering",
                    Category = "Seafood",
                    UnitPrice = 25.8900M,
                    UnitsInStock = 10,
                },
                new Product
                {
                    ProductId = 31,
                    ProductName = "Gorgonzola Telino",
                    Category = "Dairy Products",
                    UnitPrice = 12.5000M,
                    UnitsInStock = 0,
                },
                new Product
                {
                    ProductId = 32,
                    ProductName = "Mascarpone Fabioli",
                    Category = "Dairy Products",
                    UnitPrice = 32.0000M,
                    UnitsInStock = 9,
                },
                new Product
                {
                    ProductId = 33,
                    ProductName = "Geitost",
                    Category = "Dairy Products",
                    UnitPrice = 2.5000M,
                    UnitsInStock = 112,
                },
                new Product
                {
                    ProductId = 34,
                    ProductName = "Sasquatch Ale",
                    Category = "Beverages",
                    UnitPrice = 14.0000M,
                    UnitsInStock = 111,
                },
                new Product
                {
                    ProductId = 35,
                    ProductName = "Steeleye Stout",
                    Category = "Beverages",
                    UnitPrice = 18.0000M,
                    UnitsInStock = 20,
                },
                new Product
                {
                    ProductId = 36,
                    ProductName = "Inlagd Sill",
                    Category = "Seafood",
                    UnitPrice = 19.0000M,
                    UnitsInStock = 112,
                },
                new Product
                {
                    ProductId = 37,
                    ProductName = "Gravad lax",
                    Category = "Seafood",
                    UnitPrice = 26.0000M,
                    UnitsInStock = 11,
                },
                new Product
                {
                    ProductId = 38,
                    ProductName = "Côte de Blaye",
                    Category = "Beverages",
                    UnitPrice = 263.5000M,
                    UnitsInStock = 17,
                },
                new Product
                {
                    ProductId = 39,
                    ProductName = "Chartreuse verte",
                    Category = "Beverages",
                    UnitPrice = 18.0000M,
                    UnitsInStock = 69,
                },
                new Product
                {
                    ProductId = 40,
                    ProductName = "Boston Crab Meat",
                    Category = "Seafood",
                    UnitPrice = 18.4000M,
                    UnitsInStock = 123,
                },
                new Product
                {
                    ProductId = 41,
                    ProductName = "Jack's New England Clam Chowder",
                    Category = "Seafood",
                    UnitPrice = 9.6500M,
                    UnitsInStock = 85,
                },
                new Product
                {
                    ProductId = 42,
                    ProductName = "Singaporean Hokkien Fried Mee",
                    Category = "Grains/Cereals",
                    UnitPrice = 14.0000M,
                    UnitsInStock = 26,
                },
                new Product
                {
                    ProductId = 43,
                    ProductName = "Ipoh Coffee",
                    Category = "Beverages",
                    UnitPrice = 46.0000M,
                    UnitsInStock = 17,
                },
                new Product
                {
                    ProductId = 44,
                    ProductName = "Gula Malacca",
                    Category = "Condiments",
                    UnitPrice = 19.4500M,
                    UnitsInStock = 27,
                },
                new Product
                {
                    ProductId = 45,
                    ProductName = "Rogede sild",
                    Category = "Seafood",
                    UnitPrice = 9.5000M,
                    UnitsInStock = 5,
                },
                new Product
                {
                    ProductId = 46,
                    ProductName = "Spegesild",
                    Category = "Seafood",
                    UnitPrice = 12.0000M,
                    UnitsInStock = 95,
                },
                new Product
                {
                    ProductId = 47,
                    ProductName = "Zaanse koeken",
                    Category = "Confections",
                    UnitPrice = 9.5000M,
                    UnitsInStock = 36,
                },
                new Product
                {
                    ProductId = 48,
                    ProductName = "Chocolade",
                    Category = "Confections",
                    UnitPrice = 12.7500M,
                    UnitsInStock = 15,
                },
                new Product
                {
                    ProductId = 49,
                    ProductName = "Maxilaku",
                    Category = "Confections",
                    UnitPrice = 20.0000M,
                    UnitsInStock = 10,
                },
                new Product
                {
                    ProductId = 50,
                    ProductName = "Valkoinen suklaa",
                    Category = "Confections",
                    UnitPrice = 16.2500M,
                    UnitsInStock = 65,
                },
                new Product
                {
                    ProductId = 51,
                    ProductName = "Manjimup Dried Apples",
                    Category = "Produce",
                    UnitPrice = 53.0000M,
                    UnitsInStock = 20,
                },
                new Product
                {
                    ProductId = 52,
                    ProductName = "Filo Mix",
                    Category = "Grains/Cereals",
                    UnitPrice = 7.0000M,
                    UnitsInStock = 38,
                },
                new Product
                {
                    ProductId = 53,
                    ProductName = "Perth Pasties",
                    Category = "Meat/Poultry",
                    UnitPrice = 32.8000M,
                    UnitsInStock = 0,
                },
                new Product
                {
                    ProductId = 54,
                    ProductName = "Tourtière",
                    Category = "Meat/Poultry",
                    UnitPrice = 7.4500M,
                    UnitsInStock = 21,
                },
                new Product
                {
                    ProductId = 55,
                    ProductName = "Pâté chinois",
                    Category = "Meat/Poultry",
                    UnitPrice = 24.0000M,
                    UnitsInStock = 115,
                },
                new Product
                {
                    ProductId = 56,
                    ProductName = "Gnocchi di nonna Alice",
                    Category = "Grains/Cereals",
                    UnitPrice = 38.0000M,
                    UnitsInStock = 21,
                },
                new Product
                {
                    ProductId = 57,
                    ProductName = "Ravioli Angelo",
                    Category = "Grains/Cereals",
                    UnitPrice = 19.5000M,
                    UnitsInStock = 36,
                },
                new Product
                {
                    ProductId = 58,
                    ProductName = "Escargots de Bourgogne",
                    Category = "Seafood",
                    UnitPrice = 13.2500M,
                    UnitsInStock = 62,
                },
                new Product
                {
                    ProductId = 59,
                    ProductName = "Raclette Courdavault",
                    Category = "Dairy Products",
                    UnitPrice = 55.0000M,
                    UnitsInStock = 79,
                },
                new Product
                {
                    ProductId = 60,
                    ProductName = "Camembert Pierrot",
                    Category = "Dairy Products",
                    UnitPrice = 34.0000M,
                    UnitsInStock = 19,
                },
                new Product
                {
                    ProductId = 61,
                    ProductName = "Sirop d'érable",
                    Category = "Condiments",
                    UnitPrice = 28.5000M,
                    UnitsInStock = 113,
                },
                new Product
                {
                    ProductId = 62,
                    ProductName = "Tarte au sucre",
                    Category = "Confections",
                    UnitPrice = 49.3000M,
                    UnitsInStock = 17,
                },
                new Product
                {
                    ProductId = 63,
                    ProductName = "Vegie-spread",
                    Category = "Condiments",
                    UnitPrice = 43.9000M,
                    UnitsInStock = 24,
                },
                new Product
                {
                    ProductId = 64,
                    ProductName = "Wimmers gute Semmelknödel",
                    Category = "Grains/Cereals",
                    UnitPrice = 33.2500M,
                    UnitsInStock = 22,
                },
                new Product
                {
                    ProductId = 65,
                    ProductName = "Louisiana Fiery Hot Pepper Sauce",
                    Category = "Condiments",
                    UnitPrice = 21.0500M,
                    UnitsInStock = 76,
                },
                new Product
                {
                    ProductId = 66,
                    ProductName = "Louisiana Hot Spiced Okra",
                    Category = "Condiments",
                    UnitPrice = 17.0000M,
                    UnitsInStock = 4,
                },
                new Product
                {
                    ProductId = 67,
                    ProductName = "Laughing Lumberjack Lager",
                    Category = "Beverages",
                    UnitPrice = 14.0000M,
                    UnitsInStock = 52,
                },
                new Product
                {
                    ProductId = 68,
                    ProductName = "Scottish Longbreads",
                    Category = "Confections",
                    UnitPrice = 12.5000M,
                    UnitsInStock = 6,
                },
                new Product
                {
                    ProductId = 69,
                    ProductName = "Gudbrandsdalsost",
                    Category = "Dairy Products",
                    UnitPrice = 36.0000M,
                    UnitsInStock = 26,
                },
                new Product
                {
                    ProductId = 70,
                    ProductName = "Outback Lager",
                    Category = "Beverages",
                    UnitPrice = 15.0000M,
                    UnitsInStock = 15,
                },
                new Product
                {
                    ProductId = 71,
                    ProductName = "Flotemysost",
                    Category = "Dairy Products",
                    UnitPrice = 21.5000M,
                    UnitsInStock = 26,
                },
                new Product
                {
                    ProductId = 72,
                    ProductName = "Mozzarella di Giovanni",
                    Category = "Dairy Products",
                    UnitPrice = 34.8000M,
                    UnitsInStock = 14,
                },
                new Product
                {
                    ProductId = 73,
                    ProductName = "Röd Kaviar",
                    Category = "Seafood",
                    UnitPrice = 15.0000M,
                    UnitsInStock = 101,
                },
                new Product
                {
                    ProductId = 74,
                    ProductName = "Longlife Tofu",
                    Category = "Produce",
                    UnitPrice = 10.0000M,
                    UnitsInStock = 4,
                },
                new Product
                {
                    ProductId = 75,
                    ProductName = "Rhönbräu Klosterbier",
                    Category = "Beverages",
                    UnitPrice = 7.7500M,
                    UnitsInStock = 125,
                },
                new Product
                {
                    ProductId = 76,
                    ProductName = "Lakkalikööri",
                    Category = "Beverages",
                    UnitPrice = 18.0000M,
                    UnitsInStock = 57,
                },
                new Product
                {
                    ProductId = 77,
                    ProductName = "Original Frankfurter grüne Soße",
                    Category = "Condiments",
                    UnitPrice = 13.0000M,
                    UnitsInStock = 32,
                },
            };

            this.supplierList = new List<Supplier>()
            {
                new Supplier
                {
                    SupplierName = "Exotic Liquids",
                    Address = "49 Gilbert St.",
                    City = "London",
                    Country = "UK",
                },
                new Supplier
                {
                    SupplierName = "New Orleans Cajun Delights",
                    Address = "P.O. Box 78934",
                    City = "New Orleans",
                    Country = "USA",
                },
                new Supplier
                {
                    SupplierName = "Grandma Kelly's Homestead",
                    Address = "707 Oxford Rd.",
                    City = "Ann Arbor",
                    Country = "USA",
                },
                new Supplier
                {
                    SupplierName = "Tokyo Traders",
                    Address = "9-8 Sekimai Musashino-shi",
                    City = "Tokyo",
                    Country = "Japan",
                },
                new Supplier
                {
                    SupplierName = "Cooperativa de Quesos 'Las Cabras'",
                    Address = "Calle del Rosal 4",
                    City = "Oviedo",
                    Country = "Spain",
                },
                new Supplier
                {
                    SupplierName = "Mayumi's",
                    Address = "92 Setsuko Chuo-ku",
                    City = "Osaka",
                    Country = "Japan",
                },
                new Supplier
                {
                    SupplierName = "Pavlova, Ltd.",
                    Address = "74 Rose St. Moonie Ponds",
                    City = "Melbourne",
                    Country = "Australia",
                },
                new Supplier
                {
                    SupplierName = "Specialty Biscuits, Ltd.",
                    Address = "29 King's Way",
                    City = "Manchester",
                    Country = "UK",
                },
                new Supplier
                {
                    SupplierName = "PB Knäckebröd AB",
                    Address = "Kaloadagatan 13",
                    City = "Göteborg",
                    Country = "Sweden",
                },
                new Supplier
                {
                    SupplierName = "Refrescos Americanas LTDA",
                    Address = "Av. das Americanas 12.890",
                    City = "Sao Paulo",
                    Country = "Brazil",
                },
                new Supplier
                {
                    SupplierName = "Heli Süßwaren GmbH & Co. KG",
                    Address = "Tiergartenstraße 5",
                    City = "Berlin",
                    Country = "Germany",
                },
                new Supplier
                {
                    SupplierName = "Plutzer Lebensmittelgroßmärkte AG",
                    Address = "Bogenallee 51",
                    City = "Frankfurt",
                    Country = "Germany",
                },
                new Supplier
                {
                    SupplierName = "Nord-Ost-Fisch Handelsgesellschaft mbH",
                    Address = "Frahmredder 112a",
                    City = "Cuxhaven",
                    Country = "Germany",
                },
                new Supplier
                {
                    SupplierName = "Formaggi Fortini s.r.l.",
                    Address = "Viale Dante, 75",
                    City = "Ravenna",
                    Country = "Italy",
                },
                new Supplier
                {
                    SupplierName = "Norske Meierier",
                    Address = "Hatlevegen 5",
                    City = "Sandvika",
                    Country = "Norway",
                },
                new Supplier
                {
                    SupplierName = "Bigfoot Breweries",
                    Address = "3400 - 8th Avenue Suite 210",
                    City = "Bend",
                    Country = "USA",
                },
                new Supplier
                {
                    SupplierName = "Svensk Sjöföda AB",
                    Address = "Brovallavägen 231",
                    City = "Stockholm",
                    Country = "Sweden",
                },
                new Supplier
                {
                    SupplierName = "Aux joyeux ecclésiastiques",
                    Address = "203, Rue des Francs-Bourgeois",
                    City = "Paris",
                    Country = "France",
                },
                new Supplier
                {
                    SupplierName = "New England Seafood Cannery",
                    Address = "Order Processing Dept. 2100 Paul Revere Blvd.",
                    City = "Boston",
                    Country = "USA",
                },
                new Supplier
                {
                    SupplierName = "Leka Trading",
                    Address = "471 Serangoon Loop, Suite #402",
                    City = "Singapore",
                    Country = "Singapore",
                },
                new Supplier
                {
                    SupplierName = "Lyngbysild",
                    Address = "Lyngbysild Fiskebakken 10",
                    City = "Lyngby",
                    Country = "Denmark",
                },
                new Supplier
                {
                    SupplierName = "Zaanse Snoepfabriek",
                    Address = "Verkoop Rijnweg 22",
                    City = "Zaandam",
                    Country = "Netherlands",
                },
                new Supplier
                {
                    SupplierName = "Karkki Oy",
                    Address = "Valtakatu 12",
                    City = "Lappeenranta",
                    Country = "Finland",
                },
                new Supplier
                {
                    SupplierName = "G'day, Mate",
                    Address = "170 Prince Edward Parade Hunter's Hill",
                    City = "Sydney",
                    Country = "Australia",
                },
                new Supplier
                {
                    SupplierName = "Ma Maison",
                    Address = "2960 Rue St. Laurent",
                    City = "Montréal",
                    Country = "Canada",
                },
                new Supplier
                {
                    SupplierName = "Pasta Buttini s.r.l.",
                    Address = "Via dei Gelsomini, 153",
                    City = "Salerno",
                    Country = "Italy",
                },
                new Supplier
                {
                    SupplierName = "Escargots Nouveaux",
                    Address = "22, rue H. Voiron",
                    City = "Montceau",
                    Country = "France",
                },
                new Supplier
                {
                    SupplierName = "Gai pâturage",
                    Address = "Bat. B 3, rue des Alpes",
                    City = "Annecy",
                    Country = "France",
                },
                new Supplier
                {
                    SupplierName = "Forêts d'érables",
                    Address = "148 rue Chasseur",
                    City = "Ste-Hyacinthe",
                    Country = "Canada",
                },
            };
            string customerListPath = Path.GetFullPath(Path.Combine(this.dataPath, "customers.xml"));

            this.customerList = (
                from xElement in XDocument.Load(customerListPath).Root.Elements("customer")
                select new Customer
                {
                    CustomerId = (string)xElement.Element("id"),
                    CompanyName = (string)xElement.Element("name"),
                    Address = (string)xElement.Element("address"),
                    City = (string)xElement.Element("city"),
                    Region = (string)xElement.Element("region"),
                    PostalCode = (string)xElement.Element("postalcode"),
                    Country = (string)xElement.Element("country"),
                    Phone = (string)xElement.Element("phone"),
                    Fax = (string)xElement.Element("fax"),
                    Orders = (
                            from order in xElement.Elements("orders").Elements("order")
                            select new Order
                            {
                                OrderId = (int)order.Element("id"),
                                OrderDate = (DateTime)order.Element("orderdate"),
                                Total = (decimal)order.Element("total"),
                            })
                        .ToArray(),
                }).ToList();
        }
    }
}
