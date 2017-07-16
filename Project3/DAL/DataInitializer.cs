using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project3.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var products = new List<Product>
            {
                new Product { ID = 1, Name = "MacBook Air 11 Computer", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", Category=3, Price=100, Stock=10 },
                new Product { ID = 2, Name = "Star Wars", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", Category = 4, Price = 20, Stock = 2 }
            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }
    }
}