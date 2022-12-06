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
        private readonly IUploadImgService _uploadImage;

        public ProductService(DataContext context, IMapper mapper,IUploadImgService uploadImage)
        {
            _context = context;
            _mapper = mapper;
            _uploadImage = uploadImage;
        }

        public async Task<bool> CreateProduct(ProductAddDTO productAddDTO)
        {
            var linkImage = await _uploadImage.UploadImage("imageProduct",productAddDTO.Image);
            var product = _mapper.Map<ProductAddDTO, Product>(productAddDTO);
            product.ImageUrl = linkImage;
            _context.Add(product);
            return SaveChanges();
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

        public async Task<bool> UpdateProduct(int id,ProductAddDTO product)
        {
            var Product = _context.Products.FirstOrDefault(p => p.Id == id);
            if(product == null) return false;
            Product.ProductName = product.ProductName;
            Product.BrandName = product.BrandName;
            Product.Decription = product.Decription;
            Product.Price  = product.Price;
            if(product.Image !=null){
                string linkImage = await _uploadImage.UploadImage("imageProduct",product.Image);    
                Product.ImageUrl = linkImage;

            }
            SaveChanges();
            // if(product.Image != null){
            //     var linkImage = await _uploadImage.UploadImage("imageProduct",product.Image);    
            //     Product.ImageUrl = linkImage;
            // }
            return true;
        }
    }
}