using CDCNfinal.API.Data.DTOs;

namespace CDCNfinal.API.Services._AuthServices
{
    public interface IAuthService
    {
        public bool Register(UserDTO userDTO);
        public byte Login(UserDTO userDTO);
        public List<UserDTO> GetUserDTOs();
    }
}