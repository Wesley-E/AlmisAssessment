using System.Collections.Generic;
using AlmisAssessment.Models;
using AlmisAssessment.Models.Product;
using AlmisAssessment.Models.Repository;

namespace AlmisAssessment.Services
{
    public interface IProductService
    {
        Product CreateProduct(string productName, InterestRate interestRate, Term term);
        Dictionary<string, RepositoryProduct> LoadProducts(string productFile);
        Products BuildProducts(Dictionary<string, RepositoryProduct> products);
    }
}