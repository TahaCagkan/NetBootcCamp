using NetBootcCamp.API.DTOs;
using System.Collections.Immutable;

namespace NetBootcCamp.API.Models
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository = new();

        public ResponseDto<ImmutableList<ProductDto>> GetAllWithCalculatedTax()
        {

            var productList = _productRepository.GetAll().Select(product => new ProductDto(
                product.Id, 
                product.Name, 
                CalculateKdv(product.Price, 1.20m), 
                product.Created.ToShortDateString()
                )).ToImmutableList();

            return ResponseDto<ImmutableList<ProductDto>>.Success(productList);
        }

        private decimal CalculateKdv(decimal price,decimal tax) => price* tax;
        
        public ProductDto? GetById(int id)
        {
            var hasProduct =_productRepository.GetById(id);

            if(hasProduct is null)
            {
                return null!;
            }

            return new ProductDto(
                hasProduct.Id,
                hasProduct.Name,
                CalculateKdv(hasProduct.Price, 1.20m),
                hasProduct.Created.ToShortTimeString()
                );
        }

        public ResponseDto<NoContent>  Delete(int id)
        {
            var hasProduct = _productRepository.GetById(id);
            if(hasProduct is null)
            {
                return ResponseDto<NoContent>.Fail("Silinmeye çalışılan ürün bulunamadı.");
                
            }
            _productRepository.Delete(id);
            return ResponseDto<NoContent>.Success();
        }
    }
}
