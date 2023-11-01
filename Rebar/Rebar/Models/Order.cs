using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Globalization;

namespace Rebar.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid OrderID { get; private set; }

        public List<ShakeToOrder> ShakeList = new List<ShakeToOrder>(10);
        public double TotalPrice { get; private set; }
        public string? CustomerName { get; set; }
        public string? OrderDate { get; private set; }
        public string? DiscountsAndPromotions { get; private set; }
        private static IMongoCollection<Order> Orders { get; }
        private readonly string password = "ProgrammingIsFun";
        public Order(string customerName, string discountsAndPromotions)
        {
            OrderID = Guid.NewGuid();
            CustomerName = customerName;
            OrderDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            DiscountsAndPromotions = discountsAndPromotions;
        }

        public void CloseCheckout()
        {
            Console.WriteLine("Please enter an administrator password");
            var input = Console.ReadLine();
            if (input == password)
            {
                var TodaysOrders = 0;
                double TotalIncoms = 0;
                foreach (var order in Orders.AsQueryable().ToList())
                {
                    if (DateTime.ParseExact(order.OrderDate, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture).Date == DateTime.Today)
                    {
                        TodaysOrders += 1;
                        TotalIncoms += order.TotalPrice;
                    }
                    Console.WriteLine("The number of orders there were today {0}", TodaysOrders);
                    Console.WriteLine("The total incomes todayy {0}", TotalIncoms);
                }
            }
            else
                Console.WriteLine("No permission to close a checkout");
        }
    }
}