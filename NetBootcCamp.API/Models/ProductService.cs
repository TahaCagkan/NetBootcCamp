using NetBootcCamp.API.DTOs;
using System.Collections.Immutable;

namespace NetBootcCamp.API.Models
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository = new();

        public ImmutableList<ProductDto> GetAllWithCalculatedTax()
        {

            return _productRepository.GetAll().Select(product =>
                new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = CalculateKdv(product.Price,1.20m),
                    Created = product.Created.ToShortDateString()
                }).ToImmutableList();
            
        }
        private decimal CalculateKdv(decimal price,decimal tax) => price* tax;
  
    }
}
