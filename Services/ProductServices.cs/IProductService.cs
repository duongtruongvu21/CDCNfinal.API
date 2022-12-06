using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDCNfinal.API.Data.DTOs;

namespace CDCNfinal.API.Services.ProductServices.cs
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();

        ProductDetailDTO GetProductById(int id);

        bool SaveChanges();

        Task<bool> CreateProduct(ProductAddDTO productAddDTO);

        Task<bool> UpdateProduct(int id,ProductAddDTO product);

        void DeleteProduct(int Id);
    }
}