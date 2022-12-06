using Microsoft.AspNetCore.Http;

namespace CDCNfinal.API.Services.ProductServices.cs
{
    public interface IUploadImgService
    {
        Task<string> UploadImage(string folder,IFormFile model);
    }
}