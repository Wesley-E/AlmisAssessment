using System.Collections.Generic;
using System.Linq;
using AlmisAssessment.Configuration;
using AlmisAssessment.Models;
using AlmisAssessment.Models.Product;
using AlmisAssessment.Models.Repository;
using AlmisAssessment.Repository;

namespace AlmisAssessment.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;
        
        public ProductService(IRepository repository)
        {
            _repository = repository;
        }
        
        public Product CreateProduct(string productName, InterestRate interestRate, Term term)
        {
            return new Product(productName, interestRate, term);
        }

        public Dictionary<string, RepositoryProduct> LoadProducts(string productFile)
        {
            return _repository.LoadProducts(productFile);
        }

        public Products BuildProducts(Dictionary<string, RepositoryProduct> products)
        {
            return new Products(products.Select(product => 
                new Product(
                    product.Key,
                    new InterestRate(product.Value.InterestRate.Amount), 
                    new Term(new Period(
                        (int) product.Value.Period.Days,
                        (int) product.Value.Period.Weeks, 
                        product.Value.Period.Months, 
                        product.Value.Period.Years)))).ToList());
        }
    }
}