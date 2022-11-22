using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CDCNfinal.API.Data;
using CDCNfinal.API.Data.DTOs;
using CDCNfinal.API.Data.Entities;

namespace CDCNfinal.API.Services.ProductServices.cs
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateProduct(ProductAddDTO productAddDTO)
        {
            var product = _mapper.Map<ProductAddDTO, Product>(productAddDTO);
            _context.Add(product);
        }

        public void DeleteProduct(int Id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == Id);
            _context.Products.Remove(product);
        }

        public ProductDetailDTO GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if(product == null) return null;
            return _mapper.Map<Product, ProductDetailDTO>(product);
        }

        public List<ProductDTO> GetProducts()
        {
            var products = _context.Products.ToList();
            return _mapper.Map<List<Product>, List<ProductDTO>>(products);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public ProductDetailDTO UpdateProduct(ProductDetailDTO product)
        {
            var Product = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if(product == null) return null;
            Product.ProductName = product.ProductName;
            Product.BrandName = product.BrandName;
            Product.Decription = product.Decription;
            Product.Price  = product.Price;
            return _mapper.Map<Product, ProductDetailDTO>(Product);
        }
    }
}