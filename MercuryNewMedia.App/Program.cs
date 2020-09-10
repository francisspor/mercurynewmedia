using MercuryNewMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MercuryNewMedia
{
    public class Program
    {
        static void Main(string[] args)
        {
            var importService = new ImportService();
            var emps = importService.ImportEmployees("./data.json");

            var reportingService = new ReportingService();

            // Question 1
            var employeesWhoLikePineapple = reportingService.EmployeesWhoLikePineApple(emps);
            Console.Out.WriteLine($"{employeesWhoLikePineapple.First().Key} really likes pineapple");
            Console.Out.WriteLine();



            // Question 2
            var (engineerCount, pieCount) = reportingService.PizzaCountForDepartment(emps, "Engineering");
            Console.Out.WriteLine($"You're going to need {pieCount} pizzas to feed your {engineerCount} engineers.");
            Console.Out.WriteLine();

            // Question 3
            var groupedFavorites = reportingService.FavoritesByDepartment(emps);
            foreach (var g in groupedFavorites.Keys)
            {
                Console.Out.WriteLine($"{g} likes {string.Join(", ", groupedFavorites[g].Item1)} a lot ({groupedFavorites[g].Item2} times!)");
            }
        }
    }
}
