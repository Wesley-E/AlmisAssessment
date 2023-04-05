using System.Collections.Generic;
using System.IO;
using AlmisAssessment.Models.Repository;
using Newtonsoft.Json;

namespace AlmisAssessment.Repository
{
    public class Repository : IRepository
    {
        public Dictionary<string, RepositoryProduct> LoadProducts(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Product file not found at: {path}");
            var productText = File.ReadAllText(path);
            try
            {
                return JsonConvert.DeserializeObject<Dictionary<string, RepositoryProduct>>(productText);
            }
            catch (JsonException ex)
            {
                throw new JsonException($"Invalid product format given in {path}", ex);
            }
        }
    }
}