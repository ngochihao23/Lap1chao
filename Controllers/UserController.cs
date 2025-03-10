using Lab1_TH_NGOCHIHAO.DTOS.User;
using Lab1_TH_NGOCHIHAO.Enities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_TH_NGOCHIHAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
    {
    new User { Id = 1, UserName = "admin", Password = "admin", FullName = "Administrator", Birthday = new DateTime(2000, 1, 1), Role = "Admin" },
    new User { Id = 2, UserName = "user", Password = "user", FullName = "Người dùng 1", Birthday = new DateTime(2002, 2, 2), Role = "User" }
    };
     


        [HttpPost]
        public IActionResult Create([FromBody] UserRequest request)
        {
            var userExist = users.FirstOrDefault(x => x.UserName == request.UserName);
            if (userExist == null) //null
            {
                return NotFound(" Không tìm thấy User  ");
            }
            return Ok(" Đăng nhập thành công");

        }



        //2.	Lấy danh sách tất cả người dùng (ẩn password) 
        [HttpGet("ẩnpass")]
        public IActionResult Get()
        {
            var result = users.Select(x => new {
            x.Id,
            x.UserName,
            x.Birthday,
            x.Role,
            }).ToList();
            return Ok(result);
        }


        //3.	Lấy thông tin chi tiết của một user theo Id (ẩn password

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            var product = users.Select(x => new {
                x.Id,
                x.UserName,
                x.Birthday,
                x.Role,
            }).
            FirstOrDefault(p => p.Id == id);


            if (product == null) //null
            {
                return NotFound(" Không tìm thấy User  ");
            }
            return Ok(product);
        }

        //4.	Thêm người dùng mới(Id tự động lấy Max +1 )
        [HttpPost("create")]
        public IActionResult Create(User request)
        {
            var productExist = users.FirstOrDefault(p => p.UserName == request.UserName);
            if (productExist != null)
            {
                return BadRequest(" Không thể thêm");
            };
            request.Id = users.Max(p => p.Id) + 1;
            users.Add(request);
            return Ok(" Thêm thành công");

        }


        //5.	Cập nhật thông tin người dùng theo Id

        [HttpPut("update")]
        public IActionResult Update(User request)
        {
            var productExist = users.FirstOrDefault(p => p.Id == request.Id);
            if (productExist == null)
            {
                return NotFound("Không tìm thấy tài khoản mong muốn");
            }
            // SẢN PHẨM TÌM THẤY 
            productExist.Id = request.Id;
            productExist.UserName = request.UserName;
            productExist.Password = request.Password;
            productExist.FullName = request.FullName;
            productExist.Birthday = request.Birthday;
            productExist.Role = request.Role;
            return Ok("Đã cập nhật tài khoản thành công");

        }

        //6.	Xóa người dùng theo Id
        [HttpDelete("delete")]
        //Route("Delete")
        public IActionResult Delete(int id)
        {
            var productExist = users.FirstOrDefault(p => p.Id == id);
            if (productExist == null) // <=> tìm không thấy sản phẩm
            {
                return NotFound("Không tìm thấy tài khoản ");
            }
            //tim thấy ==> tiến hành xóa sản phẩm 
            users.Remove(productExist);
            return Ok($" Đã xóa tài khoản có id= {id}, Username: {productExist.UserName}, Role: {productExist.Role} thành công");

        }
    }
}
