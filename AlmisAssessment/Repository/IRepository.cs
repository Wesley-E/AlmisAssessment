using System.Collections.Generic;
using AlmisAssessment.Models.Repository;

namespace AlmisAssessment.Repository
{
    public interface IRepository 
    {
        Dictionary<string, RepositoryProduct> LoadProducts(string path);
    }
}