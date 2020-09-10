using MercuryNewMedia.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MercuryNewMedia.Services
{
    public class ImportService
    {
        private JsonSerializer serializer;

        public ImportService()
        {
            var options = new JsonSerializerSettings { };
            serializer = JsonSerializer.Create(options);
        }

        public List<Employee> ImportEmployees(string filePath)
        {
            List<Employee> result;
            using (var str = new FileStream(filePath, FileMode.Open))
            {
                result = serializer.Deserialize<List<Employee>>(new JsonTextReader(new StreamReader(str)));
            }

            return result;
        }
    }
}
