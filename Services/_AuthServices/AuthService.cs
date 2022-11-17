using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CDCNfinal.API.Data;
using CDCNfinal.API.Data.DTOs;
using CDCNfinal.API.Data.Entities;

namespace CDCNfinal.API.Services._AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public bool Register(UserDTO userDTO)
        {
            userDTO.Username = userDTO.Username.ToLower();
            if (_context.Users.Any(u => u.Username == userDTO.Username))
            {
                return false;
            }

            using var hmac = new HMACSHA512();
            var passwordByte = Encoding.UTF8.GetBytes(userDTO.Password);
            User user = new User()
            {
                Username = userDTO.Username,
                PasswordSalt = hmac.Key,
                PasswordHashed = hmac.ComputeHash(passwordByte)
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }


        ///
        // Không tồn tại tài khoản trả về 1
        // Sai mật khẩu trả về 2
        // Thành công trả về 3
        ///
        public byte Login(UserDTO userDTO)
        {
            userDTO.Username = userDTO.Username.ToLower();
            var currentUser = _context.Users.FirstOrDefault(u => u.Username == userDTO.Username);

            if (currentUser == null)
            {
                return 1;
            }

            using (var hmac = new HMACSHA512(currentUser.PasswordSalt))
            {
                var passwordBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));

                for (int i = 0; i < currentUser.PasswordHashed.Length; i++)
                {
                    if (currentUser.PasswordHashed[i] != passwordBytes[i])
                    {
                        return 2;
                    }
                }

                return 3;
            }
        }

        public List<UserDTO> GetUserDTOs()
        {
            List<User> users = _context.Users.ToList();
            List<UserDTO> userDTOs = new List<UserDTO>();

            foreach (User i in users)
            {
                userDTOs.Add(new UserDTO() { Username = i.Username, Password = "private" });
            }

            return userDTOs;
        }
    }
}