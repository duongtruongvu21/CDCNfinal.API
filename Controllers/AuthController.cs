using CDCNfinal.API.Data;
using CDCNfinal.API.Data.DTOs;
using CDCNfinal.API.Services._AuthServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserDTO userDTO)
        {
            bool isSuccess = _authService.Register(userDTO);
            ResponseData response = new ResponseData();

            if (isSuccess)
            {
                response.IsSuccess = true;
                response.Data = new List<object>() {
                    "Đăng ký thành công!"
                };
            }
            else
            {
                response.IsSuccess = false;
                response.Data = new List<object>() {
                    "Đã tồn tại tài khoản này!"
                };
            }

            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserDTO userDTO)
        {
            byte loginStatus = _authService.Login(userDTO);
            ResponseData response = new ResponseData();
            switch (loginStatus)
            {
                case 1:
                    {
                        response.IsSuccess = false;
                        response.Data = new List<object>() {
                            "Không tồn tại tài khoản này!!"
                        };
                        break;
                    }
                case 2:
                    {
                        response.IsSuccess = false;
                        response.Data = new List<object>() {
                            "Sai mật khẩu!"
                        };
                        break;
                    }
                case 3:
                    {
                        response.IsSuccess = true;
                        response.Data = new List<object>() {
                            "Thành công!"
                        };
                        break;
                    }
            }

            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            ResponseData response = new ResponseData()
            {
                IsSuccess = true,
                Data = new List<object>(_authService.GetUserDTOs())
            };

            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}