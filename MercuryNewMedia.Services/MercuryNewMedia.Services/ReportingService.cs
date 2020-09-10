using MercuryNewMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercuryNewMedia.Services
{
    public class ReportingService
    {
        public IEnumerable<IGrouping<string, Employee>> EmployeesWhoLikePineApple(List<Employee> emps)
        {
            var result = emps.Where(x => x.Toppings.Contains("Pineapple")).GroupBy(x => x.Department).OrderByDescending(x => x.Count());
            return result.AsEnumerable();
        }

        public Tuple<int, double> PizzaCountForDepartment(List<Employee> emps, string departmentName)
        {
            var engineerCount = emps.Where(x => x.Department == departmentName).Count();
            var pieCount = Math.Ceiling(engineerCount / 4.0);

            return new Tuple<int, double>(engineerCount, pieCount);
        }

        public Dictionary<string, Tuple<List<string>, int>> FavoritesByDepartment(List<Employee> emps)
        {
            var groupingFavorites = new Dictionary<string, Tuple<List<string>, int>>();
            var groups = emps.GroupBy(x => x.Department);
            foreach (var g in groups)
            {
                groupingFavorites[g.Key] = FavoriteToppings(g);
            }
            return groupingFavorites;
        }

        private Tuple<List<string>, int> FavoriteToppings(IEnumerable<Data.Employee> employees)
        {
            var options = new Dictionary<string, int>();
            var optionsMap = new Dictionary<string, List<string>>();


            foreach (var e in employees)
            {
                var toppingsList = e.Toppings.ToList();
                var toppingsKey = string.Join("_", toppingsList.OrderBy(x => x).Select(y => y.ToLower()));
                if (!optionsMap.ContainsKey(toppingsKey))
                {
                    optionsMap[toppingsKey] = toppingsList;
                    options[toppingsKey] = 0;
                }

                options[toppingsKey] += 1;
            }

            var mostPopular = options.ToList().OrderByDescending(x => x.Value).First();

            return new Tuple<List<string>, int>(optionsMap[mostPopular.Key], mostPopular.Value);
        }

    }
}
