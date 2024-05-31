using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var departmentRepo = new DepartmentRepo(conn);

            //departmentRepo.InsertDepartments("Something else");

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID} {department.Name}");
            }

            var productRepo = new ProductRepo(conn);

            //productRepo.CreateProduct("Everything Everything: Get to Heaven", 14.99, 7);

            //var productToUpdate = productRepo.GetProduct(941);
            //productToUpdate.Name = "Everything Everything: The End of the Contender";
            //productToUpdate.Price = 19.99;
            //productToUpdate.CategoryID = 7;
            //productToUpdate.OnSale = 1;
            //productToUpdate.StockLevel = 1100;

            //productRepo.UpdateProduct(productToUpdate);

            productRepo.DeleteProduct(941);

            var products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} | {product.Name} | {product.Price} | {product.CategoryID}");
            }
        }
    }
}
